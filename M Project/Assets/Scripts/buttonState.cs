using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class buttonState : MonoBehaviour
{
    [SerializeField]
    private bool isToggled = false;
    public bool IsToggled => isToggled;

    public RoundedBoxProperties roundedBoxProperties;

    public UnityEvent<buttonState> WhenToggledOn;

    [SerializeField]
    private Color buttonColor;

    // Start is called before the first frame update
    void Start()
    {
       // if (roundedBoxProperties == null)
       // {
       //     roundedBoxProperties = GetComponentInChildren<RoundedBoxProperties>();
       // }
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle()
    {
        isToggled = !isToggled;
        
        roundedBoxProperties.BorderOuterRadius = isToggled ? 0.015f : 0.002f;
        Debug.LogWarning("Toggle! : " + roundedBoxProperties.name);

        if (isToggled)
        {
            WhenToggledOn.Invoke(this);
        }

    }

    public Color GetColor()
    {
        return buttonColor;
    }   

}
