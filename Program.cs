using System;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.UI;

namespace ManufacturingExecutionSystem
{
    internal static class Program
    {

        // X00
        public static readonly byte[] X00Input = { 0x01, 0x02, 0x00, 0x00, 0x00, 0x20, 0x79, 0xD2 };


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main(String[] args)
        {

            /*            Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new LoginForm());*/
        }
    }
}
