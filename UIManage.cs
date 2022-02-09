using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManage : MonoBehaviour
{
    public GameObject safetyReminder;
    public GameObject robotArm;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 robotArmPosition = robotArm.transform.position;
        safetyReminder.transform.position = new Vector3(robotArmPosition.x + 0.5f, robotArmPosition.y + 0.7f, robotArmPosition.z - 0.3f);
    }
}
