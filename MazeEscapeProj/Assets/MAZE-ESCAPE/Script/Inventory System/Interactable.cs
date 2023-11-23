using UnityEngine;
using TMPro;
public class Interactable : MonoBehaviour
{
    private bool isFocus = false;
    private bool hasInteracted = false;
    private bool isInRange = false;
    private float timeElapsed;
    [SerializeField] private float delayTime = 1f;
    public float radius = 5f;
    private Transform player;
    private Transform camera;
    private Transform interactionTransform;
    // [SerializeField] private GameObject inventoryUI;
    private TextMeshPro textMesh;



    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact () 
    {
        // This method is meant to be overwritten
        
       

    }



    void Start()
    {
        // assine player and camera base on tag
        if(player == null || camera == null || textMesh == null || interactionTransform == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
            textMesh = GetComponentInChildren<TextMeshPro>();
            interactionTransform = transform;
            // inventoryUI = GameObject.FindGameObjectWithTag("InventoryUI");
        }
    }

    void Update() 
    {
        
        if (!hasInteracted) 
        { 
            UpdateTextOpacity();
        }

    }

    private void UpdateTextOpacity()
    {
        float distance = Vector3.Distance(player.position, interactionTransform.position);

        if (distance <= radius)
        {
            timeElapsed = Mathf.Clamp(timeElapsed + Time.deltaTime, 0f, delayTime);
            textMesh.transform.LookAt(new Vector3(camera.position.x, textMesh.transform.position.y, camera.position.z));
             
            if(Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }
        else
        {
            timeElapsed = Mathf.Clamp(timeElapsed - Time.deltaTime, 0f, delayTime);
        }
        float valueToLerp = timeElapsed / delayTime;
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, valueToLerp);

    }

    

}
