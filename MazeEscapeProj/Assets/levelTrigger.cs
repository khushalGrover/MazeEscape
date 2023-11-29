using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is the player
        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoadNextLevel();
        }
    }
}
