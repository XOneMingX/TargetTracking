using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTracking : MonoBehaviour
{
    private MyObserverEventHandler myObserverEventHandler;
    private Vector3 TrackedRealObject;
    public GameObject GeneratedObject;
    public GameObject DistanceDisplay;

    void Awake()
    {
        myObserverEventHandler = GameObject.FindObjectOfType<MyObserverEventHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get the position of tracking object from MyObserverEventHandler
        TrackedRealObject = myObserverEventHandler.TrackObjectPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the distance between the tracked object and generated object, and then display the distance in the panel
        Vector3 GeneratedObjectPosition = GeneratedObject.transform.position;
        float matchDistance = Mathf.Abs(Vector3.Distance(TrackedRealObject, GeneratedObjectPosition));
        SafetyDistance.Instance.ChangeTextMessage(string.Format("matchDistance :\n {0}", matchDistance >= 1.0f ? matchDistance.ToString("####0.0") + "m" : matchDistance.ToString("0.00") + "m"));
    }

    public void DisplayBoard()
    {
        //Define the position of display board
        Vector3 GeneratedObjectPosition = GeneratedObject.transform.position;
        DistanceDisplay.transform.position = new Vector3(GeneratedObjectPosition.x + 0.5f, GeneratedObjectPosition.y + 0.4f, GeneratedObjectPosition.z + 0f);
        DistanceDisplay.SetActive(true);
    }
}