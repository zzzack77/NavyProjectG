using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoPilotUI : MonoBehaviour
{
    private UIDocument _document;

    private Button remoteButton;
    private Button navButton;
    private Button autoButton;
    private Button manualButton;
    private Button nfuButton;

    
    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        //Query searches each button name
        remoteButton = _document.rootVisualElement.Q("MANUALB") as Button;
        navButton = _document.rootVisualElement.Q("NAVB") as Button;
        autoButton = _document.rootVisualElement.Q("AUTOB") as Button;
        manualButton = _document.rootVisualElement.Q("MANUALB") as Button;
        nfuButton = _document.rootVisualElement.Q("NFUB") as Button;


        //example code for button press, will call function "OnAutoPress"
        autoButton.RegisterCallback<ClickEvent>(OnAutoPress);
        

    }
    //Unregisters each button when the UI is disableda
    private void OnDisable()
    {
        remoteButton.UnregisterCallback<ClickEvent>(OnAutoPress);
        navButton.UnregisterCallback<ClickEvent>(OnAutoPress);
        autoButton.UnregisterCallback<ClickEvent>(OnAutoPress);
        manualButton.UnregisterCallback<ClickEvent>(OnAutoPress);
        nfuButton.UnregisterCallback<ClickEvent>(OnAutoPress);
    }

    
    private void OnAutoPress(ClickEvent evt)
    {
        Debug.Log("You pressed the AUTO button.");
    }
}
