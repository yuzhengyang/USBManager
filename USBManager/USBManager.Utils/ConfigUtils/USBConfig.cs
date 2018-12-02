using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USBManager.Utils.Commons;

namespace USBManager.Utils.ConfigUtils
{
    public static class USBConfig
    {
        public static void SetConfig(string domain, string username, string password)
        {
            R.Domain = domain;
            R.Username = username;
            R.Password = password;
        }
    }
}
