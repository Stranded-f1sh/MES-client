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
        private StreamWriter LogFile = null;
        private static LogInfoHelper _instance = null;
        private string LogFilePath = null;


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
            if (null == _instance)
            {
                _instance = new LogInfoHelper();
            }
            return _instance;
        }


        public LogInfoHelper() { }


        /// <summary>
        /// 创建日志文件
        /// </summary>
        public void CreateLogFile()
        {
            string LogFilePath = AppDomain.CurrentDomain.BaseDirectory;
            string LogFileName = (DateTime.Now.Year).ToString() + '-' + (DateTime.Now.Month).ToString() + '-' + (DateTime.Now.Day).ToString() + "_Log.log";
            LogFilePath += "logFile\\";
            if (!Directory.Exists(LogFilePath))
            {
                Directory.CreateDirectory(LogFilePath);
            }
            this.LogFilePath = LogFilePath + LogFileName;
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
                            strlogInfo = String.Format("[{0}] FAIL:{1}", DateTime.Now.ToString(), strLogInfo);
                        }
                        break;

                    case LOG_TYPE.LOG_ERROR:
                        {
                            strlogInfo = String.Format("[{0}] ERROR:{1}", DateTime.Now.ToString(), strLogInfo);
                        }
                        break;

                    case LOG_TYPE.LOG_EXCEPTION:
                        {
                            strlogInfo = String.Format("[{0}] EXCEPTION:{1}", DateTime.Now.ToString(), strLogInfo);
                        }
                        break;

                    case LOG_TYPE.LOG_WARN:
                        {
                            strlogInfo = String.Format("[{0}] WARN:{1}", DateTime.Now.ToString(), strLogInfo);
                        }
                        break;

                    case LOG_TYPE.LOG_INFO:
                        {
                            strlogInfo = String.Format("[{0}] INFO:{1}", DateTime.Now.ToString(), strLogInfo);
                        }
                        break;
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
