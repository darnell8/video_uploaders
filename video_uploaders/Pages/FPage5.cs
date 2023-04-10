namespace Sunny.UI.Demo
{
    /// <summary>
    /// 西瓜创作平台
    /// </summary>
    public partial class FPage5 : UIPage
    {
        public FPage5()
        {
            InitializeComponent();

            //Load a different url
            chromiumWebBrowser1.LoadUrl("https://member.acfun.cn/");
        }
    }
}