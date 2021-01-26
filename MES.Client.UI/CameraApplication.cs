using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvCamCtrl.NET;
using ManufacturingExecutionSystem;


namespace ManufacturingExecutionSystem.MES.Client.UI
{
    public partial class CameraApplication : Form
    {
        private MyCamera _myCamera;

        // 用于从驱动获取图像缓存
        private uint _bufferSizeForDriver;
        private IntPtr _bufferForDriver;

        // 用于保存图像的缓存
        private uint _bufferSizeForImage;
        private IntPtr _bufferForImage;

        // 图像采集状态
        private bool _collectStatus;

        // Lock锁
        private static readonly object BufForDriverLock = new object();

        // 采集线程
        private Thread _receiveThread;

        // 设备信息列表
        private MyCamera.MV_CC_DEVICE_INFO_LIST _deviceList;

        // 输出帧的信息
        private MyCamera.MV_FRAME_OUT_INFO_EX _frameInfo;


        public bool detectionStatus;

        public CameraApplication()
        {
            InitializeComponent();

            // 多线程程序中，新创建的线程不能访问UI线程创建的窗口控件,这时如果想要访问窗口的控件,
            // 这时可将窗口构造函数中的CheckForIllegalCrossThreadCalls设置为false；
            // 然后就能安全的访问窗体控件。
            // 尽量不要用这个，一般用
            // Invoke(new Action(() => { }));
            Control.CheckForIllegalCrossThreadCalls = false;

            Thread detectionRunThread = new Thread(detectionRun);
            if (detectionRunThread.ThreadState != ThreadState.Running)
            {
                detectionRunThread.Start();
            }
        }


        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="csMessage"></param>
        /// <param name="nErrorNum"></param>
        private void ShowErrorMsg(string csMessage, int nErrorNum)
        {
            string errorMsg;
            if (nErrorNum == 0)
            {
                errorMsg = csMessage;
            }
            else
            {
                errorMsg = csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
            }

            switch (nErrorNum)
            {
                case MyCamera.MV_E_HANDLE: errorMsg += " Error or invalid handle "; break;
                case MyCamera.MV_E_SUPPORT: errorMsg += " Not supported function "; break;
                case MyCamera.MV_E_BUFOVER: errorMsg += " Cache is full "; break;
                case MyCamera.MV_E_CALLORDER: errorMsg += " Function calling order error "; break;
                case MyCamera.MV_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
                case MyCamera.MV_E_RESOURCE: errorMsg += " Applying resource failed "; break;
                case MyCamera.MV_E_NODATA: errorMsg += " No data "; break;
                case MyCamera.MV_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
                case MyCamera.MV_E_VERSION: errorMsg += " Version mismatches "; break;
                case MyCamera.MV_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
                case MyCamera.MV_E_UNKNOW: errorMsg += " Unknown error "; break;
                case MyCamera.MV_E_GC_GENERIC: errorMsg += " General error "; break;
                case MyCamera.MV_E_GC_ACCESS: errorMsg += " Node accessing condition error "; break;
                case MyCamera.MV_E_ACCESS_DENIED: errorMsg += " No permission "; break;
                case MyCamera.MV_E_BUSY: errorMsg += " Device is busy, or network disconnected "; break;
                case MyCamera.MV_E_NETER: errorMsg += " Network error "; break;
            }

            label_MessageInfo.Text = errorMsg;
        }


