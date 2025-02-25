using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadingUI : MonoBehaviour
{
    public RawImage HeadingImage;
    public Transform Player;

    public float ye = 0.0027027f;
    void Update()
    {
        HeadingImage.uvRect = new Rect((Player.localEulerAngles.y * ye) - (179.0f * ye) , 0, 1, 1);

        Vector3 forward = Player.transform.forward;

        forward.y = 0;

        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));

        int displayangle;
        displayangle = Mathf.RoundToInt(headingAngle);
    }
}
