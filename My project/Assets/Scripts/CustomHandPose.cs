using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHandPose : MonoBehaviour
{
    [SerializeField] private Transform thumbTip;
    [SerializeField] private Transform indexFingerTip;
    [SerializeField] private Transform middleFingerTip;
    [SerializeField] private Transform ringFingerTip;
    [SerializeField] private Transform pinkyTip;
    [SerializeField] private Transform palm;

    public Renderer cubeRenderer;

    // Threshold for determining if a finger is considered extended or not
    public float extendedThreshold = 0.02f;

    // Update is called once per frame
    void Update()
    {
        DetectSpiderManGesture();
    }

    void DetectSpiderManGesture()
    {
        // Calculate distances from fingertips to palm center
        float distanceThumb = Vector3.Distance(thumbTip.position, palm.position);
        float distanceIndex = Vector3.Distance(indexFingerTip.position, palm.position);
        float distanceMiddle = Vector3.Distance(middleFingerTip.position, palm.position);
        float distanceRing = Vector3.Distance(ringFingerTip.position, palm.position);
        float distancePinky = Vector3.Distance(pinkyTip.position, palm.position);

        // Check if the gesture matches the "Spider-Man" pose
        if (IsFingerExtended(distanceIndex) && 
            IsFingerExtended(distancePinky) &&
            !IsFingerExtended(distanceMiddle) && 
            !IsFingerExtended(distanceRing))
        {
            // Spider-Man gesture detected
            Debug.Log("Spider-Man gesture detected!");
            ChangeCubeColor();
            // Trigger your action here, e.g., spawn web effect or anything related
        }
    }

    bool IsFingerExtended(float distance)
    {
        // A finger is considered extended if its distance to the palm center is greater than the threshold
        return distance > extendedThreshold;
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
}
