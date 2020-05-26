using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace LPRepo
{
    partial class Form1
    {

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
            //Bitmap ieImg = getImageFromResource("ie24.png");
            //Bitmap ffImg = getImageFromResource("ff24.png");
            //Bitmap gcImg = getImageFromResource("gc24.png");
            //Bitmap folderImg = getImageFromResource("folder24.png");
            Bitmap settingImg = getImageFromResource("icon-settings.png");
            //Bitmap excelImg = getImageFromResource("ico-excel-21.png");
            //Bitmap gridImg = getImageFromResource("ico-grid-21.png");
            //Bitmap loadImg = getImageFromResource("ico-load.png");
            //openAsIEButton.Image = ieImg;
            //openAsFirefoxButton.Image = ffImg;
            //openAsChromeButton.Image = gcImg;
            //openAsFolderButton.Image = folderImg;
            openAsSettingButton.Image = settingImg;
            //createSiteInfoBookButton.Image = excelImg;
            //projectIDLoadButton.Image = loadImg;
            //pageIDLoadButton.Image = loadImg;
            //techIDLoadButton.Image = loadImg;
        }

    }
}
