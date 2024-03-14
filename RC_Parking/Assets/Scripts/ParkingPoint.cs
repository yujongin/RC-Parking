using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPoint : MonoBehaviour
{
    public  List<GameObject> wheelList;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.CompareTag("Right")|| other.gameObject.CompareTag("Left"))
        {
            wheelList.Add(other.gameObject);
            if (wheelList.Count == 4)
            {
                //바퀴가 4개 모두 파킹포인트에 들어왔을 때.
                GameManager.instance.parkingReadyImage.SetActive(true);
                GameManager.instance.parkingReady = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wheelList.Remove(other.gameObject);
        GameManager.instance.parkingReadyImage.SetActive(false);
        GameManager.instance.parkingReady = false;
    }
}
