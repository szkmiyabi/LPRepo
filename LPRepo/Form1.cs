﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPRepo
{
    public partial class Form1 : Form
    {
        //ListBoxの全選択/選択解除のWindowsAPI宣言
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int LB_SETSEL = 0x185;

        //LibraDriverインスタンス監視
        private LPDriver ldr;
        private Boolean ldr_activated = false;

        //Form1インスタンス
        private static Form1 _main_form;

        //private static DataGridForm _data_grid_form;

        //Taskのキャンセル
        private CancellationTokenSource token_src;
        private CancellationToken token;

        //Errorバッファ
        private string error_buff;

        //Basic認証フラグ
        private string basic_auth;

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

            //環境設定のロード
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

            //静的プロパティに自身を代入
            _main_form = this;

            //Errorバッファ初期化
            error_buff = "";

            //Basic認証フラグ初期化
            basic_auth = "no";

            //Imageボタンの初期化
            imgButtonInit();
        }

        //Formのゲッターとセッター
        public static Form1 main_form
        {
            get { return _main_form; }
            set { _main_form = value; }
        }

        //wdインスタンス生成
        private Boolean load_wd()
        {
            Boolean flag = false;

            if (checkSettings() == false) return flag;

            try
            {
                int[] appWait = { systemWait, longWait, midWait, shortWait };
                ldr = new LPDriver(uid, pswd, appWait, driver, headless, basic_auth, workDir, debugMode);
                ldr_activated = true;
                flag = true;
            }
            catch (Exception ex)
            {
                error_buff = ex.Message;
            }
            return flag;
        }

        //wdインスタンス解放
        private void destroy_wd()
        {
            if (ldr != null) ldr.shutdown();
        }

        //設定ボタンクリック
        private void openAsSettingButton_Click(object sender, EventArgs e)
        {
            showSettingsForm();
        }

        //実装実験ボタンクリック
        private void debugButton_Click(object sender, EventArgs e)
        {
            //do_create_category_by_details();
            //do_create_asignlist_details_xlsx();
            //do_create_asignlist_with_count_xlsx();
        }

        //サイトID読込クリック
        private void projectIDLoadButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            set_projectID_combo();
        }

        //フォームを閉じようとしたとき
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //destroy_child_form();
            destroy_wd();
        }

        //Excel出力クリック
        private void createSiteInfoBookButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            create_site_info_book();
        }

        //ページID読込クリック
        private void pageIDLoadButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            set_pageID_combo();
        }

        //URL TSV出力ボタンクリック
        private void doUrlTaksFormatTextButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            do_create_pid_url_list();
        }

        //URL Excel出力ボタンクリック
        private void doUrlTaksFormatExcelButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            do_create_pid_url_list_xlsx();
        }

        //割り当て表作成ボタンクリック
        private void doAsignListButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            do_create_asignlist_with_count_xlsx();
        }

        //作業フォルダボタンクリック
        private void openAsFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(workDir);
        }

        //Basic認証有チェックON
        private void basicAuthFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            basic_auth = (basicAuthFlagCheck.Checked) ? "yes" : "no";
        }

        //TSVからロードボタンクリック
        private void doPageIDLoadFromTsvButton_Click(object sender, EventArgs e)
        {
            set_pageID_combo_from_tsv();
        }

        //スクリーンショットボタンクリック
        private void doPageIDsScreenShotButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            do_pageIDs_screenshot();
        }

        //ページID全選択クリック
        private void pageIDListBoxSelectAllButton_Click(object sender, EventArgs e)
        {
            SendMessage(pageIDListBox.Handle, LB_SETSEL, 1, -1);
            pageIDListBox.SetSelected(0, true);
        }

        //ページID選択解除クリック
        private void pageIDListBoxSelectClearButton_Click(object sender, EventArgs e)
        {
            SendMessage(pageIDListBox.Handle, LB_SETSEL, 0, -1);
            pageIDListBox.SetSelected(0, false);
        }

        //LibraPSエクセルフォーマットの整形クリック
        private async void libraPlusReportFormatButton_Click(object sender, EventArgs e)
        {
            string excel_path = getExcelFileNameFromDialog();
            if (excel_path == "") return;
            ExcelUtil eu = new ExcelUtil();
            eu.currentWbPath = excel_path;
            eu.saveDirPath = workDir + @"\";
            eu.initCurrentBook();
            await eu.lpReportFormat();
        }

        //カテゴリ別検査詳細リストクリック
        private async void createCategoryByDetailsRepotButton_Click(object sender, EventArgs e)
        {
            await do_create_category_by_details();
        }
    }
}
