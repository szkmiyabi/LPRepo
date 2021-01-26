using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LPRepo
{
    partial class Form1
    {
        private Settings appSettings;
        private string settings_filename;

        private string uid;
        private string pswd;
        private int systemWait;
        private int longWait;
        private int midWait;
        private int shortWait;
        private string driver;
        private string headless;
        private string workDir;
        private string debugMode;

        //環境設定ダイアログを開く
        private void showSettingsForm()
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog(this);
            sf.Dispose();
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

        }

        //環境設定をロード
        private void loadAppSettings()
        {
            try
            {
                appSettings = new Settings();
                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamReader sr = new StreamReader(
                    settings_filename,
                    new System.Text.UTF8Encoding(false)
                );
                appSettings = (Settings)xsz.Deserialize(sr);
                sr.Close();

                uid = appSettings.uid;
                pswd = appSettings.pswd;
                systemWait = appSettings.systemWait;
                longWait = appSettings.longWait;
                midWait = appSettings.midWait;
                shortWait = appSettings.shortWait;
                driver = appSettings.driver;
                headless = appSettings.headless;
                workDir = (appSettings.workDir == "") ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" : appSettings.workDir;
                debugMode = (appSettings.debugMode == "" || appSettings.debugMode == "no") ? "no" : "yes";

            }
            catch (Exception ex)
            {
            }
        }

        //環境設定パラメータチェック
        private Boolean checkSettings()
        {
            //デリゲートインスタンス
            _write_log __write_log = write_log;

            Boolean flag = true;
            StringBuilder sb = new StringBuilder();
            string err_txt = "";

            if (uid == "")
            {
                flag = false;
                sb.Append("・ユーザIDが未設定です。\r\n");
            }
            if (pswd == "")
            {
                flag = false;
                sb.Append("・パスワードが未設定です。\r\n");
            }
            if (headless == "")
            {
                flag = false;
                sb.Append("・ヘッドレス起動の有無効が未設定です。\r\n");
            }
            if (systemWait < 60)
            {
                flag = false;
                sb.Append("・システム待時間が60秒未満です。\r\n");
            }
            if (shortWait < 3)
            {
                flag = false;
                sb.Append("・待時間【小】が3秒未満です。\r\n");
            }
            if (midWait < 3)
            {
                flag = false;
                sb.Append("・待時間【中】が3秒未満です。\r\n");
            }
            if (longWait < 3)
            {
                flag = false;
                sb.Append("・待時間【大】が3秒未満です。\r\n");
            }

            err_txt = sb.ToString();
            if (flag == false)
            {
                err_txt = "【エラー】ブラウザドライバの起動要件を満たしません。\r\n考えられる理由は、初回起動である、あるいは環境設定の不具合です。環境設定をご確認ください。\r\n" + err_txt;
                this.Invoke(__write_log, err_txt);
            }
            return flag;
        }

        //フォーム上の全コントロールを列挙するジェネリックメソッド
        public static List<T> GetAllControls<T>(Control top) where T : Control
        {
            List<T> buf = new List<T>();
            foreach (Control ctrl in top.Controls)
            {
                if (ctrl is T) buf.Add((T)ctrl);
                buf.AddRange(GetAllControls<T>(ctrl));
            }
            return buf;
        }

        //imageリソースを取得
        public Bitmap getImageFromResource(string imgname)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("LPRepo.resources." + imgname);
            Bitmap bmp = new Bitmap(stream);
            return bmp;
        }

        //イメージボタン初期化
        private void imgButtonInit()
        {
            Bitmap ieImg = getImageFromResource("ie24.png");
            Bitmap ffImg = getImageFromResource("ff24.png");
            Bitmap gcImg = getImageFromResource("gc24.png");
            Bitmap folderImg = getImageFromResource("folder24.png");
            Bitmap settingImg = getImageFromResource("setting24.png");
            Bitmap excelImg = getImageFromResource("ico-excel-21.png");
            Bitmap gridImg = getImageFromResource("ico-grid-21.png");
            Bitmap loadImg = getImageFromResource("ico-load.png");
            Bitmap debugImg = getImageFromResource("icon-debug.png");
            Bitmap tsvImg = getImageFromResource("ico-tsv.png");
            Bitmap grpImg = getImageFromResource("ico-group.png");
            openAsSettingButton.Image = settingImg;
            createSiteInfoBookButton.Image = excelImg;
            projectIDLoadButton.Image = loadImg;
            pageIDLoadButton.Image = loadImg;
            debugButton.Image = debugImg;
            doUrlTaksFormatExcelButton.Image = excelImg;
            doUrlTaksFormatTextButton.Image = tsvImg;
            doAsignListButton.Image = grpImg;
            openAsFolderButton.Image = folderImg;
        }

        //ファイル選択ダイアログを表示
        private string getFileNameFromDialog()
        {
            string filename = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            return filename;
        }

        //テキストファイル配列を取得
        private List<List<string>> getTextLineList(string filename)
        {
            string body = "";
            List<List<string>> data = new List<List<string>>();
            char[] delimiter = { '\t', ',' };

            if (filename != null)
            {
                StreamReader sr = new StreamReader(
                    filename,
                    System.Text.Encoding.GetEncoding("UTF-8")
                );
                body = sr.ReadToEnd();
                sr.Close();
            }

            if (body == "") return null;

            StringReader text = new StringReader(body);
            while(text.Peek() > -1)
            {
                string line = text.ReadLine();
                string[] tmp = line.Split(delimiter);
                List<string> row = new List<string>();
                row.Add(tmp[0]);
                row.Add(tmp[1]);
                data.Add(row);
            }

            return data;
        }

    }
}
