using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMenu : MonoBehaviour
{
    public SimpleButton[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<SimpleButton>();     

        foreach (var  button in buttons)
        {
            button.whenToggledOn.AddListener(HandleButtonToggledOn);
        }
    }

    private void HandleButtonToggledOn(SimpleButton button)
    {
        foreach (var otherButton in buttons)
        {
            if (otherButton == button || otherButton.IsToggled == false)
                continue;

            otherButton.Toggle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
