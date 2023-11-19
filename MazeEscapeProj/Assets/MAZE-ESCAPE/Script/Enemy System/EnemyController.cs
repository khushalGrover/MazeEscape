using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{

    // public float fovDeg;
    // public float viewRadius;
    // public float attackRange;
    // public float attackDelay = 2f;  

    public Enemy enemy;
    [SerializeField] private ParticleSystem bloodEffect;
    [SerializeField] private Transform _spwanPoint;    

    private NavMeshAgent _agent;
    private GameObject _player;
    private GameObject _enemy;
    private float _attackTimer = 0f;
    public int EnemyCurrentHealth;

    [SerializeField] private Slider _zombieHealthBar;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        Vector3 offset = new Vector3(0, 0, 0);
        // _spwanPoint = this.transform;
        if(_spwanPoint == null)
        {
            _spwanPoint = this.transform;
        }
        else
        {
            // getting position from game manager and assign to _spwanPoint
            _spwanPoint.position = GameManager.instance.enemyPosition;
            Debug.Log("Zombie position is " + _spwanPoint.position);
        }

        _enemy = Instantiate(enemy.EnemyPrefab, _spwanPoint.position + offset, Quaternion.identity);  
        _enemy.transform.parent = this.transform;
        _enemy.transform.name = "Zombie"; 
        EnemyCurrentHealth = enemy.EnemyMaxHealth;
        this.transform.localScale = enemy.EnemySize;

        if(_zombieHealthBar == null ) _zombieHealthBar = this.GetComponentInChildren<Slider>();
        _zombieHealthBar.maxValue = enemy.EnemyMaxHealth;
        _zombieHealthBar.value = EnemyCurrentHealth;
    }


    void Update()
    {
        if(GameManager.instance.state != GameState.Playing)
        {
            return;
        }


        ZombieMovement();
    }

    private void ZombieMovement()
    {
        // to do : add zombie move animation
        Vector3 dir = _player.transform.position - transform.position;

        if(dir.magnitude > enemy.viewRadius)
        {
            // in ideal state, the zombie will not move
            // should return to original position
            _agent.SetDestination(_spwanPoint.position);
             // Debug.Log("Zombie returing to spwan point" + _spwanPoint.position);
            return;
        }
        
        if(Mathf.Abs(Vector3.Angle(transform.forward, dir)) < enemy.fovDeg)
        {
            // _player in range of zombie's view, pursue the _player
            _agent.SetDestination(_player.transform.position);

            // to do : add running animation
            if(dir.magnitude < enemy.attackRange)
            {
                // _player in the range of zombie's attack
                _agent.SetDestination(transform.position);
                
                // Check if enough time has passed since the last attack
                if (_attackTimer <= 0f)
                {
                    // Attack the _player
                    bloodEffect.Play();
                    GameManager.instance.HurtPlayer(enemy.attackDamage);

                    // Reset the attack timer
                    _attackTimer = enemy.attackDelay;
                }
                else
                {
                    // Update the attack timer
                    _attackTimer -= Time.deltaTime;
                }

            }
        }
        else
        {   
            // _player not in range of zombie's view, stop moving
            _agent.SetDestination(_spwanPoint.position);

            // to do : add ideal animation
        }
    }

    public void TakeDamage(int damage)
    {
        EnemyCurrentHealth -= damage;
        _zombieHealthBar.value = EnemyCurrentHealth;
        if(EnemyCurrentHealth <= 0)
        {
            // to do : add zombie die animation
            Debug.Log("Zombie die" + this.transform.name);
            Destroy(gameObject);
        }
    }

}
