using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Setting : MonoBehaviour
{
    public new string name;
    public TextMeshProUGUI textMeshPro;
    public TMP_InputField _InputField;

    public void SaveSetting()
    {
        name = _InputField.text;
        SaveSystem.SaveSetting(this);
        Debug.Log("Name will save is: " + name);
    }

    public void LoadSetting()
    {
        SettingData data = SaveSystem.LoadSetting();
        name = data.name;
        textMeshPro.text = name;
        Debug.Log("Name will load is: " + name);

    }

}
