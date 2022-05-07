using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitSelectionMenuUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement container;
    private TextElement titleText;
    private ScrollView scrollView;
    private VisualElement scrollViewContainer;

    void Start()
    {
        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : UnitSelectionMenuUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        try
        {
            container = uiDocument.rootVisualElement.Q<VisualElement>("container");
            titleText = container.Q<TextElement>("title-label");
            scrollView = container.Q<ScrollView>("scroll-view");
            scrollViewContainer = scrollView.contentContainer;
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : UnitSelectionMenuUI - Element Query Failed.");
        }
        print(scrollViewContainer);
    }
}
