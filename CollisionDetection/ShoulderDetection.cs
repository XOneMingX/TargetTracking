using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public class ShoulderDetection : MonoBehaviour
{
    private UR5Manager uR5Manager;
    internal bool isShoulderTouch;
    public Material originalColor;

    private Transform getRobot;
    private Transform[] getJoints;
    private List<Transform> allJoints;

    bool isGetJoints = false;

    void Awake()
    {
        uR5Manager = GameObject.FindObjectOfType<UR5Manager>();
    }

    void Start()
    {
        originalColor = Resources.Load<Material>("Joint");
        getJoints = uR5Manager.collisionJoints;
    }

    async void Update()
    {
        if (!isGetJoints)
        {
            await ListJoints();
            //isGetJoints = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        bool isExist = false;
        Debug.Log(collision.transform);
        if (allJoints.Contains(collision.transform))
        {
            isExist = true;
            isShoulderTouch = false;
        }
        if (!isExist)
        {
            isShoulderTouch = true;
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        MeshRenderer JointsRenderer = this.gameObject.GetComponent<MeshRenderer>();
        JointsRenderer.material = originalColor;
    }

    async Task ListJoints()
    {
        allJoints = new List<Transform>(getJoints);
    }
}
