using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy System/Enemy")]
public class Enemy : ScriptableObject
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;
    public GameObject EnemyPrefab;
    public Vector3 EnemySize = new Vector3(1,1,1);
    public string name = "New Enemy";

    public float fovDeg;
    public float viewRadius;
    public float attackRange;
    public float attackDelay = 2f;  
    public int attackDamage = 1;


}
