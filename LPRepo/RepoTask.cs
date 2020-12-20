using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPRepo
{
    partial class Form1
    {
        //category test
        private void do_categories_show()
        {
            //デリゲートインスタンス
            _write_log __write_log = write_log;
            _ldr_activate __ldr_activate = ldr_activate;
            _task_cancel __task_cancel = task_cancel;
            _is_basic_auth_condition __is_basic_auth_condition = is_basic_auth_condition;
            _is_pageID_selected __is_pageID_selected = is_pageID_selected;
            _get_workDir __get_workDir = get_workDir;
            _get_projectID __get_projectID = get_projectID;
            _get_pageID_rows __get_page_rows = get_pageID_rows;

            //Basic認証のON時の条件判定
            if (!(Boolean)this.Invoke(__is_basic_auth_condition)) return;

            if (ldr_activated == false)
            {
                //Libraドライバ起動しエラーの場合早期退出
                if (!(Boolean)this.Invoke(__ldr_activate)) return;
            }

            ldr.home();
            this.Invoke(__write_log, "LibraPlusにログインします。（" + DateUtil.get_logtime() + "）");
            ldr.login();
            DateUtil.app_sleep(shortWait);

            string projectID = (string)this.Invoke(__get_projectID);
            ldr.projectID = projectID;


            //タスクのキャンセル判定
            if ((Boolean)this.Invoke(__task_cancel)) return;

            this.Invoke(__write_log, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
            ldr.browse_sv_mainpage();
            DateUtil.app_sleep(longWait);
            ldr.select_category("リスト");
            DateUtil.app_sleep(shortWait);
            ldr.select_view("検査項目一覧");
            DateUtil.app_sleep(shortWait);
            List<List<object>> data = ldr.get_survey_details();
            for(int i=0; i<data.Count; i++)
            {
                var row = data[i];
                string v1 = (string)row[0];
                string v2 = (string)row[1];
                this.Invoke(__write_log, v1 + "  " + v2);
                List<string> gs = (List<string>)row[2];
                foreach(string tx in gs)
                {
                    this.Invoke(__write_log, tx);
                }

            }
            ldr.logout();
            this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");
        }
    }
}
