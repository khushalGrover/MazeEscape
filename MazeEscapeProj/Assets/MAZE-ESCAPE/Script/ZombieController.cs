using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieController : MonoBehaviour
{

    public float fovDeg;
    public float radius;
    public float attackRange;
    public float attackDelay = 2f;  
    public ParticleSystem bloodEffect;
    [SerializeField] private Transform _spwanPoint;
    private NavMeshAgent _agent;
    private GameObject _player;
    private float attackTimer = 0f;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        // _spwanPoint = this.transform;
        if(_spwanPoint == null)
        {
            _spwanPoint = this.transform;
        }
        else
        {
            // getting position from game manager and assign to _spwanPoint
            _spwanPoint.position = GameManager.instance.zombiePosition;
            Debug.Log("Zombie position is " + _spwanPoint.position);
        }
    }


    void Update()
    {
        ZombieMovement();
    }

    private void ZombieMovement()
    {
        // to do : add zombie move animation
        Vector3 dir = _player.transform.position - transform.position;

        if(dir.magnitude > radius)
        {
            // in ideal state, the zombie will not move
            // should return to original position
            _agent.SetDestination(_spwanPoint.position);
            Debug.Log("Zombie returing to spwan point" + _spwanPoint.position);
            return;
        }
        
        if(Mathf.Abs(Vector3.Angle(transform.forward, dir)) < fovDeg)
        {
            // _player in range of zombie's view, pursue the _player
            _agent.SetDestination(_player.transform.position);

            // to do : add running animation

            if(dir.magnitude < attackRange)
            {
                // _player in the range of zombie's attack
                _agent.SetDestination(transform.position);
                // Check if enough time has passed since the last attack
                if (attackTimer <= 0f)
                {
                    // Attack the _player
                    bloodEffect.Play();
                    GameManager.instance.HurtPlayer(1);

                    // Reset the attack timer
                    attackTimer = attackDelay;
                }
                else
                {
                    // Update the attack timer
                    attackTimer -= Time.deltaTime;
                }

            }
        }
        else
        {   
            // _player not in range of zombie's view, stop moving
            _agent.SetDestination(transform.position);

            // to do : add ideal animation
        }
    }

   

}
