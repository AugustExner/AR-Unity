using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAndPinchInteraction : MonoBehaviour
{
    public OVRHand leftHand;    

    private bool isLeftIndexPinching = false;
    private bool hasPinched = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (leftHand.IsTracked)
        {
            isLeftIndexPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
            if(Physics.Raycast(transform.position, fwd, out hit))
                
            {
                if (isLeftIndexPinching)
                {

                    Debug.LogWarning(hit.transform.gameObject.name);
                    if (!hasPinched && hit.transform != null)
                    {
                        Debug.LogWarning("Pinch Bitch");
                        hasPinched = true;
                        var pickedObject = hit.transform.gameObject;
                        pickedObject.GetComponentInParent<buttonState>().Toggle();
                        pickedObject.GetComponentInParent<clickSound>().playClick();

                    }
                }
                else {
                    hasPinched = false;
                }
            }
        }


    }
}
