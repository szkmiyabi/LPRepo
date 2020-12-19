using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPRepo
{
    class FileUtil
    {
        private Form1 main_form;

        //コンストラクタ
        public FileUtil()
        {
            main_form = Form1.main_form;
        }

        //デリゲート
        public delegate void _write_log(string msg);
        public void write_log(string msg)
        {
            main_form.operationStatusReport.AppendText(msg + "\r\n");
        }

        //配列をテキストファイルとして書き込み
        public void write_text_data(List<string> data, string filename)
        {
            _write_log __write_log = write_log;
            Encoding enc = new System.Text.UTF8Encoding(false);
            StreamWriter sw = new StreamWriter(filename, false, enc);
            for (int i = 0; i < data.Count; i++)
            {
                string row = (string)data[i] + "\r\n";
                sw.Write(row);
            }
            sw.Close();
            main_form.Invoke(__write_log, "保存に成功しました。（" + filename + "）");
        }

        //2次元配列をTSVファイルとして書き込み
        public void write_tsv_data(List<List<string>> data, string filename)
        {
            _write_log __write_log = write_log;
            Encoding enc = new System.Text.UTF8Encoding(false);
            StreamWriter sw = new StreamWriter(filename, false, enc);
            for (int i = 0; i < data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string row_data = col[0] + "\t" + col[1] + "\r\n";
                sw.Write(row_data);
            }
            sw.Close();
            main_form.Invoke(__write_log, "保存に成功しました。（" + filename + "）");
        }
    }
}
