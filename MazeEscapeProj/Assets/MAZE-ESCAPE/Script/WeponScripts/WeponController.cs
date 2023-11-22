using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponController : MonoBehaviour
{
    [SerializeField] private CrossBowWepon crossBowWepon;
    [SerializeField] private string enemyTag;
    // [SerializeField] private float currentFirePower = 0f;
    [SerializeField] private float maxFirePower;
    // private float minFirePower = 0f;
    [SerializeField] private float firePower;
    [SerializeField] private float firePowerSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float minRotation = -45f;
    [SerializeField] private float maxRotation = 45f;
    private float mouseY;
    private bool isFiring = false;

    // getter and setter of isFiring
    public bool IsFiring
    {
        get => isFiring;
        set => isFiring = value;
    }


    void Start()
    {
        crossBowWepon.SetEnemy(enemyTag);
        crossBowWepon.Reload();


    }

    void Update ()
    {
        if(GameManager.instance.state != GameState.Playing)
        {
            return;
        }
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, minRotation, maxRotation);
        crossBowWepon.transform.localRotation = Quaternion.Euler(mouseY, crossBowWepon.transform.localEulerAngles.y, crossBowWepon.transform.localEulerAngles.z);

        GameManager.instance.UpdatePowerSlider(firePower, maxFirePower);
        if(Input.GetMouseButtonDown(0))
        {
            isFiring = true;

        }

        if(isFiring && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
        }

        if(isFiring && Input.GetMouseButtonUp(0))
        {
            crossBowWepon.Fire(firePower);
            firePower = 0f;
            isFiring = false;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            crossBowWepon.Reload();
        }

        

    }

}
