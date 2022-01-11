using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class UR5Manager : MonoBehaviour
{
    private GameObject RobotArm;
    internal Transform[] collisionJoints;
    public GameObject[] robotJoints;
    public ArticulationBody[] articulation;
    private bool isInitial;
    private bool isSet;

    void Start()
    {
        RobotArm = this.gameObject;
    }

    // Update is called once per frame
    async void Update()
    {
        //Confirm the GameObject robot arm is active
        //Then, activate the initializeJoints method
        isInitial = RobotArm.activeSelf; 
        if (isInitial && !isSet)
        {
            await initializeJoints();
            isSet = true;
        }
    }


    // Create the list of GameObjects that represent each joint of the robot
    async Task initializeJoints()
    {
        //Register all joints of UR5 model & the articulation body of each joint
        //Register the joints which are used for detecting the collision
        //Add the detector script in the corresponding collision-joints
        Transform[] getJoints = RobotArm.transform.GetChild(0).GetComponentsInChildren<Transform>(true);
        robotJoints = new GameObject[6];
        articulation = new ArticulationBody[6];
        collisionJoints = new Transform[6];
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
        for (int i = 0; i < getJoints.Length; i++)
        {
            if (getJoints[i].name == "joint0")
            {
                collisionJoints[0] = getJoints[i];
            }
            if (getJoints[i].name == "joint1")
            {
                collisionJoints[1] = getJoints[i];
            }
            if (getJoints[i].name == "joint2")
            {
                collisionJoints[2] = getJoints[i];
            }
            if (getJoints[i].name == "joint3")
            {
                collisionJoints[3] = getJoints[i];
            }
            if (getJoints[i].name == "joint4")
            {
                collisionJoints[4] = getJoints[i];
            }
            if (getJoints[i].name == "joint5")
            {
                collisionJoints[5] = getJoints[i];
            }
        }
        //collisionJoints[1].gameObject.AddComponent<ShoulderDetection>();
        //collisionJoints[2].gameObject.AddComponent<ElbowDetection>();
        //collisionJoints[3].gameObject.AddComponent<Wrist01Detection>();
        //collisionJoints[4].gameObject.AddComponent<Wrist02Detection>();
        //collisionJoints[5].gameObject.AddComponent<Wrist03Detection>();
        collisionJoints[5].gameObject.AddComponent<TriggerDetection>();
    }

}

