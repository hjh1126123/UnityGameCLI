using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Code._1_Infrastructure.Base;
using Assets.Code._1_Infrastructure.Tool;

namespace Assets.Code._3_Service
{
    public class _Service
    {
        #region 基础类
        protected IOHelper GetIOHelper()
        {
            return IOHelper.GetInstance();
        }
        protected JsonHelper GetJsonHelper()
        {
            return JsonHelper.GetInstance();
        }
        protected RandomHelper GetRandomHelper()
        {
            return RandomHelper.GetInstance();
        }
        protected ReflectionHelper GetReflectionHelper()
        {
            return ReflectionHelper.GetInstance();
        }
        protected UnityEngineHelper GetUnityEngineHelper()
        {
            return UnityEngineHelper.GetInstance();
        }
        protected KeyHelper GetKeyHelper()
        {
            return KeyHelper.GetInstance();
        }
        #endregion

        #region 工具类
        protected LogHelper GetLogHelper()
        {
            return LogHelper.GetInstance();
        }
        protected XMLHelper GetXMLHelper()
        {
            return XMLHelper.GetInstance();
        }
        #endregion
    }
}
