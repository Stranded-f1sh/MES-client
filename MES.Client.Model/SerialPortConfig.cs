using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "SerialPortConfig")]
    public class SerialPortConfig
    {
        [DataMember]
        [Description("端口号")]
        public String PortName { get; set; } // 端口号

        [DataMember]
        [Description("波特率")]
        public int BaudRate { get; set; } // 波特率

        [DataMember]
        [Description("数据位")]
        public int DataBits { get; set; } // 数据位

        [DataMember]
        [Description("超时时间")]
        public int ReadTimeout { get; set; } // 超时时间

        [DataMember]
        [Description("写缓存大小")]
        public int WriteBufferSize { get; set; } // 写缓存大小

        [DataMember]
        [Description("读缓存大小")]
        public int ReadBufferSize { get; set; } // 读缓存大小

        [DataMember]
        [Description("停止位")]
        public StopBits StopBits { get; set; } // 停止位

        [DataMember]
        [Description("校验位")]
        public Parity Parity { get; set; } // 校验位

        [DataMember]
        [Description("缓冲字节")]
        public int ReceivedBytesThreshold { get; set; } // 缓冲字节
    }
}
