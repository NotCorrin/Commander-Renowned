using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AmmobarUI : Listener
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement ammobarContainer;
    private TextElement ammobarValue;
    private Camera cam;
    private Unit parent;


    protected override void SubscribeListeners()
    {
        UIEvents.onUnitAmmoChanged += UpdateAmmo;
        GameEvents.onKill += HideSelf;
    }

    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitAmmoChanged -= UpdateAmmo;
        GameEvents.onKill -= HideSelf;
    }
    void UpdateAmmo(Unit unit, int value, int maxValue)
    {
        if(unit == parent) ammobarValue.text = value + "/" + maxValue;
    }
    void HideSelf(Unit unit)
    {
        if(unit == parent)
        {
            ammobarContainer.style.display = DisplayStyle.None;
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
