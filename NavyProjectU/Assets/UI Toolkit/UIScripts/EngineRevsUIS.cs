using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rudel : MonoBehaviour
{
    private UIDocument _UIDocumentdocument;
    private PrivateVariables _PrivateVariables;

    private VisualElement portPropellerD;
    // Start is called before the first frame update
    void Start()
    {
        _UIDocumentdocument = GetComponent<UIDocument>();
        _PrivateVariables = GetComponent<PrivateVariables>();

        portPropellerD = _UIDocumentdocument.rootVisualElement.Q("PortPropellerD") as VisualElement;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            portPropellerD.style.rotate = new Rotate(new Angle(0.4f, AngleUnit.Turn));
        }
    }
}
