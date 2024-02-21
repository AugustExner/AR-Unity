using UnityEngine;

public class buttonState : MonoBehaviour
{
    [SerilizedField] Material gray;
    [SerilizedField] Material white;
    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setActive()
    {
        if (gameObject.GetComponent<MeshRenderer>().material = gray) 
        { 
            setInactive(); 
        } else 
        {
            gameObject.GetComponent<MeshRenderer>().material = gray;
        }

    }
    public void setInactive()
    {
        gameObject.GetComponent<MeshRenderer>().material = white;
    }
}
