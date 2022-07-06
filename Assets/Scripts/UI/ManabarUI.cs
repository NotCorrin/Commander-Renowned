using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the Manabar.
/// </summary>
public class ManabarUI : UISubscriber
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement manabarContainer;
    private TextElement manabarValue;
    private Camera cam;
    private Unit parent;

    /// <summary>
    /// Assign UI elements to fields in ManabarUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        manabarContainer = uiDocument.rootVisualElement.Query<VisualElement>("container");
        manabarValue = manabarContainer.Query<TextElement>("value");
    }

    /// <summary>
    /// Subscribe to events in ManabarUI.
    /// </summary>
    protected override void SubscribeListeners()
    {
        UIEvents.onUnitManaChanged += UpdateMana;
        GameEvents.onKill += HideSelf;
    }

    /// <summary>
    /// Unsubscribe from events in ManabarUI.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitManaChanged -= UpdateMana;
        GameEvents.onKill -= HideSelf;
    }

    private void UpdateMana(Unit unit, int value, int maxValue)
    {
        if (unit == parent)
        {
            manabarValue.text = value + "/" + maxValue;
        }
    }

    private void HideSelf(Unit unit)
    {
        if (unit == parent)
        {
            manabarContainer.style.display = DisplayStyle.None;
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
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(manabarContainer.panel, transform.position, cam);
        manabarContainer.transform.position = new Vector3(newPosition.x - (manabarContainer.layout.width / 2), newPosition.y - (manabarContainer.layout.height / 2), 0);
    }
}
