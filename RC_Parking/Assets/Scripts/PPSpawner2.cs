using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPSpawner2 : MonoBehaviour
{
    private int parkingPointNum;

    //������ ����
    private int term = 15;
    //���� ���� z��
    private int leftZ = -15;
    //������ ���� z��
    private int middleZ = 43;

    private int rightZ = 99;

    public List<int> pointNumList;

    public GameObject ParkingPoint;

    public ParkingPoint pp;
    // Start is called before the first frame update
    void Start()
    {
        pointNumList.Add(1);
        pointNumList.Add(5);
        pointNumList.Add(7);
        pointNumList.Add(9);
        CreateParkingZone();
    }

    // Update is called once per frame
    void Update()
    {
        //���࿡ ������ �Ϸ�Ǹ� ������ ������ ����Ʈ ����
        /*        if (InputManager.instance.parking)
                {
                    Destroy(pp.gameObject);
                    CreateParkingZone();
                }*/
    }

    //���� �� ������ ����Ʈ ����
    public void CreateParkingZone()
    {
        //���� �ߺ�ó��
        //parkingPointNum = Random.Range(0, 9);

        parkingPointNum = Random.Range(0, 12);
        while (pointNumList.Contains(parkingPointNum))
        {
            parkingPointNum = Random.Range(0, 12);
        }

        pointNumList.Add(parkingPointNum);


        //���� ���� ����
        GameObject go = Instantiate(ParkingPoint);
        pp = go.GetComponent<ParkingPoint>();
        if (parkingPointNum < 4)
        {
            //������ ������
            go.transform.position = new Vector3(ParkingPoint.transform.position.x + term * parkingPointNum,
                ParkingPoint.transform.position.y, leftZ);
        }
        else if(parkingPointNum>=4&&parkingPointNum<7)
        {
            //������ ���
            parkingPointNum -= 5;
            go.transform.position = new Vector3(ParkingPoint.transform.position.x + term * parkingPointNum,
                ParkingPoint.transform.position.y, middleZ);
        }
        else if (parkingPointNum >= 7 && parkingPointNum < 12)
        {
            //������ ���
            parkingPointNum -= 8;
            go.transform.position = new Vector3(ParkingPoint.transform.position.x + term * parkingPointNum,
                ParkingPoint.transform.position.y, rightZ);
        }
    }
}
