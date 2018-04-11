using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code._4_Business.State
{
    public class _State : _Business
    {
        protected string SceneName;
        public string GetSceneName()
        {
            return SceneName;
        }

        public virtual void StateBegin() { UnityEngine.Debug.Log("进入场景【" + SceneName + "】"); }

        public virtual void StateUpdate() { }

        public virtual void StateEnd() { UnityEngine.Debug.Log("离开场景【" + SceneName + "】"); }


        protected SimpleMediator GetMediator()
        {
            return SimpleMediator.GetInstance();
        }
    }
}

