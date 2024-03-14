using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ViewController : MonoBehaviour
{
    public List<GameObject> cameraPos;

    public GameObject mainCamera;

    public GameObject CameraPositions;
    public int Cnum = 0;
    public Text camNum;


    // Start is called before the first frame update
    void Start()
    {     
        for (int i =0; i<CameraPositions.transform.childCount; i++)
        {
            cameraPos.Add(CameraPositions.transform.GetChild(i).gameObject);
        }
        int cam = Cnum+1;
        camNum.text = "Cam" + cam;
        CameraChange(Cnum);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver&& !GameManager.instance.gameWin)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Cnum++;
                if (Cnum >= cameraPos.Count)
                {
                    Cnum = 0;
                }
                CameraChange(Cnum);
                int cam = Cnum + 1;
                camNum.text = "Cam" + cam;
            }
        }


    }

    void CameraChange(int Cnum)
    {
        for (int i = 0; i < cameraPos.Count; i++)
        {
            if (i == Cnum)
            {
                mainCamera.transform.position = cameraPos[Cnum].transform.position;
                mainCamera.transform.rotation = cameraPos[Cnum].transform.rotation;
            }
        }
    }
}
