using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobileObject : MonoBehaviour
{   
    public OVRHand rightHand;
    private Vector3 rightHandTransformPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rightHandTransformPosition = rightHand.transform.position;
        rightHandTransformPosition.y += 0.2f;
        
        gameObject.transform.position = rightHandTransformPosition;  
    }
}
