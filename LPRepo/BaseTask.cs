using System;
using System.Collections.Generic;
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
                //共通デリゲートインスタンス
                d_status_messenger message = w_status_messenger;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;
                /*
                d_ctrl_activate w_ctrl_activate = ctrl_activate;
                d_ctrl_deactivate w_ctrl_deactivate = ctrl_deactivate;
                */

                //専用デリゲートインスタンス
                d_set_projectID_combo _set_projectID_combo = w_set_projectID_combo;

                //2重実行防止
                /*
                this.Invoke(w_ctrl_deactivate, "projectIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "pageIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "doUrlTaskButton");
                this.Invoke(w_ctrl_deactivate, "cancelUrlTaskButton");
                */

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }
                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);


                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                ldr.working_site_page();
                DateUtil.app_sleep(shortWait);

                this.Invoke(message, "サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                List<List<string>> data = new List<List<string>>();
                data.AddRange(ldr.get_site_list());

                /*
                this.Invoke(message, "検査終了サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                ldr.completed_site();
                DateUtil.app_sleep(shortWait);
                data.AddRange(ldr.get_site_list());

                this.Invoke(message, "証明書発行サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                ldr.certificated_site();
                DateUtil.app_sleep(shortWait);
                data.AddRange(ldr.get_site_list());
                */

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;


                this.Invoke(_set_projectID_combo, data);
                this.Invoke(message, "サイト名コンボが設定完了しました。（" + DateUtil.get_logtime() + "）");
                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

                /*
                this.Invoke(w_ctrl_activate, "projectIDLoadButton");
                this.Invoke(w_ctrl_activate, "pageIDLoadButton");

                this.Invoke(w_ctrl_activate, "doUrlTaskButton");
                this.Invoke(w_ctrl_activate, "cancelUrlTaskButton");
                this.Invoke(w_ctrl_activate, "createSiteInfoBookButton");
                */

            });

        }

        //サイト一覧テーブルをExcelファイルで出力
        private void create_site_info_book()
        {
            Task.Run(() =>
            {
                //共通デリゲートインスタンス
                d_status_messenger message = w_status_messenger;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;
                d_get_workDir _d_get_workDir = w_get_workDir;

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);


                ldr.working_site_page();
                DateUtil.app_sleep(shortWait);

                List<List<string>> data = ldr.get_site_info_data();
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
                if ((Boolean)this.Invoke(canceler)) return;

                string save_dir = (string)this.Invoke(_d_get_workDir);
                string save_filename = save_dir + "Libra検査サイト一覧_" + DateUtil.fetch_filename_logtime() + ".xlsx";
                ExcelUtil eu = new ExcelUtil();
                eu.save_xlsx_as(data, save_filename);

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //ページIDコンボをセット
        private void set_pageID_combo()
        {

            Task.Run(() =>
            {
                //共通デリゲートインスタンス
                d_status_messenger message = w_status_messenger;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;
                d_ctrl_activate w_ctrl_activate = ctrl_activate;
                d_ctrl_deactivate w_ctrl_deactivate = ctrl_deactivate;

                //専用デリゲートインスタンス
                d_get_projectID _d_get_projectID = w_get_projectID;
                //d_get_source_flag _d_get_source_flag = w_get_source_flag;
                d_get_basic_auth_cond _d_get_basic_auth_cond = w_get_basic_auth_cond;
                d_set_pageID_combo _set_pageID_combo = w_set_pageID_combo;

                //2重実行防止
                this.Invoke(w_ctrl_deactivate, "pageIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "projectIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "doRepoTaskButton");
                this.Invoke(w_ctrl_deactivate, "cancelRepoTaskButton");

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string cr = (string)this.Invoke(_d_get_projectID);
                ldr.projectID = cr;

                Boolean auth_param_check = (Boolean)this.Invoke(_d_get_basic_auth_cond);
                if (auth_param_check == false) return;

                this.Invoke(message, "検査メイン画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.browse_sv_mainpage();
                DateUtil.app_sleep(longWait);
                List<List<string>> data = ldr.get_page_list_data_from_svpage();

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                this.Invoke(_set_pageID_combo, data);

                this.Invoke(message, "ページIDコンボが設定完了しました。（" + DateUtil.get_logtime() + "）");

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

                this.Invoke(w_ctrl_activate, "pageIDLoadButton");
                this.Invoke(w_ctrl_activate, "projectIDLoadButton");
                this.Invoke(w_ctrl_activate, "doRepoTaskButton");
                this.Invoke(w_ctrl_activate, "cancelRepoTaskButton");

                this.Invoke(w_ctrl_activate, "pageIDListBoxSelectAllButton");
                this.Invoke(w_ctrl_activate, "pageIDListBoxSelectClearButton");

                this.Invoke(w_ctrl_activate, "openAsFirefoxButton");
                this.Invoke(w_ctrl_activate, "openAsIEButton");
                this.Invoke(w_ctrl_activate, "openAsChromeButton");
                this.Invoke(w_ctrl_activate, "openAsAnotherBrowserButton");

                this.Invoke(w_ctrl_activate, "techIDLoadButton");

            });
        }
    }
}
