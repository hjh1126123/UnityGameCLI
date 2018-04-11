using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Code._4_Business.Character;

namespace Assets.Code._4_Business.GameSystem.Camp
{
    public class _CampSystem : ISystem
    {
        private Dictionary<string, List<SimpleCharacter>> campSave;
        protected void DefineCamp(List<string> _CampArray) 
        {
            if(campSave == null)
            {
                campSave = new Dictionary<string, List<SimpleCharacter>>();
            }
            foreach(var _camp in _CampArray)
            {
                campSave.Add(_camp, new List<SimpleCharacter>());
            }
        }

        protected Dictionary<string, List<SimpleCharacter>> GetCampSave()
        {
            if (campSave == null)
            {
                UnityEngine.Debug.Log("campSave为空，请先定义campSave");
                return null;
            }

            return campSave;
        }
    }
}
