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

        Scenario scenario = stories.story[stories.level + 1];
        tComplete = team.tutorialComplete;
        if (tComplete)
        {
            title.text = scenario.title;
            desc.text = AddUnit?scenario.windescription:scenario.description;
        }
        else
        {
            title.text = "Tutorial";
            desc.text = stories.tutorialText;
        }

        if (scenario.winunit.Length <= 0 || !AddUnit)
        {
            Button continueButton = new Button();
            continueButton.text = "Continue";
            continueButton.AddToClassList("button");
            continueButton.clickable.clicked += () => {
                continueButton.SetEnabled(false);
                Continue();
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
                unitButton.clickable.clicked += () => {
                    unitButton.SetEnabled(false);
                    team.units.Add(unit);
                    LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
                };

                buttonContainer.Add(unitButton);
            }
        }
    }
    void Continue()
    {
        if (tComplete)
        {
            if (stories.level > stories.story.Length - 1)
            {
                LevelManager.instance.LoadScene(SceneIndex.EndScene);
            }
            else if (team.tutorialComplete)
            {
                Debug.LogError("THIS IS RUNNING HELP ME");
                LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
            }
            else
            {
                Debug.LogError("THIS IS RUNNING HELP ME REEEEEEEEEEEEEEEEE");
                LevelManager.instance.LoadScene(SceneIndex.TerrainTestScene);
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
