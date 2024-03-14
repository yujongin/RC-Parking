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
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<InputManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static InputManager m_instance;
    public float move { get; private set; }//�� �� ������
    public float rotate { get; private set; }//���� �¿� ȸ��
    public bool parking { get; set; }// �����ϷḦ ���� ��ư 
    public bool restart { get; set; }//���� �ٽý����� ���� ��ư
    private void Awake()
    {
        if (instance != this)
        {
            // �ڽ��� �ı�
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
