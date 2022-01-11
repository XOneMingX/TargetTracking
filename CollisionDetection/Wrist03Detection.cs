using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public class Wrist03Detection : MonoBehaviour
{
    private UR5Manager uR5Manager;
    internal bool isWrist03Touch;
    public Material originalColor;

    private Transform getRobot;
    private Transform[] getJoints;
    private List<Transform> allJoints;

    bool isGetJoints = false;

    void Awake()
    {
        uR5Manager = this.gameObject.GetComponentInParent<UR5Manager>();
    }

    void Start()
    {
        //Get the original material "Joint" in the Resources folder
        originalColor = Resources.Load<Material>("Joint");
    }

    void Update()
    {
        //Confirm all joints' variables are passed into this script
        if (!isGetJoints)
        {
            ListJoints();
            isGetJoints = true;
        }
    }

    //When the collision is happening
    void OnTriggerEnter(Collider collision)
    {
        //Detects whether the collision object is the same part of the robot arm
        //If no, the collision part will change to red
        bool isExist = false;
        if (allJoints.Contains(collision.transform))
        {
            isExist = true;
            isWrist03Touch = false;
        }
        if (!isExist)
        {
            isWrist03Touch = true;
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    //After the collision occurs and adjusts, the collision disappears
    void OnTriggerExit(Collider collision)
    {
        MeshRenderer JointsRenderer = this.gameObject.GetComponent<MeshRenderer>();
        JointsRenderer.material = originalColor;    
        isWrist03Touch = false;
    }

    //Get the joints' variables from UR5Manager
    //Convert the array of joints to the list 
    async Task ListJoints()
    {
        await Task.Run(() =>
        {
            if (getJoints == null)
            {
                getJoints = uR5Manager.collisionJoints;
            }
        });
        allJoints = new List<Transform>(getJoints);
    }
}
