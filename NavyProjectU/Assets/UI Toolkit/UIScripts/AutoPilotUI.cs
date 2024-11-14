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
        UnityEngine.Debug.Log("You pressed the REMOTE button.");
        _variables.Heading = _variables.Heading + 10;
    }
    private void OnNAVPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed the NAV button.");
    }
    private void OnAUTOPress(ClickEvent evt)
    {
        _variables.IsAuto = true;
        UnityEngine.Debug.Log("You pressed the AUTO button.");
    }
    private void OnMANUALPress(ClickEvent evt)
    {
        _variables.IsAuto = false;
        UnityEngine.Debug.Log("You pressed the MANUAL button.");
    }
    private void OnNFUPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed the NFU button.");
    }
}