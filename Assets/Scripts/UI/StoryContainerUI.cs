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

        title.text = stories.story[stories.level+1].title;
        desc.text = stories.story[stories.level+1].description;

        if (stories.story[stories.level+1].winunit.Length <= 0)
        {
            Debug.Log("YO");
            Button continueButton = new Button();
            continueButton.text = "Continue";
            continueButton.AddToClassList("button");
            continueButton.clickable.clicked += () => {
                LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
            };

            buttonContainer.Add(continueButton);
        }

        else
        {
            foreach (UnitScriptableObject unit in stories.story[stories.level+1].winunit)
            {
                Button unitButton = new Button();
                unitButton.text = unit.name;
                unitButton.AddToClassList("button");
                unitButton.clickable.clicked += () => {
                    team.units.Add(unit);
                    LevelManager.instance.LoadScene(SceneIndex.MenuSelectionScene);
                };

                buttonContainer.Add(unitButton);
            }
        }
    }
}
