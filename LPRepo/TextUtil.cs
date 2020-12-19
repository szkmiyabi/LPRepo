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

        //ページIDコンボからURLだけを取り出す
        public static string fetch_url(string str)
        {
            return Regex.Replace(str, @"\[[0-9a-zA-Z\-_]+\]  ", "");
        }

    }
}
