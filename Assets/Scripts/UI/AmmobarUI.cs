using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AmmobarUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement ammobarContainer;
    private TextElement ammobarValue;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : HealthbarUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        try
        {
            ammobarContainer = uiDocument.rootVisualElement.Query<VisualElement>("container");
            ammobarValue = ammobarContainer.Query<TextElement>("value");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : AmmobarUI - Element Query Failed.");
        }
    }

    void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(ammobarContainer.panel, transform.position, cam);
        ammobarContainer.transform.position = new Vector3 (newPosition.x - ammobarContainer.layout.width / 2, newPosition.y - ammobarContainer.layout.height / 2, 0);
    }
}
