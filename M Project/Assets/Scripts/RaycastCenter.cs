using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCenter : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private Vector3 transformPosition;

    public OVRHand leftHand;
    private bool isLeftIndexPinching;
    private bool hasSpawned = false;
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

        isLeftIndexPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.LogWarning("We are looking at something! " + hit.point);
        }


        if (leftHand.IsTracked) // Checks if left hand is being tracked
        {
            if (isLeftIndexPinching && hit.transform.tag == "colorTag") // If released reset
            {
                var trackedObject = hit.transform.GetComponent<MeshRenderer>();
                trackedObject.material.color = menu.GetComponent<menuScript>().GetSelectedColor();
            }
        }
    }
}
