using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPRepo
{
    public partial class Form1 : Form
    {
        //Form1インスタンス
        private static Form1 _main_form;

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

        }

        //Formのゲッターとセッター
        public static Form1 main_form
        {
            get { return _main_form; }
            set { _main_form = value; }
        }
    }
}
