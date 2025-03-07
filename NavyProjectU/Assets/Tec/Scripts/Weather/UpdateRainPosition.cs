using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRainPosition : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    [SerializeField] private Transform rainPosition;
    public bool rainIsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rainPosition.position = transform.position;
    }
    public void ActivateRain() { rain.SetActive(true); }
    public void DeactivateRain() { rain.SetActive(false); }
}
