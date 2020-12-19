﻿using System;
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

                ldr.working_site_page();
                DateUtil.app_sleep(shortWait);

                this.Invoke(__write_log, "サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                List<List<string>> data = new List<List<string>>();
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

                this.Invoke(__write_log, "検査メイン画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.browse_sv_mainpage();
                DateUtil.app_sleep(longWait);
                List<List<string>> data = ldr.get_page_list_data_from_svpage();

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                this.Invoke(__set_pageID_combo, data);

                this.Invoke(__write_log, "ページIDコンボが設定完了しました。（" + DateUtil.get_logtime() + "）");

                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }
    }
}
