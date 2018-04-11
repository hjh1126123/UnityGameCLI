using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code._1_Infrastructure.Base
{
    public class RandomHelper
    {
        //单例模式
        private RandomHelper() { }
        private static RandomHelper _instance;
        public static RandomHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RandomHelper();
            }
            return _instance;
        }

        //设置Unity内置的Random种子
        public void SetUnityRandomSeed()
        {
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        }
    }
}
