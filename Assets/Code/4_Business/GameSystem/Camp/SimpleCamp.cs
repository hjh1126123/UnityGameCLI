using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Assets.Code._4_Business.Character;

namespace Assets.Code._4_Business.GameSystem.Camp.SimpleCamp
{
    public class SimpleCamp : _CampSystem
    {
        public override void Initialize()
        {
            base.Initialize();
            DefineCamp(GetIOHelper().GetFileNameWithAnyDir(GetUnityEngineHelper().GetStreamingAssetsPath() + "UnitData", "*.xml"));
        }

        public override void Release()
        {
            base.Release();
            GetCampSave().Clear();
        }

        #region 外部接口

        public void AddUnit(string _camp,SimpleCharacter _Chr)
        {
            if (_Chr == null)
                return;

            if (!GetCampSave().ContainsKey(_camp))
            {
                GetUnityEngineHelper().DeBug("没有" + _camp + "阵营的数据文件，请检查");
                return;
            }

            GetUnityEngineHelper().DeBug("为阵营" + _camp 
                + "添加单位：" + _Chr.GetAttr().GetModel().Name);
            
            GetCampSave()[_camp].Add(_Chr);
        }

        #endregion
    }
}
