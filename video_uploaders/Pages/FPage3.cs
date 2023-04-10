namespace Sunny.UI.Demo
{
    /// <summary>
    /// youtube工作室
    /// </summary>
    public partial class FPage3 : UIPage
    {
        public FPage3()
        {
            InitializeComponent();

            //Load a different url
            chromiumWebBrowser1.LoadUrl("https://studio.youtube.com/");
        }
    }
}