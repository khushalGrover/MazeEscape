using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customToggle : MonoBehaviour
{
    [SerializeField] private GameObject debugPanel;
    public void whenButtonClicked()
    {
        debugPanel.SetActive(!debugPanel.activeInHierarchy);
    }
}
