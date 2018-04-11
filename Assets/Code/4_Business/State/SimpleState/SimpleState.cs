using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code._4_Business.State.SimpleState
{
    public class SimpleState : _State
    {
        protected SimpleStateController Control = null;
        public SimpleState(SimpleStateController Control)
        {
            this.Control = Control;
        }

        public override void StateBegin()
        {
            base.StateBegin();
            UnityEngine.Debug.Log("场景控制器【" + Control.GetType().Name + "】");
        }

        public override void StateEnd()
        {
            base.StateEnd();
        }
    }
}
