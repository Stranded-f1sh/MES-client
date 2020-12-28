using System;
using System.Threading;
using System.Windows.Forms;
using ManufacturingExecutionSystem.MES.Client.UI;

namespace ManufacturingExecutionSystem
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Thread.Sleep(1000);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
