using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement healthbarContainer;
    private TextElement healthbarValue;
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
            healthbarContainer = uiDocument.rootVisualElement.Query<VisualElement>("container");
            healthbarValue = healthbarContainer.Query<TextElement>("value");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : HealthbarUI - Element Query Failed.");
        }
    }

    void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(healthbarContainer.panel, transform.position, cam);
        healthbarContainer.transform.position = new Vector3 (newPosition.x - healthbarContainer.layout.width / 2, newPosition.y - healthbarContainer.layout.height / 2, 0);
    }
}
