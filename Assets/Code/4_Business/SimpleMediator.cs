using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Code._4_Business.Factory;

using Assets.Code._4_Business.GameSystem.Camp.SimpleCamp;
using Assets.Code._4_Business.GameSystem.Memory.SimpleMemory;
using Assets.Code._4_Business.GameSystem.CharacterMgr.SimpleGameMgr;

namespace Assets.Code._4_Business
{
    public class SimpleMediator : _Business
    {
        private static SimpleMediator _instance;
        public static SimpleMediator GetInstance()
        {
            if (_instance == null)
                _instance = new SimpleMediator();


            return _instance;
        }

        #region 工厂类

        private CharacterFactory chrFac = null;
        public CharacterFactory GetCharacterFactory()
        {
            if (chrFac == null)
                chrFac = new CharacterFactory();

            return chrFac;
        }

        #endregion

        #region 游戏系统

        SimpleCamp CampSystem = null;
        SimpleMemory MemorySystem = null;
        SimpleGameMgr GameMgr = null;

        /// <summary>
        /// 初始化
        /// </summary>
        private SimpleMediator()
        {
            //系统实例化
            CampSystem = new SimpleCamp();
            MemorySystem = new SimpleMemory();
            GameMgr = new SimpleGameMgr();
        }

        #endregion

        #region 基础方法

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            CampSystem.Initialize();
            MemorySystem.Initialize();
            GameMgr.Initialize();
        }

        public override void Update()
        {
            base.Update();

            CampSystem.Update();
            MemorySystem.Update();
            GameMgr.Update();
        }

        public override void Release()
        {
            base.Release();

            CampSystem.Release();
            MemorySystem.Release();
            GameMgr.Release();
        }

        #endregion

        #region 外部接口

        #region 获取系统模块
        /// <summary>
        /// 获取队伍系统
        /// </summary>
        /// <returns></returns>
        public SimpleCamp GetCampSystem()
        {
            return CampSystem;
        }
        /// <summary>
        /// 获取内存系统
        /// </summary>
        /// <returns></returns>
        public SimpleMemory GetMemorySystem()
        {
            return MemorySystem;
        }
        /// <summary>
        /// 获取管理系统
        /// </summary>
        /// <returns></returns>
        public SimpleGameMgr GetGameMgr()
        {
            return GameMgr;
        }

        #endregion

        #endregion
    }
}
