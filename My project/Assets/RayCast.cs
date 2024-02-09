using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject childCursor;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject capsule;
    [SerializeField] private Material myRed;
    [SerializeField] private Material myBlue;
    private Vector3 transformPosition;

    public OVRHand leftHand;
    private bool isLeftIndexPinching;
    private bool hasSpawned = false;

    public GameObject spawnSphere;

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

        isLeftIndexPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (Physics.Raycast(transform.position, fwd, out hit))
            print("There is something in front of the object! - " + " Pointer: " + hit.point);
        if (hit.transform.tag == "plane")
            transformPosition = childCursor.transform.position;
            transformPosition.x = hit.point.x;
            transformPosition.z = hit.point.z;

        // Method for lefthand pinching
        if (leftHand.IsTracked) // Checks if left hand is being tracked
            if (isLeftIndexPinching && !hasSpawned) // Checks if a pinch is registred. And object is not already spawned. 
                SpawnObject(transformPosition.x, transformPosition.y, transformPosition.z); // Calling spawn object function. 
            else if (!isLeftIndexPinching && hasSpawned) // Else if released change hasSpawned to false again. 
                hasSpawned = false;

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
    // Spawn object method
    void SpawnObject(float x, float y, float z)
    {
        Vector3 position = new Vector3(x, y,z); // Creates a new 3D Vector for the RayCast position. 
        Instantiate(spawnSphere, position, Quaternion.identity); // Instaniates a gameObject based on spawnSPhere
        MeshRenderer sphereMesh = spawnSphere.GetComponent<MeshRenderer>(); // Gets the mesh from the element
        sphereMesh.material = myRed; // Changes it to red. 
        hasSpawned = true;
    }
}
   