//Date : 2019-05-31
//Jason Kreitz UNLV

//Note, not optimized code 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class UR5_Solver
{
    //change your DH parameters to match the scaling in unity
    private float DH_ratio = 4.185057f / 0.425f; //taken from length of DH_a
    //DH_d[4] was changed to -.119 from .109 to accomidate axis change (and .119 fit better for unity), and DH_d[5] was changed slightly as well    
    private float[] DH_d = { 0f, .08916f, 0f, 0f, -.11915f, .1f, .0823f };
    private float[] DH_a = { 0f, 0f, -.425f, -.39225f, 0f, 0f, 0f };
    private float[] DH_alph = { 0f, (float)(Math.PI / 2), 0f, 0f, (float)(Math.PI / 2), (float)(-Math.PI / 2), 0f };

    //contains final solutions for Unity
    private float[,] solutionMatrix = new float[6, 8];
    public float[] solutionArray = new float[6];

    private float x, y, z, phi, theta, psi;

    public UR5_Solver()
    {
        for (int i = 0; i < 6; i++)
        {
            solutionArray[i] = 0;

            for (int j = 0; j < 8; j++)
            {
                solutionMatrix[i, j] = 0;
            }
        }

        x = y = z = phi = theta = psi = 0;

        DHConvert();
    }

    private void DHConvert() //unity units for this model is different from real world size
    {
        for (int i = 0; i < 7; i++)
        {
            DH_d[i] *= DH_ratio;
            DH_a[i] *= DH_ratio;
        }
    }

    public void Solve(float x2, float y2, float z2, float phi2, float theta2, float psi2)
    {
        Matrix4x4 efPos;
        this.x = x2 / 0.1f;
        this.psi = phi2;
        this.y = -z2 / 0.1f;
        this.theta = -psi2;
        this.z = y2 / 0.1f;
        this.phi = theta2;

        efPos = hMatrix();

        IK_Solver(efPos);

        for (int i = 0; i < 6; i++)
        {
            this.solutionArray[i] = this.solutionMatrix[i, 0] * Mathf.Rad2Deg;
        }
    }

    //create your homogeneous transformation matrix
    //may need to update based on other transformation matrix
    private Matrix4x4 hMatrix()
    {
        //roll along z, pitch along y, yaw along x
        //phi = roll, theta = pitch, psi = yaw
        Matrix4x4 translate = Matrix4x4.identity;
        Matrix4x4 yaw = Matrix4x4.identity;
        Matrix4x4 pitch = Matrix4x4.identity;
        Matrix4x4 roll = Matrix4x4.identity;
        Matrix4x4 matrix;

        //set the translation matrix
        translate.m03 = x;
        translate.m13 = y;
        translate.m23 = z;

        //set roll matrix (z rotation)
        roll.m00 = (float)Math.Cos(phi);
        roll.m01 = -(float)Math.Sin(phi);
        roll.m10 = (float)Math.Sin(phi);
        roll.m11 = (float)Math.Cos(phi);

        //set pitch matrix (y rotation)
        pitch.m00 = (float)Math.Cos(theta);
        pitch.m02 = (float)Math.Sin(theta);
        pitch.m20 = -(float)Math.Sin(theta);
        pitch.m22 = (float)Math.Cos(theta);

        //set yaw matrix (x rotation)
        yaw.m11 = (float)Math.Cos(psi);
        yaw.m12 = -(float)Math.Sin(psi);
        yaw.m21 = (float)Math.Sin(psi);
        yaw.m22 = (float)Math.Cos(psi);

        //will need to set end effector rotation matrix
        /*        matrix = roll * pitch * yaw * translate;    */
        matrix = translate * roll * pitch * yaw;

        return matrix;
    }

    //each transformation from link i-1 to link i will use the following transformation
    //note: DH params[0] is the robot base, but the solution matrix[0] is joint 1 theta
    private Matrix4x4 aMatrix(int row, int column)
    {
        Matrix4x4 matrix = Matrix4x4.identity;

        matrix.m00 = (float)Math.Cos(this.solutionMatrix[row - 1, column]);
        matrix.m01 = -(float)Math.Sin(this.solutionMatrix[row - 1, column]);
        matrix.m03 = DH_alph[row - 1];

        matrix.m10 = (float)Math.Sin(this.solutionMatrix[row - 1, column]) * (float)Math.Cos(DH_alph[row - 1]);
        matrix.m11 = (float)Math.Cos(this.solutionMatrix[row - 1, column]) * (float)Math.Cos(DH_alph[row - 1]);
        matrix.m12 = -(float)Math.Sin(DH_alph[row - 1]);
        matrix.m13 = -(float)Math.Sin(DH_alph[row - 1]) * DH_d[row];

        matrix.m20 = (float)Math.Sin(this.solutionMatrix[row - 1, column]) * (float)Math.Sin(DH_alph[row - 1]);
        matrix.m21 = (float)Math.Cos(this.solutionMatrix[row - 1, column]) * (float)Math.Sin(DH_alph[row - 1]);
        matrix.m22 = (float)Math.Cos(DH_alph[row - 1]);
        matrix.m23 = (float)Math.Cos(DH_alph[row - 1]) * DH_d[row];

        return matrix;
    }

    private void IK_Solver(Matrix4x4 efPos)
    {
        float theta1, theta2, theta3, theta4, theta5, theta6;
        float sin1, cos1, sin5, p14Norm;
        Vector4 p05, d6, p14, p06;
        Vector2 yHat, xHat;
        Matrix4x4 efInverse, T01, T16, T65, T54, T14, T21, T32, T34;

        //******** Theta1

        d6.x = 0;
        d6.y = 0;
        d6.z = DH_d[6];
        d6.w = 1;

        p05 = efPos * d6;
        p06.x = efPos.m03;
        p06.y = efPos.m13;
        p06.z = efPos.m23;
        p06.w = efPos.m33;

        //first theta1 calculation with the positive square root
        theta1 = (float)(Math.Atan2(p05.y, p05.x) + Math.Acos(DH_d[4] / Math.Sqrt(Math.Pow(p05.x, 2) + Math.Pow(p05.y, 2))) + Math.PI / 2);
        //Debug.Log("theta1 = " + theta1 * Mathf.Rad2Deg);

        //fill in the first four elements of the first row of the solution matrix with theta1
        for (int i = 0; i < 4; i++)
        {
            this.solutionMatrix[0, i] = theta1;
        }

        //recalculate theta1 for the negative square root and store
        theta1 = (float)(Math.Atan2(p05.y, p05.x) - Math.Acos(DH_d[4] / Math.Sqrt(Math.Pow(p05.x, 2) + Math.Pow(p05.y, 2))) + Math.PI / 2);
        for (int i = 4; i < 8; i++)
        {
            this.solutionMatrix[0, i] = theta1;
        }

        //******** Theta5

        //need to take care of case when theta1 is positive sqrt
        sin1 = (float)Math.Sin(this.solutionMatrix[0, 0]);
        cos1 = (float)Math.Cos(this.solutionMatrix[0, 0]);

        //calculate positive solution
        theta5 = (float)Math.Acos(-1 * (p06.x * sin1 - p06.y * cos1 - DH_d[4]) / DH_d[6]);
        this.solutionMatrix[4, 0] = this.solutionMatrix[4, 1] = theta5;

        //now store negative solution
        this.solutionMatrix[4, 2] = this.solutionMatrix[4, 3] = -theta5;

        //need to take care of case when theta1 is negative sqrt
        sin1 = (float)Math.Sin(this.solutionMatrix[0, 4]);
        cos1 = (float)Math.Cos(this.solutionMatrix[0, 4]);
        theta5 = (float)Math.Acos(-1 * (p06.x * sin1 - p06.y * cos1 - DH_d[4]) / DH_d[6]);

        this.solutionMatrix[4, 4] = this.solutionMatrix[4, 5] = theta5;
        this.solutionMatrix[4, 6] = this.solutionMatrix[4, 7] = -theta5;

        //******** Theta6

        //if sin(theta5) == 0, then can set to arbitrary value
        if (Math.Sin(theta5) == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                this.solutionMatrix[5, i] = (float)Math.PI / 2;
            }
        }

        efInverse = efPos.inverse;
        xHat.x = efInverse.m00;
        xHat.y = efInverse.m10;
        yHat.x = efInverse.m01;
        yHat.y = efInverse.m11;

        //theta1 is positive sqrt and theta5 is positive
        sin5 = (float)Math.Sin(this.solutionMatrix[4, 0]);
        sin1 = (float)Math.Sin(this.solutionMatrix[0, 0]);
        cos1 = (float)Math.Cos(this.solutionMatrix[0, 0]);

        theta6 = (float)Math.Atan2(((-xHat[1] * sin1 + yHat[1] * cos1) / sin5), ((xHat[0] * sin1 - yHat[0] * cos1) / sin5));
        this.solutionMatrix[5, 0] = this.solutionMatrix[5, 1] = theta6;

        //theta5 is negative
        sin5 = (float)Math.Sin(this.solutionMatrix[4, 2]);
        theta6 = (float)Math.Atan2(((-xHat[1] * sin1 + yHat[1] * cos1) / sin5), ((xHat[0] * sin1 - yHat[0] * cos1) / sin5));
        this.solutionMatrix[5, 2] = this.solutionMatrix[5, 3] = theta6;

        //theta1 is negative sqrt and theta5 is positive
        sin5 = (float)Math.Sin(this.solutionMatrix[4, 4]);
        sin1 = (float)Math.Sin(this.solutionMatrix[0, 4]);
        cos1 = (float)Math.Cos(this.solutionMatrix[0, 4]);

        theta6 = (float)Math.Atan2(((-xHat[1] * sin1 + yHat[1] * cos1) / sin5), ((xHat[0] * sin1 - yHat[0] * cos1) / sin5));
        this.solutionMatrix[5, 4] = this.solutionMatrix[5, 5] = theta6;

        //theta1 is negative sqrt and theta5 is negative
        sin5 = (float)Math.Sin(this.solutionMatrix[4, 6]);

        theta6 = (float)Math.Atan2(((-xHat[1] * sin1 + yHat[1] * cos1) / sin5), ((xHat[0] * sin1 - yHat[0] * cos1) / sin5));
        this.solutionMatrix[5, 6] = this.solutionMatrix[5, 7] = theta6;

        //******** Theta3

        //T06 = T01 * T16, so T16 = T10 * T06
        //because thetas 1, 5, and 6 are different in different columns, will need to solve across all columns
        for (int i = 0; i < 8; i++)
        {
            T01 = aMatrix(1, i); //transformation from T0 to T1 - need to pass in 1 since we are using the first joint as reference
            T16 = T01.inverse * efPos;

            //T65 = T56.i = aMatrix(theta6).inverse
            T65 = aMatrix(6, i).inverse;
            T54 = aMatrix(5, i).inverse;

            T14 = T16 * T65 * T54;

            //need to get the magnitude of the translation
            p14.x = T14.m03;
            p14.y = T14.m13; //make sure this works as a negative
            p14.z = T14.m23;
            p14.w = 1;

            p14Norm = (float)Math.Sqrt(Math.Pow(p14.x, 2) + Math.Pow(p14.z, 2));

            //will be negative for odd indices
            if (i % 2 == 0)
            {
                theta3 = (float)Math.Acos((Math.Pow(p14Norm, 2) - Math.Pow(DH_a[2], 2) - Math.Pow(DH_a[3], 2)) / (2 * DH_a[2] * DH_a[3]));
                theta2 = (float)Math.Atan2(-p14.z, -p14.x) - (float)Math.Asin(-DH_a[3] * (float)Math.Sin(theta3) / p14Norm);
                T32 = aMatrix(3, i).inverse;
                T21 = aMatrix(2, i).inverse;
                T34 = T32 * T21 * T14;

                theta4 = (float)Math.Atan2(T34.m10, T34.m00);

                this.solutionMatrix[2, i] = theta3;
                this.solutionMatrix[1, i] = theta2;
                this.solutionMatrix[3, i] = theta4;
            }
            else
            {
                theta3 = -(float)Math.Acos((Math.Pow(p14Norm, 2) - Math.Pow(DH_a[2], 2) - Math.Pow(DH_a[3], 2)) / (2 * DH_a[2] * DH_a[3]));
                theta2 = (float)Math.Atan2(-p14.z, -p14.x) - (float)Math.Asin(-DH_a[3] * (float)Math.Sin(theta3) / p14Norm);
                T32 = aMatrix(3, i).inverse;
                T21 = aMatrix(2, i).inverse;
                T34 = T32 * T21 * T14;

                theta4 = (float)Math.Atan2(T34.m10, T34.m00);

                this.solutionMatrix[2, i] = theta3;
                this.solutionMatrix[1, i] = theta2;
                this.solutionMatrix[3, i] = theta4;
            }
        }
    }
}

