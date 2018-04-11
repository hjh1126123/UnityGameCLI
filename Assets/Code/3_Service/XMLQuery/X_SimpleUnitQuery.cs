using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code._2_Model;

namespace Assets.Code._3_Service.XMLQuery.UnitQuery
{
    public class X_SimpleUnitQuery : _Service
    {
        public M_SimpleUnit SimpleUnit(string _camp, string _type, string _rarity)
        {
            return GetXMLHelper().GetDataFromXml<M_SimpleUnit>(_camp, _type, _rarity);
        }
    }
}
