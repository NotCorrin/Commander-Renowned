using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseQTEUI : Listener
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement container;
    private VisualElement qteCircle;
    private bool IsClicked = false;

    protected override void SubscribeListeners()
    {
        //throw new System.NotImplementedException();

        GameEvents.onQTEStart += QTEAnimation;
    }

    protected override void UnsubscribeListeners()
    {
        //throw new System.NotImplementedException();
        GameEvents.onQTEStart -= QTEAnimation;
    }

    void Start()
    {
        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : AttackBuffUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        try
        {
            container = uiDocument.rootVisualElement.Q<VisualElement>("container");
            qteCircle = container.Query<VisualElement>("qte-circle");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : AttackBuffUI - Element Query Failed.");
        }

        qteCircle.style.scale = new Vector2(1, 1);

        container.style.opacity = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MenuEvents.QTETriggered();

            IsClicked = true;
        }
    }

    private void QTEAnimation(QTEController.QTEType qteType, int difficultyModifier)
    {
        if (!IsClicked)
        {
            qteCircle.style.scale = new Scale(new Vector2(0.6f, 0.6f));

        }
        else if (IsClicked)
        {
            qteCircle.style.scale = new Scale(new Vector2(Time.deltaTime, Time.deltaTime));

            container.style.opacity = 0;
        }
    }

    void LateUpdate()
    {
        QTEAnimation(QTEController.QTEType.shrinkingCircle, 1);
    }
}