public class UR5Controller_TrackingPoint : MonoBehaviour
{

    public GameObject RobotBase;
    public GameObject controlCube;
    private GameObject TrackingBlock;
  
    public float x = 0, y = 6, z = 3, phi = 0, theta = 0, psi = 0, oldX, oldY, oldZ, oldPhi, oldTheta, oldPsi;
    public string stringX, stringY, stringZ, stringPhi, stringTheta, stringPsi;
    public bool userHasHitOk = false;

    private int counter = 1;
    private int frameCount = 80;
    private float floatX, floatY, floatZ, floatPhi, floatTheta, floatPsi;
    internal GameObject[] jointList = new GameObject[6];
    private UR5_Solver Robot1 = new UR5_Solver();
    private UR5_Solver Robot11
    {
        get
        {
            return Robot1;
        }

        set
        {
            Robot1 = value;
        }
    }

    //private ListPoints listPoints;
    //internal GameObject[] GetPoints;
    //int NumOfPoints = 0;
    private float[] fJointsValue = new float[6];
    private string[] sJointsValue = new string[6];
    public GameObject EndEffector;
    bool isPass = false;
    bool isInitial = false;

    private ConnectServer client;
    private string editString;

    private float baseOffset = 0;

    void Awake()
    {
        //listPoints = GameObject.FindObjectOfType<ListPoints>();
        client = GameObject.FindObjectOfType<ConnectServer>();
    }
    // Use this for initialization
    void Start()
    {
        initializeJoints();
        initializeCube();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (RobotBase.activeSelf)
        {
            if (controlCube == null)
            {
                controlCube = GameObject.Find("Target");
                initializeCube();
            }
            if (TrackingBlock == null)
            {
                TrackingBlock = GameObject.Find("Block");
            }
            if (isInitial == false)
            {
                initializeBlock();
            }

            TrackingPoint();
            LimitBlock();
        }
        //controlCube.transform.position = new Vector3(floatX, floatY, floatZ);
        //controlCube.transform.eulerAngles = new Vector3(floatPhi, floatTheta, floatPsi);

        //oldX = x;
        //oldY = y;
        //oldZ = z;
        //oldPhi = phi;
        //oldTheta = theta;
        //oldPsi = psi;

        //if (userHasHitOk)
        //{
        //    if (counter >= frameCount)
        //    {
        //        counter = 1;
        //        userHasHitOk = false;
        //    }

        //    x = oldX + (counter * (controlCube.transform.position.x - oldX) / frameCount);
        //    y = oldY + (counter * (controlCube.transform.position.y - oldY) / frameCount);
        //    z = oldZ + (counter * (controlCube.transform.position.z - oldZ) / frameCount);
        //    phi = controlCube.transform.eulerAngles.x * Mathf.Deg2Rad;
        //    theta = controlCube.transform.eulerAngles.y * Mathf.Deg2Rad;
        //    psi = controlCube.transform.eulerAngles.z * Mathf.Deg2Rad;
        //    Debug.Log("psi = " + psi);

        //    Robot11.Solve(x, y, z, phi, theta, psi);

        //    for (int j = 0; j < 6; j++)
        //    {
        //        Vector3 currentRotation = jointList[j].transform.localEulerAngles;
        //        currentRotation.z = Robot11.solutionArray[j];
        //        jointList[j].transform.localEulerAngles = currentRotation;
        //    }

        //    counter++;
        //}
    }

