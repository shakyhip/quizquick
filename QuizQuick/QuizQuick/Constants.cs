using System;
using System.Collections.Generic;
using System.Text;

namespace QuizQuick
{
    public class Constants
    {
        public static string ResIpv4 = "localhost";
        public static Int16? RestPort = null;
        public static string RestHttp = "http";
        public static string RestUrl = RestHttp + "://" + ResIpv4 + (RestPort != null ? ":" + RestPort : "");
    }
}
