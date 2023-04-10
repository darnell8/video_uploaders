using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace video_uploaders.Utils
{
    class BiliupHelper
    {
        public static readonly string biliupR_path = Environment.CurrentDirectory + @"\Tools\biliup.exe";
        public static readonly string cookieFilePath = Environment.CurrentDirectory + @"\Tools\cookies.json";

        public class Cookie
        {
            public long expires { get; set; }
            public byte http_only { get; set; }
            public string name { get; set; }
            public byte secure { get; set; }
            public string value { get; set; }
        }

        public class ProcessResult
        {
            public ProcessResult(StringBuilder stdOutBuffer, StringBuilder stdErrBuffer)
            {
                this.stdOutString = ReEncodeString(stdOutBuffer);
                this.stdErrString = ReEncodeString(stdErrBuffer);

                this.isSuccess = stdErrString == "";
                if (this.isSuccess)
                {
                    return;
                }

                var errObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(stdErrString.Substring(6));
                errObject.TryGetValue("code", out var code);
                errObject.TryGetValue("message", out var message);
                errObject.TryGetValue("ttl", out var ttl);

                this.code = int.Parse(code + "");
                this.message = message;
                this.ttl = int.Parse(ttl + "");
            }

            public string stdOutString { get; }
            private string stdErrString;

            public bool isSuccess { get; }
            public int code { get; }
            public string message { get; }
            public int ttl { get; }
        }

        public static void SaveCookies(List<Cookie> cookies)
        {
            var streamWriter = File.CreateText(cookieFilePath);
            Dictionary<string, object> result = new Dictionary<string, object>
                        {
                            {"cookie_info", new Dictionary<string, object>{
                                { "cookies", cookies },
                                { "domains", new string[]{".bilibili.com", ".biligame.com", ".bigfun.cn", ".bigfunapp.cn", ".dreamcast.hk"} },
                            }},
                            { "sso", new string[]{"https://passport.bilibili.com/api/v2/sso", "https://passport.biligame.com/api/v2/sso", "https://passport.bigfunapp.cn/api/v2/sso" } },
                            { "token_info", new Dictionary<string, object>{
                                { "access_token", "ba1abcd2225e2cc36debc7338ca78312" },
                                { "expires_in", 15552000 },
                                { "mid", 31161078 },
                                { "refresh_token", "7a4d106a9a9f8cd2976aaf74637d4e12" },
                            }},
                            { "platform", "BiliTV"},
                        };
            streamWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            streamWriter.Close();
        }

        public static void login()
        {
            //请输入SESSDATA
            string SESSDATA = "";
            //请输入bili_jct
            string bili_jct = "";
            //请输入DedeUserID

            var stdInputBuffer = new System.Text.StringBuilder("^[[B<enter>");

            //Console.InputEncoding = Encoding.UTF8;
            //Console.OutputEncoding = Encoding.UTF8;

            var stdOut = Console.OpenStandardOutput();
            var stdErr = Console.OpenStandardError();

            StreamWriter utf8Writer = new StreamWriter(stdOut, new UTF8Encoding(false));

            var cmd = stdInputBuffer + "" | CliWrap.Cli.Wrap(biliupR_path)
                .WithArguments(args => args.Add("127.0.0.1"))
                | (stdOut, stdErr);

            cmd.ExecuteAsync();
            //cmd.ExecuteBufferedAsync(Encoding.GetEncoding("GB2312"), Encoding.GetEncoding("GB2312"));
        }

        public static async Task<ProcessResult> Upload(string[] dropFilePaths, string title, int copyright, string tid, string tag, string desc = "", string source = "")
        {
            // 调用biliupR B站上传视频
            var stdOutBuffer = new System.Text.StringBuilder();
            var stdErrBuffer = new System.Text.StringBuilder();

            //string biliupR_arg = @"upload " + string.Join(" ", dropFilePaths);
            var cmd = CliWrap.Cli.Wrap(biliupR_path)
                .WithArguments(args => args
                    .Add("-u")
                    .Add(cookieFilePath)
                    .Add("upload")
                    .Add(dropFilePaths)
                    .Add("--title")
                    .Add(title)
                    .Add("--copyright")
                    .Add(copyright)
                    .Add("--tid")
                    .Add(tid)
                    .Add("--tag")
                    .Add(tag)
                    .Add("--desc")
                    .Add(desc)
                    .Add("--source")
                    .Add(source)
                )
                .WithValidation(CliWrap.CommandResultValidation.None)
                .WithStandardOutputPipe(CliWrap.PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(CliWrap.PipeTarget.ToStringBuilder(stdErrBuffer));
            var result = await cmd.ExecuteAsync();

            var processResult = new ProcessResult(stdOutBuffer, stdErrBuffer);

            return processResult;
        }

        private static string ReEncodeString(StringBuilder stringBuilder)
        {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            byte[] btArr = gb2312.GetBytes(stringBuilder + "");
            return Encoding.UTF8.GetString(btArr);
        }
    }
}
