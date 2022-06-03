using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthbarUI : Listener
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement healthbarContainer;
    private TextElement healthbarValue;
    private Camera cam;
    private Unit parent;

    protected override void SubscribeListeners()
    {
        UIEvents.onUnitHealthChanged += UpdateHealth;
        GameEvents.onKill += HideSelf;
    }

    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitHealthChanged -= UpdateHealth;
        GameEvents.onKill -= HideSelf;
    }
    void UpdateHealth(Unit unit, int value)
    {
        if(unit == parent) healthbarValue.text = value + "";
    }
    void HideSelf(Unit unit)
    {
        if(unit == parent)
        {
            healthbarContainer.style.display = DisplayStyle.None;
        }
    }
    void Start()
    {
        cam = Camera.main;
        parent = transform.parent.GetComponent<Unit>();

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
