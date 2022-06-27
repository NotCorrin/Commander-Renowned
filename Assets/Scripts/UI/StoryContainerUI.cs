using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the StoryContainerUI.
/// </summary>
public class StoryContainerUI : UISubscriber
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private ScenarioScriptableObject stories;
    [SerializeField] private TeamScriptableObject team;
    private TextElement title;
    private TextElement desc;
    private VisualElement buttonContainer;

    private bool tComplete;
    private bool addUnit;

    /// <summary>
    /// Assign UI elements to fields in StoryContainerUI.
    /// </summary>
    protected override void AssignUIElements()
    {
        title = uiDocument.rootVisualElement.Q<TextElement>("title");
        desc = uiDocument.rootVisualElement.Q<TextElement>("description");
        buttonContainer = uiDocument.rootVisualElement.Q<VisualElement>("button-container");
    }

    private void Start()
    {
        if (uiDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : MainMenuUI - has no uiDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            uiDocument = GetComponent<UIDocument>();
        }

        Debug.Log(stories.Level);
        Debug.Log(stories.Story.Length);
        Scenario scenario;
        if (stories.Level >= stories.Story.Length - 1 && !addUnit)
        {
            addUnit = true;
        }

        tComplete = team.TutorialComplete;
        if (tComplete)
        {
            if (addUnit)
            {
                scenario = stories.Story[stories.Level];
            }
            else
            {
                scenario = stories.Story[stories.Level + 1];
            }

            title.text = scenario.Title;
            desc.text = addUnit ? scenario.Windescription : scenario.Description;
        }
        else
        {
            scenario = stories.Story[stories.Level + 1];
            title.text = "Tutorial";
            desc.text = stories.TutorialText;
        }

        if (scenario.Winunit.Length <= 0 || !addUnit)
        {
            Button continueButton = new ();
            continueButton.text = "Continue";
            continueButton.AddToClassList("button");
            continueButton.RegisterCallback<MouseEnterEvent>(OnButtonHover);
            continueButton.clickable.clicked += () =>
            {
                AudioManager.instance.Play("OnMousePressed");
                Continue(continueButton);
            };

            buttonContainer.Add(continueButton);
        }
        else
        {
            foreach (UnitScriptableObject unit in scenario.Winunit)
            {
                Button unitButton = new ();
                unitButton.text = unit.name;
                unitButton.AddToClassList("button");
                unitButton.RegisterCallback<MouseEnterEvent>(OnButtonHover);
                unitButton.clickable.clicked += () =>
                {
                    unitButton.SetEnabled(false);
                    unitButton.clickable.clicked -= () => { };
                    unitButton.UnregisterCallback<MouseEnterEvent>(OnButtonHover);
                    AudioManager.instance.Play("OnMousePressed");
                    team.Units.Add(unit);
                    LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
                };

                buttonContainer.Add(unitButton);
            }
        }
    }

    private void OnButtonHover(MouseEnterEvent evt)
    {
        AudioManager.instance.Play("OnMouseHover");
    }

    private void Continue(Button button)
    {
        if (tComplete)
        {
            button.SetEnabled(false);
            button.clickable.clicked -= () => { };
            button.UnregisterCallback<MouseEnterEvent>(OnButtonHover);

            if (stories.Level >= stories.Story.Length - 1)
            {
                stories.Level = 0;
                team.TutorialComplete = false;
                LevelManager.instance.LoadScene(SceneIndex.EndScene);
            }
            else if (team.TutorialComplete)
            {
                LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
            }
            else
            {
                LevelManager.instance.LoadScene(stories.Story[stories.Level + 1].Scene);
            }
        }
        else
        {
            title.text = stories.Story[stories.Level + 1].Title;
            desc.text = stories.Story[stories.Level + 1].Description;
            tComplete = true;
        }
    }
}
