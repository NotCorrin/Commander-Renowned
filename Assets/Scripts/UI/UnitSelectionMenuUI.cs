using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UnitSelectionMenuUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualTreeAsset unitCardUI;
    [SerializeField] private VisualTreeAsset unitCardCollectionUI;
    private VisualElement mainContainer;
    private TextElement mainTitleText;
    private ScrollView mainScrollView;
    private VisualElement mainScrollViewContainer;

    void Start()
    {
        VerifyInitialVars();

        TemplateContainer unitCard1 = unitCardUI.Instantiate();
        TemplateContainer unitCard2 = unitCardUI.Instantiate();
        TemplateContainer unitCard3 = unitCardUI.Instantiate();
        TemplateContainer unitCard4 = unitCardUI.Instantiate();
        TemplateContainer unitCard5 = unitCardUI.Instantiate();

        TemplateContainer unitCard6 = unitCardUI.Instantiate();
        TemplateContainer unitCard7 = unitCardUI.Instantiate();
        TemplateContainer unitCard8 = unitCardUI.Instantiate();
        TemplateContainer unitCard9 = unitCardUI.Instantiate();
        TemplateContainer unitCard10 = unitCardUI.Instantiate();

        TemplateContainer unitCard11 = unitCardUI.Instantiate();
        TemplateContainer unitCard12 = unitCardUI.Instantiate();
        TemplateContainer unitCard13 = unitCardUI.Instantiate();
        TemplateContainer unitCard14 = unitCardUI.Instantiate();
        TemplateContainer unitCard15 = unitCardUI.Instantiate();
        
        TemplateContainer unitCardCollection1 = unitCardCollectionUI.Instantiate();
        TemplateContainer unitCardCollection2 = unitCardCollectionUI.Instantiate();
        TemplateContainer unitCardCollection3 = unitCardCollectionUI.Instantiate();

        VisualElement unitCardCollectionContainer1 = unitCardCollection1.Q<VisualElement>("container");
        VisualElement unitCardCollectionContainer2 = unitCardCollection2.Q<VisualElement>("container");
        VisualElement unitCardCollectionContainer3 = unitCardCollection3.Q<VisualElement>("container");

        unitCardCollectionContainer1.Add(unitCard1);
        unitCardCollectionContainer1.Add(unitCard2);
        unitCardCollectionContainer1.Add(unitCard3);
        unitCardCollectionContainer1.Add(unitCard4);
        unitCardCollectionContainer1.Add(unitCard5);

        unitCardCollectionContainer2.Add(unitCard6);
        unitCardCollectionContainer2.Add(unitCard7);
        unitCardCollectionContainer2.Add(unitCard8);
        unitCardCollectionContainer2.Add(unitCard9);
        unitCardCollectionContainer2.Add(unitCard10);

        unitCardCollectionContainer3.Add(unitCard11);
        unitCardCollectionContainer3.Add(unitCard12);
        unitCardCollectionContainer3.Add(unitCard13);
        unitCardCollectionContainer3.Add(unitCard14);
        unitCardCollectionContainer3.Add(unitCard15);

        mainScrollViewContainer.Add(unitCardCollection1);
        mainScrollViewContainer.Add(unitCardCollection2);
        mainScrollViewContainer.Add(unitCardCollection3);

        mainScrollViewContainer.Query<Button>().ForEach(button =>
        {
            button.clicked += OnUnitCardClicked;
        });
    }

    void OnUnitCardClicked()
    {
        Debug.Log("UnitCardClicked");
    }

    void VerifyInitialVars()
    {
        if (uiDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : UnitSelectionMenuUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
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
