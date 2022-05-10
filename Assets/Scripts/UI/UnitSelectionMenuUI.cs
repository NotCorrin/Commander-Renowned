using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;


public class UnitSelectionMenuUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualTreeAsset unitCardUI;
    [SerializeField] private VisualTreeAsset unitCardCollectionUI;

    // TODO : Remove this after unit scriptable objects are implemented.
    [Range(0, 30), SerializeField] private int debugUnitCards = 10;
    [SerializeField] private TeamScriptableObject teamScriptableObject;
    private VisualElement mainContainer;
    private TextElement mainTitleText;
    private ScrollView mainScrollView;
    private VisualElement mainScrollViewContainer;

    private List<Button> activeUnits = new List<Button>();

    void Start()
    {
        VerifyInitialVars();

        VisualElement test = default;
        VisualElement unitCard = default;

        // TODO : Change to ScriptableObject Units instead of hardcoded values.

        for (int i = 0; i < teamScriptableObject.units.Count; i++)
        {
            if (i % 5 == 0)
            {
                test = unitCardCollectionUI.Instantiate();
                mainScrollViewContainer.Add(test);
            }

            unitCard = unitCardUI.Instantiate();
            unitCard.Q<TextElement>("name-label").text = teamScriptableObject.units[i].UnitName;
            test.Q<VisualElement>("container").Add(unitCard);
        }

        mainScrollViewContainer.Query<Button>().ForEach(button =>
        {
            button.clickable.clicked += () =>
            {
                if (activeUnits.Contains(button))
                {
                    activeUnits.Remove(button);
                    if (activeUnits.Count < 3)
                    {
                        EnableAllUnits();
                    }
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

                    if (activeUnits.Count == 3)
                    {
                        DisableAllUnits();
                    }
                }
                else
                {
                     button.Q<VisualElement>("white-background").style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 1));
                }
            };
        });
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
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - Element Query Failed.");
        }
    }
}
