using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafetyDistance : MonoBehaviour
{
    public static SafetyDistance Instance { get; private set; }

    public TextMeshProUGUI distance;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeTextMessage(string textMessage)
    {
        distance.text = textMessage;
    }
}
