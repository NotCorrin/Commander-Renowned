using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HelpUI : MonoBehaviour
{
    #region Page Structure
    enum PageState
    {
        Enabled,
        Disabled,
        Closing
    }

    class Page
    {
        // Needs to be a class as state is changed
        // and needs to be accessed from multiple places
        public VisualElement container, titleButton;
        public PageState state = PageState.Disabled;
    }
    #endregion

    [SerializeField] UIDocument uiDocument;
    VisualElement container, contentBar, contentContainer, toggle;
    bool isOpen = false;
    List<Page> pages = new List<Page>();
    Page phaseVanguard, phaseSupport, test;

    void Awake()
    {
        phaseVanguard = new Page();
        phaseSupport = new Page();
        test = new Page();
        
        if (uiDocument == null)
        {
            Debug.LogWarning("No UI Document assigned");
            uiDocument = GetComponent<UIDocument>();
        }

        try
        {
            toggle = uiDocument.rootVisualElement.Query<VisualElement>("toggle-container");

            container = uiDocument.rootVisualElement.Query<VisualElement>("container");
            
            contentBar = container.Query<VisualElement>("content-bar");
            contentContainer = container.Query<VisualElement>("content-container"); 

            phaseVanguard.titleButton = contentBar.Query<VisualElement>("phase-vanguard");
            phaseSupport.titleButton = contentBar.Query<VisualElement>("phase-support");
            test.titleButton = contentBar.Query<VisualElement>("test");

            phaseVanguard.container = contentContainer.Query<VisualElement>("phase-vanguard");
            phaseSupport.container = contentContainer.Query<VisualElement>("phase-support");
            test.container = contentContainer.Query<VisualElement>("test");
        }
        catch
        {
            Debug.LogError("Book UI - Element Query Failed");
        }

        toggle.RegisterCallback<ClickEvent>(Toggle_Clicked);

        phaseVanguard.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseVanguard);
        phaseSupport.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSupport);
        test.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, test);

        phaseVanguard.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseVanguard);
        phaseSupport.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSupport);
        test.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, test);

        pages.Add(phaseVanguard);
        pages.Add(phaseSupport);
        pages.Add(test);

        // Set initial state
        phaseVanguard.state = PageState.Enabled;
    }

    void OnDestroy()
    {
        toggle.UnregisterCallback<ClickEvent>(Toggle_Clicked);

        phaseVanguard.container.UnregisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd);
        phaseSupport.container.UnregisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd);
        test.container.UnregisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd);

        phaseVanguard.titleButton.UnregisterCallback<ClickEvent, Page>(PageButton_Clicked);
        phaseSupport.titleButton.UnregisterCallback<ClickEvent, Page>(PageButton_Clicked);
        test.titleButton.UnregisterCallback<ClickEvent, Page>(PageButton_Clicked);
    }

    void Toggle_Clicked(ClickEvent evt)
    {
        if (isOpen)
        {
            Debug.Log("Closing");
            isOpen = false;

            container.RemoveFromClassList("help-enabled");
            container.AddToClassList("help-disabled");
            container.SetEnabled(false);
        }
        else
        {
            Debug.Log("Opening");
            isOpen = true;

            container.RemoveFromClassList("help-disabled");
            container.AddToClassList("help-enabled");
            container.SetEnabled(true);
        }
    }

    void PageButton_Clicked(ClickEvent evt, Page page)
    {
        if (page.state != PageState.Disabled) return;

        foreach (Page enabledPage in pages)
        {
            if (enabledPage.state != PageState.Enabled) continue;

            enabledPage.state = PageState.Closing;
            enabledPage.container.RemoveFromClassList("page-enabled");
            enabledPage.container.AddToClassList("page-closing");
            enabledPage.titleButton.RemoveFromClassList("content-title-selected");
            enabledPage.titleButton.AddToClassList("content-title");
            break;
        }

        page.state = PageState.Enabled;
        page.container.RemoveFromClassList("page-disabled");
        page.container.AddToClassList("page-enabled");
        page.titleButton.RemoveFromClassList("content-title");
        page.titleButton.AddToClassList("content-title-selected");
        page.container.SetEnabled(true);
    }

    void Page_TransitionEnd(TransitionEndEvent evt, Page page)
    {
        if (page.state != PageState.Closing) return;

        page.state = PageState.Disabled;
        page.container.RemoveFromClassList("page-closing");
        page.container.AddToClassList("page-disabled");
        page.container.SetEnabled(false);
    }
}
