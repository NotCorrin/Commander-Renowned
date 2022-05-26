using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseQTEUI : Listener
{
    [Header("Debugging")]
    [Range(0, 100), SerializeField] private int critChance = 10;
    public int CritChance
    {
        get => critChance;
        set
        {
            critChance = Mathf.Clamp(value, 0, 100);
            crit.style.width = new Length(critChance, LengthUnit.Percent);
        }
    }
    [Range(0, 100), SerializeField] private int normalChance = 50;
    public int NormalChance
    {
        get => normalChance;
        set
        {
            normalChance = Mathf.Clamp(value, 0, 100);
            normal.style.width = new Length(normalChance, LengthUnit.Percent);
        }
    }

    [Header("UI Elements")]
    [SerializeField] private UIDocument uiDocument;
    private VisualElement container, arrow, normal, crit;
    private TextElement statusLabel;
    private bool isMovingLeft;
    private int currentLocation;

    protected override void SubscribeListeners()
    {
        GameEvents.onQTEResolved += EndQTE;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEResolved -= EndQTE;
    }

    void Awake()
    {
        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : AttackBuffUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        try
        {
            container = uiDocument.rootVisualElement.Query<VisualElement>("container");

            arrow = container.Query<VisualElement>("arrow");
            normal = container.Query<VisualElement>("normal");
            crit = container.Query<VisualElement>("crit");

            statusLabel = container.Query<TextElement>("status");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : Mouse QTE UI - Element Query Failed.");
        }

        normal.style.width = new Length(normalChance, LengthUnit.Percent);
        crit.style.width = new Length(critChance, LengthUnit.Percent);

        container.RegisterCallback<ClickEvent>(OnClick);
        statusLabel.RegisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);
        arrow.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.6f);
        arrow.style.left = new Length(5, LengthUnit.Percent);
        isMovingLeft = false;
    }

    void OnClick(ClickEvent evt)
    {
        container.UnregisterCallback<ClickEvent>(OnClick);
        arrow.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
        Debug.Log($"Clicked {currentLocation}");

        if (currentLocation >= 50 - (critChance / 2) && currentLocation <= 50 + (critChance / 2))
        {
            Debug.Log("Crit");
            statusLabel.text = "CRIT!";
            statusLabel.style.color = new StyleColor(new Color((0f / 255f), (152f / 255f), (220f / 255f)));
            MenuEvents.QTETriggered(GameManager.QTEResult.Critical);
        }
        else if (currentLocation >= 50 - (normalChance / 2) && currentLocation <= 50 + (normalChance / 2))
        {
            Debug.Log("Normal");
            statusLabel.text = "Hit!";
            statusLabel.style.color = new StyleColor(new Color(1f, 1f, 1f));
            MenuEvents.QTETriggered(GameManager.QTEResult.Hit);
        }
        else
        {
            Debug.Log("Miss");
            statusLabel.text = "Miss...";
            statusLabel.style.color = new StyleColor(new Color(1f, 1f, 1f, 0.69f));
            MenuEvents.QTETriggered(GameManager.QTEResult.Miss);
        }

        statusLabel.style.scale = new Scale(new Vector2(3, 3));
    }

    void OnTransitionEnd(TransitionEndEvent evt)
    {
        currentLocation += isMovingLeft ? -1 : 1;
        isMovingLeft = currentLocation == 0 || currentLocation == 100 ? !isMovingLeft : isMovingLeft;

        arrow.style.left = new Length(currentLocation, LengthUnit.Percent);
    }

    void OnStatusTransitionEnd(TransitionEndEvent evt)
    {
        statusLabel.UnregisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);
        // Set transition duration
        statusLabel.style.transitionDuration = new List<TimeValue> { new TimeValue(1000f, TimeUnit.Millisecond) };
        statusLabel.style.opacity = 0f;
        statusLabel.style.scale = new Scale(new Vector2(1, 1));
    }

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         MenuEvents.QTETriggered();

    //         IsClicked = true;
    //     }
    // }

    // private void QTEAnimation(GameManager.QTEType qteType, int difficultyModifier)
    // {
    //     qteCircle.style.transitionDuration = new StyleList<TimeValue>(new List<TimeValue> { new TimeValue(QTEController.ShrinkingCircleMaxTime, TimeUnit.Second) });

    //     //Debug.Log(qteCircle.style.scale);

    //     if (!IsClicked)
    //     {
    //         qteCircle.style.scale = new Scale(new Vector2(0f, 0));

    //         if (qteCircle.style.scale == new Scale(new Vector2(0f, 0f)))
    //         {
    //             container.style.transitionDelay = new StyleList<TimeValue>(new List<TimeValue> { new TimeValue(QTEController.ShrinkingCircleMaxTime, TimeUnit.Second) });

    //             container.style.opacity = 0;
    //         }
    //     }
    //     else if (IsClicked)
    //     {
    //         qteCircle.style.scale = new Scale(new Vector2(Time.deltaTime, Time.deltaTime));

    //         container.style.opacity = 0;
    //     }
    // }

    // void LateUpdate()
    // {
    //     QTEAnimation(GameManager.QTEType.shrinkingCircle, 1);
    // }

    void EndQTE(GameManager.QTEResult result)
    {
        Invoke("DestroyQTE", 0.2f);

    }

    void DestroyQTE()
    {
        Destroy(this.gameObject);
    }

    public void SetQTEValues(int normalChance, int critChance)
    {
        this.NormalChance = normalChance;
        this.CritChance = critChance;
    }
}
