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
        GameEvents.onQTEStart += QTEAnimation;
        GameEvents.onQTEResolved += EndQTE;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEStart -= QTEAnimation;
        GameEvents.onQTEResolved -= EndQTE;
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
        qteCircle.style.transitionDuration = new StyleList<TimeValue>(new List<TimeValue> { new TimeValue(QTEController.ShrinkingCircleMaxTime, TimeUnit.Second) });

        //Debug.Log(qteCircle.style.scale);

        if (!IsClicked)
        {
            qteCircle.style.scale = new Scale(new Vector2(0, 0));

            if (qteCircle.style.scale == new Scale(new Vector2(0f, 0f)))
            {
                container.style.transitionDelay = new StyleList<TimeValue>(new List<TimeValue> { new TimeValue(QTEController.ShrinkingCircleMaxTime, TimeUnit.Second) });

                container.style.opacity = 0;
            }
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

    void EndQTE(QTEController.QTEResult result)
    {
        Invoke("DestroyQTE", 0.2f);

    }

    void DestroyQTE()
    {
        Destroy(this.gameObject);
    }
}
