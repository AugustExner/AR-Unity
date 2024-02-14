using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    private bool isRightIndexPinching;

    public OVRHand rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isRightIndexPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (rightHand.IsTracked)
        {
            if(isRightIndexPinching)
            {
                GrabObject(collision);
            }
        }
    }


    void GrabObject(Collision collision)
    {
        if (collision != null)
        {
            Debug.LogWarning(collision.collider.name);
            if (collision.collider.tag == "pickableTag")
            {
                Debug.LogWarning("right hand in pickableTag");
                GameObject grabbedObject = collision.gameObject;
                Vector3 grabbedPosition = grabbedObject.transform.position;
                grabbedPosition = rightHand.transform.position + grabbedPosition;
                grabbedObject.transform.position = grabbedPosition;
            }
        }
    }
}
