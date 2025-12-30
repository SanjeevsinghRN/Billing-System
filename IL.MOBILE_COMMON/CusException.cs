using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class CusException
    {
        public string ModelNo { get; set; }
        public string Make { get; set; }
        public string ExceptionMsg { get; set; }
        public string StackTrace { get; set; }
        public string NetworkType { get; set; }
        public string OsVersion { get; set; }
        public string Memory { get; set; }
        public string AppName { get; set; }
        public string BandWidthSpeed { get; set; }
        public string isHostReachable { get; set; }

    }
    public class HardwareException
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public Int16 ID { get; set; }
        public string PatientID { get; set; }
        public string ModelNo { get; set; }
        public string Make { get; set; }
        public string ExceptionMsg { get; set; }
        public string StackTrace { get; set; }
        public string NetworkType { get; set; }
        public string OsVersion { get; set; }
        public string Memory { get; set; }
        public string AppName { get; set; }
        public string BandWidthSpeed { get; set; }
        public string isHostReachable { get; set; }
        public string OsType { get; set; }
        public string HardwareDevice { get; set; }
        public string ErrorDate { get; set; }
    }
}
