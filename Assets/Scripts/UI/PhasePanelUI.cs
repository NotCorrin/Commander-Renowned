using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the PhasePanel.
/// </summary>
public class PhasePanelUI : UISubscriber
{
    [SerializeField] private UIDocument uIDocument;
    private VisualElement mainContainer;
    private PhaseContainer currentPhaseContainer;
    private PhaseContainer nextPhaseContainer;
    private PhaseContainer futurePhaseContainer;

    private Arrow nextArrow;
    private Arrow futureArrow;

    private StyleLength currentContainerLeft;
    private StyleLength nextArrowLeft;
    private StyleLength nextContainerLeft;
    private StyleLength futureArrowLeft;
    private StyleLength futureContainerLeft;

    /* private bool end; */

    /// <summary>
    /// This function needs to be reimplemented.
    /// </summary>
    /// <param name="ignorethisbool">This parameter needs to be reimplemented.</param>
    public void Ended(bool ignorethisbool)
    {
        /* end = true; */
    }

    /// <summary>
    /// Assign UI elements to fields in PhasePanelUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        mainContainer = uIDocument.rootVisualElement.Q<VisualElement>("container");

        currentPhaseContainer.fill = mainContainer.Q<VisualElement>("current-phase-fill");
        currentPhaseContainer.frame = mainContainer.Q<VisualElement>("current-phase-frame");
        currentPhaseContainer.label = mainContainer.Q<TextElement>("current-phase-label");

        nextPhaseContainer.fill = mainContainer.Q<VisualElement>("next-phase-fill");
        nextPhaseContainer.frame = mainContainer.Q<VisualElement>("next-phase-frame");
        nextPhaseContainer.label = mainContainer.Q<TextElement>("next-phase-label");

        futurePhaseContainer.fill = mainContainer.Q<VisualElement>("future-phase-fill");
        futurePhaseContainer.frame = mainContainer.Q<VisualElement>("future-phase-frame");
        futurePhaseContainer.label = mainContainer.Q<TextElement>("future-phase-label");

        nextArrow.fill = mainContainer.Q<VisualElement>("next-arrow-fill");
        nextArrow.frame = mainContainer.Q<VisualElement>("next-arrow-frame");

