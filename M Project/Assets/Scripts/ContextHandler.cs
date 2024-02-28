using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextHandler : MonoBehaviour
{
    public GameObject cube;
    public GameObject menu;
    public void ChangeColorToYellow()
    {
        cube.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void ChangeColorToCyan()
    {
        cube.GetComponent<Renderer>().material.color = Color.cyan;
    }

    public void DestroyObject()
    {
        Destroy(cube);
        Destroy(menu);
    }
}
