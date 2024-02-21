using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStateColor : MonoBehaviour
{
    [SerializeField] Material matRed;
    [SerializeField] Material matGreen;
    [SerializeField] Material matBlue;

    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRed()
    {
        myRenderer = gameObject.GetComponent<MeshRenderer>();
        myRenderer.material = matRed;
        Debug.LogWarning("RED!");
    }
    public void SetGreen()
    {
        myRenderer = gameObject.GetComponent<MeshRenderer>();
        myRenderer.material = matGreen;
    }
    public void SetBlue()
    {
        myRenderer = gameObject.GetComponent<MeshRenderer>();
        myRenderer.material = matBlue;
    }
}
