using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStateColor : MonoBehaviour
{
    [SerializeField] GameObject colorMenu;


    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myRenderer = gameObject.GetComponent<MeshRenderer>();
        if (colorMenu.GetComponent<menuScript>().GetSelectedColor() == null) 
        {
            myRenderer.material.color = Color.white;
        }   else
        {
            myRenderer.material.color = colorMenu.GetComponent<menuScript>().GetSelectedColor();
        }
    }
}
