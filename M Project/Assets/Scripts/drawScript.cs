using UnityEngine;

public class DrawScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isDrawing = false;
    [SerializeField] private GameObject menu;
    private GameObject indexFinger;
    private int positionCount = 0;

    private void Update()
    {
        if (isDrawing && indexFinger != null)
        {
            lineRenderer.positionCount = positionCount + 1;
            lineRenderer.SetPosition(positionCount, indexFinger.transform.position);
            positionCount++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("fingerTip"))
        {
            if (lineRenderer == null)
            {
                lineRenderer = other.gameObject.AddComponent<LineRenderer>();
                Color drawColor = menu.GetComponent<menuScript>().GetSelectedColor();
                lineRenderer.material.color = drawColor;
                lineRenderer.widthMultiplier = 0.002f; 
            }

            if (!isDrawing)
            {
                indexFinger = other.gameObject;
                isDrawing = true;
                positionCount = 0;
            }
        }
    }

   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("fingerTip"))
        {
            isDrawing = false;
        }
    }
}

