using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A3HandRay : MonoBehaviour
{
    private bool isRightIndexPinching = false;
    private bool isLeftIndexPinching = false;

    private bool isScaling = false;

    public OVRHand rightHand;
    public OVRHand leftHand;

    public GameObject chestPoint;
    public GameObject handPoint;

    private GameObject pickedObject;

    private Vector3 rightHandTransformPosition;
    private Vector3 rightHandTransformRotation;
    private float handDistance;
    
    private Vector3 originalScale;


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
                if (isRightIndexPinching)
                {
                    if (pickedObject == null)
                    {
                        pickedObject = hit.transform.gameObject;
                    }
                    switch(pickedObject.transform.tag)
                    {
                        case "MoveCube":
                            moveObject(hit);
                        break;
                        case "ScaleCube":
                            resizeObject(hit); 
                        break;
                        case "RotateCube":
                            rotation(hit); 
                        break;

                    }
                }
                else
                {
                    pickedObject = null;
                }
            }
            rightHandTransformPosition = rightHand.transform.position;
            rightHandTransformRotation = rightHand.transform.eulerAngles;
        }
        
    }

    void moveObject(RaycastHit hit)
    {
        Vector3 moveVector = rightHandTransformPosition - rightHand.transform.position;
        pickedObject.transform.position -= moveVector * 5;
    }

    void resizeObject(RaycastHit hit)
    {
        if (leftHand.IsTracked)
        {
            isLeftIndexPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
            if (isLeftIndexPinching)
            {
                if (!isScaling)
                {
                    isScaling = true;
                    originalScale = pickedObject.transform.localScale;
                    handDistance = rightHand.transform.position.x - leftHand.transform.position.x;
                }


                var scaleFactor = handDistance / (rightHand.transform.position.x - leftHand.transform.position.x);
                var newScale = originalScale / scaleFactor;

                Debug.LogWarning(rightHand.transform.position.x + " | " + leftHand.transform.position.x + " | " + handDistance + " | " + newScale);



                pickedObject.transform.localScale = newScale;
                Debug.Log("scale it");
                // var scale = pickedObject.transform.localScale;
                //Vector3 deltaHands = rightHand.transform.position - leftHand.transform.position;
                //scale.z += 0.1f;

                //Note: Apply scale on X upon cameras X cordinate. 
            }
            else
            {
                isScaling = false;
            }
        }
    }

    void rotation(RaycastHit hit)
    {
        Vector3 objectStartRotation = pickedObject.transform.eulerAngles;

        objectStartRotation.y -= rightHandTransformRotation.y - rightHand.transform.eulerAngles.y;
        pickedObject.transform.eulerAngles = objectStartRotation;
    }
}
