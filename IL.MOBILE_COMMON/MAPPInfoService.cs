using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class MAPPInfoService
    {
        public string DeviceId { get; set; }

        public string PackageName { get; set; }

        public decimal AppVersionName { get; set; }
        public string AppVersionName_v1 { get; set; }

        public int AppVersionCode { get; set; }

        public double DeviceScreenWidth { get; set; }

        public double DeviceScreenHeight { get; set; }

        public string ReleasedOn { get; set; }

        public int ForcedUpdated { get; set; }
        public int ForcedLogout { get; set; }

        public string APP_URL { get; set; }

        public string ForcedUpdatedMsg { get; set; }
        public string ForcedLogoutMsg { get; set; }
    }
}
