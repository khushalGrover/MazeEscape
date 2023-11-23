using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _lifeTime = 60f;
    // [SerializeField] private GameObject _hitEffect;
    // [SerializeField] private GameObject _arrowPrefab;
    // [SerializeField] private GameObject _arrowSpawnPoint;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float torque = 5f;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Collider triggerCollider;
    [SerializeField] private string enemyTag = "Enemy";
    private bool didHit = false;
    private bool didShoot = false;

    public void SetEnemy(string enmeyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void ToggleCollider(bool value)
    {
        triggerCollider.enabled = value;
    }

    public void Fly(Vector3 force)
    {
        Debug.Log("Arrow Fly");
        triggerCollider.enabled = true;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force * _speed, ForceMode.Impulse);
        rigidbody.AddTorque(transform.forward * torque, ForceMode.Impulse);
        transform.parent = null;

    }

    void OnTriggerEnter(Collider collider)
    {
        if(didHit) return;

        // Debug.Log("Trigger ENTER");
        didHit = true;

        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyController>().TakeDamage(_damage);
            // Destroy(gameObject, _lifeTime );
            transform.SetParent(collider.transform);
            
           
        }

        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        // Destroy(gameObject, _lifeTime );
        


        
    }

}
