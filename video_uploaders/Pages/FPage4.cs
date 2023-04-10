namespace Sunny.UI.Demo
{
    /// <summary>
    /// 西瓜创作平台
    /// </summary>
    public partial class FPage4 : UIPage
    {
        public FPage4()
        {
            InitializeComponent();

            //Load a different url
            chromiumWebBrowser1.LoadUrl("https://studio.ixigua.com/");
        }
    }
}