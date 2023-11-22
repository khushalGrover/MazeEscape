using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowWepon : MonoBehaviour
{
    [SerializeField] private Arrow currentArrow;
    [SerializeField] private Arrow arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private float arrowSpeed = 1f;
    [SerializeField] private float arrowLifeTime = 2f;
    [SerializeField] private int arrowDamage = 10;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private bool isReloading = false;
    [SerializeField] private string enemyTag;


    public void SetEnemy(string enmeyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Reload()
    {
        if(isReloading || currentArrow /*||GameManager.instance.state != GameState.Playing*/) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        
        currentArrow = Instantiate(arrowPrefab, arrowSpawnPoint.transform);
        currentArrow.transform.parent = arrowSpawnPoint.transform;
        currentArrow.transform.localPosition = Vector3.zero;
        currentArrow.SetEnemy(enemyTag);
        isReloading = false;
    }

    public void Fire(float firePower)
    {
        if(isReloading || currentArrow == null && GameManager.instance.state != GameState.Playing) return;

        var force = arrowSpawnPoint.TransformDirection(Vector3.forward) * firePower;
        currentArrow.Fly(force);
        currentArrow.ToggleCollider(force != Vector3.zero);
        // currentArrow.DidShoot(true);
        currentArrow = null;
        Reload();
    }

    public bool IsReady()
    {
        return (!isReloading && currentArrow == null && GameManager.instance.state == GameState.Playing);

    }

}
