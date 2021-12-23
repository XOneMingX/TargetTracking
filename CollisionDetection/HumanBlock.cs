using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBlock : MonoBehaviour
{
    private GameObject humanBlock;
    // Start is called before the first frame update
    void Start()
    {
        humanBlock = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera = Camera.main.transform.position;
        humanBlock.transform.position = new Vector3(camera.x, camera.y - 0.3f, camera.z);
    }
}
