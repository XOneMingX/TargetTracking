using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;

public class HandTrackwithCube : MonoBehaviour
{
    private IMixedRealityHandJointService handJointService;

    private IMixedRealityHandJointService HandJointService =>
        handJointService ??
        (handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>());

    private MixedRealityPose? previousLeftHandPose;

    private MixedRealityPose? previousRightHandPose; 

    public GameObject HandCube;

    GameObject thumbObject;
    GameObject indexObject;
    GameObject middleObject;
    GameObject ringObject;
    GameObject pinkyObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MeasureHandCurl();
    }

    void MeasureHandCurl()
    {
        float index = HandPoseUtils.IndexFingerCurl(Handedness.Both);
        float middle = HandPoseUtils.MiddleFingerCurl(Handedness.Both);
        float ring = HandPoseUtils.RingFingerCurl(Handedness.Both);
        float pinky = HandPoseUtils.PinkyFingerCurl(Handedness.Both);
        float thumb = HandPoseUtils.ThumbFingerCurl(Handedness.Both);
        Debug.Log(index);
    }
}
