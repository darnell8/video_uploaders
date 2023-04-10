using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CliWrap.Buffered;
using video_uploaders.Utils;

namespace Sunny.UI.Demo
{
    /// <summary>
    /// bilibili创作中心
    /// </summary>
    public partial class FPage1 : UIPage
    {
        private const string bilibili_url = "https://member.bilibili.com/platform/home";

        public FPage1()
        {
            InitializeComponent();
        }

        private void FPage1_Initialize(object sender, EventArgs e)
        {


            if (chromiumWebBrowser1.Address != bilibili_url)
            {
                //Load a different url
                chromiumWebBrowser1.LoadUrl(bilibili_url);
            }
        }

        private void chromiumWebBrowser1_AddressChanged(object sender, CefSharp.AddressChangedEventArgs e)
        {
            Console.WriteLine("chromiumWebBrowser1_AddressChanged: ---" + e.Address);
            string address = e.Address;
            if (address.StartsWith(bilibili_url) && true)
            {
                CefSharp.ICookieManager cookieManager = CefSharp.Cef.GetGlobalCookieManager();
                //cookieManager.VisitUrlCookies(bilibili_url, true, new CookieVisitor(cookieFilePath));

                //CefSharp.TaskCookieVisitor cookieVisitor = new CefSharp.TaskCookieVisitor();
                //cookieManager.VisitUrlCookies(bilibili_url, true, cookieVisitor);

                CefSharp.AsyncExtensions.VisitUrlCookiesAsync(cookieManager, bilibili_url, true).ContinueWith(task =>
                {
                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        List<BiliupHelper.Cookie> cookies = new List<BiliupHelper.Cookie>();
                        foreach (CefSharp.Cookie tempCookie in task.Result)
                        {
                            BiliupHelper.Cookie cookie = new BiliupHelper.Cookie
                            {
                                expires = tempCookie.Expires == null? 0 : tempCookie.Expires.Value.Ticks,
                                http_only = Convert.ToByte(tempCookie.HttpOnly),
                                name = tempCookie.Name,
                                secure = Convert.ToByte(tempCookie.Secure),
                                value = tempCookie.Value,
                            };
                            cookies.Add(cookie);
                        }

                        //请输入SESSDATA
                        string SESSDATA = "";
                        //请输入bili_jct
                        string bili_jct = "";
                        //请输入DedeUserID
                        BiliupHelper.SaveCookies(cookies);
                    }
                    else
                    {
                        Console.WriteLine("No Cookies found");
                    }
                });
                // 验证是否已经登录
            }
        }

        
    }
}