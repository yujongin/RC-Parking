using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPSpawner2 : MonoBehaviour
{
    private int parkingPointNum;

    //주차장 간격
    private int term = 15;
    //왼쪽 라인 z값
    private int leftZ = -15;
    //오른쪽 라인 z값
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
        //만약에 주차가 완료되면 랜덤한 지점에 포인트 생성
        /*        if (InputManager.instance.parking)
                {
                    Destroy(pp.gameObject);
                    CreateParkingZone();
                }*/
    }

    //랜덤 한 지점에 포인트 생성
    public void CreateParkingZone()
    {
        //숫자 중복처리
        //parkingPointNum = Random.Range(0, 9);

        parkingPointNum = Random.Range(0, 12);
        while (pointNumList.Contains(parkingPointNum))
        {
            parkingPointNum = Random.Range(0, 12);
        }

        pointNumList.Add(parkingPointNum);


        //주차 지점 생성
        GameObject go = Instantiate(ParkingPoint);
        pp = go.GetComponent<ParkingPoint>();
        if (parkingPointNum < 4)
        {
            //주차장 오른쪽
            go.transform.position = new Vector3(ParkingPoint.transform.position.x + term * parkingPointNum,
                ParkingPoint.transform.position.y, leftZ);
        }
        else if(parkingPointNum>=4&&parkingPointNum<7)
        {
            //주차장 가운데
            parkingPointNum -= 5;
            go.transform.position = new Vector3(ParkingPoint.transform.position.x + term * parkingPointNum,
                ParkingPoint.transform.position.y, middleZ);
        }
        else if (parkingPointNum >= 7 && parkingPointNum < 12)
        {
            //주차장 가운데
            parkingPointNum -= 8;
            go.transform.position = new Vector3(ParkingPoint.transform.position.x + term * parkingPointNum,
                ParkingPoint.transform.position.y, rightZ);
        }
    }
}
