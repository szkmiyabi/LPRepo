﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPRepo
{
    partial class Form1
    {
        //PID+URLのTSVファイル出力
        private void do_create_pid_url_list()
        {
            Task.Run(() =>
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
                _get_site_name_by_projectIDCombo __get_site_name_by_projectIDCombo = get_site_name_by_projectIDCombo;

                //Basic認証のON時の条件判定
                if (!(Boolean)this.Invoke(__is_basic_auth_condition)) return;

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(__ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(__write_log, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(__get_projectID);
                ldr.projectID = projectID;

                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                this.Invoke(__write_log, "進捗管理画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.init_status_page();
                data = ldr.get_page_list_data_from_status_page();
                site_name = (string)this.Invoke(__get_site_name_by_projectIDCombo);

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                string save_dir = (string)this.Invoke(__get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " URL.txt";

                FileUtil fu = new FileUtil();
                fu.write_tsv_data(data, save_filename);

                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //PID+URLのExcelファイル出力
        private void do_create_pid_url_list_xlsx()
        {
            Task.Run(() =>
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
                _get_site_name_by_projectIDCombo __get_site_name_by_projectIDCombo = get_site_name_by_projectIDCombo;

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

                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                this.Invoke(__write_log, "進捗管理画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.init_status_page();
                data = ldr.get_page_list_data_from_status_page();
                site_name = (string)this.Invoke(__get_site_name_by_projectIDCombo);

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                //ヘッダー行の処理
                List<string> head_row = new List<string>() { "PID", "URL" };
                data.Insert(0, head_row);

                string save_dir = (string)this.Invoke(__get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " URL.xlsx";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                ExcelUtil eu = new ExcelUtil();
                eu.save_xlsx_as(data, save_filename);

                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //プロジェクト管理表のExcelファイル出力
        private void do_create_asignlist_xlsx()
        {
            Task.Run(() =>
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
                _get_site_name_by_projectIDCombo __get_site_name_by_projectIDCombo = get_site_name_by_projectIDCombo;


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

                List<List<string>> data = new List<List<string>>();
                List<string> categories = new List<string>();
                string site_name = "";
                this.Invoke(__write_log, "進捗管理画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.init_status_page();
                data = ldr.get_page_list_data_from_status_page();
                site_name = (string)this.Invoke(__get_site_name_by_projectIDCombo);
                categories = ldr.get_category_list_data_from_status_page();

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                //ヘッダー行の処理
                List<string> head_row = new List<string>() { "PID", "URL" };
                data.Insert(0, head_row);

                string save_dir = (string)this.Invoke(__get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " プロジェクト管理表.xlsx";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                ExcelUtil eu = new ExcelUtil();
                eu.save_asignlist_xlsx_as(data, categories, save_filename);

                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //プロジェクト管理表のExcelファイル出力（検査項目数付）
        private void do_create_asignlist_with_count_xlsx()
        {
            Task.Run(() =>
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
                _get_site_name_by_projectIDCombo __get_site_name_by_projectIDCombo = get_site_name_by_projectIDCombo;


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

                List<List<string>> data = new List<List<string>>();
                string site_name = "";
                this.Invoke(__write_log, "進捗管理画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.init_status_page();
                data = ldr.get_status_all_table_data();
                site_name = (string)this.Invoke(__get_site_name_by_projectIDCombo);

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                string save_dir = (string)this.Invoke(__get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " プロジェクト管理表.xlsx";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(__task_cancel)) return;

                ExcelUtil eu = new ExcelUtil();
                eu.save_asignlist_with_count_xlsx_as(data, save_filename);

                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //プロジェクト管理表（検査項目詳細版）Excel出力
        private void do_create_asignlist_details_xlsx()
        {
            Task.Run(() =>
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

                List<List<string>> pages = new List<List<string>>();
                List<string> categories = new List<string>();
                string site_name = "";

                this.Invoke(__write_log, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
                ldr.browse_sv_mainpage();
                DateUtil.app_sleep(longWait);

                site_name = ldr.get_site_name();
                pages = ldr.get_page_list_data_from_svpage();
                categories = ldr.get_category_list_data_from_svpage();
                List<List<object>> rep_data = new List<List<object>>();

                foreach (string category in categories)
                {
                    this.Invoke(__write_log, "検査カテゴリ：" + category + "の処理をしています...（" + DateUtil.get_logtime() + "）");
                    ldr.select_category(category);
                    DateUtil.app_sleep(midWait);
                    ldr.select_view("検査項目一覧");
                    DateUtil.app_sleep(midWait);
                    List<List<object>> data = ldr.get_survey_details();
                    rep_data.AddRange(data);
                }

                string save_dir = (string)this.Invoke(__get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " プロジェクト管理表【検査項目詳細版】.xlsx";

                ExcelUtil eu = new ExcelUtil();
                eu.save_asignlist_by_details_xlsx(pages, categories, rep_data, save_filename);


                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //ページのスクリーンショットの一覧取得
        private void do_pageIDs_screenshot()
        {
            Task.Run(() =>
            {

                //デリゲートインスタンス
                _get_workDir __get_workDir = get_workDir;
                _get_projectID_row __get_projectID_row = get_projectID_row;
                _get_pageID_rows __get_page_rows = get_pageID_rows;
                _ldr_activate __ldr_activate = ldr_activate;
                _write_log __write_log = write_log;
                _task_cancel_tsv __task_cancel_tsv = task_cancel_tsv;


                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(__ldr_activate)) return;
                }

                this.Invoke(__write_log, "処理を開始します。（" + DateUtil.get_logtime() + "）");

                //保存先ディレクトリ生成
                string project_dir = (string)this.Invoke(__get_projectID_row);
                project_dir = project_dir.Replace("/", "");
                string save_path = (string)this.Invoke(__get_workDir) + project_dir + @"\";
                if (!Directory.Exists(save_path)) Directory.CreateDirectory(save_path);

                List<List<string>> page_rows = (List<List<string>>)this.Invoke(__get_page_rows);

                foreach (var page_row in page_rows)
                {
                    string pageID = page_row[0];
                    string pageURL = page_row[1];
                    this.Invoke(__write_log, pageID + " を処理しています。（" + DateUtil.get_logtime() + "）");
                    ldr.wd.Navigate().GoToUrl(pageURL);
                    DateUtil.app_sleep(shortWait);
                    ldr.fullpage_screenshot_as(save_path + pageID + "." + "png");

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(__task_cancel_tsv)) return;

                }

                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");
            });

        }

    }
}
