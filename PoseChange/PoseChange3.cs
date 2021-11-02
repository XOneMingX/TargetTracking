using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoseChange3 : MonoBehaviour
{
    [System.Serializable]
    public struct Joint
    {
        public GameObject robotPart;
    }
    public Joint[] joints;
    public ArticulationBody[] articulation = new ArticulationBody[6];

    private int motionOrder = 0;

    private float baseRotation;
    private float shoudlerRotation;
    private float elbowRotation;
    private float wrist01Rotation;
    private float wrist02Rotation;
    private float handRotation;

    float rotationSpeed = 40f;


    void Start()
    {
        initializeJoints();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void initializeJoints()
    {
        for (int i = 0; i < joints.Length; i++)
        {
            GameObject robotPart = joints[i].robotPart;
            articulation[i] = joints[i].robotPart.GetComponent<ArticulationBody>();
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
        if (articulation[0].xDrive.target != -62.98f)
        {
            if (articulation[0].xDrive.target > -62.98f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -62.98f)
                {
                    baseRotation = -62.98f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -62.98f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -62.98f)
                {
                    baseRotation = -62.98f;
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
        if (articulation[4].xDrive.target != 78.67f)
        {
            if (articulation[4].xDrive.target > 78.67f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 78.67f)
                {
                    wrist02Rotation = 78.67f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 78.67f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 78.67f)
                {
                    wrist02Rotation = 78.67f;
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
        if (articulation[0].xDrive.target != -50f)
        {
            if (articulation[0].xDrive.target > -50f)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -50f)
                {
                    baseRotation = -50f;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -50f)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -50f)
                {
                    baseRotation = -50f;
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
        if (articulation[4].xDrive.target != 78.67f)
        {
            if (articulation[4].xDrive.target > 78.67f)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 78.67f)
                {
                    wrist02Rotation = 78.67f;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 78.67f)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 78.67f)
                {
                    wrist02Rotation = 78.67f;
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
        if (articulation[0].xDrive.target != -60)
        {
            if (articulation[0].xDrive.target > -60)
            {
                baseRotation -= Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target < -60)
                {
                    baseRotation = -60;
                    baseDrive.target = baseRotation;
                    articulation[0].xDrive = baseDrive;
                }
            }
            if (articulation[0].xDrive.target < -60)
            {
                baseRotation += Time.deltaTime * rotationSpeed;
                baseDrive.target = baseRotation;
                articulation[0].xDrive = baseDrive;
                if (articulation[0].xDrive.target > -60)
                {
                    baseRotation = -60;
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
        if (articulation[2].xDrive.target != -145)
        {
            if (articulation[2].xDrive.target > -145)
            {
                elbowRotation -= Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target < -145)
                {
                    elbowRotation = -145;
                    elbowDrive.target = elbowRotation;
                    articulation[2].xDrive = elbowDrive;
                }
            }
            if (articulation[2].xDrive.target < -145)
            {
                elbowRotation += Time.deltaTime * rotationSpeed;
                elbowDrive.target = elbowRotation;
                articulation[2].xDrive = elbowDrive;
                if (articulation[2].xDrive.target > -145)
                {
                    elbowRotation = -145;
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
        if (articulation[4].xDrive.target != 75)
        {
            if (articulation[4].xDrive.target > 75)
            {
                wrist02Rotation -= Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target < 75)
                {
                    wrist02Rotation = 75;
                    wrist02Drive.target = wrist02Rotation;
                    articulation[4].xDrive = wrist02Drive;
                }
            }
            if (articulation[4].xDrive.target < 75)
            {
                wrist02Rotation += Time.deltaTime * rotationSpeed;
                wrist02Drive.target = wrist02Rotation;
                articulation[4].xDrive = wrist02Drive;
                if (articulation[4].xDrive.target > 75)
                {
                    wrist02Rotation = 75;
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
        StartCoroutine(waitMoving());
    }

    IEnumerator waitMoving()
    {
        motionOrder = 1;
        yield return new WaitForSeconds(2);
        motionOrder = 2;
        yield return new WaitForSeconds(1);
        motionOrder = 3;
        yield return new WaitForSeconds(1);
        motionOrder = 4;
        yield return new WaitForSeconds(1);
        motionOrder = 7;
    }

}
