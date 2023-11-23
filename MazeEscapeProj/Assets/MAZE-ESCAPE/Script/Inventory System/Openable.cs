using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable  : Interactable
{
    public bool isLocked;
    public override void Interact()
    {
        base.Interact();

        Opening();
    }

    public Vector3 OpenRotation;

    void Opening()
    {
        // check is this have openable tag
        if (this.transform.tag == "Openable" && !isLocked)
        {
            Debug.Log("door is unlocked");  
            // rotate the Item by 90 degree
            transform.Rotate(OpenRotation);
            Debug.Log("Door Open");

            // change the tag of the Item to prevent from opening again
            this.transform.tag = "Untagged";
            return;
        }
        else if(this.transform.tag == "Openable" && isLocked)
        {
            Debug.Log("door is locked");
            return;
        }
        else 
        {
            Debug.Log("door is already open");
            return;
        }

        // rotate the Item by 90 degree
        transform.Rotate(OpenRotation);
        Debug.Log("Door Open");

        // change the tag of the Item to prevent from opening again
        this.transform.tag = "Untagged";
        
        
        
    }
}
