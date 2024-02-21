using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomHandPose : MonoBehaviour
{
    [SerializeField] private Transform thumbTip;
    [SerializeField] private Transform indexFingerTip;
    [SerializeField] private Transform middleFingerTip;
    [SerializeField] private Transform ringFingerTip;
    [SerializeField] private Transform pinkyTip;
    [SerializeField] private Transform palm;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private GameObject leftHand;

    public Renderer cubeRenderer;

    // Threshold for determining if a finger is considered extended or not
    public float bendThreshold = 0.03f;
    public float extendedThreshold = 0.07f;
    private bool hasChanged = false;

    // Update is called once per frame
    void Update()
    {
        DetectSpiderManGesture();
    }

    void DetectSpiderManGesture()
    {
        Vector3 handPoint = leftHand.transform.position;

        // Calculate distances from fingertips to palm center
        float distanceThumb = Vector3.Distance(thumbTip.position, palm.position);
        float distanceIndex = Vector3.Distance(indexFingerTip.position, palm.position);
        float distanceMiddle = Vector3.Distance(middleFingerTip.position, palm.position);
        float distanceRing = Vector3.Distance(ringFingerTip.position, palm.position);
        float distancePinky = Vector3.Distance(pinkyTip.position, palm.position);

        Debug.LogWarning(distanceMiddle);

        // Check if the gesture matches the "Spider-Man" pose
        if (IsFingerExtended(distanceIndex) && 
            IsFingerExtended(distancePinky) &&
            IsFingerBend(distanceMiddle) && 
            IsFingerBend(distanceRing))
        {
            // Spider-Man gesture detected
            Debug.Log("Spider-Man gesture detected!");

            if (!hasChanged)
            {
                //ChangeCubeColor();
                SpawnObject(handPoint.x + 0.30f, handPoint.y, handPoint.z);
                hasChanged = true;
                
            }

        } else
        {
            hasChanged = false;
        }
    }

    bool IsFingerExtended(float distance)
    {
        // A finger is considered extended if its distance to the palm center is greater than the threshold
        return distance > extendedThreshold;
    }

    bool IsFingerBend(float distance)
    {
        return distance < bendThreshold;
    }

    void ChangeCubeColor(){
        if (cubeRenderer != null)
        {
        // Check the current color of the cube and toggle it
        if (cubeRenderer.material.color == Color.red)
            {
            // If the cube is currently red, change it to white
            cubeRenderer.material.color = Color.white;
            }
        else
            {
            // If the cube is any other color, change it to red
            cubeRenderer.material.color = Color.red;
            }
        }
    }

    void SpawnObject(float x, float y, float z)
    {
        Vector3 position = new Vector3(0.1f, 0.5f, 0.0f); // Creates a new 3D Vector for the RayCast position. 
        Instantiate(spawnObject, position, Quaternion.identity); // Instaniates a gameObject based on spawnSPhere
    }
}
