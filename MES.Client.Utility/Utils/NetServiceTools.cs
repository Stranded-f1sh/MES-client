using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils.PCB
{
    class NetServiceTools
    {
        public static bool InternetGetConnectedState()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var AppSettingsSection = config.AppSettings;
                    PingReply ret = ping.Send(System.Net.IPAddress.Parse("182.92.218.150"), 3000);//Ping百度，500毫秒超时

                    if (ret == null) return false;
                    //判断ping返回来的结果
                    return  ret.Status == IPStatus.Success;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