    void initializeCube()
    {
        controlCube = GameObject.Find("Target");
        //controlCube.transform.position = new Vector3(RobotBase.transform.position.x, RobotBase.transform.position.y + 0.5f, RobotBase.transform.position.z - 0.5f); //note, this is in format x, y, z - but y is up
        controlCube.transform.position = new Vector3(RobotBase.transform.position.x, RobotBase.transform.position.y + 0.5f, RobotBase.transform.position.z - 0.5f);
        controlCube.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        controlCube.transform.eulerAngles = new Vector3(0f, 0f, 0f); //in degrees
                                                                     //controlCube.SetActive(false);
    }

    void TrackingPoint()
    {
        var objectManipulator = TrackingBlock.GetComponent<ObjectManipulator>();
        if (client.recvStr != null)
        {
            isPass = false;
            objectManipulator.enabled = true;
            client.recvStr = null;
        }

        if (userHasHitOk)
        {
            controlCube.transform.position = new Vector3(floatX, floatY, floatZ);
            controlCube.transform.eulerAngles = new Vector3(floatPhi, floatTheta, floatPsi);

            oldX = x;
            oldY = y;
            oldZ = z;
            oldPhi = phi;
            oldTheta = theta;
            oldPsi = psi;

            var PointPosX = TrackingBlock.transform.position.x - RobotBase.transform.position.x;
            var PointPosY = TrackingBlock.transform.position.y - RobotBase.transform.position.y;
            var PointPosZ = TrackingBlock.transform.position.z - RobotBase.transform.position.z;
            var PointRotaX = TrackingBlock.transform.eulerAngles.x;
            var PointRotaY = TrackingBlock.transform.eulerAngles.y;
            var PointRotaZ = TrackingBlock.transform.eulerAngles.z;

            floatX = PointPosX;
            floatY = PointPosY;
            floatZ = PointPosZ;
            floatPhi = PointRotaX;
            floatTheta = PointRotaY;
            floatPsi = PointRotaZ;


            float TargetDistance = Vector3.Distance(EndEffector.transform.position, TrackingBlock.transform.position);
            x = oldX + (counter * (controlCube.transform.position.x - oldX) / frameCount);
            y = oldY + (counter * (controlCube.transform.position.y - oldY) / frameCount);
            z = oldZ + (counter * (controlCube.transform.position.z - oldZ) / frameCount);
            phi = controlCube.transform.eulerAngles.x * Mathf.Deg2Rad;
            theta = controlCube.transform.eulerAngles.y * Mathf.Deg2Rad;
            psi = controlCube.transform.eulerAngles.z * Mathf.Deg2Rad;

            Robot11.Solve(x, y, z, phi, theta, psi);

            for (int j = 0; j < 6; j++)
            {
                Vector3 currentRotation = jointList[j].transform.localEulerAngles;
                currentRotation.z = Robot11.solutionArray[j];
                jointList[j].transform.localEulerAngles = currentRotation;
                fJointsValue[j] = currentRotation.z;
                if (baseOffset != 0)
                {
                    fJointsValue[0] += baseOffset * -1;
                }
                sJointsValue[j] = fJointsValue[j].ToString();
                if (TargetDistance < 0.04f && !isPass)
                {
                    objectManipulator.enabled = false;
                    editString = sJointsValue[0] + "," + sJointsValue[1] + "," + sJointsValue[2] + "," + sJointsValue[3] + "," + sJointsValue[4] + "," + sJointsValue[5] + "\n";
                    client.SocketSend(editString);
                    isPass = true;
                }
                
            }
            if (TargetDistance < 0.04f)
            {
                counter = 1;
                userHasHitOk = false;
            }

            counter++;
        }
    }

