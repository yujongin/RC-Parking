using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CarController : MonoBehaviour
{

    public WheelCollider[] wheels = new WheelCollider[4];
    public Transform[] tires = new Transform[4];

    public float maxF = 50.0f;
    public float power = 200.0f;
    public float rot = 45;

    public bool CanMove;
    private InputManager inputManager;
    public MeshRenderer body;

    public Rigidbody rb;

    public AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();

        CanMove = true;


        for(int i =0; i<wheels.Length; i++)
        {               
            wheels[i].ConfigureVehicleSubsteps(5, 12, 13);
        }
        //�����߽��� ����� ���缭 ���������� �����ϰ� ����
        rb.centerOfMass = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMeshesPosition();
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {

            rb.AddForce(transform.rotation * new Vector3(0, 0, inputManager.move * power));//�ڵ��� �о��ֱ�

            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = maxF * inputManager.move; // ���� ������
                if (i < 2)
                {
                    if (wheels[i].gameObject.CompareTag("Right"))
                    {
                        wheels[i].steerAngle = inputManager.rotate * 30f;
                    }
                    //���� �����϶� ���Ⱒ��
                    else if (wheels[i].gameObject.CompareTag("Left"))
                    {
                        wheels[i].steerAngle = inputManager.rotate * 30f;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 500f;
 
            }
        }
    }


    void UpdateMeshesPosition()
    {
        for(int i =0; i < wheels.Length; i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheels[i].GetWorldPose(out pos, out quat);// ���� ���� ��ǥ�迡�� ��ġ, ȸ��
            if (tires[i].gameObject.CompareTag("Right"))
            {
                tires[i].position = pos;
                tires[i].rotation = quat * Quaternion.Euler(0, -90f, 0);
            }
            //���� �����϶� ���Ⱒ��
            else if (tires[i].gameObject.CompareTag("Left"))
            {
                tires[i].position = pos;
                tires[i].rotation = quat * Quaternion.Euler(0, 90f, 0);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Right") && !collision.gameObject.CompareTag("Left"))
        {
            CanMove = false;
            GameManager.instance.GameOver();
            AudioSource AS = GetComponent<AudioSource>();
            AS.PlayOneShot(boom);
        }
    }

}
