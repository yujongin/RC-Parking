using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSpawner : MonoBehaviour
{
    float span;
    float delta;

    public AudioClip create;

    public GameObject martCart;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        span = 30f;
        delta = 0f;
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.gameOver&& !GameManager.instance.gameWin)
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject go = Instantiate(martCart);
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            AS.PlayOneShot(create);
        }   
    }
}
