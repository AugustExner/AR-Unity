using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereState : MonoBehaviour
{
    [SerializeField] private Material myRed;
    [SerializeField] private Material myBlue;

    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void changeColor() {
        myRenderer = gameObject.GetComponent<MeshRenderer>();
        myRenderer.material = myRenderer.sharedMaterial == myRed ? myBlue : myRed;
        Debug.LogWarning("YES!");
    }
}
