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
    private float currentLocation;
    private int modifier;
    private bool clicked;

    protected override void SubscribeListeners()
    {
        GameEvents.onQTEResolved += EndQTE;

        container.RegisterCallback<ClickEvent>(OnClick);
        statusLabel.RegisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEResolved -= EndQTE;

        container.UnregisterCallback<ClickEvent>(OnClick);
        statusLabel.UnregisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);
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

        modifier = 1;
        clicked = false;
    }

    void OnClick(ClickEvent evt)
    {
        clicked = true;
        currentLocation = arrow.style.left.value.value;

        container.UnregisterCallback<ClickEvent>(OnClick);

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

    void Update()
    {
        if (clicked) return;

        currentLocation = arrow.style.left.value.value;

        if (currentLocation <= 0f)
        {
            modifier = 1;
            arrow.style.left = new Length(0.1f, LengthUnit.Percent);
        }
        else if (currentLocation >= 100f)
        {
            modifier = -1;
            arrow.style.left = new Length(99.9f, LengthUnit.Percent);
        }

        arrow.style.left = new Length(currentLocation + (modifier * 150 * Time.deltaTime), LengthUnit.Percent);
    }

    void OnStatusTransitionEnd(TransitionEndEvent evt)
    {
        statusLabel.UnregisterCallback<TransitionEndEvent>(OnStatusTransitionEnd);
        // Set transition duration
        statusLabel.style.transitionDuration = new List<TimeValue> { new TimeValue(1000f, TimeUnit.Millisecond) };
        statusLabel.style.opacity = 0f;
        statusLabel.style.scale = new Scale(new Vector2(1, 1));
    }

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
