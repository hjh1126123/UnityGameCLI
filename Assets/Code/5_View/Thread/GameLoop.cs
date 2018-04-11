using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Code._4_Business.State.SimpleState;
using Assets.Code._4_Business;

public class GameLoop : MonoBehaviour {
    private SimpleStateController Control;
    // Use this for before the initialization
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Control = new SimpleStateController();
    }

    // Use this for initialization
    private void Start () {
        SimpleMediator.GetInstance().Initialize();
        Control.SetState(new State_00_Main(Control));
	}
	
	// Update is called once per frame
	private void Update ()
    {
        Control.UpdateState();
	}

    private void OnApplicationQuit()
    {
        SimpleMediator.GetInstance().Exit();
    }
}
