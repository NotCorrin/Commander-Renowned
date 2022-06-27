using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the healthbar.
/// </summary>
public class HealthbarUI : UISubscriber
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement healthbarContainer;
    private TextElement healthbarValue;
    private Camera cam;
    private Unit parent;

    /// <summary>
    /// Assign UI elements to fields in HealthBarUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        healthbarContainer = uiDocument.rootVisualElement.Query<VisualElement>("container");
        healthbarValue = healthbarContainer.Query<TextElement>("value");
    }

    /// <summary>
    /// Subscribes HealthBarUI to events.
    /// </summary>
    protected override void SubscribeListeners()
    {
        UIEvents.onUnitHealthChanged += UpdateHealth;
        GameEvents.onKill += HideSelf;
    }

    /// <summary>
    /// Unsubscribes HealthBarUI to events.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitHealthChanged -= UpdateHealth;
        GameEvents.onKill -= HideSelf;
    }

    private void UpdateHealth(Unit unit, int value)
    {
        if (unit == parent)
        {
            healthbarValue.text = value + string.Empty;
        }
    }

    private void HideSelf(Unit unit)
    {
        if (unit == parent)
        {
            healthbarContainer.style.display = DisplayStyle.None;
        }
    }

    private void Start()
    {
        cam = Camera.main;
        parent = transform.parent.GetComponent<Unit>();

        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : HealthbarUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }
    }

    private void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(healthbarContainer.panel, transform.position, cam);
        healthbarContainer.transform.position = new Vector3(newPosition.x - (healthbarContainer.layout.width / 2), newPosition.y - (healthbarContainer.layout.height / 2), 0);
    }
}
