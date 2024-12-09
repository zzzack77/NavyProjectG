using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor;
//fusing static UnityEngine.Rendering.DebugUI;

public class AutoPilotSoftTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PrivateVariables _PrivateVariables;
    // Buttons
    public Button autoButton;
    public Button manualButton;
    public Button nfuButton;

    // Panels
    public GameObject autoPanel;
    public GameObject NFUPanel;
    public GameObject headingPanel;
    public GameObject setCoursePanel;

    public Scrollbar leftScrollbar;
    public Scrollbar rightScrollbar;


    // Which steering type
    public bool isAuto;
    public bool isManual;
    public bool isNfu;

    // Bool types
    public bool isLeftNFUPressed;
    public bool isRightNFUPressed;

    private float scrollbarSpeed = 0.01f;

    public void Start()
    {
        _PrivateVariables = GetComponent<PrivateVariables>();

        // Defult manual steering mode
        PressManualButton();
    }
    private void Update()
    {
        // Tester function to check heading changes correctly
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (_PrivateVariables != null)
            {
                _PrivateVariables.Heading = _PrivateVariables.Heading + 10;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isLeftNFUPressed)
        {
            Debug.Log("b");

            if (rightScrollbar.size > 0)
            {
                Debug.Log("down");
                rightScrollbar.size = rightScrollbar.size - scrollbarSpeed;
            }
            else
            {
                Debug.Log("down");

                leftScrollbar.size = leftScrollbar.size + scrollbarSpeed;
            }
        }
        if (isRightNFUPressed)
        {
            Debug.Log("b");

            if (leftScrollbar.size > 0)
            {
                Debug.Log("down");

                leftScrollbar.size = leftScrollbar.size - scrollbarSpeed;
            }
            else
            {
                Debug.Log("down");

                rightScrollbar.size = rightScrollbar.size + scrollbarSpeed;
            }

        }
    }

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
        _PrivateVariables.SettingAutoCourse = _PrivateVariables.Heading;
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

        isNfu = false;
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
    public void PressAutoLeftButton() { _PrivateVariables.SettingAutoCourse = _PrivateVariables.SettingAutoCourse - 1; }
    // Changes the Set Course text by +1
    public void PressAutoRightButton() { _PrivateVariables.SettingAutoCourse++; }
    // Sets the auto pilot to the value you have inputted
    public void PressEnterButton() { _PrivateVariables.SetAutoCourse = _PrivateVariables.SettingAutoCourse; }

    
    // Update colour syle for selected buttons
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
    private void ChangeTextColor(Button button, Color color)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.color = color;
        }
    }
    private void UpdateButtonStyle(int number)
    {
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

    // Updating labels on text
    public void OnHeadingUpdate()
    {
        TextMeshProUGUI headingText = headingPanel.GetComponentInChildren<TextMeshProUGUI>();

        if (headingText != null)
        {
            headingText.text = _PrivateVariables.Heading.ToString("000.0");
        }
    }
    public void OnSettingAutoCourseUpdate()
    {
        TextMeshProUGUI setCourseText = setCoursePanel.GetComponentInChildren<TextMeshProUGUI>();

        if (setCourseText != null)
        {
            setCourseText.text = _PrivateVariables.SettingAutoCourse.ToString("000.0");
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
