using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject childCursor;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject capsule;
    [SerializeField] private Material myRed;
    [SerializeField] private Material myBlue;
    private Vector3 transformPosition;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit))
            print("There is something in front of the object! - " + " Pointer: " + hit.point);
        if (hit.transform.tag == "plane")
            transformPosition = childCursor.transform.position;
            transformPosition.x = hit.point.x;
            transformPosition.z = hit.point.z;

        //Store last position
        childCursor.transform.position = transformPosition;

        if (hit.transform.tag == "colorCube") {
            MeshRenderer myrenderer = cube.GetComponent<MeshRenderer>();

            myrenderer.material = myrenderer.material == myRed ? myBlue : myRed;
            Debug.LogWarning(myrenderer.material);
        }
        if(hit.transform.tag != "colorCube") {
            MeshRenderer myrenderer = cube.GetComponent<MeshRenderer>();
            myrenderer.material = myBlue;
        }


    }
}
   