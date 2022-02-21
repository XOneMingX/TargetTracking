using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct ModelTarget
    {
        public GameObject oModelTarget;
        public GameObject gModelTarget;
    }
    public ModelTarget[] modelTargets;

    private Vector3[] oModelTransform;
    private Vector3[] oModelRotation;
    private Vector3[] gModelTransform;
    private Vector3[] gModelRotation;

    //public GameObject Robot1; //For collision test

    //private GameObject GeneratedObject;
    //private MyObserverEventHandler myObserverEventHandler;
    //private Vector3 TrackedObjectPosition;

    //void Awake()
    //{
    //    myObserverEventHandler = GameObject.FindObjectOfType<MyObserverEventHandler>();
    //}

    //void Update()
    //{
    //    TrackedObjectPosition = myObserverEventHandler.TrackObjectPosition;
    //}

    void Start()
    {
        oModelTransform = new Vector3[modelTargets.Length];
        gModelTransform = new Vector3[modelTargets.Length];
        oModelRotation = new Vector3[modelTargets.Length];
        gModelRotation = new Vector3[modelTargets.Length];
    }



    public void GenerateRobotArm()
    {
        //Generate the collision-used or tracking-used robot
        oModelTransform[0] = modelTargets[0].oModelTarget.transform.position;
        oModelRotation[0] = modelTargets[0].oModelTarget.transform.eulerAngles;
        Vector3 GenModelTransform = oModelTransform[0];
        Vector3 GenModelRotation = oModelRotation[0];
        modelTargets[0].gModelTarget.transform.position = GenModelTransform;
        modelTargets[0].gModelTarget.transform.eulerAngles = new Vector3(0, GenModelRotation.y - GenModelRotation.y, 90);
        modelTargets[0].gModelTarget.SetActive(true);

        /*
        //Create the new robot nearby
        Robot1.transform.position = new Vector3(GenModelTransform.x, GenModelTransform.y, GenModelTransform.z + 0.4f);
        Robot1.transform.eulerAngles = new Vector3(GenModelRotation.x, GenModelRotation.y + 90f, GenModelRotation.z);
        Robot1.SetActive(true);

                //Generate the good-looking robot
        oModelTransform[0] = modelTargets[0].oModelTarget.transform.position;
        oModelRotation[0] = modelTargets[0].oModelTarget.transform.eulerAngles;
        Vector3 GenModelTransform = oModelTransform[0];
        Vector3 GenModelRotation = oModelRotation[0];
        modelTargets[0].gModelTarget.transform.position = GenModelTransform;
        modelTargets[0].gModelTarget.transform.eulerAngles = new Vector3(GenModelRotation.x, GenModelRotation.y, GenModelRotation.z);
        modelTargets[0].gModelTarget.SetActive(true);
        */
    }

}
/*
    // Used to generate multiple object in once
    void GenerateModelTargets()
    {
        for (int i = 0; i < modelTargets.Length; i++)
        {
            oModelTransform[i] = modelTargets[i].oModelTarget.transform.position;
            oModelRotation[i] = modelTargets[i].oModelTarget.transform.rotation;
            Vector3 GenModelTransform = oModelTransform[i];
            Quaternion GenModelRotation = oModelRotation[i];
            modelTargets[i].gModelTarget.transform.position = GenModelTransform;
            modelTargets[i].gModelTarget.transform.rotation = GenModelRotation;
            modelTargets[i].gModelTarget.SetActive(true);
        }
    }
public void GenerateRobotArm()
{
    GeneratedObject.transform.position = TrackedObjectPosition;
    GeneratedObject.SetActive(true);
}
 */
