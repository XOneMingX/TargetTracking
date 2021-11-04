using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class UR5Manager : MonoBehaviour
{
    private GameObject getRobot;
    internal Transform[] collisionJoints;
    public GameObject[] robotJoints;
    public ArticulationBody[] articulation;
    bool isInitial;

    void Start()
    {

    }

    // Update is called once per frame
    async void Update()
    {
        if (!isInitial)
        {
            await initializeJoints();
            isInitial = true;
        }
    }


    // Create the list of GameObjects that represent each joint of the robot
    async Task initializeJoints()
    {
        getRobot = this.gameObject;
        Transform[] getJoints = getRobot.transform.GetChild(0).GetComponentsInChildren<Transform>(true);
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
        //collisionJoints[1].gameObject.AddComponent<Wrist03Detection>();
        //collisionJoints[2].gameObject.AddComponent<Wrist03Detection>();
        //collisionJoints[3].gameObject.AddComponent<Wrist03Detection>();
        //collisionJoints[4].gameObject.AddComponent<Wrist03Detection>();
        collisionJoints[5].gameObject.AddComponent<Wrist03Detection>();
    }

}

