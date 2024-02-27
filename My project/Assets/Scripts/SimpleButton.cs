using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class SimpleButton : MonoBehaviour
{
    [SerializeField] private bool isToggled = false;


    public bool IsToggled => isToggled;
    
    

    public RoundedBoxProperties roundedBoxProperties;
    public UnityEvent<SimpleButton> whenToggledOn;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public void Toggle()
    {
        isToggled = !isToggled;
        Debug.Log("Button Toggled: " + isToggled);  

        roundedBoxProperties.BorderOuterRadius = isToggled ? 0.01f : 0f;

        if(isToggled)
        {
            whenToggledOn?.Invoke(this);
        }
    }

}
