using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandrayCast : MonoBehaviour
{

    public GameObject chest;
    public GameObject hand;

    [SerializeField] private Material myMaterial;

    private bool isRightIndexPinching = false;
    public OVRHand rightHand;
    private bool hasSpawned = false;
    private bool hasPinched = false;
    private Vector3 transformPosition;

    [SerializeField] private GameObject childCursor;

    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p2 = hand.transform.position;
        Vector3 p1 = chest.transform.position;
        var delta = p2 - p1;

        // YES! It is possible to simply set the up, right or forward direction 
        // so the object is rotated accordingly
        gameObject.transform.forward = delta;

        // Set the position to the center between p1 and p2
        gameObject.transform.position = (p1 + p2) / 2f;


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        isRightIndexPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (Physics.Raycast(transform.position, fwd, out hit))
            print("There is something in front of the object! - " + " Pointer: " + hit.point);
        if (hit.transform.tag == "plane")
            transformPosition = childCursor.transform.position;
            transformPosition.x = hit.point.x;
            transformPosition.z = hit.point.z;

        // Method for lefthand pinching
        if (rightHand.IsTracked) // Checks if left hand is being tracked
        {
            if (!isRightIndexPinching) // If released reset
            {
                hasPinched = false;
                hasSpawned = false;
            }


            if (isRightIndexPinching & !hasSpawned) // Checks if a pinch is registred. And object is not already spawned. 
            {
                if (hit.transform.tag == "pickableTag" & !hasPinched)
                {
                    hasPinched = true;
                    hit.collider.GetComponent<sphereState>().changeColor();
                }
                if (hit.transform.tag != "pickableTag" & !hasSpawned)
                {
                    SpawnObject(transformPosition.x, transformPosition.y, transformPosition.z); // Calling spawn object function. 
                }
            }
        }

        //Store last position
        childCursor.transform.position = transformPosition;

        // Set the Y scale to the half of the distance between p1 and p2    
        //var scale = gameObject.transform.localScale;
        //scale.z = delta.magnitude / 2f;
        //gameObject.transform.localScale = scale;
    }

    void SpawnObject(float x, float y, float z)
    {
        Vector3 position = new Vector3(x, y, z); // Creates a new 3D Vector for the RayCast position. 
        Instantiate(spawnObject, position, Quaternion.identity); // Instaniates a gameObject based on spawnSPhere
        //MeshRenderer sphereMesh = spawnObject.GetComponent<MeshRenderer>(); // Gets the mesh from the element
        //sphereMesh.material = myMaterial; // Changes it to Nice material. 
        hasSpawned = true;
    }
}

