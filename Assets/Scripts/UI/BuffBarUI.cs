using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the buffbar.
/// </summary>
/// <remarks>
/// Inherits from Listener as it does not register callbacks.
/// </remarks>
public class BuffBarUI : UISubscriber
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement container;

    private Camera cam;
    private Unit parent;

    protected override void AssignUIElements()
    {
        container = uiDocument.rootVisualElement.Q<VisualElement>("container");
    }

    /// <summary>
    /// Subscribes BuffBarUI to events.
    /// </summary>
    protected override void SubscribeListeners()
    {
        GameEvents.onKill += HideSelf;
    }

    /// <summary>
    /// Unsubscribes BuffBarUI to events.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        GameEvents.onKill -= HideSelf;
    }

    private void HideSelf(Unit unit)
    {
        if (unit == parent)
        {
            container.style.display = DisplayStyle.None;
        }
    }

    private void EmptyContainer()
    {
        foreach (VisualElement child in container.Children())
        {
            child.style.opacity = 0;
        }
    }

    private void RemoveChildFromContainer(TransitionEndEvent evt)
    {
        container.Remove(evt.target as VisualElement);
    }

    private void CreateBuff(string buffName, int buffAmount)
    {
        VisualElement buff = new ()
        {
            name = buffName,
            style =
            {
                backgroundImage = new StyleBackground(BuffBarHelper.BuffBarDict[buffName]),
            },
        };

        Label amount = new Label()
        {
            name = "label",
            text = buffAmount.ToString(),
        };

        buff.AddToClassList("buff");
        amount.AddToClassList("label");

        buff.RegisterCallback<TransitionEndEvent>(RemoveChildFromContainer);

        buff.Add(amount);

        container.Add(buff);
    }

    private void Awake()
    {
        cam = Camera.main;
        parent = transform.parent.GetComponent<Unit>();
    }

    private void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(container.panel, transform.position, cam);
        container.transform.position = new Vector3(newPosition.x - (container.layout.width / 2), newPosition.y - (container.layout.height / 2), 0);
    }
}
