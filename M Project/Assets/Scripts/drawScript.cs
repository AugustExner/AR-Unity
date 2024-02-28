using UnityEngine;
using UnityEngine.UIElements;

public class DrawScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isDrawing = false;
    [SerializeField]
    private GameObject menu;
    private GameObject indexFinger;
    private int positionCount = 1;


    private void Start()
    {
    }

    private void Update()
    {
        if (isDrawing)
        {

            lineRenderer.SetPosition(positionCount, indexFinger.transform.position);
            positionCount++;
        }

    }

    void OnTriggerEnter(Collider colider)
    {
        if (colider.gameObject.CompareTag("fingerTip"))
        {

            lineRenderer = gameObject.AddComponent<LineRenderer>();
            Color drawColor = menu.GetComponent<menuScript>().GetSelectedColor();
            lineRenderer.material.color = drawColor;
            lineRenderer.widthMultiplier = 1;
            positionCount = 1;
            lineRenderer.positionCount = positionCount;

            indexFinger = colider.gameObject;
            isDrawing = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        isDrawing = false;
    }
}
