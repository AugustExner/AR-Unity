using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ContextMenu: MonoBehaviour
{
    public GameObject contextMenu;
    private bool contextMenuActive = false; 

    // Called when a collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a controller
        if (other.gameObject.CompareTag("fingerTip"))
        {
            if (!contextMenuActive)
            {
                Debug.Log("Set Context True");
                contextMenu.SetActive(true);
                // Set the context menu flag to active
                contextMenuActive = true;
            }
            else
            {
                Debug.Log("Set Context false");
                contextMenu.SetActive(false);
                contextMenuActive = false;
            }
        }
    }
}
