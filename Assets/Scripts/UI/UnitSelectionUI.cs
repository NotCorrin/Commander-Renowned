using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitSelectionUI : Listener
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement unitSelectionContainer;
    [SerializeField] private Unit parent;

    protected override void SubscribeListeners()
    {
        UIEvents.onUnitSelected += UnitSelection;
    }

    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitSelected -= UnitSelection;
    }

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<Unit>();

        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : UnitSelectionUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        try
        {
            unitSelectionContainer = uiDocument.rootVisualElement.Q<VisualElement>("container");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionUI - Element Query Failed.");
        }

        unitSelectionContainer.style.opacity = 0;
    }

    public void UnitSelection(Unit unit)
    {
        if (parent == unit)
        {
            if (FieldController.main.IsUnitPlayer(unit))
            {
                if (unitSelectionContainer.style.opacity == 0)
                {
                    unitSelectionContainer.style.opacity = 1;
                }
                else
                {
                    unitSelectionContainer.style.opacity = 0;
                }
            }
        }
        else
        {
            unitSelectionContainer.style.opacity = 0;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(unitSelectionContainer.panel, transform.position, Camera.main);
        unitSelectionContainer.transform.position = new Vector3(newPosition.x - unitSelectionContainer.layout.width / 2, newPosition.y - unitSelectionContainer.layout.height / 2, 0);
    }
}
