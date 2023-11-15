using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class testZomController : MonoBehaviour
{

    public float fovDeg;
    public float radius;
    public float attackRange;
    [SerializeField] private Transform _spwanPoint;
    private NavMeshAgent _agent;
    private GameObject _player;



    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        // _spwanPoint = this.transform;
        if(_spwanPoint == null)
        {
            _spwanPoint = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 dir = _player.transform.position - transform.position;
        

        if(dir.magnitude > radius)
        {
            // in ideal state, the zombie will not move
            // should return to original position
            _agent.SetDestination(_spwanPoint.position);
           

            return;
        }
        
        if(Mathf.Abs(Vector3.Angle(transform.forward, dir)) < fovDeg)
        {
            // _player in range of zombie's view, pursue the _player
            _agent.SetDestination(_player.transform.position);

            // to do : add running animation

            if(dir.magnitude < attackRange)
            {
                // _player in range of zombie's attack, attack the _player
                Debug.Log("attack");
                // reducing _player health after some delay

                // to do : add attack animation, sound and spash effect

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
