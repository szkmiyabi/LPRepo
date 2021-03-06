﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPRepo
{
    partial class Form1
    {
        //カテゴリ別検査項目一覧表出力
        private async Task do_create_category_by_details()
        {

            await Task.Run(() =>
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

                string site_name = ldr.get_site_name();

                this.Invoke(__write_log, "検査カテゴリの取得を開始します。（" + DateUtil.get_logtime() + "）");
                List<string> categories = ldr.get_category_list_data_from_svpage();

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

                this.Invoke(__write_log, "Excel書き出しを開始します。（" + DateUtil.get_logtime() + "）");

                string save_dir = (string)this.Invoke(__get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " 検査項目一覧.xlsx";

                ExcelUtil eu = new ExcelUtil();
                eu.save_category_by_details_xlsx(rep_data, save_filename);


                ldr.logout();
                this.Invoke(__write_log, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }
    }
}
