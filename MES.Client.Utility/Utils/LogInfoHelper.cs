using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.UI;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    class LogInfoHelper
    {
        private static LogInfoHelper _instance;

        private static LogInfoHelper GetInstance()
        {
            if (null == _instance)
            {
                _instance = new LogInfoHelper();
            }
            return _instance;
        }


        private LogInfoHelper() { }


        /// <summary>
        /// 数据转换
        /// </summary>
        /// <param name="str"></param>
        /// <param name="logType"></param>
        private static string StrTrans(string str, LogInfoEnum.LOG_TYPE logType)
        {
            try
            {
                string strLogInfo = null;
                switch (logType)
                {
                    case LogInfoEnum.LOG_TYPE.LOG_FAIL:
                    {
                        strLogInfo = $"[{DateTime.Now}] FAIL:{str}";
                    }
                        break;

                    case LogInfoEnum.LOG_TYPE.LOG_ERROR:
                    {
                        strLogInfo = $"[{DateTime.Now}] ERROR:{str}";
                    }
                        break;

                    case LogInfoEnum.LOG_TYPE.LOG_EXCEPTION:
                    {
                        strLogInfo = $"[{DateTime.Now}] EXCEPTION:{str}";
                    }
                        break;

                    case LogInfoEnum.LOG_TYPE.LOG_WARN:
                    {
                        strLogInfo = $"[{DateTime.Now}] WARN:{str}";
                    }
                        break;

                    case LogInfoEnum.LOG_TYPE.LOG_INFO:
                    {
                        strLogInfo = $"[{DateTime.Now}] INFO:{str}";
                    }
                        break;
                }

                return strLogInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static String PrintLog(string strLogInfo, LogInfoEnum.LOG_TYPE logType)
        {
            GetInstance();
            
            return StrTrans(strLogInfo, logType);
        }
    }
}
