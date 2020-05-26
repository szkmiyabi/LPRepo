using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LPRepo
{
    class TextUtil
    {
        //改行やタブを除去
        public static string text_clean(string str)
        {
            return Regex.Replace(str, @"(\r\n|\n|\t)", "");
        }

        //行頭行末の空文字除去
        public static string trim(string str)
        {
            return str.TrimStart().TrimEnd();
        }

        //インデントを除去
        public static string trim_indent(string str)
        {
            return Regex.Replace(str, @"(^\t+|^ +)", "", RegexOptions.Multiline);
        }

        //brタグを改行コード変換
        public static string br_decode(string str)
        {
            return Regex.Replace(str, @"<br>", "");
        }

        //タグをデコード
        public static string tag_decode(string str)
        {
            string data = str;
            data = Regex.Replace(str, @"&lt;", "<");
            data = Regex.Replace(data, @"&gt;", ">");
            return data;
        }

        //達成基準番号をJIS2016形式に変換
        public static string jis2016_encode(string str)
        {
            return Regex.Replace(str, @"^7\.", "");
        }

        //ページIDコンボからURLだけを取り出す
        public static string fetch_url(string str)
        {
            return Regex.Replace(str, @"\[[0-9a-zA-Z\-_]+\]  ", "");
        }

        //レポートのヘッダー行を生成
        public static List<string> get_header()
        {
            List<string> head_row = new List<string>();
            head_row.Add("管理番号");
            head_row.Add("URL");
            head_row.Add("達成基準");
            head_row.Add("状況/要件");
            head_row.Add("実装番号");
            head_row.Add("検査結果");
            head_row.Add("検査員");
            head_row.Add("コメント");
            head_row.Add("対象ソースコード");
            head_row.Add("修正ソースコード");
            return head_row;
        }

        //レポートのヘッダー行を生成
        public static List<string> get_header_SrcTask()
        {
            List<string> head_row = new List<string>();
            head_row.Add("管理番号");
            head_row.Add("URL");
            head_row.Add("達成基準");
            head_row.Add("実装番号");
            head_row.Add("対象ソースコード");
            return head_row;
        }
    }
}
