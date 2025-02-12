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
    private Button autoButton;
    private Button manualButton;
    private Button nfuButton;

    private Button AUTOleftButton;
    private Button AUTOrightButton;

    private Button AUTOenterButton;

    // Heading
    private GameObject headingPanel;

    // Panels
    private GameObject autoPanel;
    private GameObject NFUPanel;

    private GameObject AUTOsetCoursePanel;

    // NFU
    private GameObject NFUleftRudderPanel;
    private GameObject NFUrightRudderPanel;

    private Scrollbar NFUleftScrollbar;
    private Scrollbar NFUrightScrollbar;


    // Which steering type
    private bool isAuto;
    private bool isManual;
    private bool isNfu;

    // Bool types
    private bool isLeftNFUPressed;
    private bool isRightNFUPressed;

    private float scrollbarSpeed = 0.01f;

    public void Start()
    {
        Debug.Log("hello world");
        _PrivateVariables = GetComponent<PrivateVariables>();

        GameObject AutoPSoftTouch = GameObject.Find("AutoPSoftTouch");
        if (AutoPSoftTouch != null)
        {
            Button[] buttons = AutoPSoftTouch.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                // Assign the buttons by name
                if (button.name == "autoB")
                {
                    autoButton = button;
                    Debug.Log("1");
                }
                if (button.name == "manualB")
                {
                    manualButton = button;
                    Debug.Log("2");

                }
                if (button.name == "nfuB")
                {
                    nfuButton = button;
                    Debug.Log("3");

                }
                if (button.name == "AUTOleftB")
                {
                    AUTOleftButton = button;
                    Debug.Log("4");

                }
                if (button.name == "AUTOrightB")
                {
                    AUTOrightButton = button;
                    Debug.Log("5");

                }
                if (button.name == "AUTOenterB")
                {
                    AUTOenterButton = button;
                }
                // Listeners
                if (autoButton != null)
                {
                    autoButton.onClick.AddListener(PressAutoButton);
                }
                if (manualButton != null)
                {
                    manualButton.onClick.AddListener(PressManualButton);
                }
                if (nfuButton != null)
                {
                    nfuButton.onClick.AddListener(PressNfuButton);
                }
                if (AUTOleftButton != null)
                {
                    AUTOleftButton.onClick.AddListener(PressAutoLeftButton);
                }
                if (AUTOrightButton != null)
                {
                    AUTOrightButton.onClick.AddListener(PressAutoRightButton);
                }
                if (AUTOenterButton != null)
                {
                    AUTOenterButton.onClick.AddListener(PressEnterButton);
                }
            }

            Transform[] gameobjects = AutoPSoftTouch.GetComponentsInChildren<Transform>();
            foreach (Transform transform in gameobjects)
            {
                GameObject gameObject = transform.gameObject;
                if (gameObject.name == "headingP")
                {
                    headingPanel = gameObject;
                    Debug.Log("6");

                }
                if (gameObject.name == "autoPilotP")
                {
                    autoPanel = gameObject;
                    Debug.Log("7");

                }
                if (gameObject.name == "NFUP")
                {
                    NFUPanel = gameObject;
                    Debug.Log("8");

                }
                if (gameObject.name == "AUTOsetCourseP")
                {
                    AUTOsetCoursePanel = gameObject;
                    Debug.Log("9");

                }
                if (gameObject.name == "NFUsetCourseLeftP")
                {
                    NFUleftRudderPanel = gameObject;
                    Debug.Log("10");

                }
                if (gameObject.name == "NFUsetCourseRightP")
                {
                    NFUrightRudderPanel = gameObject;
                    Debug.Log("11");

                }
            }
            Scrollbar[] scrollbars = AutoPSoftTouch.GetComponentsInChildren<Scrollbar>();
            foreach (Scrollbar scrollbar in scrollbars)
            {
                if (scrollbar.name == "NFUScrollbarLeft")
                {
                    NFUleftScrollbar = scrollbar;
                }
                if (scrollbar.name == "NFUScrollbarRight")
                {
                    NFUrightScrollbar = scrollbar;
                }
            }
        }
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

            if (NFUrightScrollbar.size > 0)
            {
                Debug.Log("down");
                NFUrightScrollbar.size = NFUrightScrollbar.size - scrollbarSpeed;
            }
            else
            {
                Debug.Log("down");

                NFUleftScrollbar.size = NFUleftScrollbar.size + scrollbarSpeed;
            }
            TextMeshProUGUI leftRudderText = NFUleftRudderPanel.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI rightRudderText = NFUrightRudderPanel.GetComponentInChildren<TextMeshProUGUI>();


            if (leftRudderText != null && NFUrightRudderPanel != null)
            {
                leftRudderText.text = (NFUleftScrollbar.size * 35).ToString("000.0");
                rightRudderText.text = (NFUrightScrollbar.size * 35).ToString("000.0");

            }
        }
        if (isRightNFUPressed)
        {
            Debug.Log("b");

            if (NFUleftScrollbar.size > 0)
            {
                Debug.Log("down");

                NFUleftScrollbar.size = NFUleftScrollbar.size - scrollbarSpeed;
            }
            else
            {
                Debug.Log("down");

                NFUrightScrollbar.size = NFUrightScrollbar.size + scrollbarSpeed;
            }
            TextMeshProUGUI leftRudderText = NFUleftRudderPanel.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI rightRudderText = NFUrightRudderPanel.GetComponentInChildren<TextMeshProUGUI>();


            if (leftRudderText != null && NFUrightRudderPanel != null)
            {
                leftRudderText.text = (NFUleftScrollbar.size * 35).ToString("000.0");
                rightRudderText.text = (NFUrightScrollbar.size * 35).ToString("000.0");

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
    public void PressAutoLeftButton() { _PrivateVariables.SettingAutoCourse = _PrivateVariables.SettingAutoCourse - 1; Debug.Log("one press"); }
    // Changes the Set Course text by +1
    public void PressAutoRightButton() { _PrivateVariables.SettingAutoCourse ++; }
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
        TextMeshProUGUI setCourseText = AUTOsetCoursePanel.GetComponentInChildren<TextMeshProUGUI>();

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
