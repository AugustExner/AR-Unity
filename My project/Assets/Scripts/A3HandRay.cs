using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A3HandRay : MonoBehaviour
{
    private bool isRightIndexPinching = false;
    public OVRHand rightHand;

    public GameObject chestPoint;
    public GameObject handPoint;

    private GameObject pickedObject;

    private Vector3 handTransformPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p2 = handPoint.transform.position;
        Vector3 p1 = chestPoint.transform.position;
        var delta = p2 - p1;

        // Object is rotated accordingly
        gameObject.transform.forward = delta;

        // Set the position to the center between p1 and p2
        gameObject.transform.position = (p1 + p2) / 2f;


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (rightHand.IsTracked)
        {   
            isRightIndexPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                if (hit.transform.tag == "pickableTag" && isRightIndexPinching && pickedObject == null)
                {
                    Debug.LogWarning("It is pickable!");
                    pickedObject = hit.transform.gameObject;
                } 

                if (isRightIndexPinching)
                {

                    Vector3 moveVector = handTransformPosition - rightHand.transform.position;
                    pickedObject.transform.position -= moveVector * 10;
                } else
                {
                    pickedObject = null;
                }
            }
            handTransformPosition = rightHand.transform.position;
        }
        
    }
}
