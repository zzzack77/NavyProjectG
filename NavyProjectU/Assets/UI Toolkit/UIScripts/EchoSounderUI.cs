using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class EchoSounderUI : MonoBehaviour
{
    private UIDocument _UIDocumentdocument;
    private PrivateVariables _PrivateVariables;

    private Button buzzerButton;
    private Button fathomButton;
    private Button feetButton;
    private Button meterButton;
    private Button bowButton;
    private Button sternButton;
    private Button powerButton;
    private Button hunderedButton;
    private Button tenButton;
    private Button oneButton;

    private void Awake()
    {
        _UIDocumentdocument = GetComponent<UIDocument>();
        _PrivateVariables = GetComponent<PrivateVariables>();

        buzzerButton = _UIDocumentdocument.rootVisualElement.Q("buzzerB") as Button;
        fathomButton = _UIDocumentdocument.rootVisualElement.Q("fathomB") as Button;
        feetButton = _UIDocumentdocument.rootVisualElement.Q("feetB") as Button;
        meterButton = _UIDocumentdocument.rootVisualElement.Q("meterB") as Button;
        bowButton = _UIDocumentdocument.rootVisualElement.Q("bowB") as Button;
        sternButton = _UIDocumentdocument.rootVisualElement.Q("sternB") as Button;
        powerButton = _UIDocumentdocument.rootVisualElement.Q("powerB") as Button;
        hunderedButton = _UIDocumentdocument.rootVisualElement.Q("hunderedB") as Button;
        tenButton = _UIDocumentdocument.rootVisualElement.Q("tenB") as Button;
        oneButton = _UIDocumentdocument.rootVisualElement.Q("oneB") as Button;

        buzzerButton.RegisterCallback<ClickEvent>(OnBuzzerPress);
        fathomButton.RegisterCallback<ClickEvent>(OnFathomPress);
        feetButton.RegisterCallback<ClickEvent>(OnFeetPress);
        meterButton.RegisterCallback<ClickEvent>(OnMeterPress);
        bowButton.RegisterCallback<ClickEvent>(OnBowPress);
        sternButton.RegisterCallback<ClickEvent>(OnSternPress);
        powerButton.RegisterCallback<ClickEvent>(OnPowerPress);
        hunderedButton.RegisterCallback<ClickEvent>(OnHunderedPress);
        tenButton.RegisterCallback<ClickEvent>(OnTenPress);
        oneButton.RegisterCallback<ClickEvent>(OnOnePress);
    }
    private void OnBuzzerPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnFathomPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnFeetPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnMeterPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnBowPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnSternPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnPowerPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnHunderedPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnTenPress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }
    private void OnOnePress(ClickEvent evt)
    {
        UnityEngine.Debug.Log("You pressed a button.");
    }



}
