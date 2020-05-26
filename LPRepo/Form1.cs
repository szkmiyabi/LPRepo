using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
        //private CancellationTokenSource token_src;
        //private CancellationToken token;

        //Errorバッファ
        private string error_buff;

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
    }
}
