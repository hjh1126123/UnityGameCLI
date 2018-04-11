using System.Collections;
using System.Collections.Generic;
using Assets.Code._1_Infrastructure.Tool;
using Assets.Code._2_Model;
using UnityEngine;

public class TEST_ONE : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        M_SimpleUnit sim_Unit_E = new M_SimpleUnit
        {
            Name = "蔡文姬",
            Str = 100,
            Dex = 100,
            Int = 100,
            Lucky = 10
        };
        XMLHelper.GetInstance().CreateDataToXML("NPC");
        XMLHelper.GetInstance().AddDataToXML("NPC", "卫士", "黄金级", sim_Unit_E);

        M_SimpleUnit sim_Unit_D = XMLHelper.GetInstance().GetDataFromXml<M_SimpleUnit>("NPC", "卫士", "黄金级");
        Debug.Log(sim_Unit_D.Name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
