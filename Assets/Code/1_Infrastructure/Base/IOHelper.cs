using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.Code._1_Infrastructure.Base
{
    public class IOHelper
    {
        //单例模式
        private static IOHelper _instance;
        public static IOHelper GetInstance()
        {
            if (_instance == null)
                _instance = new IOHelper();

            return _instance;
        }
        private IOHelper() { }

        /// <summary>
        /// 获取某路径下所有文件夹名
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public List<string> GetFolderNameWithAnyDir(string path)
        {
            List<string> list = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(path);
            foreach(var dir in folder.GetDirectories())
            {
                list.Add(dir.Name);
            }
            return list;
        }

        /// <summary>
        /// 获取某路径下所有文件的文件名
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="postfix">文件后缀</param>
        /// <returns></returns>
        public List<string> GetFileNameWithAnyDir(string path,string postfix)
        {
            List<string> list = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(path);
            foreach(var file in folder.GetFiles(postfix))
            {
                list.Add(file.Name);
            }
            return list;
        }
    }
}