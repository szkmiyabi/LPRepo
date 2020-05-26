using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LPRepo
{
    public class LPDriver
    {
        private Form1 main_form;
        private string _projectID;
        private IWebDriver _wd;
        private IJavaScriptExecutor _jexe;
        private int systemWait;
        private int longWait;
        private int midWait;
        private int shortWait;
        private string uid;
        private string pswd;
        private string _windowID;
        private string app_url = "https://jis2.infocreate.co.jp/libraplus/";
        /*
        private string index_url = "https://jis.infocreate.co.jp/";
        private string rep_index_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/report/projID/";
        private string rep_detail_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/report2/projID/";
        private string sv_mainpage_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/index/projID/";
        private string completed_site_url = "https://jis.infocreate.co.jp/index/end/";
        private string certificated_site_url = "https://jis.infocreate.co.jp/index/rediagnose/";
        */
        private string _basic_auth_flag;
        private Boolean _basic_authenicated;
        private string workDir;

        //コンストラクタ
        public LPDriver( string uid, string pswd, int[] appWait, string driver_type, string headless_flag, string basic_auth_flag, string workDir, string debugMode)
        {
            main_form = Form1.main_form;
            this.uid = uid;
            this.pswd = pswd;
            systemWait = appWait[0];
            longWait = appWait[1];
            midWait = appWait[2];
            shortWait = appWait[3];
            this.workDir = workDir;

            //basic認証フラグ
            _basic_auth_flag = basic_auth_flag;
            _basic_authenicated = false;

            if (driver_type.Equals("firefox"))
            {
                FirefoxOptions fxopt = new FirefoxOptions();
                FirefoxDriverService fxserv = FirefoxDriverService.CreateDefaultService(workDir);
                fxserv.FirefoxBinaryPath = get_firefox_binary_path();
                if (debugMode == "no") fxserv.HideCommandPromptWindow = true;
                if (headless_flag.Equals("yes")) fxopt.AddArguments("-headless");
                _wd = new FirefoxDriver(fxserv, fxopt);
            }
            else if (driver_type.Equals("chrome"))
            {
                ChromeOptions chopt = new ChromeOptions();
                ChromeDriverService chserv = ChromeDriverService.CreateDefaultService(workDir);
                if (debugMode == "no") chserv.HideCommandPromptWindow = true;
                if (headless_flag.Equals("yes")) chopt.AddArguments("--headless");
                _wd = new ChromeDriver(chserv, chopt);
            }

            _wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(systemWait);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
            _windowID = _wd.WindowHandles[0];
            //MessageBox.Show(_windowID);
            _jexe = (IJavaScriptExecutor)_wd;
        }

        //Firefoxバイナリパスの取得
        private string get_firefox_binary_path()
        {
            string ffpath = "";
            string ffpath1 = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            string ffpath2 = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            if (System.IO.File.Exists(ffpath1)) ffpath = ffpath1;
            else if (System.IO.File.Exists(ffpath2)) ffpath = ffpath2;
            return ffpath;
        }

        //operationStatusReportのデリゲート
        public delegate void d_messenger(string msg);
        public void w_messenger(string msg)
        {
            main_form.operationStatusReport.AppendText(msg + "\r\n");
        }

        //WebDriverのゲッター
        public IWebDriver wd
        {
            get { return _wd; }
        }

        //projectIDのセッター
        public string projectID
        {
            set { _projectID = value; }
        }

        //JavascriptExecutorのゲッター
        public IJavaScriptExecutor jexe
        {
            get { return _jexe; }
        }

        //basic認証済みフラグのゲッター/セッター
        public Boolean basic_authenicated
        {
            get { return _basic_authenicated; }
            set { _basic_authenicated = value; }
        }

        //スクリーンショットを撮る
        public void screenshot(string filename)
        {
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            string save_dir = workDir + filename + ".png";
            sc.SaveAsFile(save_dir, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        //スクリーンショットを撮る（ディレクトリ指定）
        public void screenshot_as(string save_path)
        {
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            sc.SaveAsFile(save_path, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        //fullpage screenshotを撮る
        public void fullpage_screenshot(string filename)
        {
            //IJavaScriptExecutor jsexe = (IJavaScriptExecutor)wd;
            string ret = jexe.ExecuteScript("return document.body.parentNode.scrollHeight;").ToString();
            int require_height = Int32.Parse(ret);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, require_height);
            DateUtil.app_sleep(longWait);
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            string save_dir = workDir + @"screenshots\";
            if (!Directory.Exists(save_dir)) Directory.CreateDirectory(save_dir);
            sc.SaveAsFile(save_dir + filename + ".png", OpenQA.Selenium.ScreenshotImageFormat.Png);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
        }

        //fullpage screenshotを撮る（ディレクトリも指定）
        public void fullpage_screenshot_as(string save_path)
        {
            //IJavaScriptExecutor jsexe = (IJavaScriptExecutor)wd;
            string ret = jexe.ExecuteScript("return document.body.parentNode.scrollHeight;").ToString();
            int require_height = Int32.Parse(ret);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, require_height);
            DateUtil.app_sleep(longWait);
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            sc.SaveAsFile(save_path, OpenQA.Selenium.ScreenshotImageFormat.Png);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
        }

        //シャットダウン
        public void shutdown()
        {
            _wd.Quit();
        }
    }
}
