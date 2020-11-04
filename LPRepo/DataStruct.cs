using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPRepo
{
    //プロジェクトIDコンボのデータ構造クラス
    public class projectIDComboItem
    {
        private string _id_str;
        private string _display_str;

        //コンストラクタ
        public projectIDComboItem() { }
        public projectIDComboItem(string id, string display)
        {
            _id_str = id;
            _display_str = display;
        }

        //ゲッターとセッター
        public string id_str
        {
            get { return _id_str; }
            set { _id_str = value; }
        }
        public string display_str
        {
            get { return _display_str; }
            set { _display_str = value; }
        }

    }

    //ページIDコンボのデータ構造クラス
    public class pageIDComboItem
    {
        private string _id_str;
        private string _display_str;

        //コンストラクタ
        public pageIDComboItem() { }
        public pageIDComboItem(string id, string display)
        {
            _id_str = id;
            _display_str = display;
        }

        //ゲッターとセッター
        public string id_str
        {
            get { return _id_str; }
            set { _id_str = value; }
        }
        public string display_str
        {
            get { return _display_str; }
            set { _display_str = value; }
        }
    }
}