        futureArrow.fill = mainContainer.Q<VisualElement>("future-arrow-fill");
        futureArrow.frame = mainContainer.Q<VisualElement>("future-arrow-frame");
    }

    /// <summary>
    /// Subscribe UIElements to events in PhasePanelUI.
    /// </summary>
    protected override void RegisterCallbacks()
    {
        mainContainer.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

    /// <summary>
    /// Unsubscribe UIElements to events in PhasePanelUI.
    /// </summary>
    protected override void UnregisterCallbacks()
    {
        mainContainer.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

    /// <summary>
    /// Subscribe to events in PhasePanelUI.
    /// </summary>
    protected override void SubscribeListeners()
    {
        GameEvents.onPhaseChanged += OnPhaseChange;
        GameEvents.onGameEnd += Ended;
    }

    /// <summary>
    /// Unsubscribe to events in PhasePanelUI.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        GameEvents.onPhaseChanged -= OnPhaseChange;
        GameEvents.onGameEnd -= Ended;
    }

    private void Start()
    {
        if (uIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : PhasePanelUI - has no uiDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            uIDocument = GetComponent<UIDocument>();
        }

        currentContainerLeft = new Length(0, LengthUnit.Pixel);
        nextArrowLeft = new Length(400, LengthUnit.Pixel);
        nextContainerLeft = new Length(550, LengthUnit.Pixel);
        futureArrowLeft = new Length(950, LengthUnit.Pixel);
        futureContainerLeft = new Length(1100, LengthUnit.Pixel);
    }

    private string AddSpacesToPhase(string phase)
    {
        if (string.IsNullOrWhiteSpace(phase))
        {
            return string.Empty;
        }

        StringBuilder newPhase = new (phase.Length * 2);
        newPhase.Append(phase[0]);
        for (int i = 1; i < phase.Length; i++)
        {
            if (char.IsUpper(phase[i]) && phase[i - 1] != ' ')
            {
                newPhase.Append(' ');
            }

            newPhase.Append(phase[i]);
        }

        return newPhase.ToString();
    }

    private void OnPhaseChange(RoundController.Phase phase)
    {
        // if (WorldMenuController.End) return;
        currentPhaseContainer.label.style.left = new Length(-400, LengthUnit.Pixel);
        currentPhaseContainer.label.style.opacity = 0;

        nextPhaseContainer.frame.style.left = currentContainerLeft;
        nextPhaseContainer.frame.style.opacity = 0f;
        nextPhaseContainer.fill.style.left = currentContainerLeft;
        nextPhaseContainer.fill.style.opacity = 0f;
        nextPhaseContainer.label.style.left = currentContainerLeft;
        nextPhaseContainer.label.style.opacity = 1f;

        nextArrow.frame.style.left = new Length(-20f, LengthUnit.Pixel);
        nextArrow.frame.style.opacity = 0f;
        nextArrow.fill.style.left = new Length(-20f, LengthUnit.Pixel);
        nextArrow.fill.style.opacity = 0f;

        futurePhaseContainer.frame.style.left = nextContainerLeft;
        futurePhaseContainer.frame.style.opacity = 0.69f;
        futurePhaseContainer.fill.style.left = nextContainerLeft;
        futurePhaseContainer.fill.style.opacity = 0.69f;
        futurePhaseContainer.label.style.left = nextContainerLeft;
        futurePhaseContainer.label.style.opacity = 0.69f;

        futureArrow.frame.style.left = nextArrowLeft;
        futureArrow.frame.style.opacity = 1f;
        futureArrow.fill.style.left = nextArrowLeft;
        futureArrow.fill.style.opacity = 1f;

        if (RoundController.phase.ToString().Contains("Player"))
        {
            currentPhaseContainer.fill.style.unityBackgroundImageTintColor = new StyleColor(new Color(12f / 255f, 241f / 255f, 1f, 0.69f));
        }
        else
        {
            currentPhaseContainer.fill.style.unityBackgroundImageTintColor = new StyleColor(new Color(245f / 255f, 85f / 255f, 93f / 255f, 0.69f));
        }
    }

    private void OnTransitionEnd(TransitionEndEvent evt)
    {
        mainContainer.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);

        currentPhaseContainer.label.text = AddSpacesToPhase(RoundController.phase.ToString()) + " Phase";
        nextPhaseContainer.label.text = AddSpacesToPhase(((RoundController.Phase)(((int)RoundController.phase + 1) % 6)).ToString()) + " Phase";
        futurePhaseContainer.label.text = AddSpacesToPhase(((RoundController.Phase)(((int)RoundController.phase + 2) % 6)).ToString()) + " Phase";

        SetAllTransitionTimes(0f);

        currentPhaseContainer.label.style.left = currentContainerLeft;
        currentPhaseContainer.label.style.opacity = 1f;

        nextPhaseContainer.frame.style.left = nextContainerLeft;
        nextPhaseContainer.frame.style.opacity = 0.69f;
        nextPhaseContainer.fill.style.left = nextContainerLeft;
        nextPhaseContainer.fill.style.opacity = 0.69f;
        nextPhaseContainer.label.style.left = nextContainerLeft;
        nextPhaseContainer.label.style.opacity = 0.69f;

        nextArrow.frame.style.left = nextArrowLeft;
        nextArrow.frame.style.opacity = 1f;
        nextArrow.fill.style.left = nextArrowLeft;
        nextArrow.fill.style.opacity = 1f;

        futurePhaseContainer.frame.style.left = futureContainerLeft;
        futurePhaseContainer.frame.style.opacity = 0f;
        futurePhaseContainer.fill.style.left = futureContainerLeft;
        futurePhaseContainer.fill.style.opacity = 0f;
        futurePhaseContainer.label.style.left = futureContainerLeft;
        futurePhaseContainer.label.style.opacity = 0f;

        futureArrow.frame.style.left = futureArrowLeft;
        futureArrow.frame.style.opacity = 0f;
        futureArrow.fill.style.left = futureArrowLeft;
        futureArrow.fill.style.opacity = 0f;

        mainContainer.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);

        SetAllTransitionTimes(600f);
    }

    private void SetAllTransitionTimes(float timeInMs)
    {
        currentPhaseContainer.frame.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        currentPhaseContainer.fill.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        currentPhaseContainer.label.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };

        nextPhaseContainer.frame.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        nextPhaseContainer.fill.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        nextPhaseContainer.label.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };

        futurePhaseContainer.frame.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        futurePhaseContainer.fill.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        futurePhaseContainer.label.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };

        nextArrow.frame.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        nextArrow.fill.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };

        futureArrow.frame.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
        futureArrow.fill.style.transitionDuration = new List<TimeValue> { new TimeValue(timeInMs, TimeUnit.Millisecond) };
    }

    private struct PhaseContainer
    {
        public VisualElement frame;
        public VisualElement fill;
        public TextElement label;
    }

    private struct Arrow
    {
        public VisualElement frame;
        public VisualElement fill;
    }
}