    void LimitBlock()
    {
        float radius = 0.7f;
        float distance = Vector3.Distance(TrackingBlock.transform.position, RobotBase.transform.position);
        if(distance > radius)
        {
            Vector3 fromOriginToObject = TrackingBlock.transform.position - RobotBase.transform.position;
            fromOriginToObject *= radius / distance;
            Vector3 newLoc = RobotBase.transform.position + fromOriginToObject;
            TrackingBlock.transform.position = newLoc;
        }
        /*
        // Limit Movement in Cube
        float MaxX_Bounday = 0.9f;
        float MinX_Bounday = -0.9f;
        float MaxY_Bounday = 0.9f;
        float MinY_Bounday = -0.9f;
        float MaxZ_Bounday = 0.9f;
        float MinZ_Bounday = -0.9f;
        float xClamp = Mathf.Clamp(controlCube.transform.position.x, MinX_Bounday, MaxX_Bounday);
        float yClamp = Mathf.Clamp(controlCube.transform.position.y, MinY_Bounday, MaxY_Bounday);
        float zClamp = Mathf.Clamp(controlCube.transform.position.z, MinZ_Bounday, MaxZ_Bounday);
        Vector3 limitBlock = new Vector3(xClamp, yClamp, zClamp);
        controlCube.transform.position = limitBlock;
        */

    }

