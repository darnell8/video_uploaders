using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using video_uploaders.Utils;

namespace Sunny.UI.Demo
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FPageMain : UIPage
    {
        public FPageMain()
        {
            InitializeComponent();
        }

        private void FPage1_Initialize(object sender, EventArgs e)
        {
        }

        private void FPageMain_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] dropFilePaths = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
            CompleteInfomationForUploadAsync(dropFilePaths);
        }

        private async void CompleteInfomationForUploadAsync(string[] dropFilePaths)
        {
            string[] line = new[] { "", "bda2", "ws", "qn", "kodo", "cos", "cos-internal" };
            //ComboCheckedListBoxItem[] checkedItems = new ComboCheckedListBoxItem[4]
            //{
            //    new ComboCheckedListBoxItem("AAA",false),
            //           new ComboCheckedListBoxItem("BBB",false),
            //                  new ComboCheckedListBoxItem("CCC",true),
            //                         new ComboCheckedListBoxItem("DDD",false)
            //};

            // 大区
            //string daqu = "160,生活 4,游戏 5,娱乐 36,知识 181,影视 3,音乐 1,动画 155,时尚 211,美食 223,汽车 234,运动 188,科技 217,动物圈 129,舞蹈 167,国创 119,鬼畜 177,纪录片 13,番剧 11,电视剧 23,电影";
            //string[] daquArray = daqu.Split(" ");

            List<string> typeTitleArray = new List<string>();
            typeTitleArray.Add("生活区： 138,搞笑 239,家居房产 161,手工 162,绘画 21,日常");
            typeTitleArray.Add("游戏区： 17,单机游戏 65,网络游戏 172,手机游戏 171,电子竞技 173,桌游棋牌 136,音游 121,GMV 19,Mugen");
            typeTitleArray.Add("娱乐区： 71,综艺 137,明星");
            typeTitleArray.Add("知识区： 201,科学科普 124,社科·法律·心理 228,人文历史 207,财经商业 208,校园学习 209,职业职场 229,设计·创意 122,野生技能协会");
            typeTitleArray.Add("影视区： 85,短片 182,影视杂谈 183,影视剪辑 184,预告·资讯");
            typeTitleArray.Add("音乐区： 130,音乐综合 29,音乐现场 59,演奏 31,翻唱 193,MV 30,VOCALOID·UTAU 194,电音 28,原创音乐");
            typeTitleArray.Add("动画区： 24,MAD·AMV 25,MMD·3D 27,综合 47,短片·手书·配音 210,手办·模玩 86,特摄");
            typeTitleArray.Add("时尚区： 157,美妆护肤 158,穿搭 159,时尚潮流");
            typeTitleArray.Add("美食区： 76,美食制作 212,美食侦探 213,美食测评 214,田园美食 215,美食记录");
            typeTitleArray.Add("汽车区： 176,汽车生活 224,汽车文化 225,汽车极客 240,摩托车 226,智能出行 227,购车攻略");
            typeTitleArray.Add("运动区： 235,篮球·足球 164,健身 236,竞技体育 237,运动文化 238,运动综合");
            typeTitleArray.Add("科技区： 95,数码 230,软件应用 231,计算机技术 232,工业·工程·机械 233,极客DIY");
            typeTitleArray.Add("动物圈区： 218,喵星人 219,汪星人 221,野生动物 222,爬宠 220,大熊猫 75,动物综合");
            typeTitleArray.Add("舞蹈区： 20,宅舞 154,舞蹈综合 156,舞蹈教程 198,街舞 199,明星舞蹈 200,中国舞");
            typeTitleArray.Add("国创区： 153,国产动画 168,国产原创相关 169,布袋戏 170,资讯 195,动态漫·广播剧");
            typeTitleArray.Add("鬼畜区： 22,鬼畜调教 26,音MAD 126,人力VOCALOID 216,鬼畜剧场 127,教程演示");
            typeTitleArray.Add("纪录片区： 37,人文·历史 178,科学·探索·自然 179,军事 180,社会·美食·旅行");
            typeTitleArray.Add("番剧区： 51,资讯 152,官方延伸 32,完结动画 33,连载动画");
            typeTitleArray.Add("电视剧区： 185,国产剧 187,海外剧");
            typeTitleArray.Add("电影区： 83,其他国家 145,欧美电影 146,日本电影 147,国产电影");
            // 小区

            TreeNode[] nodes = new TreeNode[typeTitleArray.Count];
            int i = 0;
            foreach (string typeTemp in typeTitleArray)
            {
                string[] daquArray = typeTemp.Split("： ");
                string daqu = daquArray[0];
                nodes[i] = new TreeNode(daquArray[0]);

                if (daquArray.Length < 2)
                {
                    i++;
                    continue;
                }
                string[] xiaoquArray = daquArray[1].Split(" ");
                foreach (string xiaoqu in xiaoquArray)
                {
                    nodes[i].Nodes.Add(xiaoqu);
                }
                i++;
            }

            UIEditOption option = new UIEditOption
            {
                AutoLabelWidth = true,
                Text = "投稿"
            };

            option.AddText("title", "视频标题", dropFilePaths[0].Split("\\").Last(), true);
            option.AddSwitch("copyright", "是否转载", true, "1-自制", "2-转载");
            option.AddComboTreeView("tid", "投稿分区", nodes, nodes[0].Nodes[0], true);
            option.AddText("tag", "视频标签，逗号分隔多个tag", null, false);
            option.AddText("desc", "视频简介", null, false);
            option.AddText("source", "转载来源", null, false);
            option.AddSwitch("dolby", "是否开启杜比音效", false, "1-开启", "0-关闭");
            option.AddSwitch("hires", "是否开启 Hi-Res", false, "1-开启", "0-关闭");
            option.AddDateTime("dtime", "延时发布时间", DateTime.Now, false);
            option.AddText("dynamic", "空间动态", null, false);
            option.AddCombobox("line", "选择上传线路", line);
            option.AddInteger("limit", "单视频文件最大并发数", 3);
            option.AddSwitch("no-reprint", "二创设置", false, "0-允许转载", "1-禁止转载");
            option.AddSwitch("open-elec", "是否开启充电", true, "1-开启", "0-关闭");

            //option.AddComboCheckedListBox("checkedList", "选择", checkedItems, "CCC");

            UIEditForm frm = new UIEditForm(option);
            frm.Render();
            //frm.CheckedData += Frm_CheckedData;
            frm.ShowDialog();

            if (frm.IsOK)
            {
                int copyright = Convert.ToBoolean(frm["copyright"] + "") ? 1 : 2;
                string tid = ((TreeNode)frm["tid"]).Text.Split(",")[0];
                string source = frm["source"] + "";

                var result = await BiliupHelper.Upload(dropFilePaths, frm["title"] + "", copyright, tid, frm["tag"] + "", frm["desc"] + "", source);
                if (!result.isSuccess)
                {
                    Console.WriteLine(result.stdOutString);
                    ShowErrorDialog(result.message);
                }

                //System.Diagnostics.Process exep = new System.Diagnostics.Process();
                //exep.StartInfo.FileName = biliupR_path;
                //exep.StartInfo.Arguments = biliupR_arg;
                //exep.StartInfo.CreateNoWindow = true;
                //exep.StartInfo.UseShellExecute = true;
                //exep.StartInfo.RedirectStandardOutput = true;
                //exep.Start();
                //while (!exep.StandardOutput.EndOfStream)
                //{
                //    string line = exep.StandardOutput.ReadLine();
                //    Console.WriteLine(line);
                //}
                //exep.WaitForExit();//关键，等待外部程序退出后才能往下执行


                //Console.WriteLine("姓名: " + frm["Name"]);
                //Console.WriteLine("年龄: " + frm["Age"]);
                //Console.WriteLine("生日: " + frm["Birthday"]);
                //Console.WriteLine("性别: " + sex[(int)frm["Sex"]]);
                ////Console.WriteLine("关联: " + frm["Info"]);
                //Console.WriteLine("选择: " + frm["Switch"]);
                //Console.WriteLine("选择: " + frm["ComboTree"]);

                //var outCheckedItems = (ComboCheckedListBoxItem[])frm["checkedList"];
                //foreach (var item in outCheckedItems)
                //{
                //    Console.WriteLine(item.Text, item.Checked);
                //}
            }

            frm.Dispose();
        }

        private void FPageMain_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            else
            {
                _ = e.Data.GetFormats();
                e.Effect = System.Windows.Forms.DragDropEffects.None;
            }
        }

        private void FPageMain_DragLeave(object sender, EventArgs e)
        {
            
        }
    }
}