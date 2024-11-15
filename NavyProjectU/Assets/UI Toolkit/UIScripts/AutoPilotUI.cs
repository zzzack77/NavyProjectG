using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoPilotUI : MonoBehaviour
{
    private UIDocument _document;
    private PrivateVariables _variables;

    //LHS buttons
    private Button remoteButton;
    private Button navButton;
    private Button autoButton;
    private Button manualButton;
    private Button nfuButton;

    //Text
    private Label _headingOutputL;

    public int a = 0;

    //colours



    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _variables = GetComponent<PrivateVariables>();

        //Query searches each button name
        remoteButton = _document.rootVisualElement.Q("remoteB") as Button;
        navButton = _document.rootVisualElement.Q("navB") as Button;
        autoButton = _document.rootVisualElement.Q("autoB") as Button;
        manualButton = _document.rootVisualElement.Q("manualB") as Button;
        nfuButton = _document.rootVisualElement.Q("nfuB") as Button;


        //example code for button press, will call function "OnAutoPress"
        
        
        remoteButton.RegisterCallback<ClickEvent>(OnREMOTEPress);
        navButton.RegisterCallback<ClickEvent>(OnNAVPress);
        autoButton.RegisterCallback<ClickEvent>(OnAUTOPress);
        manualButton.RegisterCallback<ClickEvent>(OnMANUALPress);
        nfuButton.RegisterCallback<ClickEvent>(OnNFUPress);


        //explample changing text code
        
        
    }
    private void Update()
    {
        var _headingOutputL = _document.rootVisualElement.Q("headingOutputL") as Label;

        _headingOutputL.text = _variables.Heading.ToString();
        
        

    }
    //Unregisters each button when the UI is disableda
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
        _variables.Heading = _variables.Heading + 10;
    }
    private void OnNAVPress(ClickEvent evt)
    {
        HighlightSelectedButton(1);

        UnityEngine.Debug.Log("You pressed the NAV button.");
    }
    private void OnAUTOPress(ClickEvent evt)
    {
        HighlightSelectedButton(2);

        _variables.IsAuto = true;
        UnityEngine.Debug.Log("You pressed the AUTO button.");
    }
    private void OnMANUALPress(ClickEvent evt)
    {
        HighlightSelectedButton(3);

        manualButton.AddToClassList("buttonClicked");

        _variables.IsAuto = false;
        UnityEngine.Debug.Log("You pressed the MANUAL button.");
        
    }
    private void OnNFUPress(ClickEvent evt)
    {
        HighlightSelectedButton(4);

        
        UnityEngine.Debug.Log("You pressed the NFU button.");
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
        if (ColorUtility.TryParseHtmlString(hexColorDB, out colorDB)) ;
        else UnityEngine.Debug.Log("error1");

        if (ColorUtility.TryParseHtmlString(hexColorG, out colorGrey)) ;
        else UnityEngine.Debug.Log("error2");

        if (ColorUtility.TryParseHtmlString(hexColorB, out colorBlue)) ;
        else UnityEngine.Debug.Log("error3");

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
