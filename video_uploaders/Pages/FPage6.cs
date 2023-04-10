namespace Sunny.UI.Demo
{
    /// <summary>
    /// 西瓜创作平台
    /// </summary>
    public partial class FPage6 : UIPage
    {
        public FPage6()
        {
            InitializeComponent();

            //Load a different url
            chromiumWebBrowser1.LoadUrl("https://cp.kuaishou.com/profile");
        }
    }
}