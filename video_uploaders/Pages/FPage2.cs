namespace Sunny.UI.Demo
{
    /// <summary>
    /// 抖音创作服务平台
    /// </summary>
    public partial class FPage2 : UIPage
    {
        public FPage2()
        {
            InitializeComponent();

            //Load a different url
            chromiumWebBrowser1.LoadUrl("https://creator.douyin.com/creator-micro/content/upload");
        }
    }
}