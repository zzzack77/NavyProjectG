using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class VRTestMovement : MonoBehaviour
{
    public GameObject XROriginEmpty;
    private float speed = 3f;
    int y = 0;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset = transform.position - XROriginEmpty.transform.position;
        transform.position = XROriginEmpty.transform.position + offset;


        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, (float)y, vertical).normalized;


        //if (Input.GetKey(KeyCode.Space))
        //{
        //    y = 1;
        //    Debug.Log("Space");
        //}
        //else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    y = 0;
        //}
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    y = -1;
        //    Debug.Log("Shift");
        //}
        //else if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    y = 0;
        //}

        //transform.Translate(direction * speed * Time.deltaTime);
        
    }
}
