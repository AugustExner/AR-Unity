using UnityEngine;

public class FingertipScript : MonoBehaviour
{
    public GameObject whiteboard;
    private LineRenderer lineRenderer;
    private bool isDrawing = false;


    private void Start()
    {
      lineRenderer = whiteboard.GetComponent<LineRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("whiteboard"))
        {
            StartDrawing(transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Whiteboard") && isDrawing)
        {
            DrawLine(transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Whiteboard") && isDrawing)
        {
            StopDrawing();
        }
    }

    private void StartDrawing(Vector3 position)
    {
        isDrawing = true;

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, position);
    }

    private void DrawLine(Vector3 position)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
    }

    private void StopDrawing()
    {
        isDrawing = false;
    }
}
