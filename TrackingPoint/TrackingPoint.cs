using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class TrackingPoint : MonoBehaviour
{
    private ListPoints listPoints;
    internal GameObject[] GetPoints;

    void Awake()
    {
        listPoints = GameObject.FindObjectOfType<ListPoints>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GetPoints == null)
        {
            GetPoints = listPoints.points;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    async Task GetPointsTransform()
    {
        await Task.Run(() =>
        {
            foreach (GameObject point in GetPoints)
            {
                var PointPosX = point.transform.position.x;
                var PointPosY = point.transform.position.y;
                var PointPosZ = point.transform.position.z;
                var PointRotaX = point.transform.rotation.x;
                var PointRotaY = point.transform.rotation.y;
                var PointRotaZ = point.transform.rotation.z;
            }
        });
    }
}
