using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code._2_Model;
using Assets.Code._3_Service.XMLQuery.UnitQuery;
using Assets.Code._4_Business.Character.Attr.AttrCal;

namespace Assets.Code._4_Business.Character.Attr
{
    public class SimpleAttr
    {
        M_SimpleUnit m_SimpleUnit;
        private int Lv;
        private int HP;
        private int MP;

        //属性计算器
        private simpleAttrCal Cal;

        public SimpleAttr(string _camp, string _type, string _rarity)
        {
            X_SimpleUnitQuery query = new X_SimpleUnitQuery();
            m_SimpleUnit = query.SimpleUnit(_camp, _type, _rarity);

            Cal = new simpleAttrCal(this);
            
        }

        //等级提升
        public void LevelUp()
        {
            if (Cal == null)
                return;

            SetLv(Lv+1);
            Cal.CalAttribute();
        }

        #region Set
        public void SetLv(int val)
        {
            Lv = val;
        }
        public void SetHP(int val)
        {
            HP = val;
        }
        public void SetMP(int val)
        {
            MP = val;
        }
        #endregion

        #region Get
        public int GetLv()
        {
            return Lv;
        }
        public int GetHP()
        {
            return HP;
        }
        public int GetMP()
        {
            return MP;
        }
        public M_SimpleUnit GetModel()
        {
            return m_SimpleUnit;
        }
        #endregion
    }
}
