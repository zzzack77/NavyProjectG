using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Runtime.CompilerServices;
//using System.Drawing;
//fusing static UnityEngine.Rendering.DebugUI;

public class AutoPilot2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PrivateVariables privateVariables;
    private ShipMovement shipMovement;

    // Heading 000.0
    public GameObject headingPanel;

    // Buttons
    public Button autoButton;
    public Button manualButton;
    public Button nfuButton;

    // Main visable lower half Panels
    public GameObject autoPanel;
    public GameObject NFUPanel;
    
    // AutoPilot panel 000.0
    public GameObject AUTOsetCoursePanel;
    public GameObject AUTOcurrentTargetPanel;

    // NFU panels 000.0
    public GameObject NFUSetCourseLeftPanel;
    public GameObject NFUSetCourseRightPanel;

    // NFU Red and Green scrollbar
    public Scrollbar leftScrollbar;
    public Scrollbar rightScrollbar;

    // Which steering type
    public bool isAuto;
    public bool isManual;
    public bool isNfu;

    // Bool types
    public bool isLeftNFUPressed;
    public bool isRightNFUPressed;

    private float scrollbarSpeed = 0.005f;

    public void Start()
    {
        privateVariables = GetComponent<PrivateVariables>();
        shipMovement = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipMovement>();

        // Defult manual steering mode
        PressManualButton();
    }

    private void FixedUpdate() { NFUButtonHandeling(); }

    // Auto pilot button press
    public void PressAutoButton()
    {
        UpdateButtonStyle(0);

        isAuto = true;
        isManual = false;
        isNfu = false;

        // Update visual pannel at bottom of UI
        if (autoPanel != null && NFUPanel != null)
        {
            autoPanel.SetActive(true);
            NFUPanel.SetActive(false);
        }
        // Set the auto pilot "set course" to the current heading value
        privateVariables.SettingAutoCourse = Mathf.FloorToInt(privateVariables.Heading);
    }

    // Manual button press
    public void PressManualButton()
    {
        UpdateButtonStyle(1);


        isAuto = false;
        isManual = true;
        isNfu = false;

        // Update visual pannel at bottom of UI
        if (autoPanel != null && NFUPanel != null)
        {
            autoPanel.SetActive(false);
            NFUPanel.SetActive(false);
        }
    }

    // NFU button press
    public void PressNfuButton()
    {
        UpdateButtonStyle(2);

        isAuto = false;
        isManual = false;
        isNfu = true;

        // Update visual pannel at bottom of UI
        if (autoPanel != null && NFUPanel != null)
        {
            autoPanel.SetActive(false);
            NFUPanel.SetActive(true);
        }
    }

    // Changes the Set Course text by -1
    public void PressAutoLeftButton() { privateVariables.SettingAutoCourse = privateVariables.SettingAutoCourse - 1; }
    // Changes the Set Course text by +1
    public void PressAutoRightButton() { privateVariables.SettingAutoCourse++; }
    // Sets the auto pilot to the value you have inputted
    public void PressEnterButton() { privateVariables.SetAutoCourse = privateVariables.SettingAutoCourse; }


    // Function changes the colour of a button
    private void ChangeButtonColor(Button button, Color color)
    {
        if (button != null)
        {
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = color;
            }
        }
    }

    // Function changes the colour of the Text under a button
    private void ChangeTextColor(Button button, Color color)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.color = color;
        }
    }

    // Handels highlighted colours on the main 3 pannels (auto, manual, nfu)
    private void UpdateButtonStyle(int number)
    {
        OnCurrentTargetUpdate();
        // Variables
        Color colorDB = Color.black;
        Color colorGrey = Color.gray;
        Color colorBlue = Color.blue;


        // Hex codes for each colour
        string hexColorDB = "#1B1D24";
        string hexColorG = "#898989";
        string hexColorB = "#9BEFFF";

        // Attempts to parse the hex colour to a unity colour
        ColorUtility.TryParseHtmlString(hexColorDB, out colorDB);
        ColorUtility.TryParseHtmlString(hexColorG, out colorGrey);
        ColorUtility.TryParseHtmlString(hexColorB, out colorBlue);

        // Toggle highlighted buttons
        switch (number)
        {
            case 0:
                ChangeButtonColor(autoButton, colorDB);
                ChangeTextColor(autoButton, colorBlue);

                ChangeButtonColor(manualButton, colorGrey);
                ChangeTextColor(manualButton, Color.white);

                ChangeButtonColor(nfuButton, colorGrey);
                ChangeTextColor(nfuButton, Color.white);
                break;
            case 1:
                ChangeButtonColor(autoButton, colorGrey);
                ChangeTextColor(autoButton, Color.white);

                ChangeButtonColor(manualButton, colorDB);
                ChangeTextColor(manualButton, colorBlue);

                ChangeButtonColor(nfuButton, colorGrey);
                ChangeTextColor(nfuButton, Color.white);
                break;
            case 2:
                ChangeButtonColor(autoButton, colorGrey);
                ChangeTextColor(autoButton, Color.white);

                ChangeButtonColor(manualButton, colorGrey);
                ChangeTextColor(manualButton, Color.white);

                ChangeButtonColor(nfuButton, colorDB);
                ChangeTextColor(nfuButton, colorBlue);
                break;

        }
    }

    // Updates heading text
    public void OnHeadingUpdate()
    {
        TextMeshProUGUI headingText = headingPanel.GetComponentInChildren<TextMeshProUGUI>();

        if (headingText != null)
        {
            headingText.text = privateVariables.Heading.ToString("000.0");
        }
    }
    // Updates set course text
    public void OnSettingAutoCourseUpdate()
    {
        TextMeshProUGUI setCourseText = AUTOsetCoursePanel.GetComponentInChildren<TextMeshProUGUI>();

        if (setCourseText != null)
        {
            setCourseText.text = privateVariables.SettingAutoCourse.ToString("000.0");
        }
    }

    // Changes current target text, if you change menu screens the target text will turn red to indicate that it is no longer using this value and you should reset it.
    // This is to avoid held values being read and turning the boat without warning when chaning to the autopilot menu
    public void OnCurrentTargetUpdate()
    {
        Color colorBlue = Color.blue;

        string hexColorB = "#9BEFFF";

        ColorUtility.TryParseHtmlString(hexColorB, out colorBlue);

        TextMeshProUGUI currentTargetText = AUTOcurrentTargetPanel.GetComponentInChildren<TextMeshProUGUI>();

        if (currentTargetText != null)
        {
            if (isAuto)
            {
                currentTargetText.text = privateVariables.SetAutoCourse.ToString("000.0");
                currentTargetText.color = colorBlue;
            }
            else
            {
                currentTargetText.color = Color.red;
            }
        }
    }
    public void NFUButtonHandeling()
    {
        // Left NFU button press
        if (isLeftNFUPressed)
        {
            if (rightScrollbar.size > 0) { rightScrollbar.size = rightScrollbar.size - scrollbarSpeed; }
            else { leftScrollbar.size = leftScrollbar.size + scrollbarSpeed; }

            TextMeshProUGUI leftRudderText = NFUSetCourseLeftPanel.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI rightRudderText = NFUSetCourseRightPanel.GetComponentInChildren<TextMeshProUGUI>();

            if (leftRudderText != null && NFUSetCourseRightPanel != null)
            {
                leftRudderText.text = (leftScrollbar.size * 35).ToString("000.0");
                rightRudderText.text = (rightScrollbar.size * 35).ToString("000.0");
            }
        }
        // Right NFU button press
        if (isRightNFUPressed)
        {
            if (leftScrollbar.size > 0) { leftScrollbar.size = leftScrollbar.size - scrollbarSpeed; }
            else { rightScrollbar.size = rightScrollbar.size + scrollbarSpeed; }

            TextMeshProUGUI leftRudderText = NFUSetCourseLeftPanel.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI rightRudderText = NFUSetCourseRightPanel.GetComponentInChildren<TextMeshProUGUI>();


            if (leftRudderText != null && NFUSetCourseRightPanel != null)
            {
                leftRudderText.text = (leftScrollbar.size * 35).ToString("000.0");
                rightRudderText.text = (rightScrollbar.size * 35).ToString("000.0");
            }
        }
        if (isNfu)
        {
            //privateVariables.                         ****START HERE****
        }
    }

    // Event triggers so holding buttons down can work
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Button listeners to change Rudder Command
    public void PressNFULeftButtonDown() { isLeftNFUPressed = true; }
    public void PressNFULeftButtonUp() { isLeftNFUPressed = false; }
    public void PressNFURightButtonDown() { isRightNFUPressed = true; }
    public void PressNFURightButtonUp() { isRightNFUPressed = false; }
}
