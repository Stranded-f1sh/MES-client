using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.Model;
using System.Data.SQLite;
using System.Drawing.Printing;
using ManufacturingExecutionSystem.MES.Client.Mapper;


namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class PrinterSettingsForm : Form
    {
        public PrinterSettingsForm()
        {
            InitializeComponent();
        }

        private void PrinterSettingsForm_Load(object sender, EventArgs e)
        {
            PrinterMapper printerMapper = new PrinterMapper();

            printerMapper.CreateTableIfNotExist();

            DataSet selectPrinters = printerMapper.SelectPrinters();

            foreach (DataRow dr in selectPrinters.Tables[0].Rows)
            {
                PrinterName_ComboBox.Items.Add(dr[1]);
                HorizontalOffset_TextBox.Text = dr[2].ToString();
                VerticalOffset_TextBox.Text = dr[3].ToString();
                foreach (string sPrint in PrinterSettings.InstalledPrinters)
                {
                    if (sPrint != dr[1].ToString())
                    {
                        PrinterName_ComboBox.Items.Add(sPrint ?? String.Empty);
                    }
                    else
                    {
                        PrinterName_ComboBox.SelectedIndex = PrinterName_ComboBox.Items.IndexOf(sPrint);
                    }
                }
                break;
            }
        }



        private void PrinterName_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
/*            Console.WriteLine(PrinterName_ComboBox.SelectedIndex);
            PrinterMapper printerMapper = new PrinterMapper();
            printerMapper.SelectByPrinterId(new PrintSetting {PrintSettingId = PrinterName_ComboBox.SelectedIndex});*/
        }



        private void Submit_btn_Click(object sender, EventArgs e)
        {
            PrinterMapper printerMapper = new PrinterMapper();
            PrintSetting printSetting = new PrintSetting
            {
                PrintSettingId = 0,
                PrinterName = PrinterName_ComboBox.Text,
                HorizontalOffset = int.Parse(HorizontalOffset_TextBox.Text),
                VerticalOffset = int.Parse(VerticalOffset_TextBox.Text)
            };
            printerMapper.CreateTableIfNotExist();
            printerMapper.UpdatePrintSettingById(printSetting);
            this.Close();
        }
    }
}
