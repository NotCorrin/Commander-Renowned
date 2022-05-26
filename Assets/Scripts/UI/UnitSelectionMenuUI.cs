using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UnitSelectionMenuUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualTreeAsset unitCardUI;
    [SerializeField] private VisualTreeAsset unitCardCollectionUI;

    [SerializeField] private TeamScriptableObject teamScriptableObject;
    private VisualElement mainContainer;
    private TextElement mainTitleText;
    private ScrollView mainScrollView;
    private VisualElement mainScrollViewContainer;
    private Button confirmButton;

    private List<Button> activeUnits = new List<Button>();

    void Start()
    {
        VerifyInitialVars();

        confirmButton.SetEnabled(false);
        confirmButton.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 1));
        confirmButton.clickable.clicked += ConfirmButton_Clicked;

        VisualElement test = default;
        VisualElement unitCard = default;

        for (int i = 0; i < teamScriptableObject.units.Count; i++)
        {
            if (i % 5 == 0)
            {
                test = unitCardCollectionUI.Instantiate();
                mainScrollViewContainer.Add(test);
            }

            unitCard = unitCardUI.Instantiate();
            unitCard.Q<TextElement>("name-label").text = teamScriptableObject.units[i].UnitName;
            unitCard.Q<VisualElement>("unit").style.backgroundImage = new StyleBackground(teamScriptableObject.units[i].sprite);
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
                    button.Q<VisualElement>("white-background").style.backgroundColor = new StyleColor(Color.white);
                }
                else
                {
                     button.Q<VisualElement>("white-background").style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 1));
                }

                if (activeUnits.Count == 3)
                {
                    DisableAllUnits();
                    confirmButton.SetEnabled(true);
                    confirmButton.style.backgroundColor = new StyleColor(new Color(0.3529412f, 0.772549f, 0.3098039f, 1));
                }
                else {
                    EnableAllUnits();
                    confirmButton.SetEnabled(false);
                    confirmButton.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 1));
                }
            };
        });
    }

    void ConfirmButton_Clicked()
    {
        // TODO : Use the activeUnits list to set the player's team
        teamScriptableObject.activeUnits.Clear();
        foreach (Button button in activeUnits)
        {
            foreach(UnitScriptableObject unit in teamScriptableObject.units)
            {
                if(unit.UnitName == button.Q<TextElement>("name-label").text)
                {
                    teamScriptableObject.activeUnits.Add(unit);
                    break;
                }
            }
        }
        LevelManager.instance.LoadScene(SceneIndex.TerrainTestScene);
    }

    void EnableAllUnits()
    {
        mainScrollViewContainer.Query<Button>().ForEach(subbutton =>
        {
            subbutton.Q<VisualElement>("unit").RemoveFromClassList("unit-card-image-null");
        });
    }

    void DisableAllUnits()
    {
        mainScrollViewContainer.Query<Button>().ForEach(subbutton =>
        {
            if (!(activeUnits.Contains(subbutton)))
            {
                subbutton.Q<VisualElement>("unit").AddToClassList("unit-card-image-null");
            }
        });
    }

    void VerifyInitialVars()
    {
        if (uiDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : UnitSelectionMenuUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        if (teamScriptableObject == null)
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - has no TeamScriptableObject assigned in the inspector.");
            // teamScriptableObject = Resources.Load<TeamScriptableObject>("ScriptableObjects/TeamScriptableObject"); TODO : Maybe come back to this.
        }

        if (unitCardUI == null)
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - has no unitCardUI assigned in the inspector.");
        }

        if (unitCardCollectionUI == null)
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - has no unitCardCollectionUI assigned in the inspector.");
        }

        try
        {
            mainContainer = uiDocument.rootVisualElement.Q<VisualElement>("container");
            mainTitleText = mainContainer.Q<TextElement>("title-label");
            mainScrollView = mainContainer.Q<ScrollView>("scroll-view");
            mainScrollViewContainer = mainContainer.Q<VisualElement>("unity-content-container");
            confirmButton = mainContainer.Q<Button>("confirm-button");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - Element Query Failed.");
        }
    }
}
