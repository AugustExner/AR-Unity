using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintInAir : MonoBehaviour
{
    public OVRHand leftHand;
    public LineRenderer lineRenderer;
    public Color lineColor;

    private bool isLeftIndexPinching = false;
    private List<Vector3> linePoints = new List<Vector3>();

    void Start()
    {
        // Ensure LineRenderer component exists
        if (!lineRenderer)
        {
            Debug.LogError("LineRenderer component is missing in PaintInAir script!");
            return;
        }

        // Set LineRenderer properties
        lineRenderer.startWidth = 0.01f; // Adjust width as needed
        lineRenderer.enabled = false; // Initially disabled
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (leftHand.IsTracked)
        {
            isLeftIndexPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

            if (isLeftIndexPinching)
            {
                if (Physics.Raycast(transform.position, fwd, out hit))
                {
                    // Ignore hits on the user's hands or controllers to avoid interference
                    if (!hit.collider.isTrigger && !hit.collider.CompareTag("Hand") && !hit.collider.CompareTag("Controller"))
                    {
                        linePoints.Add(hit.point);
                        UpdateLineRenderer();
                    }
                }
                else
                {
                    // Draw a line in empty space (optional)
                    Vector3 endPoint = transform.position + fwd * 5f; // Adjust length as needed
                    linePoints.Add(endPoint);
                    UpdateLineRenderer();
                }
            }
            else if (linePoints.Count > 0) // Clear line on unpinch
            {
                linePoints.Clear();
                UpdateLineRenderer();
            }
        }
    }

    void UpdateLineRenderer()
    {
        if (linePoints.Count > 0)
        {
            lineRenderer.positionCount = linePoints.Count;
            lineRenderer.SetPositions(linePoints.ToArray());
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
