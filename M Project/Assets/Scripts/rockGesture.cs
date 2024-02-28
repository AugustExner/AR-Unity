using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockGesture : MonoBehaviour
{
    [SerializeField] private Transform thumbTip;
    [SerializeField] private Transform indexFingerTip;
    [SerializeField] private Transform middleFingerTip;
    [SerializeField] private Transform ringFingerTip;
    [SerializeField] private Transform pinkyTip;
    [SerializeField] private Transform palm;
    [SerializeField] private GameObject menu;


    // Threshold for determining if a finger is considered extended or not
    public float bendThreshold = 0.03f;
    public bool isRockMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectRockGesture();
    }


    void DetectRockGesture()
    {
        

        // Calculate distances from fingertips to palm center
        float distanceThumb = Vector3.Distance(thumbTip.position, palm.position);
        float distanceIndex = Vector3.Distance(indexFingerTip.position, palm.position);
        float distanceMiddle = Vector3.Distance(middleFingerTip.position, palm.position);
        float distanceRing = Vector3.Distance(ringFingerTip.position, palm.position);
        float distancePinky = Vector3.Distance(pinkyTip.position, palm.position);

        // Check if the gesture matches the "Spider-Man" pose
        if (IsFingerBend(distanceIndex) &&
            IsFingerBend(distancePinky) &&
            IsFingerBend(distanceMiddle) &&
            IsFingerBend(distanceRing))
        {
<<<<<<< HEAD
            if (!isRockMove)
            {
                //Debug.Log("Rock gesture detected!");
                menu.SetActive(true);
                GetComponent<clickSound>().playClick();
                isRockMove = true;
            }
=======
            // Spider-Man gesture detected
<<<<<<< HEAD
=======
            //Debug.Log("Rock gesture detected!");
>>>>>>> 277147dacaab5636ac323f75d00bc755feaa666e
            menu.SetActive(true);
>>>>>>> f0171be724652e04af29807ecd615df89716a85f
        }
        else
        {
            menu.SetActive(false);
            isRockMove = false;
        }

    }

    bool IsFingerBend(float distance)
    {
        return distance < bendThreshold;
    }
}
