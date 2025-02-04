using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoPilotUI : MonoBehaviour
{
    //useful code not beging used anymore
    //manualButton.AddToClassList("buttonClicked");

    private UIDocument _UIDocumentdocument;
    private PrivateVariables _PrivateVariables;

    //LHS buttons
    private Button remoteButton;
    private Button navButton;
    private Button autoButton;
    private Button manualButton;
    private Button nfuButton;

    //Middle buttons
    private Button leftButton;
    private Button rightButton;
    private Button enterButton;
    private Button radiusButton;
    private Button rateButton;
    private Button paramButton;
    private Button epButton;

    //Text
    private Label _headingOutputL;
    private Label _setCourseOutputL;

    private void start()
    {
        //get component variables assigned here
        _UIDocumentdocument = GetComponent<UIDocument>();
        _PrivateVariables = GetComponent<PrivateVariables>();

        //Query searches each button name
        //LHS buttons.
        remoteButton = _UIDocumentdocument.rootVisualElement.Q("remoteB") as Button;
        navButton = _UIDocumentdocument.rootVisualElement.Q("navB") as Button;
        autoButton = _UIDocumentdocument.rootVisualElement.Q("autoB") as Button;
        manualButton = _UIDocumentdocument.rootVisualElement.Q("manualB") as Button;
        nfuButton = _UIDocumentdocument.rootVisualElement.Q("nfuB") as Button;

        //Middle buttons.
        leftButton = _UIDocumentdocument.rootVisualElement.Q("leftB") as Button;
        rightButton = _UIDocumentdocument.rootVisualElement.Q("rightB") as Button;
        enterButton = _UIDocumentdocument.rootVisualElement.Q("enterB") as Button;
        radiusButton = _UIDocumentdocument.rootVisualElement.Q("radiusB") as Button;
        rateButton = _UIDocumentdocument.rootVisualElement.Q("rateB") as Button;
        paramButton = _UIDocumentdocument.rootVisualElement.Q("paramAdjustB") as Button;
        epButton = _UIDocumentdocument.rootVisualElement.Q("epB") as Button;



        //button listener, will call funcations on press.
        remoteButton.RegisterCallback<ClickEvent>(OnREMOTEPress);
        navButton.RegisterCallback<ClickEvent>(OnNAVPress);
        autoButton.RegisterCallback<ClickEvent>(OnAUTOPress);
        manualButton.RegisterCallback<ClickEvent>(OnMANUALPress);
        nfuButton.RegisterCallback<ClickEvent>(OnNFUPress);

        leftButton.RegisterCallback<ClickEvent>(OnLeftPress);
        rightButton.RegisterCallback<ClickEvent>(OnRightPress);
        enterButton.RegisterCallback<ClickEvent>(OnEnterPress);
        radiusButton.RegisterCallback<ClickEvent>(OnRadiusPress);
        rateButton.RegisterCallback<ClickEvent>(OnRatePress);
        paramButton.RegisterCallback<ClickEvent>(OnParamPress);
        epButton.RegisterCallback<ClickEvent>(OnEpPress);


        //set manual as defult.
        HighlightSelectedButton(3);
    }
    private void Update()
    {
     
    }
    //function is called from PrivateVariables everytime Heading is updated.
    public void OnHeadingUpdate()
    {
        var _headingOutputL = _UIDocumentdocument.rootVisualElement.Q("headingOutputL") as Label;
        _headingOutputL.text = _PrivateVariables.Heading.ToString("000.0");
    }
    public void OnSettingAutoCourseUpdate()
    {
        var _setCourseOutputL = _UIDocumentdocument.rootVisualElement.Q("setCourseOutputL") as Label;
        _setCourseOutputL.text = _PrivateVariables.SettingAutoCourse.ToString("000.0");
    }
    //Unregisters each button when the UI is disabled
    private void OnDisable()
    {
        remoteButton.UnregisterCallback<ClickEvent>(OnREMOTEPress);
        navButton.UnregisterCallback<ClickEvent>(OnNAVPress);
        autoButton.UnregisterCallback<ClickEvent>(OnAUTOPress);
        manualButton.UnregisterCallback<ClickEvent>(OnMANUALPress);
        nfuButton.UnregisterCallback<ClickEvent>(OnNFUPress);
    }

    
    private void OnREMOTEPress(ClickEvent evt)
    {
        HighlightSelectedButton(0);
        UnityEngine.Debug.Log("You pressed the REMOTE button.");
        _PrivateVariables.Heading = _PrivateVariables.Heading + 10;
    }
    private void OnNAVPress(ClickEvent evt)
    {
        HighlightSelectedButton(1);

        UnityEngine.Debug.Log("You pressed the NAV button.");
    }
    private void OnAUTOPress(ClickEvent evt)
    {
        HighlightSelectedButton(2);
        _PrivateVariables.IsAuto = true;

        _PrivateVariables.SettingAutoCourse = _PrivateVariables.Heading;

        UnityEngine.Debug.Log("You pressed the AUTO button.");
    }
    private void OnMANUALPress(ClickEvent evt)
    {
        HighlightSelectedButton(3);

        _PrivateVariables.IsAuto = false;
        UnityEngine.Debug.Log("You pressed the MANUAL button.");
        
    }
    private void OnNFUPress(ClickEvent evt)
    {
        HighlightSelectedButton(4);
        
        UnityEngine.Debug.Log("You pressed the NFU button.");
    }
    private void OnLeftPress(ClickEvent evt)
    {
        _PrivateVariables.SettingAutoCourse = _PrivateVariables.SettingAutoCourse - 1; ;
    }
    private void OnRightPress(ClickEvent evt)
    {
        _PrivateVariables.SettingAutoCourse++;

    }
    private void OnEnterPress(ClickEvent evt)
    {
        _PrivateVariables.SetAutoCourse = _PrivateVariables.SettingAutoCourse;
    }
    private void OnRadiusPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");

    }
    private void OnRatePress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnParamPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnEpPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void HighlightSelectedButton(int number)
    {
        //variables
        Color colorDB = Color.black;
        Color colorGrey = Color.gray;
        Color colorBlue = Color.blue;

        
        //hex codes for each colour
        string hexColorDB = "#1B1D24";
        string hexColorG = "#898989";
        string hexColorB = "#9BEFFF";

        //attempts to parse the hex colour to a unity colour
        ColorUtility.TryParseHtmlString(hexColorDB, out colorDB);
        ColorUtility.TryParseHtmlString(hexColorG, out colorGrey);
        ColorUtility.TryParseHtmlString(hexColorB, out colorBlue);

        //depending on which button is pressed, e.g. remote button = 0, nav button = 1
        //change the background to dark blue and the text to blue and change all the other
        //buttons back to original colour.
        switch (number)
        {
            case 0:
                remoteButton.style.backgroundColor = new StyleColor(colorDB);
                remoteButton.style.color = new StyleColor(colorBlue);
                navButton.style.backgroundColor = new StyleColor(colorGrey);
                navButton.style.color = new StyleColor(Color.white);
                autoButton.style.backgroundColor = new StyleColor(colorGrey);
                autoButton.style.color = new StyleColor(Color.white);
                manualButton.style.backgroundColor = new StyleColor(colorGrey);
                manualButton.style.color = new StyleColor(Color.white);
                nfuButton.style.backgroundColor = new StyleColor(colorGrey);
                nfuButton.style.color = new StyleColor(Color.white);
                break;
            case 1:
                remoteButton.style.backgroundColor = new StyleColor(colorGrey);
                remoteButton.style.color = new StyleColor(Color.white);
                navButton.style.backgroundColor = new StyleColor(colorDB);
                navButton.style.color = new StyleColor(colorBlue);
                autoButton.style.backgroundColor = new StyleColor(colorGrey);
                autoButton.style.color = new StyleColor(Color.white);
                manualButton.style.backgroundColor = new StyleColor(colorGrey);
                manualButton.style.color = new StyleColor(Color.white);
                nfuButton.style.backgroundColor = new StyleColor(colorGrey);
                nfuButton.style.color = new StyleColor(Color.white);
                break;
            case 2:
                remoteButton.style.backgroundColor = new StyleColor(colorGrey);
                remoteButton.style.color = new StyleColor(Color.white);
                navButton.style.backgroundColor = new StyleColor(colorGrey);
                navButton.style.color = new StyleColor(Color.white);
                autoButton.style.backgroundColor = new StyleColor(colorDB);
                autoButton.style.color = new StyleColor(colorBlue);
                manualButton.style.backgroundColor = new StyleColor(colorGrey);
                manualButton.style.color = new StyleColor(Color.white);
                nfuButton.style.backgroundColor = new StyleColor(colorGrey);
                nfuButton.style.color = new StyleColor(Color.white);
                break;
            case 3:
                remoteButton.style.backgroundColor = new StyleColor(colorGrey);
                remoteButton.style.color = new StyleColor(Color.white);
                navButton.style.backgroundColor = new StyleColor(colorGrey);
                navButton.style.color = new StyleColor(Color.white);
                autoButton.style.backgroundColor = new StyleColor(colorGrey);
                autoButton.style.color = new StyleColor(Color.white);
                manualButton.style.backgroundColor = new StyleColor(colorDB);
                manualButton.style.color = new StyleColor(colorBlue);
                nfuButton.style.backgroundColor = new StyleColor(colorGrey);
                nfuButton.style.color = new StyleColor(Color.white);
                break;
            case 4:
                remoteButton.style.backgroundColor = new StyleColor(colorGrey);
                remoteButton.style.color = new StyleColor(Color.white);
                navButton.style.backgroundColor = new StyleColor(colorGrey);
                navButton.style.color = new StyleColor(Color.white);
                autoButton.style.backgroundColor = new StyleColor(colorGrey);
                autoButton.style.color = new StyleColor(Color.white);
                manualButton.style.backgroundColor = new StyleColor(colorGrey);
                manualButton.style.color = new StyleColor(Color.white);
                nfuButton.style.backgroundColor = new StyleColor(colorDB);
                nfuButton.style.color = new StyleColor(colorBlue);
                break;
        }
    }
}
