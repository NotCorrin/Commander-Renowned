using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuffBarUI : Listener
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement barContainer;
    private VisualElement attackBuffContainer;
    private TextElement attackBuffValue;
    private VisualElement defenceBuffContainer;
    private TextElement defenceBuffValue;
    private VisualElement accuracyBuffContainer;
    private TextElement accuracyBuffValue;

    private Camera cam;
    private Unit parent;

    protected override void SubscribeListeners()
    {
        // UIEvents.onUnitAttackBuffChanged += UpdateAttackBuff;
    }

    protected override void UnsubscribeListeners()
    {
        // UIEvents.onUnitAttackBuffChanged -= UpdateAttackBuff;
    }

    void Start()
    {
        cam = Camera.main;
        parent = transform.parent.GetComponent<Unit>();

        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : AttackBuffUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        try
        {
            barContainer = uiDocument.rootVisualElement.Q<VisualElement>("container");
            attackBuffContainer = uiDocument.rootVisualElement.Query<VisualElement>("attack-container");
            attackBuffValue = attackBuffContainer.Query<TextElement>("attack-value");
            defenceBuffContainer = uiDocument.rootVisualElement.Query<VisualElement>("defence-container");
            defenceBuffValue = defenceBuffContainer.Query<TextElement>("defence-value");
            accuracyBuffContainer = uiDocument.rootVisualElement.Query<VisualElement>("accuracy-container");
            accuracyBuffValue = accuracyBuffContainer.Query<TextElement>("accuracy-value");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : AttackBuffUI - Element Query Failed.");
        }

        attackBuffContainer.style.opacity = 0;
        defenceBuffContainer.style.opacity = 0;
        accuracyBuffContainer.style.opacity = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            attackBuffContainer.style.opacity = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            defenceBuffContainer.style.opacity = 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            accuracyBuffContainer.style.opacity = 1;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            attackBuffContainer.style.opacity = 0;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            defenceBuffContainer.style.opacity = 0;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            accuracyBuffContainer.style.opacity = 0;
        }
    }

    void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(barContainer.panel, transform.position, cam);
        barContainer.transform.position = new Vector3(newPosition.x - barContainer.layout.width / 2, newPosition.y - barContainer.layout.height / 2, 0);
    }
}
