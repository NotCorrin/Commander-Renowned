using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the help pop-up.
/// </summary>
public class HelpUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement container;
    private VisualElement contentBar;
    private VisualElement contentContainer;
    private VisualElement toggle;
    private VisualElement overlay;
    private bool isOpen = false;
    private List<Page> pages = new ();
    private Page welcome;
    private Page units;
    private Page abilities;
    private Page buffs;
    private Page phaseSwap;
    private Page phaseSupport;
    private Page phaseVanguard;
    private Page qte;

    private enum PageState
    {
        Enabled,
        Disabled,
        Closing,
    }

    private void Awake()
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

            welcome.TitleButton = contentBar.Query<VisualElement>("welcome");
            units.TitleButton = contentBar.Query<VisualElement>("units");
            abilities.TitleButton = contentBar.Query<VisualElement>("abilities");
            buffs.TitleButton = contentBar.Query<VisualElement>("buffs");
            phaseSwap.TitleButton = contentBar.Query<VisualElement>("phase-swap");
            phaseSupport.TitleButton = contentBar.Query<VisualElement>("phase-support");
            phaseVanguard.TitleButton = contentBar.Query<VisualElement>("phase-vanguard");
            qte.TitleButton = contentBar.Query<VisualElement>("qte");

            welcome.Container = contentContainer.Query<VisualElement>("welcome");
            units.Container = contentContainer.Query<VisualElement>("units");
            abilities.Container = contentContainer.Query<VisualElement>("abilities");
            buffs.Container = contentContainer.Query<VisualElement>("buffs");
            phaseSwap.Container = contentContainer.Query<VisualElement>("phase-swap");
            phaseSupport.Container = contentContainer.Query<VisualElement>("phase-support");
            phaseVanguard.Container = contentContainer.Query<VisualElement>("phase-vanguard");
            qte.Container = contentContainer.Query<VisualElement>("qte");
        }
        catch
        {
            Debug.LogError("Book UI - Element Query Failed");
        }

        toggle.RegisterCallback<ClickEvent>(Toggle_Clicked);

        welcome.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, welcome);
        units.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, units);
        abilities.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, abilities);
        buffs.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, buffs);
        phaseSwap.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSwap);
        phaseSupport.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSupport);
        phaseVanguard.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseVanguard);
        qte.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, qte);

        welcome.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, welcome);
        units.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, units);
        abilities.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, abilities);
        buffs.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, buffs);
        phaseSwap.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSwap);
        phaseSupport.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSupport);
        phaseVanguard.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseVanguard);
        qte.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, qte);

        pages.Add(welcome);
        pages.Add(units);
        pages.Add(abilities);
        pages.Add(buffs);
        pages.Add(phaseSwap);
        pages.Add(phaseSupport);
        pages.Add(phaseVanguard);
        pages.Add(qte);

        // Set initial state
        welcome.State = PageState.Enabled;
    }

    private void OnDestroy()
    {
        toggle.UnregisterCallback<ClickEvent>(Toggle_Clicked);

        welcome.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, welcome);
        units.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, units);
        abilities.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, abilities);
        buffs.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, buffs);
        phaseSwap.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSwap);
        phaseSupport.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseSupport);
        phaseVanguard.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, phaseVanguard);
        qte.Container.RegisterCallback<TransitionEndEvent, Page>(Page_TransitionEnd, qte);

        welcome.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, welcome);
        units.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, units);
        abilities.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, abilities);
        buffs.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, buffs);
        phaseSwap.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSwap);
        phaseSupport.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseSupport);
        phaseVanguard.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, phaseVanguard);
        qte.TitleButton.RegisterCallback<ClickEvent, Page>(PageButton_Clicked, qte);
    }

    private void Toggle_Clicked(ClickEvent evt)
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

    private void PageButton_Clicked(ClickEvent evt, Page page)
    {
        if (page.State != PageState.Disabled)
        {
            return;
        }

        foreach (Page enabledPage in pages)
        {
            if (enabledPage.State != PageState.Enabled)
            {
                continue;
            }

            enabledPage.State = PageState.Closing;
            enabledPage.Container.RemoveFromClassList("page-enabled");
            enabledPage.Container.AddToClassList("page-closing");
            enabledPage.TitleButton.RemoveFromClassList("content-title-selected");
            enabledPage.TitleButton.AddToClassList("content-title");
            break;
        }

        page.State = PageState.Enabled;
        page.Container.RemoveFromClassList("page-disabled");
        page.Container.AddToClassList("page-enabled");
        page.TitleButton.RemoveFromClassList("content-title");
        page.TitleButton.AddToClassList("content-title-selected");
        page.Container.SetEnabled(true);
    }

    private void Page_TransitionEnd(TransitionEndEvent evt, Page page)
    {
        if (page.State != PageState.Closing)
        {
            return;
        }

        page.State = PageState.Disabled;
        page.Container.RemoveFromClassList("page-closing");
        page.Container.AddToClassList("page-disabled");
        page.Container.SetEnabled(false);
    }

    private class Page
    {
        // Needs to be a class as state is changed
        // and needs to be accessed from multiple placess
        private VisualElement container;
        private VisualElement titleButton;
        private PageState state = PageState.Disabled;

        public VisualElement Container
        {
            get { return container; }
            set { container = value; }
        }

        public VisualElement TitleButton
        {
            get { return titleButton; }
            set { titleButton = value; }
        }

        public PageState State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
