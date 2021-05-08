using System;
using System.Collections.Generic;
using System.Globalization;
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
        private StreamWriter LogFile;
        private static LogInfoHelper _instance;
        private string LogFilePath;


        /// <summary>
        /// 日志类型
        /// </summary>
        public enum LOG_TYPE
        {
            LOG_FAIL = 0,    //致命错误
            LOG_ERROR,       //一般错误
            LOG_EXCEPTION,   //异常
            LOG_WARN,        //警告
            LOG_INFO,        //一般信息
        }


        public static LogInfoHelper GetInstence()
        {
            return _instance ?? (_instance = new LogInfoHelper());
        }
        

        /// <summary>
        /// 创建日志文件
        /// </summary>
        public void CreateLogFile()
        {
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory;
            string LogFileName = (DateTime.Now.Year).ToString() + '-' + (DateTime.Now.Month) + '-' + (DateTime.Now.Day) + "_Log.log";
            logFilePath += "logFile\\";
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            this.LogFilePath = logFilePath + LogFileName;
        }



        /// <summary>
        /// 信息写入日志
        /// </summary>
        /// <param name="strLogInfo"></param>
        /// <param name="logType"></param>
        public void WriteInfoToLogFile(string strLogInfo, LOG_TYPE logType)
        {
            try
            {
                LogFile = new StreamWriter(LogFilePath, true);
                string strlogInfo = null;
                switch (logType)
                {
                    case LOG_TYPE.LOG_FAIL:
                        {
                            strlogInfo = $"[{DateTime.Now.ToString(CultureInfo.InvariantCulture)}] FAIL:{strLogInfo}";
                        }
                        break;

                    case LOG_TYPE.LOG_ERROR:
                        {
                            strlogInfo = $"[{DateTime.Now.ToString(CultureInfo.InvariantCulture)}] ERROR:{strLogInfo}";
                        }
                        break;

                    case LOG_TYPE.LOG_EXCEPTION:
                        {
                            strlogInfo = $"[{DateTime.Now.ToString(CultureInfo.InvariantCulture)}] EXCEPTION:{strLogInfo}";
                        }
                        break;

                    case LOG_TYPE.LOG_WARN:
                        {
                            strlogInfo = $"[{DateTime.Now.ToString(CultureInfo.InvariantCulture)}] WARN:{strLogInfo}";
                        }
                        break;

                    case LOG_TYPE.LOG_INFO:
                        {
                            strlogInfo = $"[{DateTime.Now.ToString(CultureInfo.InvariantCulture)}] INFO:{strLogInfo}";
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
                }
                LogFile.WriteLine(strlogInfo);
                LogFile.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        public void printLog(string strLogInfo, LOG_TYPE logType)
        {
            GetInstence();
            CreateLogFile();
            WriteInfoToLogFile(strLogInfo, logType);
        }
    }
}
