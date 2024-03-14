using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    public Text timer;
    public Text remain;

    private float delta;
    private float span;

    public CarSpawner carSpawner;
    public PPSpawner ppSpawner;
    public PPSpawner2 ppSpawner2;
    private int goal = 4; 
    public bool gameOver = false;
    public bool gameWin = false;

    public bool parkingReady;
    public GameObject parkingReadyImage;
    public GameObject winImage;
    public GameObject loseImage;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
        parkingReady = false;
        delta = 240;
        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            goal = 5;
        }
        remain.text = "Remain: " + goal.ToString();
        //span = 180;
    }

    // Update is called once per frame
    void Update()
    {        
        if (goal == 0)
        {
            GameSet();
        }
        if(!gameOver&&!gameWin)
        {
            delta -= Time.deltaTime;
            timer.text = "Time : " + delta.ToString("F0");
            if (delta < 0)
            {
                gameOver = true;
            }
        }

        if (InputManager.instance.parking)
        {
            goal--; 
            remain.text = "Remain: "+goal.ToString();
            if (goal > 0)
            {
                parkingReadyImage.SetActive(false);
                if(SceneManager.GetActiveScene().name == "Stage2")
                {
                    Destroy(ppSpawner2.pp.gameObject);
                    ppSpawner2.CreateParkingZone();
                }
                else
                {
                    Destroy(ppSpawner.pp.gameObject);
                    ppSpawner.CreateParkingZone();
                }

                carSpawner.carController.CanMove = false;
                carSpawner.NextCarSpawn();

                parkingReady = false;
                InputManager.instance.parking = false;
            }
        }

        if (InputManager.instance.restart)
        {
            if (gameOver)
            {
                if (SceneManager.GetActiveScene().name == "Stage2")
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
            else if(gameWin)
            {
                if (SceneManager.GetActiveScene().name == "Stage2")
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(2);
                }
            }
           
        }
    }

    void SaveTime()
    {
        if (PlayerPrefs.GetFloat("BestTime") > delta)
        {
            PlayerPrefs.SetFloat("BestTime", delta);
        }
        else if (PlayerPrefs.GetFloat("BestTime") == 0)
        {
            PlayerPrefs.SetFloat("BestTime", delta);
        }
        
    }

    void GameSet()
    {
        gameWin = true;
        //SaveTime();
        //bestTime.text = PlayerPrefs.GetFloat("BestTime").ToString("F2")+"sec";
        winImage.SetActive(true);
        carSpawner.carController.CanMove = false;
        
    }

    public void GameOver()
    {
        loseImage.SetActive(true);
        carSpawner.carController.CanMove = false;
        gameOver = true;

    }
}
