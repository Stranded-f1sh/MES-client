using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Enum
{
    public enum ProcessNameEnum
    {
        /// <summary>
        /// 备料
        /// </summary>
        MaterialPreparation = 1,
        /// <summary>
        /// 焊接
        /// </summary>
        Welding,
        /// <summary>
        /// 烧录配置
        /// </summary>
        BurnConfiguration,
        /// <summary>
        /// 编码注册
        /// </summary>
        CodeRegistration,
        /// <summary>
        /// 老化
        /// </summary>
        WornOut,
        /// <summary>
        /// 功耗
        /// </summary>
        PowerConsumption,
        /// <summary>
        /// 传感器校验
        /// </summary>
        SensorCalibration,
        /// <summary>
        /// 组装
        /// </summary>
        Assembly,
        /// <summary>
        /// 检验
        /// </summary>
        WarehouseInspection,
        /// <summary>
        /// 包装
        /// </summary>
        Pack,
        /// <summary>
        /// 入库
        /// </summary>
        Warehousing,
        /// <summary>
        /// 出库
        /// </summary>
        OutBound,
        /// <summary>
        /// 发货
        /// </summary>
        Ship,
        /// <summary>
        /// 维修
        /// </summary>
        Repair,
        /// <summary>
        /// 消防栓外壳
        /// </summary>
        FireHydrantShell,
        /// <summary>
        /// 成品检验
        /// </summary>
        OutboundInspection
    }
}