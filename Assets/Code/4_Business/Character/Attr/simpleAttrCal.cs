using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code._4_Business.Character.Attr.AttrCal
{
    public class simpleAttrCal
    {
        SimpleAttr simpleAttr;
        public simpleAttrCal(SimpleAttr Attr)
        {
            simpleAttr = Attr;
            CalAttribute();
        }

        public void CalAttribute()
        {
            if (simpleAttr == null)
                return;

            simpleAttr.SetHP(simpleAttr.GetModel().Str * simpleAttr.GetModel().GeniusIndex);
            simpleAttr.SetMP(simpleAttr.GetModel().Int * simpleAttr.GetModel().GeniusIndex);
        }
    }
}
