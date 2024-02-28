using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSound : MonoBehaviour
{
    public AudioClip click;
    [SerializeField] private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source.GetComponent<AudioSource>();   
    }

    public void playClick()
    {
        source.PlayOneShot(click, 0.8f);
        Debug.Log("Play Click");

    }
}
