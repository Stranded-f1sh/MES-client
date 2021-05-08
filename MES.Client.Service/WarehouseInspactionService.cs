using FastReport;
using FastReport.Table;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Mapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    public class WarehouseInspactionService
    {
        public JToken DataUpon(LoginInfo _loginInfo, WareHouseInspactValueCacheMapper mapper)
        {
            ProductOrderService productOrderService = new ProductOrderService();

            BaoGongService baoGongService = new BaoGongService();

            DataSet ds1 = mapper.GroupByImei();

            InspactResult inspactResult = null;

            foreach (DataRow i in ds1.Tables[0].Rows)
            {
                float[] arr = new float[9];
                DataSet ds2 = mapper.GetValueByImei(i[0].ToString());
                foreach (DataRow d in ds2.Tables[0].Rows)
                {
                    switch (int.Parse(d[1].ToString()))
                    {
                        case 1:
                            arr[0] = float.Parse(d[0].ToString());
                            break;
                        case 2:
                            arr[1] = float.Parse(d[0].ToString());
                            break;
                        case 3:
                            arr[2] = float.Parse(d[0].ToString());
                            break;
                        case 4:
                            arr[3] = float.Parse(d[0].ToString());
                            break;
                        case 5:
                            arr[4] = float.Parse(d[0].ToString());
                            break;
                        case 6:
                            arr[5] = float.Parse(d[0].ToString());
                            break;
                        case 7:
                            arr[6] = float.Parse(d[0].ToString());
                            break;
                        case 8:
                            arr[7] = float.Parse(d[0].ToString());
                            break;
                        case 9:
                            arr[8] = float.Parse(d[0].ToString());
                            break;
                    }
                }

                inspactResult = new InspactResult
                {
                    imei = i[0].ToString(),
                    value1 = arr[0],
                    value2 = arr[1],
                    value3 = arr[2],
                    value4 = arr[3],
                    value5 = arr[4],
                    value6 = arr[5],
                    value7 = arr[6],
                    value8 = arr[7],
                    value9 = arr[8],
                    updatetime = DateTime.Now.AddHours(-8).ToString("yyyy-MM-dd'T'HH:mm:ss.sssZ")
                };

                // 调用接口
                var ret = WareHouseInspactApi.InspactResultUponApi(_loginInfo, inspactResult);
                JToken baogongRet = baoGongService.DeviceBaoGong(_loginInfo, i[0].ToString(), Utility.Enum.ProcessNameEnum.WarehouseInspection, DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"));
                if ("ok" == ret["data"]?.ToString())
                {
                    mapper.CommitData(i[0].ToString());
                }
            }
            var OrderIdRet = productOrderService.FindProductOrderIdByImei(_loginInfo, inspactResult.imei);
            var valueRet = WareHouseInspactApi.FindValueByOrderIdApi(_loginInfo, int.Parse(OrderIdRet.ToString()));
            return MyJsonConverter.GetJToken(valueRet);
        }

        public String GetSpecialValue(JToken inputValue, string childItem)
        {
            JObject JObj = (JObject)JsonConvert.DeserializeObject(inputValue.ToString());
            var res = JObj.SelectToken(childItem + ".defaultConfig");

            if (JObj.SelectToken(childItem+".special").ToString() == String.Empty)
            {
                return JObj.SelectToken(childItem+".defaultConfig").ToString();
            }
            return JObj.SelectToken(childItem + ".special").ToString();
        }

        public String GetWorkCurrent(String DeviceType, String deviceProtocol)
        {
            if (DeviceType == "TSM-01P")
            {
                if (deviceProtocol == "new")
                {
                    // TSM-01P(ble)
                    return "低功耗电流<40uA,发送平均电流60mA";
                }
                else
                {
                    return "低功耗电流<40uA,发送平均电流60mA";
                }
            }else if (DeviceType == "TSM-04P")
            {
                if (deviceProtocol == "new")
                {
                    return "低功耗电流<45uA,发送平均电流60mA";
                }
                else
                {
                    return "低功耗电流<45uA,发送平均电流60mA";
                }
            }else if (DeviceType == "TSM-01L")
            {
                if (deviceProtocol == "new")
                {
                    return "低功耗电流<40uA,发送平均电流60mA";
                }
                else
                {
                    return "低功耗电流<40uA,发送平均电流60mA";
                }
            }else if (DeviceType == "TSM-04L")
            {
                if (deviceProtocol == "new")
                {
                    return "低功耗电流<45uA,上报平均电流60mA";
                }
                else
                {
                    return "低功耗电流<45uA,上报平均电流60mA";
                }
            }else if (DeviceType == "TSM-01H")
            {
                if (deviceProtocol == "new")
                {
                    return "低功耗电流<80uA,发送平均电流60mA";
                }
                else
                {
                    return "低功耗电流<80uA,发送平均电流60mA";
                }
            }
            return String.Empty;
        }


        public void ReportGenerate(LoginInfo _loginInfo, String deviceImei)
        {
            JObject valueRet = WareHouseInspactApi.FindValueByImeiApi(_loginInfo, deviceImei);
            JToken jt = MyJsonConverter.GetJToken(valueRet);
            var ret = jt.GroupBy(x => x["imei"].ToString());
            JToken item = null;
            foreach (var items in ret)
            {
                item = items.OrderBy(x => x["updatetime"]).Reverse().First();
            }

            Report rep = new Report();
            rep.Load("C:\\Users\\Jinyu\\Desktop\\Report.frx");

            

            // 在确定IMEI号后 设备名称、型号、测量范围（量程）、精度等级、过程连接、防护等级 可通过订单关联
            JObject productOrderObj = ProductOrderApi.GetProductOrderInfoApi(_loginInfo, int.Parse(item.SelectToken("orderId").ToString()));
            JToken productOrder = MyJsonConverter.GetJTokenList(productOrderObj);
            string saleOrderid = productOrder.First.SelectToken("saleOrderid").ToString();
            JObject saleOrderinfoObj = SaleOrderApi.GetSaleOrderInfoApi(_loginInfo, saleOrderid);
            JToken saleOrderinfo = MyJsonConverter.GetJTokenList(saleOrderinfoObj);

            // ****************************************************************************************************
            InspactReportModel model = new InspactReportModel();
            model.DeviceName = saleOrderinfo.First.SelectToken("customerDeviceName").ToString();
            model.DeviceType = saleOrderinfo.First.SelectToken("customerDeviceModel").ToString();
            model.Imei = deviceImei;
            model.PowerSupplyMode = "锂亚电池供电";
            model.OutputVoltage = "3.6V（直流）";
            model.MeasureRange = GetSpecialValue(saleOrderinfo.First.SelectToken("orderDetail"), "range");
            model.AccuracyClass = "±"+ GetSpecialValue(saleOrderinfo.First.SelectToken("orderDetail"), "precision") + "%F·S";
            model.MaxPermissibleError = double.Parse(model.MeasureRange.Substring(2, 3)) * double.Parse(GetSpecialValue(saleOrderinfo.First.SelectToken("orderDetail"), "precision")) + model.MeasureRange.Substring(5, 3);
            model.MaxOverloadPressure = double.Parse(model.MeasureRange.Substring(2, 3)) * 2 + model.MeasureRange.Substring(5, 3);
            model.ProcessConnection = GetSpecialValue(saleOrderinfo.First.SelectToken("orderDetail"), "processConnection");
            model.LiquidCrystalDisplay = "7位断码液晶动态显示";
            model.LiquidCrystalDisplayNote = "显示信号强度、电池电量、校准过程、联网过程及数据发送过程";
            model.WorkTemperature = "-20~70℃";
            model.WorkHumidity = "<93%RH";
            model.IndustrialClock = "内置工业时钟，自动校时";
            model.WorkCurrent = GetWorkCurrent(saleOrderinfo.First.SelectToken("deviceModel").ToString(), saleOrderinfo.First.SelectToken("deviceProtocol").ToString());
            model.ProtectionLevel = GetSpecialValue(saleOrderinfo.First.SelectToken("orderDetail"), "protectionClass");
            model.FangBaoWaiKeCaiZhi = "铝合金";
            model.DianLanFangShuiJieTouCaiZhi = "PA尼龙";
            model.TianXianCaiZhi = "铜";
            model.TianXianYanChangXianCaiZhi = "RG174纯铜线";
            model.ChuanGanQiWaiKeCaiZhi = "304不锈钢";
            model.MingPaiCaiZhi = "304不锈钢";
            model.CheckEquipment = "压力天平";
            model.CheckEquipmentMeasureRange = "0-6MPa";
            model.CheckEquipmentAccuracy = "±0.05%F·S";
            model.Value1 = (float)item.SelectToken("value1");
            model.Value2 = (float)item.SelectToken("value2");
            model.Value3 = (float)item.SelectToken("value3");
            model.Value4 = (float)item.SelectToken("value4");
            model.Value5 = (float)item.SelectToken("value5");
            model.Value6 = (float)item.SelectToken("value6");
            model.Value7 = (float)item.SelectToken("value7");
            model.Value8 = (float)item.SelectToken("value8");
            model.Value9 = (float)item.SelectToken("value9");




            // ****************************************************************************************************


            //saleOrderinfo.First.SelectToken("")

            //  客户设备名称
            if (rep.FindObject("TableCell1_2") is TableCell TableCell1_2)
            {
                TableCell1_2.Text = model.DeviceName ?? String.Empty;
            }   

            // 客户设备型号
            if (rep.FindObject("TableCell1_4") is TableCell TableCell1_4)
            {
                TableCell1_4.Text = model.DeviceType ?? String.Empty;
            }

            // 设备号
            if (rep.FindObject("TableCell1_6") is TableCell TableCell1_6)
            {
                TableCell1_6.Text = model.Imei ?? String.Empty;
            }

            // 供电方式
            if (rep.FindObject("TableCell4_2") is TableCell TableCell4_2)
            {
                TableCell4_2.Text = model.PowerSupplyMode ?? String.Empty;
            }

            // 电池输出电压
            if (rep.FindObject("TableCell5_2") is TableCell TableCell5_2)
            {
                TableCell5_2.Text = model.OutputVoltage ?? String.Empty;
            }

            // 测量范围
            if (rep.FindObject("TableCell6_2") is TableCell TableCell6_2)
            {
                TableCell6_2.Text = model.MeasureRange ?? String.Empty;
            }

            // 精度等级
            if (rep.FindObject("TableCell7_2") is TableCell TableCell7_2)
            {
                TableCell7_2.Text = model.AccuracyClass ?? String.Empty;
            }

            // 最大允许误差
            if (rep.FindObject("TableCell8_2") is TableCell TableCell8_2)
            {
                TableCell8_2.Text = model.MaxPermissibleError ?? String.Empty;
            }

            // 最大过载压力
            if (rep.FindObject("TableCell9_2") is TableCell TableCell9_2)
            {
                TableCell9_2.Text = model.MaxOverloadPressure ?? String.Empty;
            }

            // 过程连接
            if (rep.FindObject("TableCell10_2") is TableCell TableCell10_2)
            {
                TableCell10_2.Text = model.ProcessConnection ?? String.Empty;
            }

            // 液晶显示屏
            if (rep.FindObject("TableCell11_2") is TableCell TableCell11_2)
            {
                TableCell11_2.Text = model.LiquidCrystalDisplay ?? String.Empty;
            }

            // 液晶显示屏备注
            if (rep.FindObject("TableCell11_3") is TableCell TableCell11_3)
            {
                TableCell11_3.Text = model.LiquidCrystalDisplayNote ?? String.Empty;
            }

            // 工作温度
            if (rep.FindObject("TableCell12_2") is TableCell TableCell12_2)
            {
                TableCell12_2.Text = model.WorkTemperature ?? String.Empty;
            }

            // 工作湿度
            if (rep.FindObject("TableCell13_2") is TableCell TableCell13_2)
            {
                TableCell13_2.Text = model.WorkHumidity ?? String.Empty;
            }

            // 工业时钟
            if (rep.FindObject("TableCell14_2") is TableCell TableCell14_2)
            {
                TableCell14_2.Text = model.IndustrialClock ?? String.Empty;
            }

            // 工作电流
            if (rep.FindObject("TableCell15_2") is TableCell TableCell15_2)
            {
                TableCell15_2.Text = model.WorkCurrent ?? String.Empty;
            }

            // 防护等级
            if (rep.FindObject("TableCell16_2") is TableCell TableCell16_2)
            {
                TableCell16_2.Text = model.ProtectionLevel ?? String.Empty;
            }

            // 防爆外壳材质
            if (rep.FindObject("TableCell19_2") is TableCell TableCell19_2)
            {
                TableCell19_2.Text = model.FangBaoWaiKeCaiZhi ?? String.Empty;
            }

            // 电缆防水接头材质
            if (rep.FindObject("TableCell19_3") is TableCell TableCell19_3)
            {
                TableCell19_3.Text = model.DianLanFangShuiJieTouCaiZhi ?? String.Empty;
            }

            // 天线材质
            if (rep.FindObject("TableCell19_4") is TableCell TableCell19_4)
            {
                TableCell19_4.Text = model.TianXianCaiZhi ?? String.Empty;
            }

            // 天线延长线材质
            if (rep.FindObject("TableCell19_5") is TableCell TableCell19_5)
            {
                TableCell19_5.Text = model.TianXianYanChangXianCaiZhi ?? String.Empty;
            }

            // 表前盖视窗材质
            if (rep.FindObject("TableCell19_6") is TableCell TableCell19_6)
            {
                TableCell19_6.Text = model.BiaoQianGaiShiChuangCaiZhi ?? String.Empty;
            }

            // 传感器外壳材质
            if (rep.FindObject("TableCell19_7") is TableCell TableCell19_7)
            {
                TableCell19_7.Text = model.ChuanGanQiWaiKeCaiZhi ?? String.Empty;
            }

            // 铭牌材质
            if (rep.FindObject("TableCell19_8") is TableCell TableCell19_8)
            {
                TableCell19_8.Text = model.MingPaiCaiZhi ?? String.Empty;
            }

            // 校验设备
            if (rep.FindObject("TableCell21_2") is TableCell TableCell21_2)
            {
                TableCell21_2.Text = model.CheckEquipment ?? String.Empty;
            }

            // 校验设备测量范围
            if (rep.FindObject("TableCell21_4") is TableCell TableCell21_4)
            {
                TableCell21_4.Text = model.CheckEquipmentMeasureRange ?? String.Empty;
            }

            // 校验设备精度
            if (rep.FindObject("TableCell21_6") is TableCell TableCell21_6)
            {
                TableCell21_6.Text = model.CheckEquipmentAccuracy ?? String.Empty;
            }

            // 被检设备
            if (rep.FindObject("TableCell22_2") is TableCell TableCell22_2)
            {
                TableCell22_2.Text = model.DeviceType ?? String.Empty;
            }

            // 被检设备测量范围
            if (rep.FindObject("TableCell22_4") is TableCell TableCell22_4)
            {
                TableCell22_4.Text = model.MeasureRange ?? String.Empty;
            }

            // 被检设备精度等级
            if (rep.FindObject("TableCell22_6") is TableCell TableCell22_6)
            {
                TableCell22_6.Text = model.AccuracyClass ?? String.Empty;
            }

            // 被检设备最大允许误差
            if (rep.FindObject("TableCell22_8") is TableCell TableCell22_8)
            {
                TableCell22_8.Text = model.MaxPermissibleError ?? String.Empty;
            }

            // 上行程0.5
            if (rep.FindObject("TableCell25_3") is TableCell TableCell25_3)
            {
                TableCell25_3.Text = model.Value1.ToString() ?? String.Empty;
            }

            // 上行程1.0
            if (rep.FindObject("TableCell25_4") is TableCell TableCell25_4)
            {
                TableCell25_4.Text = model.Value2.ToString() ?? String.Empty;
            }

            // 上行程1.5
            if (rep.FindObject("TableCell25_5") is TableCell TableCell25_5)
            {
                TableCell25_5.Text = model.Value3.ToString() ?? String.Empty;
            }
            // 上行程2.0
            if (rep.FindObject("TableCell25_6") is TableCell TableCell25_6)
            {
                TableCell25_6.Text = model.Value4.ToString() ?? String.Empty;
            }

            // 上行程2.5
            if (rep.FindObject("TableCell25_7") is TableCell TableCell25_7)
            {
                TableCell25_7.Text = model.Value5.ToString() ?? String.Empty;
            }

            // 下行程2.0
            if (rep.FindObject("TableCell26_6") is TableCell TableCell26_6)
            {
                TableCell26_6.Text = model.Value6.ToString() ?? String.Empty;
            }


            // 下行程1.5
            if (rep.FindObject("TableCell26_5") is TableCell TableCell26_5)
            {
                TableCell26_5.Text = model.Value7.ToString() ?? String.Empty;
            }

            // 下行程1.0
            if (rep.FindObject("TableCell26_4") is TableCell TableCell26_4)
            {
                TableCell26_4.Text = model.Value8.ToString() ?? String.Empty;
            }

            // 下行程0.5
            if (rep.FindObject("TableCell26_3") is TableCell TableCell26_3)
            {
                TableCell26_3.Text = model.Value9.ToString() ?? String.Empty;
            }

            // 回程误差0.5
            if (rep.FindObject("TableCell27_3") is TableCell TableCell27_3)
            {
                TableCell27_3.Text = Math.Abs(model.Value1 - model.Value9).ToString("0.0000");
            }

            // 回程误差1.0
            if (rep.FindObject("TableCell27_4") is TableCell TableCell27_4)
            {
                TableCell27_4.Text = Math.Abs(model.Value2 - model.Value8).ToString("0.0000");
            }

            // 回程误差1.5
            if (rep.FindObject("TableCell27_5") is TableCell TableCell27_5)
            {
                TableCell27_5.Text = Math.Abs(model.Value3 - model.Value7).ToString("0.0000");
            }

            // 回程误差2.0
            if (rep.FindObject("TableCell27_6") is TableCell TableCell27_6)
            {
                TableCell27_6.Text = Math.Abs(model.Value4 - model.Value6).ToString("0.0000");
            }

            // 上行基本误差0.5
            if (rep.FindObject("TableCell28_3") is TableCell TableCell28_3)
            {
                TableCell28_3.Text = (model.Value1 - 0.5000).ToString("0.0000");
            }

            // 上行基本误差1.0
            if (rep.FindObject("TableCell28_4") is TableCell TableCell28_4)
            {
                TableCell28_4.Text = (model.Value2 - 1.0000).ToString("0.0000");
            }

            // 上行基本误差1.5
            if (rep.FindObject("TableCell28_5") is TableCell TableCell28_5)
            {
                TableCell28_5.Text = (model.Value3 - 1.5000).ToString("0.0000");
            }

            // 上行基本误差2.0
            if (rep.FindObject("TableCell28_6") is TableCell TableCell28_6)
            {
                TableCell28_6.Text = (model.Value4 - 2.0000).ToString("0.0000");
            }

            // 上行基本误差2.5
            if (rep.FindObject("TableCell28_7") is TableCell TableCell28_7)
            {
                TableCell28_7.Text = (model.Value5 - 2.5000).ToString("0.0000");
            }

            // 下行基本误差0.5
            if (rep.FindObject("TableCell29_3") is TableCell TableCell29_3)
            {
                TableCell29_3.Text = (model.Value9 - 0.5000).ToString("0.0000");
            }

            // 下行基本误差1.0
            if (rep.FindObject("TableCell29_4") is TableCell TableCell29_4)
            {
                TableCell29_4.Text = (model.Value8 - 1.0000).ToString("0.0000");
            }

            // 下行基本误差1.5
            if (rep.FindObject("TableCell29_5") is TableCell TableCell29_5)
            {
                TableCell29_5.Text = (model.Value7 - 1.5000).ToString("0.0000");
            }

            // 下行基本误差2.0
            if (rep.FindObject("TableCell29_6") is TableCell TableCell29_6)
            {
                TableCell29_6.Text = (model.Value6 - 2.0000).ToString("0.0000");
            }

            // 最大回程误差
            if (rep.FindObject("TableCell30_2") is TableCell TableCell30_2)
            {

                List<float> list = new List<float>
                {
                    float.Parse(((TableCell)rep.FindObject("TableCell27_3")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell27_4")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell27_5")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell27_6")).Text.ToString())
                };
                TableCell30_2.Text = list.Max().ToString();
            }

            // 最大基本误差
            if (rep.FindObject("TableCell30_6") is TableCell TableCell30_6)
            {
                List<float> list = new List<float>
                {
                    float.Parse(((TableCell)rep.FindObject("TableCell28_3")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell28_4")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell28_5")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell28_6")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell28_7")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell29_3")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell29_4")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell29_5")).Text.ToString()),
                    float.Parse(((TableCell)rep.FindObject("TableCell29_6")).Text.ToString())
                };
                TableCell30_6.Text = Math.Abs(list.Max()) > Math.Abs(list.Min()) ? list.Max().ToString() : list.Min().ToString();
            }

            rep.PrintSettings.Printer = "Microsoft Print to PDF";
            rep.PrintSettings.ShowDialog = false;
            _ = new EnvironmentSettings { ReportSettings = { ShowProgress = true } };
            // rep.PrintPrepared();
            rep.Print();
        }
    }
}
