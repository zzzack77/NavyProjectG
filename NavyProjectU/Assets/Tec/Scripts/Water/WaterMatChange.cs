using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMatChange : MonoBehaviour
{
    [SerializeField] private Material water;
    [SerializeField] private Material darkerWater;
    private GameObject[] allWater;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allWater = GameObject.FindGameObjectsWithTag("Water");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (GameObject water in allWater)
            {
                water.GetComponent<Renderer>().material = darkerWater;
            }
        }
    }
}
