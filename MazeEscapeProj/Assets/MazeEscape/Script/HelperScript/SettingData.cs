using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.RestService;
using UnityEngine;

[System.Serializable] 
public class SettingData
{
    public string name;

    // constractor
    public SettingData(Setting setting)
    {
        name = setting.name;
    }


}
