using UnityEngine;

public class rotatingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}
