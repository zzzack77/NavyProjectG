using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument _document;
    //VTA = Visual Tree Asset, aka different UI screens
    //public VisualTreeAsset rudderAngleVTA;
    //public VisualTreeAsset shipsHeadVTA;
    //public VisualTreeAsset rateOfTurnVTA;
    //public VisualTreeAsset autoPilotVTA;
    //public VisualTreeAsset echoSounderVTA;
    //public VisualTreeAsset engineRevsVTA;

    public VisualTreeAsset[] uiAssets;

    // Start is called before the first frame update
    void Start()
    {
        if (_document == null)
        {
            _document = GetComponent<UIDocument>();
        }
        if (uiAssets.Length > 0)
        {
            //ChangeUIAsset(1); // Display the first asset
        }
    }
    private void Update()
    {
        
    }
    public void ChangeUIAsset(int index)
    {
        if (_document == null)
        {
            Debug.LogWarning("UIDocument is not assigned.");
            return;
        }
        if (index >= 0 && index < uiAssets.Length && uiAssets[index] != null)
        {
            _document.visualTreeAsset = uiAssets[index];

            // After checks clear current UI and repopulate with new
            var root = _document.rootVisualElement;
            root.Clear();
            uiAssets[index].CloneTree(root);
        }
        else
        {
            Debug.LogWarning("Invalid index or VisualTreeAsset is null.");
        }
    }
}


