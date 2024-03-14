using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartCart : MonoBehaviour
{
    bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver && !GameManager.instance.gameWin)
        {
            if (move)
            {
                transform.Translate(0.1f, 0, 0);
            }
            if (transform.position.x > 80 || transform.position.x < -90)
            {
                Destroy(gameObject);
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = false;
        }
    }
}
