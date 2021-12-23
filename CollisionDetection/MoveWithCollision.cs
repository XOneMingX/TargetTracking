using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveWithCollision : MonoBehaviour
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

    private TriggerDetection triggerDetection;
    //private Transform[] getCollisionJoints;
    //bool isTouch;
    float rotationSpeed = 50f;

    void Awake()
    {

    }

    void Start()
    {
        initializeJoints();
    }

    // Update is called once per frame
    void Update()
    {
        triggerDetection = GameObject.FindObjectOfType<TriggerDetection>();

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
            movement_Around();
        }
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

        motionOrder = 1;

    }
    public void rotateMotion_up2()
    {
        motionOrder = 2;

    }
    public void rotateMotion_up3()
    {
        motionOrder = 3;

    }
    public void rotateMotion_down1()
    {
        motionOrder = 4;

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
        if (articulation[0].xDrive.target != 62.98f)
        {
            if (articulation[0].xDrive.target > 62.98f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < 62.98f)
                {
                    baseRotation = 62.98f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < 62.98f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > 62.98f)
                {
                    baseRotation = 62.98f;
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
        if (articulation[2].xDrive.target != -106.15f)
        {
            if (articulation[2].xDrive.target > -106.15f)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -106.15f)
                {
                    elbowRotation = -106.15f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -106.15f)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -106.15f)
                {
                    elbowRotation = -106.15f;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 10.65f)
        {
            if (articulation[3].xDrive.target > 10.65f)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 10.65f)
                {
                    wrist01Rotation = 10.65f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 10.65f)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 10.65f)
                {
                    wrist01Rotation = 10.65f;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != -78.67f)
        {
            if (articulation[4].xDrive.target > -78.67f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < -78.67f)
                {
                    wrist02Rotation = -78.67f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < -78.67f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > -78.67f)
                {
                    wrist02Rotation = -78.67f;
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
        if (articulation[0].xDrive.target != -40)
        {
            if (articulation[0].xDrive.target > -40)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -40)
                {
                    baseRotation = -40;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -40)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -40)
                {
                    baseRotation = -40;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 20)
        {
            if (articulation[1].xDrive.target > 20)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 20)
                {
                    shoudlerRotation = 20;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 20)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 20)
                {
                    shoudlerRotation = 20;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -110)
        {
            if (articulation[2].xDrive.target > -110)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -110)
                {
                    elbowRotation = -110;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -110)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -110)
                {
                    elbowRotation = -110;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 20)
        {
            if (articulation[3].xDrive.target > 20)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 20)
                {
                    wrist01Rotation = 20;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 20)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 20)
                {
                    wrist01Rotation = 20;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 50)
        {
            if (articulation[4].xDrive.target > 50)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 50)
                {
                    wrist02Rotation = 50;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 50)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 50)
                {
                    wrist02Rotation = 50;
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
        if (articulation[0].xDrive.target != -45)
        {
            if (articulation[0].xDrive.target > -45)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -45)
                {
                    baseRotation = -45;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -45)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -45)
                {
                    baseRotation = -45;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 0)
        {
            if (articulation[1].xDrive.target > 0)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 0)
                {
                    shoudlerRotation = 0;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 0)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 0)
                {
                    shoudlerRotation = 0;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -120)
        {
            if (articulation[2].xDrive.target > -120)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -120)
                {
                    elbowRotation = -120;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -120)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -120)
                {
                    elbowRotation = -120;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 40)
        {
            if (articulation[3].xDrive.target > 40)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 40)
                {
                    wrist01Rotation = 40;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 40)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 40)
                {
                    wrist01Rotation = 40;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != 50)
        {
            if (articulation[4].xDrive.target > 50)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 50)
                {
                    wrist02Rotation = 50;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 50)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 50)
                {
                    wrist02Rotation = 50;
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
        if (articulation[0].xDrive.target != 60)
        {
            if (articulation[0].xDrive.target > 60)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < 60)
                {
                    baseRotation = 60;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < 60)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > 60)
                {
                    baseRotation = 60;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != -20)
        {
            if (articulation[1].xDrive.target > -20)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < -20)
                {
                    shoudlerRotation = -20;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < -20)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > -20)
                {
                    shoudlerRotation = -20;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -120)
        {
            if (articulation[2].xDrive.target > -120)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -120)
                {
                    elbowRotation = -120;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -120)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -120)
                {
                    elbowRotation = -120;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 40)
        {
            if (articulation[3].xDrive.target > 40)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 40)
                {
                    wrist01Rotation = 40;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 40)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 40)
                {
                    wrist01Rotation = 40;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != -75)
        {
            if (articulation[4].xDrive.target > -75)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < -75)
                {
                    wrist02Rotation = -75;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < -75)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > -75)
                {
                    wrist02Rotation = -75;
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
        if (articulation[2].xDrive.target != -120)
        {
            if (articulation[2].xDrive.target > -120)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -120)
                {
                    elbowRotation = -120;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -120)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -120)
                {
                    elbowRotation = -120;
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
        if (articulation[1].xDrive.target != 10)
        {
            if (articulation[1].xDrive.target > 10)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 10)
                {
                    shoudlerRotation = 10;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 10)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 10)
                {
                    shoudlerRotation = 10;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -140)
        {
            if (articulation[2].xDrive.target > -140)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -140)
                {
                    elbowRotation = -140;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -140)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -140)
                {
                    elbowRotation = -140;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 50)
        {
            if (articulation[3].xDrive.target > 50)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 50)
                {
                    wrist01Rotation = 50;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 50)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 50)
                {
                    wrist01Rotation = 50;
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

    void movement_Around()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (triggerDetection.isTrigger == true)
        {
            baseDrive.target = baseRotation;
            articulation[0].xDrive = baseDrive;
        }
        if (triggerDetection.isTrigger == false)
        {
            baseRotation -= Time.deltaTime * rotationSpeed;
            baseDrive.target = baseRotation;
            articulation[0].xDrive = baseDrive;
        }
    }
}
