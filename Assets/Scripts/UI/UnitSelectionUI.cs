using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the UnitSelection.
/// </summary>
public class UnitSelectionUI : UISubscriber
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement unitSelectionContainer;
    [SerializeField] private Unit parent;

    /// <summary>
    /// Assign UI elements to fields in UnitSelectionUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        unitSelectionContainer = uiDocument.rootVisualElement.Q<VisualElement>("container");
    }

    /// <summary>
    /// Subscribe to events in UnitSelectionUI.
    /// </summary>
    protected override void SubscribeListeners()
    {
        UIEvents.onUnitSelected += UnitSelection;
    }

    /// <summary>
    /// Unsubscribe to events in UnitSelectionUI.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitSelected -= UnitSelection;
    }

    // Start is called before the first frame update
    private void Start()
    {
        parent = transform.parent.GetComponent<Unit>();

        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : UnitSelectionUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        unitSelectionContainer.style.opacity = 0;
    }

    private void UnitSelection(Unit unit)
    {
        if (parent == unit)
        {
            if (FieldController.main.IsUnitPlayer(unit))
            {
                unitSelectionContainer.style.opacity = 1;
            }
        }
        else
        {
            unitSelectionContainer.style.opacity = 0;
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(unitSelectionContainer.panel, transform.position, Camera.main);
        unitSelectionContainer.transform.position = new Vector3(newPosition.x - (unitSelectionContainer.layout.width / 2), newPosition.y - (unitSelectionContainer.layout.height / 2), 0);
    }
}
