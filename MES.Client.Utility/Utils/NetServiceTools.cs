using System;
using System.Collections.Generic;
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
                    PingReply ret = ping.Send(System.Net.IPAddress.Parse("47.97.117.253"), 3000);//Ping百度，500毫秒超时

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
