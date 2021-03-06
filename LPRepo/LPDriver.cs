﻿using System;
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
        private string index_url = "https://jis2.infocreate.co.jp/libraplus/top";
        private string working_site_url = "https://jis2.infocreate.co.jp/libraplus/site/list/0";
        private string completed_site_url = "https://jis2.infocreate.co.jp/libraplus/site/list/1";
        private string sv_mainpage_url_base = "http://jis2.infocreate.co.jp/libraplus/inspect/start/index/";

        private string status_list_url = "https://jis2.infocreate.co.jp/libraplus/status/list/";

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
        public delegate void _write_log(string msg);
        public void write_log(string msg)
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

        //ホームページを開く
        public void home()
        {
            _wd.Navigate().GoToUrl(app_url);
        }

        //検査中サイト一覧画面に遷移
        public void working_site_page()
        {
            _wd.Navigate().GoToUrl(working_site_url);
        }


        //検査終了サイト一覧画面に遷移
        public void completed_site_page()
        {
            _wd.Navigate().GoToUrl(completed_site_url);
        }

        //シャットダウン
        public void shutdown()
        {
            _wd.Quit();
        }

        //ログイン
        public void login()
        {
            _wd.FindElement(By.Id("userid")).SendKeys(uid);
            _wd.FindElement(By.Id("pw")).SendKeys(pswd);
            var btns = _wd.FindElements(By.TagName("button"));
            for(int i=0; i<btns.Count<IWebElement>(); i++)
            {
                IWebElement btn = btns.ElementAt<IWebElement>(i);
                string attr = btn.GetAttribute("type");
                string txt = btn.Text.TrimStart().TrimEnd();
                if(attr == "submit" && txt == "ログイン")
                {
                    btn.Click();
                    break;
                }
            }
        }

        //ログアウト
        public void logout()
        {
            _wd.Navigate().GoToUrl(index_url);
            DateUtil.app_sleep(shortWait);
            IWebElement btnWrap = _wd.FindElement(By.Id("navbar-header"));
            var btns = btnWrap.FindElements(By.TagName("button"));
            for (int i = 0; i < btns.Count<IWebElement>(); i++)
            {
                IWebElement btn = btns.ElementAt<IWebElement>(i);
                string attr = btn.GetAttribute("type");
                string txt = btn.Text.TrimStart().TrimEnd();
                if (attr == "button" && txt == "ログアウト")
                {
                    btn.Click();
                    break;
                }
            }

        }

        //検査メインページに移動
        public void browse_sv_mainpage()
        {
            //basic認証の処理
            if (_basic_auth_flag.Equals("yes") && _basic_authenicated == false)
            {
                _write_log __write_log = write_log;
                main_form.Invoke(__write_log, "【お知らせ】基本認証オプションが有効化されています。ログインアラートで認証してください。");
                _basic_authenicated = true;
            }
            _wd.Navigate().GoToUrl(sv_mainpage_url_base + _projectID);
        }

        //サイト一覧を取得（サイトIDコンボ用）
        public List<List<string>> get_site_list()
        {
            List<List<string>> data = new List<List<string>>();
            var tbl = _wd.FindElement(By.Id("myTable"));
            var trs = tbl.FindElements(By.TagName("tr"));
            int nx = trs.Count<IWebElement>();

            for (int i = 1; i < nx; i++)
            {
                var tds = trs.ElementAt<IWebElement>(i).FindElements(By.TagName("td"));
                List<string> row = new List<string>();
                string td1 = TextUtil.text_clean(tds.ElementAt<IWebElement>(0).Text);
                string td2 = TextUtil.text_clean(tds.ElementAt<IWebElement>(1).Text);
                row.Add(td1);
                row.Add(td2);
                data.Add(row);
            }
            return data;
        }

        //サイトデータを取得
        public List<List<string>> get_site_info_data()
        {
            List<List<string>> data = new List<List<string>>();
            var tbl = _wd.FindElement(By.Id("myTable"));
            var trs = tbl.FindElements(By.TagName("tr"));
            int nx = trs.Count<IWebElement>();
            for (int i = 1; i < nx; i++)
            {
                var tds = trs.ElementAt<IWebElement>(i).FindElements(By.TagName("td"));
                List<string> row = new List<string>();
                string id = TextUtil.text_clean(tds.ElementAt<IWebElement>(0).Text);
                string name = TextUtil.text_clean(tds.ElementAt<IWebElement>(1).Text);
                string orgname = TextUtil.text_clean(tds.ElementAt<IWebElement>(2).Text);
                string groupname = TextUtil.text_clean(tds.ElementAt<IWebElement>(3).Text);
                string startdate = TextUtil.text_clean(tds.ElementAt<IWebElement>(4).Text);
                string enddate = TextUtil.text_clean(tds.ElementAt<IWebElement>(5).Text);
                string urlcnt = TextUtil.text_clean(tds.ElementAt<IWebElement>(6).Text);
                string status = TextUtil.text_clean(tds.ElementAt<IWebElement>(7).Text);
                row.Add(id);
                row.Add(name);
                row.Add(orgname);
                row.Add(groupname);
                row.Add(startdate);
                row.Add(enddate);
                row.Add(urlcnt);
                row.Add(status);
                data.Add(row);
            }
            return data;
        }


        //PID+URL一覧データを生成（検査メイン画面から）
        public List<List<string>> get_page_list_data_from_svpage()
        {
            List<List<string>> data = new List<List<string>>();
            var url_ddl = _wd.FindElement(By.Id("select_urlno"));
            var opts = url_ddl.FindElements(By.TagName("option"));
            for (int i = 0; i < opts.Count<IWebElement>(); i++)
            {
                IWebElement opt = opts.ElementAt<IWebElement>(i);
                List<string> row = new List<string>();
                //string v1 = opt.GetAttribute("value");
                string v1 = _get_option_pidtext(opt);
                string v2 = _get_option_urltext(opt);
                row.Add(v1);
                row.Add(v2);
                data.Add(row);
            }
            return data;
        }
        private string _get_option_pidtext(IWebElement opt)
        {
            string ret = "";
            string val = opt.Text;
            Regex pt = new Regex(@"(\[)([a-zA-Z0-9\-]+)(\] )(.+)");
            if (pt.IsMatch(val))
            {
                MatchCollection mc = pt.Matches(val);
                ret = mc[0].Groups[2].Value;
            }
            return ret;
        }
        private string _get_option_urltext(IWebElement opt)
        {
            string ret = "";
            string val = opt.Text;
            Regex pt = new Regex(@"(\[[a-zA-Z0-9\-]+\] )(.+)");
            if (pt.IsMatch(val))
            {
                MatchCollection mc = pt.Matches(val);
                ret = mc[0].Groups[2].Value;
            }
            return ret;
        }

        //進捗管理画面セットアップ（PID選択→表示ボタンクリック）
        public void init_status_page()
        {
            Regex pt = new Regex(@"\[" + _projectID + @"\]");

            _wd.Navigate().GoToUrl(status_list_url);
            DateUtil.app_sleep(shortWait);

            var select_pids_wrap = _wd.FindElement(By.Id("siteno"));
            var select_pids = select_pids_wrap.FindElements(By.TagName("option"));
            for (int i = 0; i < select_pids.Count<IWebElement>(); i++)
            {
                IWebElement op = select_pids.ElementAt<IWebElement>(i);
                string op_txt = op.Text.TrimStart().TrimEnd();
                if (pt.IsMatch(op_txt))
                {
                    op.Click();
                    break;
                }
            }
            DateUtil.app_sleep(shortWait);
            var btns = _wd.FindElements(By.TagName("button"));
            for (int i = 0; i < btns.Count<IWebElement>(); i++)
            {
                IWebElement btn = btns.ElementAt<IWebElement>(i);
                string attr = btn.GetAttribute("value");
                if (attr == "表示")
                {
                    btn.Click();
                    break;
                }
            }
            DateUtil.app_sleep(shortWait);
        }

        //PID+URL一覧データを生成（進捗管理画面から）
        public List<List<string>> get_page_list_data_from_status_page()
        {
            List<List<string>> data = new List<List<string>>();
            var tbl = _wd.FindElement(By.Id("myTable"));
            var tbl_bd = tbl.FindElement(By.TagName("tbody"));
            var trs = tbl_bd.FindElements(By.TagName("tr"));
            int nx = trs.Count<IWebElement>() - 1;
            for(int i=0; i<nx; i++)
            {
                IWebElement tr = trs.ElementAt<IWebElement>(i);
                var tds = tr.FindElements(By.TagName("td"));
                IWebElement td1 = tds.ElementAt<IWebElement>(0);
                IWebElement td2 = tds.ElementAt<IWebElement>(1);
                string pid = td1.Text.TrimStart().TrimEnd();
                string url = td2.Text.TrimStart().TrimEnd();
                List<string> row = new List<string>();
                row.Add(pid);
                row.Add(url);
                data.Add(row);
            }
            return data;
        }

        //カテゴリ一覧を取得（検査メイン画面から）
        public List<string> get_category_list_data_from_svpage()
        {
            List<string> data = new List<string>();
            var cat_list_wrap = _wd.FindElement(By.Id("tabs-category"));
            var cat_list = cat_list_wrap.FindElements(By.TagName("li"));
            for(int i=0; i<cat_list.Count<IWebElement>(); i++)
            {
                IWebElement li = cat_list.ElementAt<IWebElement>(i);
                var atg = li.FindElement(By.TagName("a"));
                string vl = _get_category_only_text(atg.Text);
                data.Add(vl);
            }
            return data;
        }
        private string _get_category_only_text(string str)
        {
            string ret = "";
            Regex pt = new Regex(@"(.+?)([0-9]+)");
            if (pt.IsMatch(str))
            {
                MatchCollection mc = pt.Matches(str);
                ret = mc[0].Groups[1].Value;
            }
            else
            {
                return str;
            }
            return ret;
        }

        //カテゴリ一覧を取得（進捗管理画面から）
        public List<string> get_category_list_data_from_status_page()
        {
            List<string> data = new List<string>();
            var tbl = _wd.FindElement(By.Id("myTable"));
            var tbl_hd = tbl.FindElement(By.TagName("thead"));
            var trs = tbl_hd.FindElements(By.TagName("tr"));
            IWebElement tr = trs.ElementAt<IWebElement>(1);
            var ths = tr.FindElements(By.TagName("th"));
            int nx = ths.Count<IWebElement>() - 1;
            for(int i=0; i<nx; i++)
            {
                IWebElement th = ths.ElementAt<IWebElement>(i);
                string tx = th.Text.TrimStart().TrimEnd();
                data.Add(tx);
            }
            return data;
        }

        //進捗管理表データを取得
        public List<List<string>> get_status_all_table_data()
        {
            List<List<string>> data = new List<List<string>>();
            List<string> head_row = new List<string>();

            var tbl = _wd.FindElement(By.Id("myTable"));
            var tbl_hd = tbl.FindElement(By.TagName("thead"));
            var trs = tbl_hd.FindElements(By.TagName("tr"));
            IWebElement tr = trs.ElementAt<IWebElement>(1);
            var ths = tr.FindElements(By.TagName("th"));
            int nx = ths.Count<IWebElement>() - 1;

            head_row.Add("管理番号");
            head_row.Add("URL");
            for (int i = 0; i < nx; i++)
            {
                IWebElement th = ths.ElementAt<IWebElement>(i);
                string tx = th.Text.TrimStart().TrimEnd();
                head_row.Add(tx);
            }

            data.Add(head_row);

            var tbl_bd = tbl.FindElement(By.TagName("tbody"));
            var trs_bd = tbl_bd.FindElements(By.TagName("tr"));
            var nx_bd = trs_bd.Count<IWebElement>() - 1;
            for(int i=0; i<nx_bd; i++)
            {
                IWebElement tr_bd = trs_bd.ElementAt<IWebElement>(i);
                var tds = tr_bd.FindElements(By.TagName("td"));
                int tdnx = tds.Count<IWebElement>() - 1;
                List<string> row = new List<string>();
                for(int j=0; j<tdnx; j++)
                {
                    if (j == 2) continue;
                    IWebElement td = tds.ElementAt<IWebElement>(j);
                    string val = "";
                    if(j==0 || j==1)
                    {
                        val = td.Text.TrimStart().TrimEnd();
                    }
                    else
                    {
                        var atg = td.FindElement(By.TagName("a"));
                        val = atg.Text.TrimStart().TrimEnd();
                    }
                    row.Add(val);
                }
                data.Add(row);
            }

            return data; 
        }

        //カテゴリタブを選択
        public void select_category(int nx)
        {
            var cat_list_wrap = _wd.FindElement(By.Id("tabs-category"));
            var cat_list = cat_list_wrap.FindElements(By.TagName("li"));
            for (int i = 0; i < cat_list.Count<IWebElement>(); i++)
            {
                IWebElement li = cat_list.ElementAt<IWebElement>(i);
                var atg = li.FindElement(By.TagName("a"));
                if (i == nx)
                {
                    atg.Click();
                    break;
                }
            }
        }

        //カテゴリタブを選択（オーバーライド）
        public void select_category(string catname)
        {
            var cat_list_wrap = _wd.FindElement(By.Id("tabs-category"));
            var cat_list = cat_list_wrap.FindElements(By.TagName("li"));
            for (int i = 0; i < cat_list.Count<IWebElement>(); i++)
            {
                IWebElement li = cat_list.ElementAt<IWebElement>(i);
                var atg = li.FindElement(By.TagName("a"));
                string val = _get_category_only_text(atg.Text);
                if (val == catname)
                {
                    atg.Click();
                    break;
                }
            }
        }

        //カレントカテゴリ名を取得
        private string get_current_category_name()
        {
            string ret = "";
            var cat_list_wrap = _wd.FindElement(By.Id("tabs-category"));
            var cat_list = cat_list_wrap.FindElements(By.TagName("li"));
            for (int i = 0; i < cat_list.Count<IWebElement>(); i++)
            {
                IWebElement li = cat_list.ElementAt<IWebElement>(i);
                var atg = li.FindElement(By.TagName("a"));
                var attr = atg.GetAttribute("class");
                Regex pt = new Regex(@"active", RegexOptions.Compiled);
                if (pt.IsMatch(attr))
                {
                    ret = _get_category_only_text(atg.Text);
                }
            }
            return ret;
        }

        //画面モードタブを選択
        public void select_view(int nx)
        {
            var vw_list_wrap = _wd.FindElement(By.Id("tabs"));
            var vw_list = vw_list_wrap.FindElements(By.TagName("li"));
            for (int i = 0; i < vw_list.Count<IWebElement>(); i++)
            {
                IWebElement li = vw_list.ElementAt<IWebElement>(i);
                var atg = li.FindElement(By.TagName("a"));
                if (i == nx)
                {
                    atg.Click();
                    break;
                }
            }
        }

        //画面モードタブを選択（オーバーライド）
        public void select_view(string vwname)
        {
            var vw_list_wrap = _wd.FindElement(By.Id("tabs"));
            var vw_list = vw_list_wrap.FindElements(By.TagName("li"));
            for (int i = 0; i < vw_list.Count<IWebElement>(); i++)
            {
                IWebElement li = vw_list.ElementAt<IWebElement>(i);
                var atg = li.FindElement(By.TagName("a"));
                string val = atg.Text;
                if (val == vwname)
                {
                    atg.Click();
                    break;
                }
            }
        }

        //サイト名を取得
        public string get_site_name()
        {
            string sname = "";
            var tbls = _wd.FindElements(By.TagName("table"));
            var tbl = tbls.ElementAt<IWebElement>(0);
            var tds = tbl.FindElements(By.CssSelector("tr td"));
            var td = tds.ElementAt<IWebElement>(0);
            string td_val = TextUtil.text_clean(td.Text);
            Regex pt1 = new Regex(@"(\[)([0-9]+)(\])( )(.+?)( / )");
            Regex pt2 = new Regex(@"(\[)([0-9]+)(\])( )(.+)");
            if (pt1.IsMatch(td_val))
            {
                Match mt1 = pt1.Match(td_val);
                sname = mt1.Groups[5].Value;
            }
            else if (pt2.IsMatch(td_val))
            {
                Match mt2 = pt2.Match(td_val);
                sname = mt2.Groups[5].Value;
            }
            return sname;
        }

        //検査項目一覧を取得
        public List<List<object>> get_survey_details()
        {
            List<List<object>> data = new List<List<object>>();
            var tbl = _wd.FindElement(By.Id("table-inspect"));
            var trs = tbl.FindElements(By.TagName("tr"));
            for(int i=0; i<trs.Count<IWebElement>(); i++)
            {
                //ヘッダー行スキップ
                if (i == 0) continue;

                string category = get_current_category_name();
                string num = "";
                string title = "";
                List<string> gs = new List<string>();
                List<object> row = new List<object>();
                var tr = trs.ElementAt<IWebElement>(i);
                var tds = tr.FindElements(By.TagName("td"));

                //検査項目が0件の時の処理（セル結合でエラー出るため早期返却）
                if (tds.ElementAt<IWebElement>(0).GetAttribute("colspan") != null)
                {
                    List<object> row_ = new List<object>();
                    List<string> gs_ = new List<string>();
                    row_.Add(category);
                    row_.Add("");
                    row_.Add("");
                    row_.Add(gs_);
                    data.Add(row_);
                    return data;
                }

                var td1 = tds.ElementAt<IWebElement>(0);
                var td2 = tds.ElementAt<IWebElement>(1);
                num = td1.Text;
                title = td2.Text;

                var sps = td2.FindElements(By.TagName("span"));
                foreach(IWebElement e in sps)
                {
                    var tx = e.Text;
                    title = title.Replace(tx, "");
                }

                var ul = td2.FindElement(By.TagName("ul"));
                var ls = ul.FindElements(By.TagName("li"));
                foreach(IWebElement e in ls)
                {
                    var tx = e.Text;
                    title = title.Replace(tx, "");
                    gs.Add(tx);
                }

                title = TextUtil.trim(TextUtil.text_clean(title));
                row.Add(category);
                row.Add(num);
                row.Add(title);
                row.Add(gs);
                data.Add(row);
            }
            return data;
        }


    }
}
