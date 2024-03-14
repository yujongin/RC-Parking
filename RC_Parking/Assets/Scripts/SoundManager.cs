using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip rpm2000;
    public AudioClip rpm1000;
    public AudioClip engineStart;
    public AudioClip crash;

    AudioSource sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.move == 0)
        {
            sm.clip = rpm1000;
            if (!sm.isPlaying)
            {
                sm.Play();
            }
            sm.pitch = 1;
        }
        else if (InputManager.instance.move != 0)
        {
            sm.pitch = 1+Mathf.Abs(InputManager.instance.move / 10);
        }
        else if (InputManager.instance.parking)
        {
            sm.clip = engineStart;
            if (!sm.isPlaying)
            {
                sm.Play();
            }
        }
        

    }
}
