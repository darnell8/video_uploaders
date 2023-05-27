using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_uploaders.Utils
{
    class CefSharpHelper
    {
        public static void InitCefSharp()
        {
            CefSharp.CefSettingsBase settings = new CefSharp.WinForms.CefSettings
            {
                CachePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            CefSharp.Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
        }

        public static void ClearBrowserCache()
        {
            CefSharp.ICookieManager cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            cookieManager.DeleteCookies();
        }
    }
}
