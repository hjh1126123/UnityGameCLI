using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Assets.Code._4_Business.Character.Attr;

namespace Assets.Code._4_Business.Character
{
    public class SimpleCharacter
    {
        private SimpleAttr _Attr;
        private GameObject _prefab;
        /// <summary>
        /// 构造角色
        /// </summary>
        /// <param name="Attr"></param>
        /// <param name="prefab"></param>
        public SimpleCharacter(SimpleAttr Attr, GameObject prefab)
        {
            _Attr = Attr;
            _prefab = prefab;
        }


        #region Get
        /// <summary>
        /// 获取属性
        /// </summary>
        /// <returns></returns>
        public SimpleAttr GetAttr()
        {
            return _Attr;
        }
        /// <summary>
        /// 获取游戏预设
        /// </summary>
        /// <returns></returns>
        public GameObject GetPrefab()
        {
            return _prefab;
        }
        #endregion
    }
}
