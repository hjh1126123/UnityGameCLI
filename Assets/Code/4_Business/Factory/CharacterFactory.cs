using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Code._4_Business.Character.Attr;
using Assets.Code._4_Business.Character;

namespace Assets.Code._4_Business.Factory
{
    public class CharacterFactory : _Factory
    {
        public void CreateCharacter(string _camp,string _type,string _rarity)
        {
            SimpleAttr _attr = new SimpleAttr(_camp, _type, _rarity);
            SimpleCharacter _chr = new SimpleCharacter(_attr, GetUnityEngineHelper().GetItemInResource("unit/" + _camp + "/" + _type + "/" + _rarity));

            SimpleMediator.GetInstance().GetCampSystem().AddUnit(_camp, _chr);
        }
    }
}
