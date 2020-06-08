using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TestProjectXamarin.Models
{
    public class Constants
    {
        public static bool isDev = true;
        public static Color backgroundColor = Color.White;
        public static Color mainTextColor = Color.Black;
        public static int LoginIconHeight = 120;

        //-------Login-----
        public static string LoginUrl = "https://reqres.in/api/login";

        public static string NoInternetText = "No internet, Please Reconnect.";

        public static string SettingsScreenTitle = "Settings";
    }
}
