using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Code._4_Business.State.SimpleState;

public class State_00_Main : SimpleState {
    public State_00_Main(SimpleStateController Control) : base(Control)
    {
        SceneName = "01_Main";
    }

    public override void StateBegin()
    {
        base.StateBegin();

        GetMediator().GetMemorySystem().SaveButton("GONextBtn");

        GameObject GoNextBtn = GetMediator().GetMemorySystem().GetButton("GONextBtn");
        GoNextBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
        {
            Control.SetState(new State_01_Scene(Control));
        });

        GetMediator().GetGameMgr().AddData("Human","村民",'&',"名字&林翔","STR&10","DEX&10","INT&10","GENIUS&10");
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }
}
