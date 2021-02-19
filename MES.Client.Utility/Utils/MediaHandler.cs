using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    class MediaHandler
    {
        /// <summary>
        /// 入库成功提示音
        /// </summary>
        public static void SyncPlayWAV_Succ()
        {
            SyncPlayWAV("入库成功");
        }

        /// <summary>
        /// 入库失败提示音
        /// </summary>
        public static void SyncPlayWAV_Fail()
        {
            SyncPlayWAV("入库失败");
        }


        public static void SyncPlayWAV(string status)
        {
            new Thread(() =>
            {
                string path1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                string exename = "ManufacturingExecutionSystem.exe";
                path1 = path1.Substring(0, path1.Length - exename.Length);
                path1 += (status + ".wav");
                try
                {
                    //创建一个SoundPlaryer类，并设置wav文件的路径
                    SoundPlayer sp = new SoundPlayer(path1);
                    //使用异步方式加载wav文件
                    sp.LoadAsync();
                    //使用同步方式播放wav文件
                    if (sp.IsLoadCompleted)
                    {
                        sp.PlaySync();
                    }
                }
                catch
                {

                }
            }).Start();
        }


    }
}
