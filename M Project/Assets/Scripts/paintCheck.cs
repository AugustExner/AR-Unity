using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintCheck : MonoBehaviour
{
    public bool canPaint = false;
    public void togglePaint (){
        
        if (!canPaint)
        {
            canPaint = true;
            Debug.Log("Paint: true");
        }
        else
        {
            canPaint = false;
            Debug.Log("Paint:" + canPaint);
        }
    }
}