    public void ConfirmMove()
    {
        userHasHitOk = true;

    }
    public void PlacePoint()
    {
        Debug.Log("WAIT");
        //controlCube.GetComponent<Renderer>().material.color = Color.red;
    }

    // Create the list of GameObjects that represent each joint of the robot
    public void initializeBlock()
    {
        TrackingBlock.transform.position = new Vector3(RobotBase.transform.position.x, RobotBase.transform.position.y + 0.3f, RobotBase.transform.position.z + 0.5f);
        controlCube.transform.position = new Vector3(RobotBase.transform.position.x, RobotBase.transform.position.y + 0.3f, RobotBase.transform.position.z + 0.5f);

        //controlCube.transform.position = new Vector3(floatX, floatY, floatZ);
        //controlCube.transform.eulerAngles = new Vector3(floatPhi, floatTheta, floatPsi);

        oldX = x;
        oldY = y;
        oldZ = z;
        oldPhi = phi;
        oldTheta = theta;
        oldPsi = psi;

        var PointPosX = TrackingBlock.transform.position.x - RobotBase.transform.position.x;
        var PointPosY = TrackingBlock.transform.position.y - RobotBase.transform.position.y;
        var PointPosZ = TrackingBlock.transform.position.z - RobotBase.transform.position.z;
        var PointRotaX = TrackingBlock.transform.eulerAngles.x;
        var PointRotaY = TrackingBlock.transform.eulerAngles.y;
        var PointRotaZ = TrackingBlock.transform.eulerAngles.z;

        floatX = PointPosX;
        floatY = PointPosY;
        floatZ = PointPosZ;
        floatPhi = PointRotaX;
        floatTheta = PointRotaY;
        floatPsi = PointRotaZ;

        float TargetDistance = Vector3.Distance(EndEffector.transform.position, TrackingBlock.transform.position);

        x = oldX + (counter * (floatX - oldX) / 30);
        y = oldY + (counter * (floatY - oldY) / 30);
        z = oldZ + (counter * (floatZ - oldZ) / 30);
        phi = controlCube.transform.eulerAngles.x * Mathf.Deg2Rad;
        theta = controlCube.transform.eulerAngles.y * Mathf.Deg2Rad;
        psi = controlCube.transform.eulerAngles.z * Mathf.Deg2Rad;

        Robot11.Solve(x, y, z, phi, theta, psi);

        for (int j = 0; j < 6; j++)
        {
            Vector3 currentRotation = jointList[j].transform.localEulerAngles;
            currentRotation.z = Robot11.solutionArray[j];
            jointList[j].transform.localEulerAngles = currentRotation;
        }

        if (TargetDistance < 0.04f)
        {
            counter = 1;
            isInitial = true;
        }
    }

