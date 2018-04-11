using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Code._4_Business.State.SimpleState;

public class State_01_Scene : SimpleState {
    public State_01_Scene(SimpleStateController Control) : base(Control)
    {
        SceneName = "State_01";
    }

    public override void StateBegin()
    {
        base.StateBegin();
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }
}
