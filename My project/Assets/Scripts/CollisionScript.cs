using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Gets called at the start of the collision 
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("pickableTag"))
        {
            Destroy(collider.gameObject);
        }
        Debug.Log("Entered collision with " + collider.gameObject.name);
    }



}