        /// <summary>
        /// 判断是否是彩色数据
        /// </summary>
        /// <param name="enGvspPixelType"> 像素格式 </param>
        /// <returns> 成功，返回0；错误，返回-1 </returns>
        private static Boolean IsColorData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YCBCR411_8_CBYYCRYY:
                    return true;
                default:
                    return false;
            }
        }


        /// <summary>
        /// 将active设备添加到下拉菜单里
        /// </summary>
        private void AddDeviceIntoList()
        {
            comb_DeviceList.Items.Clear();
            _deviceList.nDeviceNum = 0;
            // 枚举Active的设备
            int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref _deviceList);
            if (0 != nRet)
            {
                ShowErrorMsg(Properties.Resources.Enum_Devices_Failed, 0);
                return;
            }
            else
            {
                label_MessageInfo.Text = Properties.Resources.Enum_Devices_Succeed;
            }
            for (int i = 0; i < _deviceList.nDeviceNum; i++)
            {
                // 将设备信息从非托管内存块封送到托管对象Device
                MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(_deviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                // 如果设备是Gige设备
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    // 获取当前Gige设备的信息
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    if (gigeInfo.chUserDefinedName != "")
                    {
                        comb_DeviceList.Items.Add("GEV: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        comb_DeviceList.Items.Add("GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                    }
                }
                // 如果当前设备是USB设备
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chUserDefinedName != "")
                    {
                        comb_DeviceList.Items.Add("U3V: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                    }
                    else
                    {
                        comb_DeviceList.Items.Add("U3V: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                    }
                }
            }

            // ch:选择第一项 | en:Select the first item
            if (_deviceList.nDeviceNum != 0)
            {
                comb_DeviceList.SelectedIndex = 0;
            }
        }


        private void btn_ScanDevice_Click(object sender, EventArgs e)
        {
            label_MessageInfo.Text = Properties.Resources.btn_ScanDevice_Click_Label_MessageInfo;
            Application.DoEvents();
            AddDeviceIntoList();
            if (comb_DeviceList.Items.Count > 0)
            {
                btn_OpenDevice.Enabled = true;
                btn_ShutDevice.Enabled = true;
            }
            MsgInfoClear_Timer.Start();
        }


        private void MsgInfoClear_Timer_Tick(object sender, EventArgs e)
        {
            MsgInfoClear_Timer?.Stop();
            if (label_MessageInfo != null) label_MessageInfo.Text = String.Empty;
        }


        /// <summary>
        /// 启用设备
        /// </summary>
        private void OpenDevice()
        {
            if (_deviceList.nDeviceNum == 0 || comb_DeviceList.SelectedIndex == -1)
            {
                ShowErrorMsg("NO DEVICE, PLEASE SELECT!", 0);
                return;
            }

            MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(_deviceList.pDeviceInfo[comb_DeviceList.SelectedIndex], typeof(MyCamera.MV_CC_DEVICE_INFO));

            // 初始化对象
            if (null == _myCamera)
            {
                _myCamera = new MyCamera();
                if (null == _myCamera) return;
            }

            // 根据输入的设备信息， 创建库内部必须的资源和初始化内部模块。 通过该接口创建设备，调用SDK接口，
            // 会默认生成SDK文件。
            // 根据设备信息创建设备
            int nRet = _myCamera.MV_CC_CreateDevice_NET(ref device);
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg(Properties.Resources.Device_Open_Failed, nRet);
                return;
            }

            // 连接设备
            nRet = _myCamera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                _myCamera.MV_CC_DestroyDevice_NET();
                ShowErrorMsg(Properties.Resources.Device_Open_Failed, nRet);
            }

            // 探测网络最佳包大小(Gige)
            new Thread(() =>
            {
                if (MyCamera.MV_GIGE_DEVICE != device.nTLayerType) return;
                int nPacketSize = _myCamera.MV_CC_GetOptimalPacketSize_NET();
                if (nPacketSize > 0)
                {
                    nRet = _myCamera.MV_CC_SetIntValueEx_NET("GevSCPSPacketSize", (uint)nPacketSize);
                    if (nRet != MyCamera.MV_OK)
                    {
                        ShowErrorMsg("SET PACKET SIZE FAILED", nRet);
                    }
                    else
                    {
                        label_MessageInfo.Text = Properties.Resources.Device_Open_Succeed;
                    }
                }
                else
                {
                    ShowErrorMsg("GET PACKET SIZE FAILED!", nPacketSize);
                }
            }).Start();

            _myCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
            _myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            GetParam_Timer.Start();
            SetCtrlWhenOpen();
        }


        private void GetParam()
        {
            try
            {
                Application.DoEvents();
                MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
                int nRet = _myCamera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    label_ExposureTime.Text = Properties.Resources.ExposureTime + stParam.fCurValue.ToString("F1") + Properties.Resources.ExposureTimeUnit;

                    trackBar_ExposureTime.Value = Convert.ToInt32(stParam.fCurValue) / 2000;
                }

                nRet = _myCamera.MV_CC_GetFloatValue_NET("Gain", ref stParam);
                if (MyCamera.MV_OK == nRet)
                {
                    label_Gain.Text = Properties.Resources.Gain + stParam.fCurValue.ToString("F1");
                    trackBar_Gain.Value = (int)(Convert.ToInt32(stParam.fCurValue) / 2);
                }

                nRet = _myCamera.MV_CC_GetFloatValue_NET("ResultingFrameRate", ref stParam);

                if (MyCamera.MV_OK == nRet)
                {
                    label_FrameRate.Text = Properties.Resources.FrameRate + stParam.fCurValue.ToString("F1");
                    trackBar_FrameRate.Value = (int)(Convert.ToInt32(stParam.fCurValue) / 1.5);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        private void GetParam_Timer_Tick(object sender, EventArgs e)
        {
            new Thread(GetParam).Start();
        }


        private void SetCtrlWhenOpen()
        {
            btn_OpenDevice.Enabled = false;
            btn_ShutDevice.Enabled = true;
            Radio_ContinuousAcquisitionMode.Enabled = true;
            Radio_ContinuousAcquisitionMode.Checked = true;
            radio_TriggerAcquisitionMode.Enabled = true;
            btn_StartCollect.Enabled = true;
            btn_StopCollect.Enabled = true;
        }


        private void SetCtrlWhenShut()
        {
            btn_OpenDevice.Enabled = true;
            btn_ShutDevice.Enabled = false;
            Radio_ContinuousAcquisitionMode.Enabled = false;
            Radio_ContinuousAcquisitionMode.Checked = false;
            radio_TriggerAcquisitionMode.Enabled = false;
            btn_StartCollect.Enabled = false;
            btn_StopCollect.Enabled = false;
        }



        private static Boolean IsMonoData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;

                default:
                    return false;
            }
        }



        private void ShutDevice()
        {

            // ch:取流标志位清零 | en:Reset flow flag bit
            if (_collectStatus == true)
            {
                _collectStatus = false;
                _receiveThread.Join();
            }

            if (_bufferForDriver != IntPtr.Zero)
            {
                Marshal.Release(_bufferForDriver);
            }
            if (_bufferForImage != IntPtr.Zero)
            {
                Marshal.Release(_bufferForImage);
            }

            GetParam_Timer.Stop();
            if (_myCamera == null) return;
            int nRet = _myCamera.MV_CC_CloseDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg("CLOSE DEVICE FAILED!!", nRet);
            }
            else
            {
                label_MessageInfo.Text = Properties.Resources.CloseDeviceSucceed;
            }
            _myCamera.MV_CC_DestroyDevice_NET();
            SetCtrlWhenShut();
        }



        private void btn_OpenDevice_Click(object sender, EventArgs e)
        {
            label_MessageInfo.Text = Properties.Resources.btn_OpenDevice_Click_label_MessageInfo;
            Application.DoEvents();
            OpenDevice();
            MsgInfoClear_Timer.Start();
        }



        private void btn_ShutDevice_Click(object sender, EventArgs e)
        {
            label_MessageInfo.Text = "SHUTTING DOWN DEVICE...";
            Application.DoEvents();
            ShutDevice();
            MsgInfoClear_Timer.Start();
        }



        #region 参数自动调整

        private void trackBar_ExposureTime_Scroll(object sender, EventArgs e)
        {
            try
            {
                _myCamera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
                int nRet = _myCamera.MV_CC_SetFloatValue_NET("ExposureTime", float.Parse((trackBar_ExposureTime.Value * 2000).ToString()));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Exposure Time Fail!", nRet);
                }
            }
            catch
            {
                ShowErrorMsg("Please enter correct type!", 0);
            }
        }



        private void trackBar_FrameRate_Scroll(object sender, EventArgs e)
        {
            try
            {
                int nRet = _myCamera.MV_CC_SetFloatValue_NET("AcquisitionFrameRate", float.Parse((trackBar_FrameRate.Value * 1.5).ToString()));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Frame Rate Fail!", nRet);
                }
            }
            catch
            {
                ShowErrorMsg("Please enter correct type!", 0);
            }
        }



        private void trackBar_Gain_Scroll(object sender, EventArgs e)
        {
            try
            {
                _myCamera.MV_CC_SetEnumValue_NET("GainAuto", 0);
                int nRet = _myCamera.MV_CC_SetFloatValue_NET("Gain", float.Parse((trackBar_Gain.Value * 2).ToString()));
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Gain Fail!", nRet);
                }
            }
            catch
            {
                ShowErrorMsg("Please enter correct type!", 0);
            }
        }

        #endregion



        private void ReceiveThreadProcess()
        {
            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
            int nRet = _myCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
            if (MyCamera.MV_OK != nRet)
            {
                ShowErrorMsg(Properties.Resources.GetPayloadSizeFailed, nRet);
                return;
            }
            UInt32 payLoadSize = stParam.nCurValue;
            if (payLoadSize > _bufferSizeForDriver)
            {
                if (_bufferForDriver != IntPtr.Zero)
                {
                    Marshal.Release(_bufferForDriver);
                }
                _bufferSizeForDriver = payLoadSize;
                _bufferForDriver = Marshal.AllocHGlobal((Int32)_bufferSizeForDriver);
            }
            if (_bufferForDriver == IntPtr.Zero) return;
            MyCamera.MV_FRAME_OUT_INFO_EX nFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
            MyCamera.MV_DISPLAY_FRAME_INFO nDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO();

            while (_collectStatus)
            {
                lock (BufForDriverLock)
                {
                    nRet = _myCamera.MV_CC_GetOneFrameTimeout_NET(_bufferForDriver, payLoadSize, ref nFrameInfo, 1000);
                    if (nRet == MyCamera.MV_OK)
                    {
                        _frameInfo = nFrameInfo;
                    }
                }
                if (nRet == MyCamera.MV_OK)
                {
                    if (RemoveCustomPixelFormats(nFrameInfo.enPixelType))
                    {
                        continue;
                    }
                    nDisplayInfo.hWnd = pictureBox1.Handle;
                    nDisplayInfo.pData = _bufferForDriver;
                    nDisplayInfo.nDataLen = nFrameInfo.nFrameLen;
                    nDisplayInfo.nWidth = nFrameInfo.nWidth;
                    nDisplayInfo.nHeight = nFrameInfo.nHeight;
                    nDisplayInfo.enPixelType = nFrameInfo.enPixelType;
                    _myCamera.MV_CC_DisplayOneFrame_NET(ref nDisplayInfo);
                }
                else
                {
                    if (radio_TriggerAcquisitionMode.Checked)
                    {
                        Thread.Sleep(5);
                    }
                }
            }
            btn_StartCollect.Enabled = true;
        }



        // ch:去除自定义的像素格式 | en:Remove custom pixel formats
        private static bool RemoveCustomPixelFormats(MyCamera.MvGvspPixelType enPixelFormat)
        {
            Int32 nResult = ((int)enPixelFormat) & (unchecked((Int32)0x80000000));
            return 0x80000000 == nResult;
        }



        private void btn_StartCollect_Click(object sender, EventArgs e)
        {
            label_MessageInfo.Text = "GRABBING...";
            Application.DoEvents();
            _collectStatus = true;
            _receiveThread = new Thread(ReceiveThreadProcess);
            _receiveThread.Start();
            _frameInfo.nFrameLen = 0; //取流之前先清除帧长度
            _frameInfo.enPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;

            // ch:开始采集 | en:Start Grabbing
            int nRet = _myCamera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                _collectStatus = false;
                _receiveThread.Join();
                ShowErrorMsg("START GRABBING FAILED!", nRet);
                return;
            }
            else
            {
                label_MessageInfo.Text = "START GRABBING SUCCEED";
                btn_StopCollect.Enabled = true;
            }
            _myCamera.MV_CC_SetGainMode_NET(2);
            MsgInfoClear_Timer.Start();
        }



        private void btn_StopCollect_Click(object sender, EventArgs e)
        {
            try
            {
                _collectStatus = false;
                _receiveThread?.Join();
                if (_myCamera == null) return;
                int nRet = _myCamera.MV_CC_StopGrabbing_NET();
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("STOP GRABBING FAILED!", nRet);
                }
                else
                {
                    label_MessageInfo.Text = "STOP GRABBING SUCCEED";
                    btn_StopCollect.Enabled = false;
                    Image img = Image.FromFile("black.bmp");
                    pictureBox1.Image = img;
                }
                MsgInfoClear_Timer?.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }



        private string FileSavePath()
        {
            string path = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
            string exeFileName = "ObjectDetectionProgram.exe";
            path = path.Substring(0, path.Length - exeFileName.Length);
            path += "BitMaps\\";

            Boolean directoryExists = Directory.Exists(path);
            if (directoryExists)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                IEnumerable<FileInfo> enumerable = directory.EnumerateFiles();
                int filesCount = enumerable.Count() + 1;

                if (filesCount > 0 && filesCount < 10)
                {
                    path += ("00000" + filesCount + ".bmp");
                }
                else if (filesCount >= 10 && filesCount < 100)
                {
                    path += ("0000" + filesCount + ".bmp");
                }
                else if (filesCount >= 100 && filesCount < 1000)
                {
                    path += ("000" + filesCount + ".bmp");
                }
                else if (filesCount >= 1000 && filesCount < 10000)
                {
                    path += ("00" + filesCount + ".bmp");
                }
                return path;
            }
            else
            {
                Directory.CreateDirectory(path);
                return string.Empty;
            }
        }



        private Bitmap SaveImgAsBmp()
        {
            // label_MessageInfo.Text = "STARTING SAVE...";
            if (!_collectStatus)
            {
                ShowErrorMsg("NOT START GRABBING", 0);
                return null;
            }
            if (RemoveCustomPixelFormats(_frameInfo.enPixelType))
            {
                ShowErrorMsg("NOT SUPPORT!", 0);
                return null;
            }
            IntPtr pTemp;
            MyCamera.MvGvspPixelType enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Undefined;
            if (_frameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8 || _frameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed)
            {
                pTemp = _bufferForDriver;
                enDstPixelType = _frameInfo.enPixelType;
            }
            else
            {
                MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                lock (BufForDriverLock)
                {
                    if (_frameInfo.nFrameLen == 0)
                    {
                        ShowErrorMsg("SAVE BMPFILE FAILED!", 0);
                        return null;
                    }

                    UInt32 nSaveImageNeedSize = 0;
                    if (IsMonoData(_frameInfo.enPixelType))
                    {
                        enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                        nSaveImageNeedSize = (uint)_frameInfo.nWidth * _frameInfo.nHeight;
                    }
                    else if (IsColorData(_frameInfo.enPixelType))
                    {
                        enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
                        nSaveImageNeedSize = (uint)_frameInfo.nWidth * _frameInfo.nHeight * 3;
                    }
                    else
                    {
                        ShowErrorMsg("NO SUCH PIXEL TYPE!", 0);
                        return null;
                    }

                    if (_bufferSizeForImage < nSaveImageNeedSize)
                    {
                        if (_bufferForImage != IntPtr.Zero)
                        {
                            Marshal.Release(_bufferForImage);
                        }
                        _bufferSizeForImage = nSaveImageNeedSize;
                        _bufferForImage = Marshal.AllocHGlobal((Int32)_bufferSizeForImage);
                    }

                    stConverPixelParam.nWidth = _frameInfo.nWidth;
                    stConverPixelParam.nHeight = _frameInfo.nHeight;
                    stConverPixelParam.pSrcData = _bufferForDriver;
                    stConverPixelParam.nSrcDataLen = _frameInfo.nFrameLen;
                    stConverPixelParam.enSrcPixelType = _frameInfo.enPixelType;
                    stConverPixelParam.enDstPixelType = enDstPixelType;
                    stConverPixelParam.pDstBuffer = _bufferForImage;
                    stConverPixelParam.nDstBufferSize = _bufferSizeForImage;
                    int nRet = _myCamera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        ShowErrorMsg("CONVERT PIXEL TYPE FAILED!", nRet);
                        return null;
                    }
                    pTemp = _bufferForImage;
                }
            }

            lock (BufForDriverLock)
            {
                if (enDstPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                {
                    //************************Mono8 转 Bitmap*******************************
                    try
                    {
                        Bitmap bmp = new Bitmap(_frameInfo.nWidth, _frameInfo.nHeight, _frameInfo.nWidth * 1, PixelFormat.Format8bppIndexed, pTemp);

                        ColorPalette cp = bmp.Palette;
                        // init palette
                        for (int i = 0; i < 256; i++)
                        {
                            cp.Entries[i] = Color.FromArgb(i, i, i);
                        }
                        // set palette back
                        bmp.Palette = cp;
                        return bmp;
                        // bmp.Save(savePath, ImageFormat.Bmp);
                        // label_MessageInfo.Text = "SAVE BMPFILE SUCCEED";
                    }
                    catch (Exception e)
                    {
                        ShowErrorMsg("WRITE FILE FAILED!" + e.Message, 0);
                        return null;
                    }

                }

                //*********************BGR8 转 Bitmap**************************
                try
                {
                    Bitmap bmp = new Bitmap(_frameInfo.nWidth, _frameInfo.nHeight, _frameInfo.nWidth * 3, PixelFormat.Format24bppRgb, pTemp);
                    return bmp;
                    // bmp.Save(savePath, ImageFormat.Bmp);
                    // label_MessageInfo.Text = "SAVE BMPFILE SUCCEED";
                }
                catch (Exception e)
                {
                    ShowErrorMsg("WRITE FILE FAILED!" + e.Message, 0);
                    return null;
                }
            }
        }


        private void btn_SaveAsBmp_Click(object sender, EventArgs e)
        {
            //string path = FileSavePath();
            Bitmap imgBmp = SaveImgAsBmp();
            MsgInfoClear_Timer?.Start();
            if (imgBmp == null)
            {
                MessageBox.Show("未检测到图像输入");
            }
            ObjectDetectionProgram.ImageIdentification.ObjectDetection.Run(imgBmp);
        }




        private void CameraApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要关闭吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                if (label_MessageInfo != null) label_MessageInfo.Text = Properties.Resources.CameraApplication_FormClose;
                GetParam_Timer?.Stop();
                Thread.Sleep(1000);
                btn_StopCollect_Click(null, null);
                // Thread.Sleep(500);
                btn_ShutDevice_Click(null, null);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }


        private void detectionRun()
        {
            while (true)
            {
                Thread.Sleep(500);
                Application.DoEvents();
                if (detectionStatus)
                {
                    MessageBox.Show("调用btn_SaveAsBmp_Click");
                    btn_SaveAsBmp_Click(null, null);
                }
            }
        }
    }
}
