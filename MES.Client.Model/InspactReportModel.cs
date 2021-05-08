using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "InspactReportModel")]
    class InspactReportModel
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        [DataMember]
        public string DeviceName { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        [DataMember]
        public string DeviceType { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [DataMember]
        public String Imei { get; set; }

        /// <summary>
        /// 供电方式
        /// </summary>
        [DataMember]
        public String PowerSupplyMode { get; set; }

        /// <summary>
        /// 电池输出电压
        /// </summary>
        [DataMember]
        public String OutputVoltage { get; set; }

        /// <summary>
        /// 测量范围
        /// </summary>
        [DataMember]
        public String MeasureRange { get; set; }

        /// <summary>
        /// 精度等级
        /// </summary>
        [DataMember]
        public String AccuracyClass { get; set; }

        /// <summary>
        /// 最大允许误差
        /// </summary>
        [DataMember]
        public String MaxPermissibleError { get; set; }

        /// <summary>
        /// 最大过载压力
        /// </summary>
        [DataMember]
        public String MaxOverloadPressure { get; set; }

        /// <summary>
        /// 过程连接
        /// </summary>
        [DataMember]
        public String ProcessConnection { get; set; }

        /// <summary>
        /// 液晶显示屏
        /// </summary>
        [DataMember]
        public String LiquidCrystalDisplay { get; set; }

        /// <summary>
        /// 液晶显示屏备注
        /// </summary>
        [DataMember]
        public String LiquidCrystalDisplayNote { get; set; }

        /// <summary>
        /// 工作温度
        /// </summary>
        [DataMember]
        public String WorkTemperature { get; set; }

        /// <summary>
        /// 工作湿度
        /// </summary>
        [DataMember]
        public String WorkHumidity { get; set; }

        /// <summary>
        /// 工业时钟
        /// </summary>
        [DataMember]
        public String IndustrialClock { get; set; }

        /// <summary>
        /// 工作电流
        /// </summary>
        [DataMember]
        public String WorkCurrent { get; set; }

        /// <summary>
        /// 防护等级
        /// </summary>
        [DataMember]
        public String ProtectionLevel { get; set; }

        /// <summary>
        /// 防爆外壳材质
        /// </summary>
        [DataMember]
        public String FangBaoWaiKeCaiZhi { get; set; }

        /// <summary>
        /// 电缆防水接头材质
        /// </summary>
        [DataMember]
        public String DianLanFangShuiJieTouCaiZhi { get; set; }

        /// <summary>
        /// 天线材质
        /// </summary>
        [DataMember]
        public String TianXianCaiZhi { get; set; }

        /// <summary>
        /// 天线延长线材质
        /// </summary>
        [DataMember]
        public String TianXianYanChangXianCaiZhi { get; set; }

        /// <summary>
        /// 表前盖视窗材质
        /// </summary>
        [DataMember]
        public String BiaoQianGaiShiChuangCaiZhi { get; set; }

        /// <summary>
        /// 传感器外壳材质
        /// </summary>
        [DataMember]
        public String ChuanGanQiWaiKeCaiZhi { get; set; }

        /// <summary>
        /// 铭牌材质
        /// </summary>
        [DataMember]
        public String MingPaiCaiZhi { get; set; }

        /// <summary>
        /// 校验设备
        /// </summary>
        public String CheckEquipment { get; set; }

        /// <summary>
        /// 校验设备测量范围
        /// </summary>
        public String CheckEquipmentMeasureRange { get; set; }

        /// <summary>
        /// 校验设备精度
        /// </summary>
        public String CheckEquipmentAccuracy { get; set; }

        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public float Value4 { get; set; }
        public float Value5 { get; set; }
        public float Value6 { get; set; }
        public float Value7 { get; set; }
        public float Value8 { get; set; }
        public float Value9 { get; set; }
    }
}
