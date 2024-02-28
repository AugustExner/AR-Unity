using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    [SerializeField] private Transform target; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        //transform.RotateAround(transform.position, transform.right, 180);
        transform.rotation = Quaternion.LookRotation(transform.position - target.position);
    }
}
