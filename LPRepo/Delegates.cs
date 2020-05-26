﻿using System;
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
        public delegate Boolean d_get_basic_auth_cond();
        public Boolean w_get_basic_auth_cond()
        {
            Boolean flg = true;
            if (basic_auth == "yes" && headless == "yes")
            {
                flg = false;
                operationStatusReport.AppendText("【エラー】基本認証⇒「はい」を選択した場合、ヘッドレス起動⇒「いいえ」に設定しないと動作しません。基本設定を確認してください。\r\n");
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

    }
}