using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the UnitSelectionMenuUI.
/// </summary>
public class UnitSelectionMenuUI : UISubscriber
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualTreeAsset unitCardUI;
    [SerializeField] private VisualTreeAsset unitCardCollectionUI;

    [SerializeField] private TeamScriptableObject teamScriptableObject;
    [SerializeField] private ScenarioScriptableObject stories;
    private VisualElement mainContainer;
    private TextElement mainTitleText;
    private ScrollView mainScrollView;
    private VisualElement mainScrollViewContainer;
    private Button confirmButton;

    private List<Button> activeUnits = new ();

    /// <summary>
    /// Assign UI elements to fields in UnitSelectionMenuUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        mainContainer = uiDocument.rootVisualElement.Q<VisualElement>("container");
        mainTitleText = mainContainer.Q<TextElement>("title-label");
        mainScrollView = mainContainer.Q<ScrollView>("scroll-view");
        mainScrollViewContainer = mainContainer.Q<VisualElement>("unity-content-container");
        confirmButton = mainContainer.Q<Button>("confirm-button");
    }

    private void Start()
    {
        VerifyInitialVars();

        confirmButton.SetEnabled(false);
        confirmButton.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 1));
        confirmButton.clickable.clicked += ConfirmButton_Clicked;

        VisualElement test = default;
        VisualElement unitCard = default;

        if (!teamScriptableObject.TutorialComplete)
        {
            teamScriptableObject.Reset();
        }

        for (int i = 0; i < teamScriptableObject.Units.Count; i++)
        {
            if (i % 5 == 0)
            {
                test = unitCardCollectionUI.Instantiate();
                mainScrollViewContainer.Add(test);
            }

            unitCard = unitCardUI.Instantiate();
            unitCard.Q<TextElement>("name-label").text = teamScriptableObject.Units[i].UnitName;
            unitCard.Q<VisualElement>("unit").style.backgroundImage = new StyleBackground(teamScriptableObject.Units[i].Sprite);
            test.Q<VisualElement>("container").Add(unitCard);
        }

        mainScrollViewContainer.Query<Button>().ForEach(button =>
        {
            button.clickable.clicked += () =>
            {
                if (activeUnits.Contains(button))
                {
                    activeUnits.Remove(button);
                }
                else
                {
                    if (activeUnits.Count < 3)
                    {
                        activeUnits.Add(button);
                    }
                }

                if (activeUnits.Contains(button))
                {
                    AudioManager.instance.Play("OnMousePressed");
                    button.Q<VisualElement>("white-background").style.backgroundColor = new StyleColor(Color.white);
                }
                else
                {
                    AudioManager.instance.Play("OnMousePressed");
                    button.Q<VisualElement>("white-background").style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 1));
                }

                if (activeUnits.Count == 3)
                {
                    DisableAllUnits();
                    confirmButton.SetEnabled(true);
                    confirmButton.style.backgroundColor = new StyleColor(new Color(0.3529412f, 0.772549f, 0.3098039f, 1));
                }
                else
                {
                    EnableAllUnits();
                    confirmButton.SetEnabled(false);
                    confirmButton.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 1));
                }
            };
        });
    }

    private void OnDisable()
    {
        mainScrollViewContainer.Query<Button>().ForEach(button =>
        {
            button.clickable.clicked -= () => { };
        });
    }

    private void ConfirmButton_Clicked()
    {
        confirmButton.SetEnabled(false);
        confirmButton.clickable.clicked -= ConfirmButton_Clicked;

        teamScriptableObject.ActiveUnits.Clear();
        foreach (Button button in activeUnits)
        {
            foreach (UnitScriptableObject unit in teamScriptableObject.Units)
            {
                if (unit.UnitName == button.Q<TextElement>("name-label").text)
                {
                    teamScriptableObject.ActiveUnits.Add(unit);
                    break;
                }
            }
        }

        LevelManager.instance.LoadScene(stories.story[stories.level + 1].scene);
    }

    private void EnableAllUnits()
    {
        mainScrollViewContainer.Query<Button>().ForEach(subbutton =>
        {
            subbutton.Q<VisualElement>("unit").RemoveFromClassList("unit-card-image-null");
        });
    }

    private void DisableAllUnits()
    {
        mainScrollViewContainer.Query<Button>().ForEach(subbutton =>
        {
            if (!activeUnits.Contains(subbutton))
            {
                subbutton.Q<VisualElement>("unit").AddToClassList("unit-card-image-null");
            }
        });
    }

    private void VerifyInitialVars()
    {
        if (uiDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : UnitSelectionMenuUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        if (teamScriptableObject == null)
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - has no TeamScriptableObject assigned in the inspector.");
        }

        if (unitCardUI == null)
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - has no unitCardUI assigned in the inspector.");
        }

        if (unitCardCollectionUI == null)
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - has no unitCardCollectionUI assigned in the inspector.");
        }
    }
}
