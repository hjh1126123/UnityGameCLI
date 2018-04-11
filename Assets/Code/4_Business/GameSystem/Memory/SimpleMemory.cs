using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code._4_Business.GameSystem.Memory.SimpleMemory
{
    public class SimpleMemory : _Memory
    {
        /// <summary>
        /// 存储按钮
        /// </summary>
        /// <param name="buttonName"></param>
        public void SaveButton(string buttonName)
        {
            SaveItem("Button", buttonName, UnityEngine.GameObject.Find(buttonName));
        }

        /// <summary>
        /// 根据名称取得按钮对象
        /// </summary>
        /// <param name="ButtonName"></param>
        /// <returns></returns>
        public UnityEngine.GameObject GetButton(string ButtonName)
        {
            var ButtonObj = GetItem("Button", ButtonName) as UnityEngine.GameObject;
            if (ButtonObj is UnityEngine.GameObject)
            {
                return ButtonObj;
            }

            return null;
        }
    }
}
