using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuffBarUI : Listener
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement container;

    private Camera cam;
    private Unit parent;

    struct Buff
    {
        public VisualElement element;
        public Label label;
    }

    Buff permAttack;
    Buff permDefence;
    Buff attack;
    Buff defence; 
    Buff thorns;
    Buff accuracy;

    protected override void SubscribeListeners()
    {
        UIEvents.onUnitPermAttackChanged += UpdatePermAttackBuff;
        UIEvents.onUnitPermDefenseChanged += UpdatePermDefenceBuff;
        UIEvents.onUnitAttackChanged += UpdateAttackBuff;
        UIEvents.onUnitDefenseChanged += UpdateDefenceBuff;
        UIEvents.onUnitAccuracyChanged += UpdateAccuracyBuff;
        UIEvents.onUnitThornsChanged += UpdateThornsBuff;
        GameEvents.onKill += HideSelf;
    }

    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitPermAttackChanged -= UpdatePermAttackBuff;
        UIEvents.onUnitPermDefenseChanged -= UpdatePermDefenceBuff;
        UIEvents.onUnitAttackChanged -= UpdateAttackBuff;
        UIEvents.onUnitDefenseChanged -= UpdateDefenceBuff;
        UIEvents.onUnitAccuracyChanged -= UpdateAccuracyBuff;
        UIEvents.onUnitThornsChanged -= UpdateThornsBuff;
        GameEvents.onKill -= HideSelf;
    }

    void HideSelf(Unit unit)
    {
        if(unit == parent)
        {
            container.style.display = DisplayStyle.None;
        }
    }

    void Awake()
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
            container = uiDocument.rootVisualElement.Q<VisualElement>("container");

            permAttack.element = container.Q<VisualElement>("permAttack");
            permDefence.element = container.Q<VisualElement>("permDefence");
            attack.element = container.Q<VisualElement>("attack");
            defence.element = container.Q<VisualElement>("defence");
            thorns.element = container.Q<VisualElement>("thorns");
            accuracy.element = container.Q<VisualElement>("accuracy");

            permAttack.label = permAttack.element.Q<Label>("label");
            permDefence.label = permDefence.element.Q<Label>("label");
            attack.label = attack.element.Q<Label>("label");
            defence.label = defence.element.Q<Label>("label");
            thorns.label = thorns.element.Q<Label>("label");
            accuracy.label = accuracy.element.Q<Label>("label");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : AttackBuffUI - Element Query Failed.");
        }
    }

    void UpdateBuff(Buff buff, int amount)
    {
        if (amount == 0)
        {
            buff.element.style.display = DisplayStyle.None;
            return;
        }

        buff.element.style.display = DisplayStyle.Flex;
        buff.label.text = amount.ToString();
    }

    void UpdatePermAttackBuff(Unit unit, int amount)
    {
        if(unit != parent) return;

        UpdateBuff(permAttack, amount);
    }

    void UpdatePermDefenceBuff(Unit unit, int amount)
    {
        if(unit != parent) return;

        UpdateBuff(permDefence, amount);
    }

    void UpdateAttackBuff(Unit unit, int buff)
    {
        if(unit != parent) return;

        UpdateBuff(attack, buff);
    }

    void UpdateDefenceBuff(Unit unit, int buff)
    {
        if(unit != parent) return;

        UpdateBuff(defence, buff);
    }

    void UpdateAccuracyBuff(Unit unit, int buff)
    {
        if(unit != parent) return;

        UpdateBuff(accuracy, buff);
    }

    void UpdateThornsBuff(Unit unit, int buff)
    {
        if(unit != parent) return;

        UpdateBuff(thorns, buff);
    }

    void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(container.panel, transform.position, cam);
        container.transform.position = new Vector3(newPosition.x - container.layout.width / 2, newPosition.y - container.layout.height / 2, 0);
    }
}
