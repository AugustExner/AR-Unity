using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{

    public buttonState[] buttons;

    private Color selectedColor;

    // Start is called before the first frame update
    void Start()
    {
     buttons = GetComponentsInChildren<buttonState>();   

        foreach (var button in buttons)
        {
            button.WhenToggledOn.AddListener(HandleButtonToggledOn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleButtonToggledOn(buttonState button)
    {
        foreach (var otherButton in buttons)
        {
            if (otherButton == button || otherButton.IsToggled == false)
            {
                selectedColor = button.GetColor();
                continue;
            }
            otherButton.Toggle();
        }
    }

    public Color GetSelectedColor()
    {
        return selectedColor;
    }
}
