using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Enum
{
    class LogInfoEnum
    {
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
    }
}
