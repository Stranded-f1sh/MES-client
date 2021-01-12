using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using FastReport;
using FastReport.Barcode;
using FastReport.Table;
using ManufacturingExecutionSystem.MES.Client.Mapper;
using ManufacturingExecutionSystem.MES.Client.Model;


namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    class CodeScanHelper
    {
        #region 扫码内容过滤器
        
        public String CodeScanFilter(String code, out String pinDian)
        {
            pinDian = String.Empty;
            String words = String.Empty;
            String[] wordsPart = code?.Split(';', ':', '；', '：', '，', ',');
            IEnumerator enumerator = wordsPart?.GetEnumerator();
            if (enumerator == null) return String.Empty;
            while (enumerator.MoveNext())
            {
                String wordsCell = enumerator.Current?.ToString();
                switch (wordsCell?.Length)
                {
                    case 15 when Regex.Match(wordsCell, @"\d{15}").Success:
                        words = wordsCell;
                        return words;
                    case 15 when wordsCell.Substring(0, 3) == "835":
                        words = wordsCell;
                        break;
                    case 9 when Regex.Match(wordsCell, @"\d{9}").Success:
                        pinDian = wordsCell;
                        break;
                    case 15 when wordsCell.Substring(0, 1) != "M":
                        return code;
                    case 16 when Regex.Match(wordsCell, @"^.{16}").Success:
                        words = wordsCell;
                        break;
                }
            }

            return words;
        }
        
        #endregion


        #region QRCode打印
        
        public void PrintQrCode(Device device, String frxModelName)
        {
            if (device == null) return;
            Report rep = new Report();
            String mainModuleFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
            String exeName = "ManufacturingExecutionSystem.exe";
            mainModuleFileName = mainModuleFileName?.Substring(0, mainModuleFileName.Length - exeName.Length);
            mainModuleFileName += frxModelName;
            rep.Load(mainModuleFileName);
            if (rep.FindObject("Text1") is TextObject textObject)
            {
                textObject.Text = device.Imei;
            }
            
            if (rep.FindObject("Text2") is TextObject textObject1)
            {
                textObject1.Text = device.PinDian;
            }
            
            if (rep.FindObject("Barcode42") is BarcodeObject barcodeObject)
            {
                barcodeObject.Text = device.Imei;
                barcodeObject.Barcode = new BarcodeQR();
            }
            
            PrinterMapper printerMapper = new PrinterMapper();
            printerMapper.CreateTableIfNotExist();
            DataSet selectPrinters = printerMapper.SelectPrinters();

            foreach (DataRow dr in selectPrinters.Tables[0].Rows)
            {
                rep.PrintSettings.Printer = dr[1].ToString();
                rep.PrintSettings.ShowDialog = false;
                if (rep.FindObject("Page1") is ReportPage reportPage)
                {
                    // 右偏移
                    reportPage.LeftMargin = int.Parse(dr[2].ToString());
                    // 下偏移
                    reportPage.TopMargin = int.Parse(dr[3].ToString());
                }
                rep.Print();
                return;
            }
        }

        #endregion


        #region 小箱单打印

        
        public void PrintSmallPackList(Device device, SaleOrder saleOrder,  String frxModelName)
        {
            if (device == null) return;
            if (saleOrder == null) return;

            Report rep = new Report();
            String mainModuleFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
            String exeName = "ManufacturingExecutionSystem.exe";
            mainModuleFileName = mainModuleFileName?.Substring(0, mainModuleFileName.Length - exeName.Length);
            mainModuleFileName += frxModelName;
            rep.Load(mainModuleFileName);

            // 设备名称
            if (rep.FindObject("Cell2") is TableCell tableCell1)
            {
                tableCell1.Text = saleOrder.CustomerDeviceName;
                if (saleOrder.CustomerDeviceName?.Length <= 11)
                {
                    tableCell1.FontWidthRatio = 1.0F;
                }
                else if (saleOrder.CustomerDeviceName?.Length <= 15 && saleOrder.CustomerDeviceName.Length > 11)
                {
                    tableCell1.FontWidthRatio = 0.8F;
                }
                else if (saleOrder.CustomerDeviceName?.Length <= 19 && saleOrder.CustomerDeviceName.Length > 16)
                {
                    tableCell1.FontWidthRatio = 0.6F;
                }
            }

            // 设备型号
            if (rep.FindObject("Cell7") is TableCell tableCell2)
            {
                tableCell2.Text = saleOrder.CustomerDeviceModel;
            }

            // 设备编码
            if (rep.FindObject("Barcode1") is BarcodeObject barcodeObject)
            {
                barcodeObject.Text = device.Imei;
                barcodeObject.Barcode = new BarcodeQR();
            }

            if (rep.FindObject("Text5") is TextObject textObject4)
            {
                textObject4.Text = device.Imei;
            }


            // 设备量程
            if (rep.FindObject("Text6") is TextObject textObject1)
            {
                textObject1.Text = saleOrder.DefaultConfig;
            }

            // 设备箱单
            if (rep.FindObject("Text4") is TextObject textObject2)
            {
                textObject2.Text = "设备箱单";
            }

            // 设备数量
            if (rep.FindObject("Text2") is TextObject textObject3)
            {
                textObject3.Text = "1";
            }

            PrinterMapper printerMapper = new PrinterMapper();
            printerMapper.CreateTableIfNotExist();
            DataSet selectPrinters = printerMapper.SelectPrinters();

            foreach (DataRow dr in selectPrinters.Tables[0].Rows)
            {
                rep.PrintSettings.Printer = dr[1].ToString();
                rep.PrintSettings.ShowDialog = false;
                if (rep.FindObject("Page1") is ReportPage reportPage)
                {
                    // 右偏移
                    reportPage.LeftMargin = int.Parse(dr[2].ToString());
                    // 下偏移
                    reportPage.TopMargin = int.Parse(dr[3].ToString());
                }
                rep.Print();
                return;
            }
        }


        #endregion
    }
}
