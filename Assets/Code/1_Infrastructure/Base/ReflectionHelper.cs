using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assets.Code._1_Infrastructure.Base
{
    public class ReflectionHelper
    {
        //单例模式
        private ReflectionHelper() { }
        private static ReflectionHelper _instance;
        public static ReflectionHelper GetInstance()
        {
            if (_instance == null)
                _instance = new ReflectionHelper();
            return _instance;
        }

        #region 基础工具
        /// <summary>
        /// 通过完全限定名来实例化类
        /// </summary>
        /// <param name="spaceName">命名空间</param>
        /// <param name="className">类的名称</param>
        /// <returns></returns>
        public object CreateClassInstance(string spaceName, string className)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.CreateInstance(spaceName + className);
        }

        /// <summary>
        /// 通过反射设置值
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="Value">数值</param>
        /// <param name="obj">需要设定对象</param>
        /// <returns></returns>
        public bool SetPropertyValue(string FieldName, string Value, object obj)
        {
            try
            {
                Type type = obj.GetType();
                object o = Convert.ChangeType(Value, type.GetProperty(FieldName).PropertyType);
                type.GetProperty(FieldName).SetValue(obj, o, null);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 通过反射获取值
        /// </summary>
        /// <param name="FieldName">字段名称</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public string GetPropertyValue(string FieldName, object obj)
        {
            try
            {
                Type type = obj.GetType();
                object o = type.GetProperty(FieldName).GetValue(obj, null);
                string Value = Convert.ToString(o);
                if (String.IsNullOrEmpty(Value)) { return Value; }
                else { return Value; }
            }
            catch{ return "获取值失败"; }
        }

        #endregion

        #region 额外工具

        /// <summary>
        /// 通过反射获取类的所有Public属性
        /// </summary>
        /// <typeparam name="Model"></typeparam>
        /// <returns></returns>
        public List<string> GetAllProName<Model>()
        {
            PropertyInfo[] pros = typeof(Model).GetProperties();

            List<string> tempList = new List<string>();
            foreach (var pro in pros)
            {
                tempList.Add(pro.Name);
            }
            return tempList;
        }

        /// <summary>
        /// 通过反射获取枚举类所有枚举
        /// </summary>
        /// <typeparam name="CusEnum"></typeparam>
        /// <returns></returns>
        public List<string> GetEnum<CusEnum>()
        {
            var fields = typeof(CusEnum).GetFields(BindingFlags.Static | BindingFlags.Public);
            var listStr = new List<string>();
            foreach(var fl in fields)
            {
                listStr.Add(fl.Name);
            }

            return listStr;
        }

        #endregion

    }
}
