using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<InputManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static InputManager m_instance;
    public float move { get; private set; }//앞 뒤 움직임
    public float rotate { get; private set; }//바퀴 좌우 회전
    public bool parking { get; set; }// 주차완료를 위한 버튼 
    public bool restart { get; set; }//게임 다시시작을 위한 버튼
    private void Awake()
    {
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");

        if (GameManager.instance.parkingReady)
        {
            parking = Input.GetKeyDown(KeyCode.Space);           
            //Debug.Log(parking);         
        }

        if (GameManager.instance.gameOver||GameManager.instance.gameWin)
        {
            restart = Input.GetKeyDown(KeyCode.R);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if(SceneManager.GetActiveScene().name == "Stage1")
            {
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
