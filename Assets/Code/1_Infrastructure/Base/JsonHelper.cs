using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Assets.Code._1_Infrastructure.Base
{
    public class JsonHelper
    {
        //单例模式
        private static JsonHelper _instance;
        public static JsonHelper GetInstance()
        {
            if (_instance == null)
                _instance = new JsonHelper();

            return _instance;
        }

        private JsonSerializerSettings _jsonSettings;
        private JsonHelper()
        {
            IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter();
            dateTimeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            _jsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            _jsonSettings.Converters.Add(dateTimeConverter);
        }

        public string ToJson(object obj)
        {
            try
            {
                if (obj != null)
                {
                    return JsonConvert.SerializeObject(obj, Formatting.None, _jsonSettings);
                }
                else
                {
                    return "转换失败，对象为空..";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public T FromJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, _jsonSettings);
            }
            catch
            {
                return default(T);
            }
        }

    }
}
