using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the ammobar.
/// </summary>
/// <remarks>
/// Inherits from Listener as it does not register callbacks.
/// </remarks>
public class AmmobarUI : UISubscriber
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement ammobarContainer;
    private TextElement ammobarValue;
    private Camera cam;
    private Unit parent;

    /// <summary>
    /// Assign UI elements to fields in AmmoBarUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        ammobarContainer = uiDocument.rootVisualElement.Query<VisualElement>("container");
        ammobarValue = ammobarContainer.Query<TextElement>("value");
    }

    /// <summary>
    /// Subscribes AmmobarUI to events.
    /// </summary>
    protected override void SubscribeListeners()
    {
        UIEvents.onUnitAmmoChanged += UpdateAmmo;
        GameEvents.onKill += HideSelf;
    }

    /// <summary>
    /// Unsubscribes AmmobarUI to events.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitAmmoChanged -= UpdateAmmo;
        GameEvents.onKill -= HideSelf;
    }

    private void UpdateAmmo(Unit unit, int value, int maxValue)
    {
        if (unit == parent)
        {
            ammobarValue.text = value + "/" + maxValue;
        }
    }

    private void HideSelf(Unit unit)
    {
        if (unit == parent)
        {
            ammobarContainer.style.display = DisplayStyle.None;
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
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(ammobarContainer.panel, transform.position, cam);
        ammobarContainer.transform.position = new Vector3(newPosition.x - (ammobarContainer.layout.width / 2), newPosition.y - (ammobarContainer.layout.height / 2), 0);
    }
}
