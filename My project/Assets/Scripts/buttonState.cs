using Oculus.Interaction;
using UnityEngine;

public class buttonState : MonoBehaviour
{
    public bool isToggled = false;

    public RoundedBoxProperties roundedBoxProperties;

    // Start is called before the first frame update
    void Start()
    {
        if (roundedBoxProperties == null)
        {
            roundedBoxProperties = GetComponentInChildren<RoundedBoxProperties>();
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle()
    {
        isToggled = !isToggled;

        roundedBoxProperties.BorderInnerRadius = isToggled ? 0.1f : 0.005f;
        Debug.LogWarning("Toggle!");

    }
}
