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

    /// <summary>
    /// Initializes the buffbar.
    /// </summary>
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
        StatusEvents.onStatusAdded += CreateBuff;
        StatusEvents.onStatusStacked += UpdateBuff;
        StatusEvents.onStatusRemoved += RemoveBuff;
    }

    /// <summary>
    /// Unsubscribes BuffBarUI to events.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        GameEvents.onKill -= HideSelf;
        StatusEvents.onStatusAdded -= CreateBuff;
        StatusEvents.onStatusStacked -= UpdateBuff;
        StatusEvents.onStatusRemoved -= RemoveBuff;
    }

    private void HideSelf(Unit unit)
    {
        if (unit == parent)
        {
            container.style.display = DisplayStyle.None;
        }
    }

    private void CreateBuff(Unit unit, Status status)
    {
        if (unit != parent)
        {
            return;
        }

        VisualElement buff = new ()
        {
            name = status.Name,
            style =
            {
                backgroundImage = new StyleBackground(BuffBarHelper.BuffBarDict[status.Name]),
            },
        };

        Label amount = new ()
        {
            name = "label",
            text = string.Empty,
        };

        buff.AddToClassList("buff");
        amount.AddToClassList("label");

        buff.Add(amount);

        container.Add(buff);
    }

    private void UpdateBuff(Unit unit, Status status)
    {
        if (unit != parent)
        {
            return;
        }

        foreach (VisualElement child in container.Children())
        {
            if (child.name == status.Name)
            {
                Label amount = child.Q<Label>("label");
                amount.text = status.StackAmount.ToString();
            }
        }
    }

    private void RemoveBuff(Unit unit, Status status)
    {
        if (unit != parent)
        {
            return;
        }

        foreach (VisualElement child in container.Children())
        {
            if (child.name == status.Name)
            {
                child.style.opacity = 0;
                container.Remove(child);
                break;
            }
        }
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
