using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FastReport;


namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    class CodeScanHelper
    {
        public String CodeScanFilter(String code)
        {
            String[] wordsPart = code?.Split(';', ':', '；', '：', '，', ',');
            IEnumerator enumerator = wordsPart?.GetEnumerator();
            if (enumerator == null) return String.Empty;
            while (enumerator.MoveNext())
            {
                String wordsCell = enumerator.Current?.ToString();
                switch (wordsCell?.Length)
                {
                    case 15 when Regex.Match(wordsCell, @"\d{15}").Success:
                        return wordsCell;
                    case 15 when wordsCell.Substring(0, 3) == "835":
                        return wordsCell;
                    case 9 when Regex.Match(wordsCell, @"\d{9}").Success:
                        return wordsCell;
                    case 15 when wordsCell.Substring(0, 1) != "M":
                        return code;
                    case 16 when Regex.Match(wordsCell, @"^.{16}").Success:
                        return wordsCell;
                }
            }

            return null;
        }


        public void PrintQrCode(String code)
        {
            Report rep = new Report();
            string mainModuleFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;

        }
    }
}
