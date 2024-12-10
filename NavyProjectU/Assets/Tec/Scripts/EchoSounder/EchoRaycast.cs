using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoRaycast : MonoBehaviour
{
    RaycastHit hit;
    float height;



    void Update()
    {
        Ray ES = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(ES, out hit))
        {
            if (hit.collider.tag == "SeaFloor")
            {
                height = hit.distance - 0.5f;
                Debug.Log(height);
            }
        }
    }
}
