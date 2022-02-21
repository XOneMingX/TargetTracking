using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdjustOffset : MonoBehaviour
{
    public TMP_InputField GetBaseOffset;
    private UR5Controller_TrackingPoint uR5Controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            uR5Controller = GameObject.Find("Controller").GetComponent<UR5Controller_TrackingPoint>();
        }
    }

    public void ConfirmOffset()
    {
        float BaseOffset = float.Parse(GetBaseOffset.text);
        uR5Controller.AdjustJointOffset(BaseOffset);
    }
}
