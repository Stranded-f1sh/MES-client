using System;
using System.Data;
using ManufacturingExecutionSystem.MES.Client.Mapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    public class DataCacheService
    {

        public int InsertDataRecord(Device device)
        {
            DataCacheMapper dataCacheMapper = new DataCacheMapper();
            dataCacheMapper.CreateTableIfNotExist();
            return dataCacheMapper.InsertIntoDeviceCache(device);
        }

        
        /*
         * 需要传不合格原因
         */
        public int DeviceCache(
            String imei,
            int userId,
            ProcessNameEnum process,
            SubmitStatus baoGongStatus)
        {
            Device device = new Device
            {
                Imei = imei,
                UserId = userId,
                ProcessId = (int)process,
                Passed = (int)PassJudge.Qualified,
                BaoGongStatus = baoGongStatus
            };

            return InsertDataRecord(device);
        }
        
        
        /*
         * 需要传不合格原因
         */
        public int DeviceCache(
            String imei,
            int reasonId,
            String reasonContext,
            int userId,
            ProcessNameEnum process,
            SubmitStatus baoGongStatus)
        {
            Device device = new Device
            {
                Imei = imei,
                UserId = userId,
                ProcessId = (int)process,
                Passed = (int)PassJudge.Unqualified,
                ReasonId = reasonId,
                ReasonContext = reasonContext,
                BaoGongStatus = baoGongStatus
            };

            return InsertDataRecord(device);
        }


        public DataSet FindDataRecord()
        {
            DataCacheMapper dataCacheMapper = new DataCacheMapper();
            return dataCacheMapper.FindUnUploadData();
        }


        public int DeleteDeviceCacheById(int id)
        {
            DataCacheMapper dataCacheMapper = new DataCacheMapper();
            return dataCacheMapper.DeleteDataById(id);
        }


        public int UpdateDeviceSubmitStatusById(int id)
        {
            DataCacheMapper dataCacheMapper = new DataCacheMapper();
            return dataCacheMapper.UpdateDataById(id);
        }
    }
}