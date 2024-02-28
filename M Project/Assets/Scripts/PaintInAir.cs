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

    private paintCheck paintCheckScript;


    private void Start()
    {
        paintCheckScript = FindObjectOfType<paintCheck>();
    }
    void Update()
    {
        if (paintCheckScript != null && paintCheckScript.canPaint)
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
                        }
                    }
                    else
                    {
                        // Draw a line in empty space (optional)
                        Vector3 endPoint = transform.position + fwd * 5f; // Adjust length as needed
                        linePoints.Add(endPoint);
                    }
                }
                else if (linePoints.Count > 0) // Clear line on unpinch
                {
                    linePoints.Clear();
                }
            }

            // Update line renderer
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
}
