using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace onepicture.proxy
{
    public static class GerConnectionGeneration
    {
        static string None = "None";
        static string Unknown = "Unknown";
        static string IIG = "2G";
        static string IIIG = "3G";
        static string IVG = "4G";
        static string Wifi = "wifi";
        static string Lan = "Lan";


        public static string GetConnectionGeneration()
        {
            bool isConnected = false;

            string InternetType = null;
            ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
            if (profile == null)
            {
                InternetType = GerConnectionGeneration.None;
            }
            else
            {
                NetworkConnectivityLevel cl = profile.GetNetworkConnectivityLevel();
                isConnected = (cl != NetworkConnectivityLevel.None);
            }
            if (!isConnected)
            {
                return GerConnectionGeneration.None;
            }
            if (profile.IsWwanConnectionProfile)
            {
                if (profile.WwanConnectionProfileDetails == null)
                {
                    InternetType = GerConnectionGeneration.Unknown;
                }
                WwanDataClass connectionClass = profile.WwanConnectionProfileDetails.GetCurrentDataClass();
                switch (connectionClass)
                {
                    //2G
                    case WwanDataClass.Edge:
                    case WwanDataClass.Gprs:
                        InternetType = GerConnectionGeneration.IIG;
                        break;
                    //3G
                    case WwanDataClass.Cdma1xEvdo:
                    case WwanDataClass.Cdma1xEvdoRevA:
                    case WwanDataClass.Cdma1xEvdoRevB:
                    case WwanDataClass.Cdma1xEvdv:
                    case WwanDataClass.Cdma1xRtt:
                    case WwanDataClass.Cdma3xRtt:
                    case WwanDataClass.CdmaUmb:
                    case WwanDataClass.Umts:
                    case WwanDataClass.Hsdpa:
                    case WwanDataClass.Hsupa:
                        InternetType = GerConnectionGeneration.IIIG;
                        break;
                    //4G
                    case WwanDataClass.LteAdvanced:
                        InternetType = GerConnectionGeneration.IVG;
                        break;
                    //无网
                    case WwanDataClass.None:
                        InternetType = GerConnectionGeneration.Unknown;
                        break;
                    case WwanDataClass.Custom:
                    default:
                        InternetType = GerConnectionGeneration.Unknown;
                        break;
                }
            }
            else if (profile.IsWlanConnectionProfile)
            {
                InternetType = GerConnectionGeneration.Wifi;
            }
            else
            {
                ///不是Wifi也不是蜂窝数据判断为Lan
                InternetType = GerConnectionGeneration.Lan;
            }
            return InternetType;
        }
    }
}
