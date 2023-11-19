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
    [SerializeField] private string enemyTag = "Enemy";
    private bool didHit = false;

    public void SetEnemy(string enmeyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force * _speed, ForceMode.Impulse);
        rigidbody.AddTorque(transform.forward * torque, ForceMode.Impulse);
        transform.parent = null;

    }

    void OnTriggerEnter(Collider collider)
    {
        if(didHit) return;
        didHit = true;

        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyController>().TakeDamage(_damage);
            // Debug.Log("enemy taking damge "+_damage +"  !!!!!!! " + collider.gameObject.name + " , with tag " + collider.gameObject.tag);
        }
        else
        {
            // Instantiate(_hitEffect, transform.position, Quaternion.identity);
            // Debug.Log("Arrow hit " + collider.gameObject.name);
        }

        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        Destroy(gameObject, _lifeTime);
        // transform.SetParent(collider.transform);
        // Debug.Log("Arrow hit " + collider.gameObject.name + " , with tag " + collider.gameObject.tag);

        
    }

}
