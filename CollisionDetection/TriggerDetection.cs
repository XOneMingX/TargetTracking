using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public class TriggerDetection : MonoBehaviour
{
    private UR5Manager uR5Manager;
    internal bool isTrigger;
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

    }

    void Update()
    {
        if (!isGetJoints)
        {
            ListJoints();
            isGetJoints = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        bool isExist = false;
        Debug.Log(collision.transform);
        if (allJoints.Contains(collision.transform))
        {
            isExist = true;
            isTrigger = false;
        }
        if (!isExist)
        {
            isTrigger = true;
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        MeshRenderer JointsRenderer = this.gameObject.GetComponent<MeshRenderer>();
        JointsRenderer.material = originalColor;
        isTrigger = false;
    }

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
