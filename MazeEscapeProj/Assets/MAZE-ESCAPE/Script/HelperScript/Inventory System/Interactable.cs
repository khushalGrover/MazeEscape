using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
