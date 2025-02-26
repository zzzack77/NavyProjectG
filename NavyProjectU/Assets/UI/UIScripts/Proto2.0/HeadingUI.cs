using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeadingUI : MonoBehaviour
{
    private PrivateVariables privateVariables;

    public RawImage HeadingImage;
    public Transform Ship;

    public GameObject HeadingValue;
    public GameObject SpeedValue;
    public GameObject ROTValue;

    private float ye = 1 / 360f;
    private float offset = 179.49865f;

    private void Start()
    {
        privateVariables = GetComponent<PrivateVariables>();

    }
    void Update()
    {
        HeadingImage.uvRect = new Rect((Ship.localEulerAngles.y * ye) - offset, 0, 1, 1);

        Vector3 forward = Ship.transform.forward;

        forward.y = 0;

        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));

        int displayangle;
        displayangle = Mathf.RoundToInt(headingAngle);
    }

    public void OnHeadingUpdate()
    {
        TextMeshProUGUI headingText = HeadingValue.GetComponentInChildren<TextMeshProUGUI>();

        if (headingText != null)
        {
            headingText.text = privateVariables.Heading.ToString("000.0");
        }
    }
    public void OnRateOfTurnUpdate()
    {
        TextMeshProUGUI ROTText = ROTValue.GetComponentInChildren<TextMeshProUGUI>();

        if (ROTText != null)
        {
            ROTText.text = privateVariables.RateOfTurn.ToString("000.0");
        }
    }
    public void OnSpeedKnUpdate()
    {
        TextMeshProUGUI SpeedText = SpeedValue.GetComponentInChildren<TextMeshProUGUI>();

        if (SpeedText != null)
        {
            SpeedText.text = privateVariables.SpeedKn.ToString("000.0");
        }
    }
}