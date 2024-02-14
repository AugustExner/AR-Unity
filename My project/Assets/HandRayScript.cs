using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRayScript : MonoBehaviour
{
    public OVRHand rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.LookRotation(rightHand.transform.position);
    }
}
