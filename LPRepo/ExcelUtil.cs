using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;


namespace LPRepo
{
    class ExcelUtil
    {
        private Form1 main_form;

        //コンストラクタ
        public ExcelUtil()
        {
            main_form = Form1.main_form;
        }

        //デリゲート
        public delegate void _write_log(string msg);
        public void write_log(string msg)
        {
            main_form.operationStatusReport.AppendText(msg + "\r\n");
        }

        //最大文字数32767に収める
        private string fetch_overflow_characters(string data)
        {
            if (data.Length > 32767)
            {
                string prefix = "【注意】セルに入力可能な文字数の上限を超えました。32767文字以降は切り捨てられます。\n\n";
                int prefix_cnt = prefix.Length + 1;
                return prefix + data.Substring(0, (32767 - prefix_cnt));
            }
            else
            {
                return data;
            }
        }

        //Excelファイルに出力
        public void save_xlsx_as(List<List<string>> data, string filename)
        {
            _write_log __write_log = write_log;

            try
            {
                using (var wb = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Sheet1");

                    //行のループ
                    for (int i = 0; i < data.Count; i++)
                    {
                        List<string> row = (List<string>)data[i];

                        //列のループ
                        for (int j = 0; j < row.Count; j++)
                        {
                            string col = (string)row[j];
                            ws.Cell(i + 1, j + 1).SetValue<string>(fetch_overflow_characters(col));
                            ws.Cell(i + 1, j + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Font.FontName = "ＭＳ Ｐゴシック";
                            ws.Cell(i + 1, j + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);

                        }

                    }

                    wb.SaveAs(filename);
                    main_form.Invoke(__write_log, "保存に成功しました。（" + filename + "）");
                }
            }
            catch (Exception ex)
            {
                main_form.Invoke(__write_log, "【エラー】" + ex.Message);
                return;
            }



        }

        //作業割り当て表Excelファイル出力
        public void save_asignlist_xlsx_as(List<List<string>> data, List<string> categories, string filename)
        {
            _write_log __write_log = write_log;

            try
            {
                using (var wb = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Sheet1");

                    //行のループ
                    for (int i = 0; i < data.Count; i++)
                    {
                        List<string> row = (List<string>)data[i];

                        //列のループ
                        for (int j = 0; j < row.Count; j++)
                        {
                            string col = (string)row[j];
                            ws.Cell(i + 1, j + 1).SetValue<string>(fetch_overflow_characters(col));
                            ws.Cell(i + 1, j + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Font.FontName = "ＭＳ Ｐゴシック";
                            ws.Cell(i + 1, j + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);

                        }

                        if(i == 0)
                        {
                            int maxcol = row.Count;
                            for(int z=0; z<categories.Count; z++)
                            {
                                ws.Cell(i + 1, maxcol + (z + 1)).SetValue<string>((string)categories[z]);
                                ws.Cell(i + 1, maxcol + (z + 1)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                ws.Cell(i + 1, maxcol + (z + 1)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                                ws.Cell(i + 1, maxcol + (z + 1)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                ws.Cell(i + 1, maxcol + (z + 1)).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                                ws.Cell(i + 1, maxcol + (z + 1)).Style.Font.FontName = "ＭＳ Ｐゴシック";
                                ws.Cell(i + 1, maxcol + (z + 1)).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
                                ws.Cell(i + 1, maxcol + (z + 1)).Style.Alignment.TopToBottom = true;


                            }
                        }

                    }

                    wb.SaveAs(filename);
                    main_form.Invoke(__write_log, "保存に成功しました。（" + filename + "）");
                }
            }
            catch (Exception ex)
            {
                main_form.Invoke(__write_log, "【エラー】" + ex.Message);
                return;
            }
        }

        //カテゴリ別検査項目一覧表Excelファイル作成
        public void save_category_by_details_xlsx(List<List<object>> data, string filename)
        {
            _write_log __write_log = write_log;

            try
            {
                using(var wb = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("検査項目一覧");

                    //ヘッダー行
                    ws.Cell(1, 1).SetValue<string>("カテゴリ");
                    ws.Cell(1, 2).SetValue<string>("項番");
                    ws.Cell(1, 3).SetValue<string>("検査内容");
                    ws.Cell(1, 4).SetValue<string>("レベル/達成基準/実装番号");
                    double[] col_wd = { 15, 5, 91.9, 68 };
                    for(int cx=1; cx<=4; cx++)
                    {
                        ws.Cell(1, cx).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, cx).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, cx).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, cx).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(1, cx).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
                        ws.Cell(1, cx).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        ws.Cell(1, cx).Style.Font.Bold = true;
                        ws.Column(cx).Width = col_wd[cx - 1];
                    }

                    for (int i=0; i<data.Count; i++)
                    {
                        var row = data[i];
                        string v0 = (string)row[0];
                        string v1 = (string)row[1];
                        string v2 = (string)row[2];
                        string v3 = "";
                        List<string> gs = (List<string>)row[3];
                        int nx = 0;

                        ws.Cell(i + 2, 1).SetValue<string>(v0);
                        ws.Cell(i + 2, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);

                        ws.Cell(i + 2, 2).SetValue<string>(v1);
                        ws.Cell(i + 2, 2).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 2).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);

                        ws.Cell(i + 2, 3).SetValue<string>(v2);
                        ws.Cell(i + 2, 3).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 3).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
                        ws.Cell(i + 2, 3).Style.Alignment.WrapText = true;
                        foreach (string tx in gs)
                        {
                            v3 += tx;
                            if (nx != (gs.Count - 1)) v3 += "\r\n";
                            nx++;
                        }
                        ws.Cell(i + 2, 4).SetValue<string>(v3);
                        ws.Cell(i + 2, 4).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 4).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        ws.Cell(i + 2, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
                        ws.Cell(i + 2, 4).Style.Alignment.WrapText = true;
                    }

                    wb.SaveAs(filename);
                    main_form.Invoke(__write_log, "保存に成功しました。（" + filename + "）");
                }
            }
            catch(Exception ex)
            {
                main_form.Invoke(__write_log, "【エラー】" + ex.Message);
                return;
            }
        }

    }
}
