using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class LoopPose : MonoBehaviour
{
    private GameObject getRobot;
    public GameObject[] robotJoints;
    public ArticulationBody[] articulation;

    private int motionOrder = 1;

    private float baseRotation;
    private float shoudlerRotation;
    private float elbowRotation;
    private float wrist01Rotation;
    private float wrist02Rotation;
    private float handRotation;

    float rotationSpeed = 40f;
    int limit = 150;
    int counter = 0;


    void Start()
    {
        initializeJoints();
    }

    // Update is called once per frame
    void Update()
    {
        LoopingPose();
        if (motionOrder == 1)
        {
            movement_Pose1();
        }
        if (motionOrder == 2)
        {
            movement_Pose2();
        }
        if (motionOrder == 3)
        {
            movement_Pose3();
        }
        if (motionOrder == 4)
        {
            movement_Pose4();
        }
        if (motionOrder == 5)
        {
            movement_Pose5();
        }
        if (motionOrder == 6)
        {
            movement_Pose6();
        }
    }

    void LoopingPose()
    {
        if(counter > limit)
        {
            motionOrder += 1;
            counter = 0;
        }
        if(motionOrder > 6)
        {
            motionOrder = 1;
            counter = counter - 80;
        }
        counter++;
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



    void movement_Pose1()
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
    void movement_Pose2()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != 40)
        {
            if (articulation[0].xDrive.target > 40)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < 40)
                {
                    baseRotation = 40;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < 40)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > 40)
                {
                    baseRotation = 40;
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
        if (articulation[2].xDrive.target != -80)
        {
            if (articulation[2].xDrive.target > -80)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -80)
                {
                    elbowRotation = -80;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -80)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -80)
                {
                    elbowRotation = -80;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 30)
        {
            if (articulation[3].xDrive.target > 30)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 30)
                {
                    wrist01Rotation = 30;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 30)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 30)
                {
                    wrist01Rotation = 30;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != -90)
        {
            if (articulation[4].xDrive.target > -90)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < -90)
                {
                    wrist02Rotation = -90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < -90)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > -90)
                {
                    wrist02Rotation = -90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }

    void movement_Pose3()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != 80)
        {
            if (articulation[0].xDrive.target > 80)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < 80)
                {
                    baseRotation = 80;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < 80)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > 80)
                {
                    baseRotation = 80;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != -10)
        {
            if (articulation[1].xDrive.target > -10)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < -10)
                {
                    shoudlerRotation = -10;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < -10)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > -10)
                {
                    shoudlerRotation = -10;
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
        if (articulation[3].xDrive.target != 30)
        {
            if (articulation[3].xDrive.target > 30)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 30)
                {
                    wrist01Rotation = 30;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 30)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 30)
                {
                    wrist01Rotation = 30;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != -90)
        {
            if (articulation[4].xDrive.target > -90)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < -90)
                {
                    wrist02Rotation = -90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < -90)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > -90)
                {
                    wrist02Rotation = -90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }

    void movement_Pose4()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != 120)
        {
            if (articulation[0].xDrive.target > 120)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < 120)
                {
                    baseRotation = 120;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < 120)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > 120)
                {
                    baseRotation = 120;
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
        if (articulation[4].xDrive.target != -90)
        {
            if (articulation[4].xDrive.target > -90)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < -90)
                {
                    wrist02Rotation = -90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < -90)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > -90)
                {
                    wrist02Rotation = -90;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }

    void movement_Pose5()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != 160)
        {
            if (articulation[0].xDrive.target > 220)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < 220)
                {
                    baseRotation = 220;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < 220)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > 220)
                {
                    baseRotation = 220;
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
        if (articulation[2].xDrive.target != -100)
        {
            if (articulation[2].xDrive.target > -100)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -100)
                {
                    elbowRotation = -100;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -100)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -100)
                {
                    elbowRotation = -100;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 30)
        {
            if (articulation[3].xDrive.target > 30)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 30)
                {
                    wrist01Rotation = 30;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 30)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 30)
                {
                    wrist01Rotation = 30;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != -91.21f)
        {
            if (articulation[4].xDrive.target > -91.21f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < -91.21f)
                {
                    wrist02Rotation = -91.21f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < -91.21f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > -91.21f)
                {
                    wrist02Rotation = -91.21f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }
    void movement_Pose6()
    {
        var baseDrive = articulation[0].xDrive;
        var shoudlerDrive = articulation[1].xDrive;
        var elbowDrive = articulation[2].xDrive;
        var wrist01Drive = articulation[3].xDrive;
        var wrist02Drive = articulation[4].xDrive;
        if (articulation[0].xDrive.target != 270)
        {
            if (articulation[0].xDrive.target > 270)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < 270)
                {
                    baseRotation = 270;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < 270)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > 270)
                {
                    baseRotation = 270;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
        }
        if (articulation[1].xDrive.target != 30)
        {
            if (articulation[1].xDrive.target > 30)
            {
                shoudlerRotation -= Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target < 30)
                {
                    shoudlerRotation = 30;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
            if (articulation[1].xDrive.target < 30)
            {
                shoudlerRotation += Time.deltaTime * rotationSpeed;
                shoudlerDrive.target = shoudlerRotation;
                articulation[1].xDrive = shoudlerDrive;
                if (articulation[1].xDrive.target > 30)
                {
                    shoudlerRotation = 30;
                    shoudlerDrive.target = shoudlerRotation;
                    articulation[1].xDrive = shoudlerDrive;
                }
            }
        }
        if (articulation[2].xDrive.target != -100)
        {
            if (articulation[2].xDrive.target > -100)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -100)
                {
                    elbowRotation = -100;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -100)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -100)
                {
                    elbowRotation = -100;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
        }
        if (articulation[3].xDrive.target != 70)
        {
            if (articulation[3].xDrive.target > 70)
            {
                wrist01Rotation -= Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target < 70)
                {
                    wrist01Rotation = 70;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
            if (articulation[3].xDrive.target < 70)
            {
                wrist01Rotation += Time.deltaTime * rotationSpeed;
                wrist01Drive.target = wrist01Rotation;
                articulation[3].xDrive = wrist01Drive;
                if (articulation[3].xDrive.target > 70)
                {
                    wrist01Rotation = 70;
                    wrist01Drive.target = wrist01Rotation;
                    articulation[3].xDrive = wrist01Drive;
                }
            }
        }
        if (articulation[4].xDrive.target != -91.21f)
        {
            if (articulation[4].xDrive.target > -91.21f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < -91.21f)
                {
                    wrist02Rotation = -91.21f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < -91.21f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > -91.21f)
                {
                    wrist02Rotation = -91.21f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
        }
    }
}
