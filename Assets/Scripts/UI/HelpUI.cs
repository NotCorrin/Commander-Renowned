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
    VisualElement container, contentBar, contentContainer, toggle, overlay;
    bool isOpen = false;
    List<Page> pages = new List<Page>();
    Page welcome, units, abilities, buffs, phaseSwap, phaseSupport, phaseVanguard, qte;

    void Awake()
    {
        welcome = new Page();
        units = new Page();
        abilities = new Page();
        buffs = new Page();
        phaseSwap = new Page();
        phaseSupport = new Page();
        phaseVanguard = new Page();
        qte = new Page();
        
        if (uiDocument == null)
        {
            Debug.LogWarning("No UI Document assigned");
            uiDocument = GetComponent<UIDocument>();
        }

        try
        {
            toggle = uiDocument.rootVisualElement.Query<VisualElement>("toggle-container");

            overlay = uiDocument.rootVisualElement.Query<VisualElement>("overlay");

            container = uiDocument.rootVisualElement.Query<VisualElement>("container");
            
            contentBar = container.Query<VisualElement>("content-bar");
            contentContainer = container.Query<VisualElement>("content-container");

            welcome.titleButton = contentBar.Query<VisualElement>("welcome");
            units.titleButton = contentBar.Query<VisualElement>("units");
            abilities.titleButton = contentBar.Query<VisualElement>("abilities");
            buffs.titleButton = contentBar.Query<VisualElement>("buffs");
            phaseSwap.titleButton = contentBar.Query<VisualElement>("phase-swap");
            phaseSupport.titleButton = contentBar.Query<VisualElement>("phase-support");
            phaseVanguard.titleButton = contentBar.Query<VisualElement>("phase-vanguard");
            qte.titleButton = contentBar.Query<VisualElement>("qte");

            welcome.container = contentContainer.Query<VisualElement>("welcome");
            units.container = contentContainer.Query<VisualElement>("units");
            abilities.container = contentContainer.Query<VisualElement>("abilities");
            buffs.container = contentContainer.Query<VisualElement>("buffs");
            phaseSwap.container = contentContainer.Query<VisualElement>("phase-swap");
            phaseSupport.container = contentContainer.Query<VisualElement>("phase-support");
            phaseVanguard.container = contentContainer.Query<VisualElement>("phase-vanguard");
            qte.container = contentContainer.Query<VisualElement>("qte");
        }
        catch
        {
            Debug.LogError("Book UI - Element Query Failed");
        }

        toggle.RegisterCallback<ClickEvent>(Toggle_Clicked);

        welcome.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, welcome);
        units.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, units);
        abilities.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, abilities);
        buffs.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, buffs);
        phaseSwap.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSwap);
        phaseSupport.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSupport);
        phaseVanguard.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseVanguard);
        qte.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, qte);

        welcome.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, welcome);
        units.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, units);
        abilities.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, abilities);
        buffs.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, buffs);
        phaseSwap.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSwap);
        phaseSupport.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSupport);
        phaseVanguard.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseVanguard);
        qte.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, qte);

        pages.Add(welcome);
        pages.Add(units);
        pages.Add(abilities);
        pages.Add(buffs);
        pages.Add(phaseSwap);
        pages.Add(phaseSupport);
        pages.Add(phaseVanguard);
        pages.Add(qte);

        // Set initial state
        welcome.state = PageState.Enabled;
    }

    void OnDestroy()
    {
        toggle.UnregisterCallback<ClickEvent>(Toggle_Clicked);

        welcome.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, welcome);
        units.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, units);
        abilities.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, abilities);
        buffs.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, buffs);
        phaseSwap.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSwap);
        phaseSupport.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSupport);
        phaseVanguard.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseVanguard);
        qte.container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, qte);

        welcome.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, welcome);
        units.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, units);
        abilities.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, abilities);
        buffs.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, buffs);
        phaseSwap.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSwap);
        phaseSupport.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSupport);
        phaseVanguard.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseVanguard);
        qte.titleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, qte);
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

            overlay.RemoveFromClassList("help-enabled");
            overlay.AddToClassList("help-disabled");
            overlay.SetEnabled(false);

            toggle.RemoveFromClassList("toggle-opened");
            toggle.AddToClassList("toggle-closed");
        }
        else
        {
            Debug.Log("Opening");
            isOpen = true;

            container.RemoveFromClassList("help-disabled");
            container.AddToClassList("help-enabled");
            container.SetEnabled(true);

            overlay.RemoveFromClassList("help-disabled");
            overlay.AddToClassList("help-enabled");
            overlay.SetEnabled(true);

            toggle.RemoveFromClassList("toggle-closed");
            toggle.AddToClassList("toggle-opened");
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
