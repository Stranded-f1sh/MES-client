using System;
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
            using (PrinterContext db = new PrinterContext())
            {

                PrintSetting printSetting = new PrintSetting {PrinterName = "你大爷", HorizontalOffset = 12, VerticalOffset = 20};


                db.PrintSettings.Add(printSetting);
                //db.PrintSettings.SqlQuery("delete from PrintSettings");


                // context.Blogs.SqlQuery("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));

                Console.WriteLine(@"开始查询");
                // db.PrintSettings?.SqlQuery("drop table PrintSettings");
                // db.PrintSettings.Remove(printSetting);

                db.SaveChanges();

                var printers1 = db.PrintSettings?.SqlQuery("select PrinterName, PrintSettingId, HorizontalOffset, VerticalOffset from PrintSettings")?.ToList();




                foreach (var item in printers1)
                {
                    
                    Console.WriteLine(item.PrintSettingId);
                    Console.WriteLine(item.HorizontalOffset);
                    Console.WriteLine(item.VerticalOffset);
                    Console.WriteLine("==============");
                }


            }
        }
    }
}
