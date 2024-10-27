using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public GameObject[] clouds;
    public float speed;

    void Update()
    {
        foreach (GameObject cloud in clouds)
        {
            cloud.transform.Translate(speed * Time.deltaTime, 0, 0);
            if (cloud.transform.position.x > 8)
            {
                cloud.transform.position = new Vector3(cloud.transform.position.x*-1, cloud.transform.position.y, cloud.transform.position.z);
            }
        }

    }
}
