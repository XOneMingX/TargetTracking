using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public class Wrist01Detection : MonoBehaviour
{
    private UR5Manager uR5Manager;
    internal bool isWrist01Touch;
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
        originalColor = Resources.Load<Material>("Joint");

    }

    async void Update()
    {
        if (!isGetJoints)
        {
            await ListJoints();
            isGetJoints = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        bool isExist = false;
        if (allJoints.Contains(collision.transform))
        {
            isExist = true;
            isWrist01Touch = false;
        }
        if (!isExist)
        {
            isWrist01Touch = true;
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        MeshRenderer JointsRenderer = this.gameObject.GetComponent<MeshRenderer>();
        JointsRenderer.material = originalColor;
        isWrist01Touch = false;
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
