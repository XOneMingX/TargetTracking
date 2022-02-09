using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyDetection : MonoBehaviour
{
    public GameObject robotArm;
    private GameObject safetyReminder;
    private GameObject innerSafetyArea;
    //private GameObject midSafetyArea;
    //private GameObject outterSafetyArea;

    public Material oldInnerLayer;
    //public Material oldMidLayer;
    //public Material oldOutterLayer;
    public Material newInnerLayer;
    //public Material newMidLayer;
    //public Material newOutterLayer;

    internal float safetyDistance;

    void Start()
    {
        safetyReminder = this.gameObject;
        innerSafetyArea = this.gameObject.transform.Find("SafetyArea - inner").gameObject;
       // midSafetyArea = this.gameObject.transform.Find("SafetyArea - mid").gameObject;
       // outterSafetyArea = this.gameObject.transform.Find("SafetyArea - outer").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 robotArmPosition = robotArm.transform.position;
        safetyReminder.transform.position = robotArmPosition;
        var headPosition = Camera.main.transform.position;
        safetyDistance = Mathf.Abs(Vector3.Distance(robotArmPosition, headPosition));
        //Debug.Log(safetyDistance);

        MeshRenderer inMeshRenderer = innerSafetyArea.GetComponent<MeshRenderer>();
        //MeshRenderer midMeshRenderer = midSafetyArea.GetComponent<MeshRenderer>();
        //MeshRenderer outMeshRenderer = outterSafetyArea.GetComponent<MeshRenderer>();
        if(safetyDistance > 2f)
        {
            inMeshRenderer.material = oldInnerLayer;
        }
        if (safetyDistance <= 2f)
        {
            inMeshRenderer.material = newInnerLayer;

        }


        SafetyDistance.Instance.ChangeTextMessage(string.Format("SafetyDistance :\n {0}", safetyDistance >= 1.0f ? safetyDistance.ToString("####0.0") + "m" : safetyDistance.ToString("0.00") + "cm"));
    }
}
