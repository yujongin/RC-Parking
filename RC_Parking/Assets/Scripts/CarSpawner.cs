using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> carList;

    public CarController carController;
    public bool Ready;

    private MeshRenderer testRenderer;

    // Start is called before the first frame update
    void Start()
    {
        NextCarSpawn();
    }

    // Update is called once per frame
    void Update()
    {   
/*        if (InputManager.instance.parking)
        {
            carController.CanMove = false;
            NextCarSpawn();
        }*/
    }

    public void NextCarSpawn()
    {

        int c = Random.Range(0, carList.Count);
        GameObject go = Instantiate(carList[c]);
        carController = go.GetComponent<CarController>();
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;

        testRenderer = carController.body;

    }
}
