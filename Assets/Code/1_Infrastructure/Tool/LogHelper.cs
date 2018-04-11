using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assets.Code._1_Infrastructure.Tool
{
    public class LogHelper
    {
        private static LogHelper _instance;
        public static LogHelper GetInstance()
        {
            if (_instance == null)
                _instance = new LogHelper();

            return _instance;
        }

        private Dictionary<string, string> DictLogFile = null;
        private LogHelper()
        {
            DictLogFile = new Dictionary<string, string>();
        }

        private string logPath = "";
        /// <summary>
        /// 设置日志文件路径
        /// </summary>
        /// <param name="path"></param>
        public string setLogPath(string path)
        {
            logPath = path;
            return "设置日志路径" + path + "成功";
        }

        /// <summary>
        /// 创建日志文件
        /// </summary>
        public string CreateLog(string logTitle)
        {
            //判断文件夹是否存在
            if (Directory.Exists(logPath) == false)
                Directory.CreateDirectory(logPath);

            string logFileFullName = logPath + "/" + logTitle + "_LOG【" + DateTime.Now.ToString("yyyy_MM_dd(HH_mm_ss)") + "】.txt";
            //根据日志标题存储日志文件地址
            if (DictLogFile.ContainsKey(logTitle))
                return "已有同标题日志，请不要重复创建";
            else
                DictLogFile.Add(logTitle, logFileFullName);

            //创建日志文件
            if (!File.Exists(logFileFullName))
            {
                using (FileStream fs = new FileStream(logFileFullName, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("日志");
                        sw.WriteLine("作者:HJH");
                    }
                }
            }

            return "日志文件【" + logFileFullName + "】创建成功\n在路径【" + logPath + "】";
        }

        public string GetLogFullName(string logTitle)
        {
            if (DictLogFile.ContainsKey(logTitle))
                return DictLogFile[logTitle];

            return "没有找到这个日志哟";
        }

        /// <summary>
        /// 写入普通信息到日志文件
        /// </summary>
        /// <param name="log">信息</param>
        public string WriteInfoLog(string path,string model, string log, object obj = null, string symbol = "*")
        {
            return WriteLog(path, model, log, "信息", symbol ,obj);
        }

        /// <summary>
        /// 写入警告信息到日志文件
        /// </summary>
        /// <param name="log">信息</param>
        public string WriteWarnLog(string path, string model, string log, object obj = null, string symbol = "*")
        {
            return WriteLog(path, model, log, "警告", symbol, obj);
        }

        /// <summary>
        /// 写入错误信息到日志文件
        /// </summary>
        /// <param name="log">信息</param>
        public string WriteErrorLog(string path, string model, string log, object obj = null, string symbol = "*")
        {
            return WriteLog(path, model, log, "错误", symbol, obj);
        }

        private string WriteLog(string path,string model, string log, string logType , string symbol, object obj)
        {
            StringBuilder tempLog = new StringBuilder();
            tempLog.AppendLine("\t" + StringLengthToSymbol(log, symbol));
            tempLog.AppendLine("\t由模块【" + model + "】发送来【" + logType + "】");
            if (obj != null)
                tempLog.AppendLine("\t(该消息来自于" + obj.GetType().Name + ")");
            tempLog.AppendLine("\t生成时间【" + DateTime.Now.ToString("yyyy-MM-dd") + "】\n");
            tempLog.AppendLine("\t\t" + StringLengthToSymbol(log, symbol));
            tempLog.AppendLine("\t\t" + log);
            tempLog.AppendLine("\t\t\n" + StringLengthToSymbol(log, symbol));
            tempLog.AppendLine("\t\n" + StringLengthToSymbol(log, symbol));

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    var tempLogTOByte = Encoding.UTF8.GetBytes(tempLog.ToString());
                    fs.Write(tempLogTOByte, 0, tempLogTOByte.Length);
                }
                return "日志写入【" + path + "】成功";
            }
            catch (Exception ex)
            {
                return "日志写入失败【错误信息：" + ex.Message + "】";
            }
        }

        private string StringLengthToSymbol(string anyString, string Symbol)
        {
            StringBuilder tempSbuild = new StringBuilder();
            for (int i = 0; i < anyString.Length; i++)
            {
                tempSbuild.Append(Symbol);
            }
            return tempSbuild.ToString();
        }
    }
}
