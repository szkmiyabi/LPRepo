using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LPRepo
{
    class DateUtil
    {
        //現在の時刻からファイル名を生成
        public static string fetch_filename_from_datetime(string extension)
        {
            DateTime ld = DateTime.Now;
            return ld.ToString("yyyy-MM-dd_HH-mm-ss") + "." + extension;
        }

        //ファイル用時刻文字列を生成
        public static string fetch_filename_logtime()
        {
            DateTime ld = DateTime.Now;
            return ld.ToString("yyyy-MM-dd_HH-mm-ss");
        }

        //ログ出力の時刻文字列を生成
        public static string get_logtime()
        {
            DateTime ld = DateTime.Now;
            return ld.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //アプリのスリープ
        public static void app_sleep(int second)
        {
            int milisec = second * 1000;
            Thread.Sleep(milisec);
        }
    }
}
