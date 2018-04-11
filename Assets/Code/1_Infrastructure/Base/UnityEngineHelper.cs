using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code._1_Infrastructure.Base
{
    public class UnityEngineHelper
    {
        private static UnityEngineHelper _instance;
        public static UnityEngineHelper GetInstance()
        {
            if (_instance == null)
                _instance = new UnityEngineHelper();

            return _instance;
        }
        private UnityEngineHelper() { }

        public void DeBug(string log)
        {
            Debug.Log(log);
        }

        /// <summary>
        /// 获取streaming路径
        /// </summary>
        /// <returns></returns>
        public string GetStreamingAssetsPath()
        {
            return Application.streamingAssetsPath + "/";
        }

        /// <summary>
        /// 获取Data路径
        /// </summary>
        /// <returns></returns>
        public string GetPersistentDataPath()
        {
            return Application.persistentDataPath + "/";
        }

        /// <summary>
        /// 根据地址获取资源目录资源
        /// </summary>
        /// <param name="path">资源地址</param>
        /// <returns></returns>
        public GameObject GetItemInResource(string path)
        {
            return Resources.Load(path) as GameObject;
        }
    }
}
