using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LPRepo
{
    public partial class SettingsForm : Form
    {
        private Settings appSettings;
        private string filename;

        public SettingsForm()
        {
            InitializeComponent();
            filename = Application.UserAppDataPath + @"\settings.config";
            appSettings = new Settings();
            loadSettings();
        }

        //環境設定を保存
        private void saveSettings()
        {
            try
            {
                appSettings.uid = uidText.Text;
                appSettings.pswd = pswdText.Text;
                appSettings.systemWait = (int)systemWaitCombo.Value;
                appSettings.longWait = (int)longWaitCombo.Value;
                appSettings.midWait = (int)midWaitCombo.Value;
                appSettings.shortWait = (int)shortWaitCombo.Value;
                appSettings.driver = (string)driverCombo.SelectedItem;
                appSettings.headless = (string)headlessCombo.SelectedItem;
                appSettings.workDir = (workDirText.Text == "") ? getDefaultWorkDir() : workDirText.Text;
                appSettings.debugMode = (debugModeCheck.Checked == true) ? "yes" : "no";

                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamWriter sw = new StreamWriter(
                    filename,
                    false,
                    new System.Text.UTF8Encoding(false)
                );
                xsz.Serialize(sw, appSettings);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("設定が保存でませんでした。" + ex.Message);
            }
        }

        //環境設定をロード
        private void loadSettings()
        {
            try
            {
                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamReader sr = new StreamReader(
                    filename,
                    new System.Text.UTF8Encoding(false)
                );
                appSettings = (Settings)xsz.Deserialize(sr);
                sr.Close();

                uidText.Text = appSettings.uid;
                pswdText.Text = appSettings.pswd;
                systemWaitCombo.Value = (decimal)appSettings.systemWait;
                longWaitCombo.Value = (decimal)appSettings.longWait;
                midWaitCombo.Value = (decimal)appSettings.midWait;
                shortWaitCombo.Value = (decimal)appSettings.shortWait;
                driverCombo.Text = appSettings.driver;
                headlessCombo.Text = appSettings.headless;
                workDirText.Text = (appSettings.workDir == "") ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" : appSettings.workDir;
                debugModeCheck.Checked = (appSettings.debugMode == "yes") ? true : false;

            }
            catch (Exception ex)
            {

            }
        }

        //環境設定を削除
        private void deleteSettings()
        {
            try
            {
                appSettings.uid = "";
                appSettings.pswd = "";
                appSettings.systemWait = 60;
                appSettings.longWait = 10;
                appSettings.midWait = 8;
                appSettings.shortWait = 5;
                appSettings.driver = "";
                appSettings.headless = "";
                appSettings.workDir = "";
                appSettings.debugMode = "";


                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamWriter sw = new StreamWriter(
                    filename,
                    false,
                    new System.Text.UTF8Encoding(false)
                );
                xsz.Serialize(sw, appSettings);
                sw.Close();

                uidText.Text = "";
                pswdText.Text = "";
                systemWaitCombo.Value = 60;
                longWaitCombo.Value = 10;
                midWaitCombo.Value = 8;
                shortWaitCombo.Value = 5;
                driverCombo.Text = "";
                headlessCombo.Text = "";
                workDirText.Text = "";
                debugModeCheck.Checked = false;

                MessageBox.Show("設定が削除できました。");

            }
            catch (Exception ex)
            {
                MessageBox.Show("設定が保存でませんでした。" + ex.Message);
            }
        }

        //作業ディレクトリをセットする
        private void setWorkDir()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを指定してください";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                workDirText.Text = fbd.SelectedPath + @"\";
            }
        }

        //デフォルトの作業ディレクトリを取得
        private string getDefaultWorkDir()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
        }

        //ユーザのホームフォルダパス
        private string getUserHomePath()
        {
            return System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            deleteSettings();
        }

        private void workDirBrowseButton_Click(object sender, EventArgs e)
        {
            setWorkDir();
        }
    }
}
