using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Sunny.UI.Demo;
using video_uploaders.Utils;

namespace video_uploaders
{
    public partial class Form1 : UIAsideHeaderMainFrame
    {
       

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new System.Drawing.Size(1600, 900);

            //设置关联
            Aside.TabControl = MainTabControl;

            //增加页面到Main
            AddPage(new FPageMain(), 1000);
            AddPage(new FPage1(), 1001);
            AddPage(new FPage2(), 1002);
            AddPage(new FPage3(), 1003);
            AddPage(new FPage4(), 1004);
            AddPage(new FPage5(), 1005);
            AddPage(new FPage6(), 1006);

            //设置Header节点索引
            Aside.CreateNode("上传助手", 1000);
            Aside.CreateNode("bilibili创作中心", 1001);
            Aside.CreateNode("抖音创作服务平台", 1002);
            Aside.CreateNode("youtube工作室", 1003);
            Aside.CreateNode("西瓜创作平台", 1004);
            Aside.CreateNode("快手创作者服务平台", 1005);

            //显示默认界面
            Aside.SelectFirst();
        }

    }
}
