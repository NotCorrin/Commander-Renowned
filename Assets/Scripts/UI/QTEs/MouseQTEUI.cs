using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the MouseQTEUI.
/// </summary>
public class MouseQTEUI : UISubscriber
{
    [Header("Debugging")]
    [Range(0, 100)] [SerializeField] private int critChance = 10;
    [Range(0, 100)] [SerializeField] private int normalChance = 50;
    [SerializeField] private UIDocument uiDocument;

    [Header("UI Elements")]
    private VisualElement container;
    private VisualElement arrow;
    private VisualElement normal;
    private VisualElement crit;
    private TextElement statusLabel;
    private float currentLocation;
    private bool clicked;
    private int qteLengthPercent;
    private int normalLeft;
    private int critLeft;

    /// <summary>
    /// Gets or sets the crit chance.
    /// </summary>
    public int CritChance
    {
        get => critChance;
        set
        {
            critChance = Mathf.Clamp(value, 0, 100);
            crit.style.width = new Length(critChance, LengthUnit.Percent);
        }
    }

    /// <summary>
    /// Gets or sets the normal chance.
    /// </summary>
    public int NormalChance
    {
        get => normalChance;
        set
        {
            normalChance = Mathf.Clamp(value, 0, 100);
            normal.style.width = new Length(normalChance, LengthUnit.Percent);
        }
    }

    /// <summary>
    /// Sets chance values for the QTE.
    /// </summary>
    /// <param name="normalChance">The normal chance out of 100.</param>
    /// <param name="critChance">The crit chance out of 100.</param>
    public void SetQTEValues(int normalChance, int critChance)
    {
        NormalChance = normalChance;
        CritChance = critChance;
    }

    /// <summary>
    /// Assign UI elements to fields in MouseQTEUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        container = uiDocument.rootVisualElement.Query<VisualElement>("container");

        arrow = container.Query<VisualElement>("arrow");
        normal = container.Query<VisualElement>("normal");
        crit = container.Query<VisualElement>("crit");

        statusLabel = container.Query<TextElement>("status");
    }

    /// <summary>
    /// Subscribe to events in MouseQTEUI.
    /// </summary>
    protected override void SubscribeListeners()
    {
        GameEvents.onQTEResolved += EndQTE;
    }

    /// <summary>
    /// Unsubscribe from events in MouseQTEUI.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEResolved -= EndQTE;
    }

    /// <summary>
    /// Subscribe UIElements to events in MouseQTEUI.
    /// </summary>
    protected override void RegisterCallbacks()
    {
        container.RegisterCallback<ClickEvent>(OnClick);
        statusLabel.RegisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);
    }

    /// <summary>
    /// Unsubscribe UIElements from events in MouseQTEUI.
    /// </summary>
    protected override void UnregisterCallbacks()
    {
        container.UnregisterCallback<ClickEvent>(OnClick);
        statusLabel.UnregisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);
    }

    private void Start()
    {
        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : AttackBuffUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        qteLengthPercent = 95;
        int offsetPercent = 4;

        normalLeft = qteLengthPercent - normalChance;
        critLeft = qteLengthPercent - critChance - offsetPercent;

        normal.style.left = new Length(normalLeft, LengthUnit.Percent);
        crit.style.left = new Length(critLeft, LengthUnit.Percent);

        normal.style.width = new Length(normalChance, LengthUnit.Percent);
        crit.style.width = new Length(critChance, LengthUnit.Percent);

        clicked = false;
    }

    private void OnClick(ClickEvent evt)
    {
        clicked = true;
        currentLocation = arrow.style.left.value.value;

        container.UnregisterCallback<ClickEvent>(OnClick);

        if (currentLocation >= critLeft && currentLocation <= critLeft + critChance)
        {
            Debug.Log("Crit");
            statusLabel.text = "CRIT!";
            statusLabel.style.color = new StyleColor(new Color(0f / 255f, 152f / 255f, 220f / 255f));
            MenuEvents.QTETriggered(GameManager.QTEResult.Critical);
        }
        else if (currentLocation >= normalLeft && currentLocation <= normalLeft + normalChance)
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

    private void Update()
    {
        if (clicked)
        {
            return;
        }

        currentLocation = arrow.style.left.value.value;

        if (currentLocation >= 99.9f)
        {
            arrow.style.left = new Length(0f, LengthUnit.Percent);
            currentLocation = arrow.style.left.value.value;
        }

        arrow.style.left = new Length(currentLocation + (150 * Time.deltaTime), LengthUnit.Percent);
    }

    private void OnStatusTransitionEnd(TransitionEndEvent evt)
    {
        statusLabel.UnregisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);

        // Set transition duration
        statusLabel.style.transitionDuration = new List<TimeValue> { new TimeValue(1000f, TimeUnit.Millisecond) };
        statusLabel.style.opacity = 0f;
        statusLabel.style.scale = new Scale(new Vector2(1, 1));
    }

    private void EndQTE(GameManager.QTEResult result)
    {
        Invoke("DestroyQTE", 0.2f);
    }

    private void DestroyQTE()
    {
        Destroy(gameObject);
    }
}
