using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoryContainerUI : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;
    [SerializeField] ScenarioScriptableObject stories;
    [SerializeField] TeamScriptableObject team;
    TextElement title;
    TextElement desc;
    VisualElement buttonContainer;

    bool tComplete;
    public bool AddUnit;

    void Awake()
    {
        if (uiDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : MainMenuUI - has no uiDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            uiDocument = GetComponent<UIDocument>();
        }

        try
        {
            title = uiDocument.rootVisualElement.Q<TextElement>("title");
            desc = uiDocument.rootVisualElement.Q<TextElement>("description");
            buttonContainer = uiDocument.rootVisualElement.Q<VisualElement>("button-container");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : MainMenuUI - Element Query Failed.");
        }
        Debug.Log(stories.level);
        Debug.Log(stories.story.Length);
        Scenario scenario;
        if (stories.level >= stories.story.Length - 1 && !AddUnit) AddUnit = true;
        tComplete = team.tutorialComplete;
        if (tComplete)
        {
            if (AddUnit) scenario = stories.story[stories.level];
            else scenario = stories.story[stories.level + 1];
            title.text = scenario.title;
            desc.text = AddUnit?scenario.windescription:scenario.description;
        }
        else
        {
            scenario = stories.story[stories.level + 1];
            title.text = "Tutorial";
            desc.text = stories.tutorialText;
        }

        if (scenario.winunit.Length <= 0 || !AddUnit)
        {
            Button continueButton = new Button();
            continueButton.text = "Continue";
            continueButton.AddToClassList("button");
            continueButton.RegisterCallback<MouseEnterEvent>(OnButtonHover);
            continueButton.clickable.clicked += () => {
                AudioManager.instance.Play("OnMousePressed");
                Continue(continueButton);
            };

            buttonContainer.Add(continueButton);
        }
        else
        {
            foreach (UnitScriptableObject unit in scenario.winunit)
            {
                Button unitButton = new Button();
                unitButton.text = unit.name;
                unitButton.AddToClassList("button");
                unitButton.RegisterCallback<MouseEnterEvent>(OnButtonHover);
                unitButton.clickable.clicked += () => {
                    unitButton.SetEnabled(false);
                    unitButton.clickable.clicked -= () => { };
                    unitButton.UnregisterCallback<MouseEnterEvent>(OnButtonHover);
                    AudioManager.instance.Play("OnMousePressed");
                    team.units.Add(unit);
                    LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
                };

                buttonContainer.Add(unitButton);
            }
        }
    }

    void OnButtonHover(MouseEnterEvent evt)
    {
        AudioManager.instance.Play("OnMouseHover");
    }

    void Continue(Button button)
    {
        if (tComplete)
        {
            button.SetEnabled(false);
            button.clickable.clicked -= () => { };
            button.UnregisterCallback<MouseEnterEvent>(OnButtonHover);

            if (stories.level >= stories.story.Length - 1)
            {
                stories.level = 0;
                team.tutorialComplete = false;
                LevelManager.instance.LoadScene(SceneIndex.EndScene);
            }
            else if (team.tutorialComplete)
            {
                LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
            }
            else
            {
                LevelManager.instance.LoadScene(stories.story[stories.level + 1].scene);
            }
        }
        else
        {
            title.text = stories.story[stories.level + 1].title;
            desc.text = stories.story[stories.level + 1].description;
            tComplete = true;
        }
    }
}
