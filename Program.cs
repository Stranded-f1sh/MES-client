using System;
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
            DateTime dsad;
            // Console.WriteLine(dsad);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }


        public static bool TimeTest(DateTime lastTime)
        {
            DateTime nowTime = DateTime.Now;
            if (lastTime == null)
            {
                return true;
            }

            if (nowTime.Subtract(lastTime).TotalSeconds > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
