using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//fusing static UnityEngine.Rendering.DebugUI;

public class AutoPilotSoftTouch : MonoBehaviour
{
    // Buttons
    public Button autoButton;
    public Button manualButton;
    public Button nfuButton;

    // Panels
    public GameObject autoPanel;
    public GameObject NFUPanel;

    // Which steering type
    public bool isAuto;
    public bool isManual;
    public bool isNfu;

    public void Start()
    {
        // Defult manual steering mode
        PressManualButton();

        // Defult bottom panel Auto Pilot
        if (autoPanel != null && NFUPanel != null)
        {
            autoPanel.SetActive(true);
            NFUPanel.SetActive(false);
        }
    }
    // Auto pilot button press
    public void PressAutoButton()
    {
        UpdateButtonStyle(0);
        
        isAuto = true;
        isManual = false;
        isNfu = false;

        if (autoPanel != null && NFUPanel != null)
        {
            autoPanel.SetActive(true);
            NFUPanel.SetActive(false);
        }
    }

    // Manual button press
    public void PressManualButton()
    {
        UpdateButtonStyle(1);
        
        isAuto = false;
        isManual = true;
        isNfu = false;
    }

    // NFU button press
    public void PressNfuButton()
    {
        UpdateButtonStyle(2);

        isNfu = false;
        isManual = false;
        isNfu = true;

        if (autoPanel != null && NFUPanel != null)
        {
            autoPanel.SetActive(false);
            NFUPanel.SetActive(true);
        }
    }
    
    public void ChangeButtonColor(Button button, Color color)
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
    public void ChangeTextColor(Button button, Color color)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.color = color;
        }
    }
    public void UpdateButtonStyle(int number)
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
}
