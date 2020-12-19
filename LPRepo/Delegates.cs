using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPRepo
{
    partial class Form1
    {
        //デリゲート（Libraドライバの起動とエラー処理）
        private delegate Boolean d_ldr_activate();
        private Boolean w_ldr_activate()
        {
            if (load_wd())
            {
                operationStatusReport.AppendText("ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）" + "\r\n");
                return true;
            }
            else
            {
                operationStatusReport.AppendText("【エラー】ブラウザドライバの起動に失敗しました。考えられる理由は、ブラウザのドライバが作業フォルダ内に未設置、あるいは、ブラウザのドライバのバージョンが現行のブラウザ用より古いか、新しすぎるかのどちらかです。サポートされているバージョンのブラウザのドライバに差し換えてください。\r\n");
                operationStatusReport.AppendText(error_buff + "\r\n");
                return false;
            }
        }

        //デリゲート（基本認証ON/OFFチェック）
        public delegate Boolean _is_basic_auth_condition();
        public Boolean is_basic_auth_condition()
        {
            Boolean flg = true;
            if (basicAuthFlagCheck.Checked == true && headless == "yes")
            {
                flg = false;
                operationStatusReport.AppendText("【エラー】Basic認証有のチェックON時は、ヘッドレス起動⇒「いいえ」に設定しないと動作しません。基本設定を確認してください。\r\n");
            }
            return flg;
        }

        //デリゲート（処理状況テキストの更新）
        public delegate void d_status_messenger(string msg);
        public void w_status_messenger(string msg)
        {
            operationStatusReport.AppendText(msg + "\r\n");
        }

        //デリゲート（保存先フォルダ参照）
        public delegate string d_get_workDir();
        public string w_get_workDir()
        {
            return workDir;
        }


        //デリゲート（プロジェクトID参照）
        public delegate string d_get_projectID();
        public string w_get_projectID()
        {
            return projectIDListBox.SelectedValue.ToString();
        }



        //デリゲート（タスクのキャンセル判定とキャンセル実行処理）
        private delegate Boolean d_task_cancel();
        private Boolean w_task_cancel()
        {
            Boolean flag = false;
            if (token.IsCancellationRequested)
            {
                operationStatusReport.AppendText("処理をキャンセルします。（" + DateUtil.get_logtime() + "）" + "\r\n");
                token_src.Dispose();
                token_src = null;
                if (ldr != null) ldr.logout();
                operationStatusReport.AppendText("処理をキャンセルしLibraからログアウトしました。（" + DateUtil.get_logtime() + "）" + "\r\n");
                flag = true;
            }
            return flag;
        }

        //デリゲート（コントロールの有効無効制御）
        private delegate void d_ctrl_toggle(string ctrl_name);
        private void ctrl_toggle(string ctrl_name)
        {
            List<Control> controls = GetAllControls<Control>(this);
            foreach (var ctrl in controls)
            {
                if (ctrl.Name == ctrl_name)
                {
                    ctrl.Enabled = !ctrl.Enabled;
                    break;
                }
            }
        }

        //デリゲート（コントロールの有効制御）
        private delegate void d_ctrl_activate(string ctrl_name);
        private void ctrl_activate(string ctrl_name)
        {
            List<Control> controls = GetAllControls<Control>(this);
            foreach (var ctrl in controls)
            {
                if (ctrl.Name == ctrl_name)
                {
                    ctrl.Enabled = true;
                    break;
                }
            }
        }

        //デリゲート（コントロールの無効制御）
        private delegate void d_ctrl_deactivate(string ctrl_name);
        private void ctrl_deactivate(string ctrl_name)
        {
            List<Control> controls = GetAllControls<Control>(this);
            foreach (var ctrl in controls)
            {
                if (ctrl.Name == ctrl_name)
                {
                    ctrl.Enabled = false;
                    break;
                }
            }
        }

        //デリゲート（メイン画面のサイトIDコンボセットアップ）
        private delegate void d_set_projectID_combo(List<List<string>> data);
        private void w_set_projectID_combo(List<List<string>> data)
        {
            List<projectIDComboItem> ListBoxItem = new List<projectIDComboItem>();
            projectIDComboItem itm;
            for (int i = 0; i < data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string text = col[0] + "  " + col[1];
                itm = new projectIDComboItem(col[0], text);
                ListBoxItem.Add(itm);
            }
            projectIDListBox.DisplayMember = "display_str";
            projectIDListBox.ValueMember = "id_str";
            projectIDListBox.DataSource = ListBoxItem;
        }

        //デリゲート（メイン画面のページIDコンボセットアップ）
        private delegate void d_set_pageID_combo(List<List<string>> data);
        private void w_set_pageID_combo(List<List<string>> data)
        {
            List<pageIDComboItem> ListBoxItem = new List<pageIDComboItem>();
            pageIDComboItem itm;
            for (int i = 0; i < data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string text = "[" + col[0] + "]  " + col[1];
                itm = new pageIDComboItem(col[0], text);
                ListBoxItem.Add(itm);
            }
            pageIDListBox.DisplayMember = "display_str";
            pageIDListBox.ValueMember = "id_str";
            pageIDListBox.DataSource = ListBoxItem;

            SendMessage(pageIDListBox.Handle, LB_SETSEL, 0, -1);
            pageIDListBox.SetSelected(0, false);
        }


        //デリゲート（ページIDコンボが選択されているか）
        private delegate Boolean d_is_pageID_selected();
        private Boolean w_is_pageID_selected()
        {
            if (pageIDListBox.SelectedItems.Count == 0) return false;
            else return true;
        }


        //デリゲート（ページIDコンボ選択値を取得）
        private delegate List<List<string>> d_pageID_data();
        private List<List<string>> w_pageID_data()
        {
            List<List<string>> data = new List<List<string>>();

            //データバインドしたListBoxの項目はそのデータ型でしか取り出せない
            foreach (pageIDComboItem cmb in pageIDListBox.SelectedItems)
            {
                List<string> row = new List<string>();
                string pid = cmb.id_str;
                string url = TextUtil.fetch_url(cmb.display_str);
                row.Add(pid);
                row.Add(url);
                data.Add(row);
            }
            return data;
        }

    }
}
