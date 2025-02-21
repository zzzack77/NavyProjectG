using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadingUI : MonoBehaviour
{
    public RawImage HeadingImage;
    public Transform Player;

    private float ye = 0.002703f;

    private float headingUnit = ((14998.0f * (25.0f / 9.0f)) / 360.0f) /100f;
  //  public Text Heading;


    void Start()
    {
        Debug.Log(headingUnit);
    }

  
    void Update()
    {
        Debug.Log(Player.localEulerAngles.y / 360);
        HeadingImage.uvRect = new Rect((Player.localEulerAngles.y * ye) - (184.5f * ye) , 0, 1, 1);
        //HeadingImage.uvRect = new Rect(Player.localEulerAngles.y  , 0, 1, 1);

        Vector3 forward = Player.transform.forward;

        forward.y = 0;

        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));

        int displayangle;
        displayangle = Mathf.RoundToInt(headingAngle);

       // Heading.text = headingAngle.ToString();
    

        //switch (displayangle)
        //{
        //    case 0:
        //        Heading.text = "0";
        //        break;

        //    case 360:
        //        Heading.text = "0";
        //        break;

        //    case 45:
        //        Heading.text = "45";
        //        break;

        //    case 90:
        //        Heading.text = "90";
        //        break;

        //    case 130:
        //        Heading.text = "130";
        //        break;

        //    case 180:
        //        Heading.text = "180";
        //        break;

        //    case 225:
        //        Heading.text = "225";
        //        break;

        //    case 270:
        //        Heading.text = "270";
        //        break;

        //    default:
        //        Heading.text = headingAngle.ToString();
        //        break;


        //}




    }
}
