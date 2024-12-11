using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float roationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * roationSpeed * Time.deltaTime);

    }
}
