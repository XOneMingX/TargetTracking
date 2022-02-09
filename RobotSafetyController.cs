using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSafetyController : MonoBehaviour
{
    private GameObject getRobot;
    public GameObject[] robotJoints;
    public ArticulationBody[] articulation;

    private int motionOrder = 0;

    private float baseRotation;
    private float shoudlerRotation;
    private float elbowRotation;
    private float wrist01Rotation;
    private float wrist02Rotation;
    private float handRotation;

    float rotationSpeed = 40f;

    private ConnectServer client;
    private string editString;

    private SafetyDetection safety;

    void Awake()
    {
        client = GameObject.FindObjectOfType<ConnectServer>();
    }

    void Start()
    {
        initializeJoints();

    }

    // Update is called once per frame
    void Update()
    {
        safety = GameObject.FindObjectOfType<SafetyDetection>();

        if (motionOrder == 1)
        {
            movement_Up1();
        }
        if (motionOrder == 2)
        {
            movement_Up2();
        }
        if (motionOrder == 3)
        {
            movement_Up3();
        }
        if (motionOrder == 4)
        {
            movement_Down1();
        }
        if (motionOrder == 5)
        {
            movement_Down2();
        }
        if (motionOrder == 6)
        {
            movement_Center();
        }

        //Debug.Log(motionOrder);
    }

    void initializeJoints()
    {
        getRobot = this.gameObject;
        Transform[] getJoints = getRobot.transform.GetChild(0).GetComponentsInChildren<Transform>(true);
        robotJoints = new GameObject[6];
        articulation = new ArticulationBody[6];
        for (int i = 0; i < getJoints.Length; i++)
        {
            if (getJoints[i].name == "Base")
            {
                robotJoints[0] = getJoints[i].gameObject;
            }
            if (getJoints[i].name == "Shoulder")
            {
                robotJoints[1] = getJoints[i].gameObject;
            }
            if (getJoints[i].name == "Elbow")
            {
                robotJoints[2] = getJoints[i].gameObject;
            }
            if (getJoints[i].name == "Wrist01")
            {
                robotJoints[3] = getJoints[i].gameObject;
            }
            if (getJoints[i].name == "Wrist02")
            {
                robotJoints[4] = getJoints[i].gameObject;
            }
            if (getJoints[i].name == "Wrist03")
            {
                robotJoints[5] = getJoints[i].gameObject;
            }
        }
        for (int j = 0; j < robotJoints.Length; j++)
        {
            if (robotJoints[j] != null)
            {
                articulation[j] = robotJoints[j].GetComponent<ArticulationBody>();
            }
        }
    }



    public void rotateMotion_up1()
    {
        if (safety.safetyDistance > 2f)
        {
            rotationSpeed = 40f;
            editString = "up1_fast\n";
            client.SocketSend(editString);
            motionOrder = 1;
        }
        else
        {
            rotationSpeed = 20f;
            editString = "up1\n";
            client.SocketSend(editString);
            motionOrder = 1;
        }
    }
    public void rotateMotion_up2()
    {
        if (safety.safetyDistance > 2f)
        {
            rotationSpeed = 40f;
            editString = "left_fast\n";
            client.SocketSend(editString);
            motionOrder = 2;
        }
        else
        {
            rotationSpeed = 20f;
            editString = "left\n";
            client.SocketSend(editString);
            motionOrder = 2;
        }

    }
    public void rotateMotion_up3()
    {
        if (safety.safetyDistance > 2f)
        {
            rotationSpeed = 40f;
            editString = "right_fast\n";
            client.SocketSend(editString);
            motionOrder = 3;
        }
        else
        {
            rotationSpeed = 20f;
            editString = "right\n";
            client.SocketSend(editString);
            motionOrder = 3;
        }

    }
    public void rotateMotion_down1()
    {
        if (safety.safetyDistance > 2f)
        {
            rotationSpeed = 40f;
            editString = "reset_fast\n";
            client.SocketSend(editString);
            motionOrder = 4;
        }
        else
        {
            rotationSpeed = 20f;
            editString = "reset\n";
            client.SocketSend(editString);
            motionOrder = 4;
        }

    }
    public void rotateMotion_down2()
    {
        motionOrder = 5;

    }
    public void rotateMotion_center()
    {
        motionOrder = 6;

    }

    void movement_Up1()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != -83.44f)
        {
            if (articulation[0].xDrive.target > -83.44f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -83.44f)
                {
                    baseRotation = -83.44f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -83.44f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -83.44f)
                {
                    baseRotation = -83.44f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 32.87f)
        {
            if (articulation[1].xDrive.target > 32.87f)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 32.87f)
                {
                    shoudlerRotation = 32.87f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 32.87f)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 32.87f)
                {
                    shoudlerRotation = 32.87f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -87.1f)
        {
            if (articulation[2].xDrive.target > -87.1f)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -87.1f)
                {
                    elbowRotation = -87.1f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -87.1f)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -87.1f)
                {
                    elbowRotation = -87.1f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 1.04f)
        {
            if (articulation[3].xDrive.target > 1.04f)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 1.04f)
                {
                    wrist01Rotation = 1.04f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 1.04f)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 1.04f)
                {
                    wrist01Rotation = 1.04f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 86.55f)
        {
            if (articulation[4].xDrive.target > 86.55f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 86.55f)
                {
                    wrist02Rotation = 86.55f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 86.55f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 86.55f)
                {
                    wrist02Rotation = 86.55f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }
    void movement_Up2()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != -45.32f)
        {
            if (articulation[0].xDrive.target > -45.32f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -45.32f)
                {
                    baseRotation = -45.32f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -45.32f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -45.32f)
                {
                    baseRotation = -45.32f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 29.02f)
        {
            if (articulation[1].xDrive.target > 29.02f)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 29.02f)
                {
                    shoudlerRotation = 29.02f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 29.02f)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 29.02f)
                {
                    shoudlerRotation = 29.02f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -104.73f)
        {
            if (articulation[2].xDrive.target > -104.73f)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -104.73f)
                {
                    elbowRotation = -104.73f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -104.73f)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -104.73f)
                {
                    elbowRotation = -104.73f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 13.92f)
        {
            if (articulation[3].xDrive.target > 13.92f)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 13.92f)
                {
                    wrist01Rotation = 13.92f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 13.92f)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 13.92f)
                {
                    wrist01Rotation = 13.92f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 86.61f)
        {
            if (articulation[4].xDrive.target > 86.61f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 86.61f)
                {
                    wrist02Rotation = 86.61f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 86.61f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 86.61f)
                {
                    wrist02Rotation = 86.61f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }

    void movement_Up3()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != -101.17f)
        {
            if (articulation[0].xDrive.target > -101.17f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -101.17f)
                {
                    baseRotation = -101.17f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -101.17f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -101.17f)
                {
                    baseRotation = -101.17f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 28.95f)
        {
            if (articulation[1].xDrive.target > 28.95f)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 28.95f)
                {
                    shoudlerRotation = 28.95f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 28.95f)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 28.95f)
                {
                    shoudlerRotation = 28.95f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -104.72f)
        {
            if (articulation[2].xDrive.target > -104.72f)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -104.72f)
                {
                    elbowRotation = -104.72f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -104.72f)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -104.72f)
                {
                    elbowRotation = -104.72f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 13.89f)
        {
            if (articulation[3].xDrive.target > 13.89f)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 13.89f)
                {
                    wrist01Rotation = 13.89f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 13.89f)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 13.89f)
                {
                    wrist01Rotation = 13.89f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 86.66f)
        {
            if (articulation[4].xDrive.target > 86.66f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 86.66f)
                {
                    wrist02Rotation = 86.66f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 86.66f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 86.66f)
                {
                    wrist02Rotation = 86.66f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }

    void movement_Down1()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target !=  -83.45f)
        {
            if (articulation[0].xDrive.target >  -83.45f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target <  -83.45f)
                {
                    baseRotation =  -83.45f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target <  -83.45f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target >  -83.45f)
                {
                    baseRotation =  -83.45f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 29.06f)
        {
            if (articulation[1].xDrive.target > 29.06f)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 29.06f)
                {
                    shoudlerRotation = 29.06f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 29.06f)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 29.06f)
                {
                    shoudlerRotation = 29.06f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -104.71f)
        {
            if (articulation[2].xDrive.target > -104.71f)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -104.71f)
                {
                    elbowRotation = -104.71f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -104.71f)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -104.71f)
                {
                    elbowRotation = -104.71f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 10.93f)
        {
            if (articulation[3].xDrive.target > 10.93f)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 10.93f)
                {
                    wrist01Rotation = 10.93f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 10.93f)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 10.93f)
                {
                    wrist01Rotation = 10.93f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 86.61f)
        {
            if (articulation[4].xDrive.target > 86.61f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 86.61f)
                {
                    wrist02Rotation = 86.61f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 86.61f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 86.61f)
                {
                    wrist02Rotation = 86.61f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }

    void movement_Down2()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != -70.23f)
        {
            if (articulation[0].xDrive.target > -70.23f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -70.23f)
                {
                    baseRotation = -70.23f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -70.23f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -70.23f)
                {
                    baseRotation = -70.23f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 24.48f)
        {
            if (articulation[1].xDrive.target > 24.48f)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 24.48f)
                {
                    shoudlerRotation = 24.48f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 24.48f)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 24.48f)
                {
                    shoudlerRotation = 24.48f;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -130.71f)
        {
            if (articulation[2].xDrive.target > -130.71f)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -130.71f)
                {
                    elbowRotation = -130.71f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -130.71f)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -130.71f)
                {
                    elbowRotation = -130.71f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 19.4f)
        {
            if (articulation[3].xDrive.target > 19.4f)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 19.4f)
                {
                    wrist01Rotation = 19.4f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 19.4f)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 19.4f)
                {
                    wrist01Rotation = 19.4f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 91.21f)
        {
            if (articulation[4].xDrive.target > 91.21f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 91.21f)
                {
                    wrist02Rotation = 91.21f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 91.21f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 91.21f)
                {
                    wrist02Rotation = 91.21f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }
    void movement_Center()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != -80)
        {
            if (articulation[0].xDrive.target > -80)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -80)
                {
                    baseRotation = -80;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -80)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -80)
                {
                    baseRotation = -80;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 15)
        {
            if (articulation[1].xDrive.target > 15)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 15)
                {
                    shoudlerRotation = 15;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 15)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 15)
                {
                    shoudlerRotation = 15;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -90)
        {
            if (articulation[2].xDrive.target > -90)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -90)
                {
                    elbowRotation = -90;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -90)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -90)
                {
                    elbowRotation = -90;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 0)
        {
            if (articulation[3].xDrive.target > 0)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 0)
                {
                    wrist01Rotation = 0;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 0)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 0)
                {
                    wrist01Rotation = 0;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 90)
        {
            if (articulation[4].xDrive.target > 90)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 90)
                {
                    wrist02Rotation = 90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 90)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 90)
                {
                    wrist02Rotation = 90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }

}
