using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Enum
{
    public enum SignStatusEnum
    {
        None,
        ScannerI,
        ScannerII,
        Camera,
        ScannerIAndScannerII,
        ScannerIAndScannerIIAndCamera,
        ScannerIAndCamera,
        ScannerIIAndCamera
    }

}
