using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPRepo
{
    partial class Form1
    {
        //プロジェクトIDコンボをセット
        private void set_projectID_combo()
        {

            Task.Run(() =>
            {
                //デリゲートインスタンス
                _write_log __write_log = write_log;
                _ldr_activate __ldr_activate = ldr_activate;
                _task_cancel __task_cancel = task_cancel;
                _is_basic_auth_condition __is_basic_auth_condition = is_basic_auth_condition;
                _set_projectID_combo __set_projectID_combo = set_projectID_combo;

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


                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                List<List<string>> data = new List<List<string>>();

                this.Invoke(__write_log, "検査中サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                ldr.working_site_page();
                DateUtil.app_sleep(shortWait);
                data.AddRange(ldr.get_site_list());

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                this.Invoke(__write_log, "検査終了サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                ldr.completed_site_page();
                DateUtil.app_sleep(shortWait);
                data.AddRange(ldr.get_site_list());

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                this.Invoke(__set_projectID_combo, data);
                this.Invoke(__write_log, "サイト名コンボが設定完了しました。（" + DateUtil.get_logtime() + "）");
                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");



            });

        }

        //サイト一覧テーブルをExcelファイルで出力
        private void create_site_info_book()
        {
            Task.Run(() =>
            {
                //デリゲートインスタンス
                _write_log __write_log = write_log;
                _ldr_activate __ldr_activate = ldr_activate;
                _task_cancel __task_cancel = task_cancel;
                _get_workDir __get_workDir = get_workDir;
                _is_basic_auth_condition __is_basic_auth_condition = is_basic_auth_condition;

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

                List<List<string>> data = new List<List<string>>();

                //検査終了サイト一覧を取得
                this.Invoke(__write_log, "検査中サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                ldr.working_site_page();
                DateUtil.app_sleep(shortWait);
                data.AddRange(ldr.get_site_info_data());

                this.Invoke(__write_log, "検査終了サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                ldr.completed_site_page();
                DateUtil.app_sleep(shortWait);
                data.AddRange(ldr.get_site_info_data());


                List<string> head_row = new List<string>() {
                    "ID",
                    "サイト名/備考",
                    "検査機関",
                    "グループ",
                    "検査開始日",
                    "検査終了日",
                    "URL数",
                    "進捗"
                };
                data.Insert(0, head_row);

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                string save_dir = (string)this.Invoke(__get_workDir);
                string save_filename = save_dir + "LibraPlus検査サイト一覧_" + DateUtil.fetch_filename_logtime() + ".xlsx";
                ExcelUtil eu = new ExcelUtil();
                eu.save_xlsx_as(data, save_filename);

                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //ページIDコンボをセット
        private void set_pageID_combo()
        {

            Task.Run(() =>
            {
                //デリゲートインスタンス
                _write_log __write_log = write_log;
                _ldr_activate __ldr_activate = ldr_activate;
                _task_cancel __task_cancel = task_cancel;
                _get_workDir __get_workDir = get_workDir;
                _is_basic_auth_condition __is_basic_auth_condition = is_basic_auth_condition;
                _get_projectID __get_projectID = get_projectID;
                _set_pageID_combo __set_pageID_combo = set_pageID_combo;

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

                string cr = (string)this.Invoke(__get_projectID);
                ldr.projectID = cr;

                this.Invoke(__write_log, "進捗管理画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.init_status_page();
                List<List<string>> data = ldr.get_page_list_data_from_status_page();

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                this.Invoke(__set_pageID_combo, data);

                this.Invoke(__write_log, "ページIDコンボが設定完了しました。（" + DateUtil.get_logtime() + "）");

                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //ページIDコンボをTSVからセット
        private void set_pageID_combo_from_tsv()
        {
            //デリゲートインスタンス
            _write_log __write_log = write_log;
            _set_projectID_combo __set_projectID_combo = set_projectID_combo;
            _set_pageID_combo __set_pageID_combo = set_pageID_combo;

            string filepath = getFileNameFromDialog();
            if (filepath == "") return;

            string filename_str = Path.GetFileNameWithoutExtension(filepath);
            List<List<string>> projectData = new List<List<string>>
            {
                new List<string> { "T0", filename_str }
            };

            List<List<string>> pageIDData = new List<List<string>>();
            pageIDData = getTextLineList(filepath);
            this.Invoke(__set_projectID_combo, projectData);
            this.Invoke(__set_pageID_combo, pageIDData);
            this.Invoke(__write_log, "ページIDコンボが設定完了しました。（" + DateUtil.get_logtime() + "）");
            this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");
        }

    }
}