    void initializeJoints()
    {
        var RobotChildren = RobotBase.GetComponentsInChildren<Transform>();
        for (int i = 0; i < RobotChildren.Length; i++)
        {
            if (RobotChildren[i].name == "Base")
            {
                jointList[0] = RobotChildren[i].gameObject;
                //Vector3 currentRotation = jointList[0].transform.localEulerAngles;
                //currentRotation.z = RobotBase.transform.eulerAngles.y - 80;
                //jointList[0].transform.localEulerAngles = currentRotation;
            }
            else if (RobotChildren[i].name == "Shoulder")
            {
                jointList[1] = RobotChildren[i].gameObject;
                ////Vector3 currentRotation = jointList[1].transform.localEulerAngles;
                ////currentRotation.z = -110;
                ////jointList[1].transform.localEulerAngles = currentRotation;
                //jointList[1].transform.rotation.z = -100;
            }
            else if (RobotChildren[i].name == "Elbow")
            {
                jointList[2] = RobotChildren[i].gameObject;
                //Vector3 currentRotation = jointList[2].transform.localEulerAngles;
                //currentRotation.z = 90;
                //jointList[2].transform.localEulerAngles = currentRotation;
                //jointList[2].transform.rotation.z = 80;
            }
            else if (RobotChildren[i].name == "Wrist01")
            {
                jointList[3] = RobotChildren[i].gameObject;
                //Vector3 currentRotation = jointList[3].transform.localEulerAngles;
                //currentRotation.z = -90;
                //jointList[3].transform.localEulerAngles = currentRotation;
                //jointList[3].transform.rotation.z = -90;
            }
            else if (RobotChildren[i].name == "Wrist02")
            {
                jointList[4] = RobotChildren[i].gameObject;
                //Vector3 currentRotation = jointList[4].transform.localEulerAngles;
                //currentRotation.z = 90;
                //jointList[4].transform.localEulerAngles = currentRotation;
                //jointList[4].transform.rotation.z = 90;
            }
            else if (RobotChildren[i].name == "Wrist03")
            {
                jointList[5] = RobotChildren[i].gameObject;
                EndEffector = RobotChildren[i].gameObject;
            }
        }
    }

    internal void AdjustJointOffset(float offset)
    {
        if(jointList != null)
        {
            baseOffset = offset;
            Vector3 currentRotation = jointList[0].transform.localEulerAngles;
            currentRotation.z += offset;
            jointList[0].transform.localEulerAngles = currentRotation;
        }
    }
}

