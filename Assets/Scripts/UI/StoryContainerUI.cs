using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StoryContainerUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private Button continueButton;
    private TextElement storyTitle;
    private TextElement storyDesc;
    public ScenarioScriptableObject stories;
    void Start()
    {
        if (uiDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : MainMenuUI - has no uiDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            uiDocument = GetComponent<UIDocument>();
        }

        try
        {
            continueButton = uiDocument.rootVisualElement.Q<Button>("continue-button");
            storyTitle = uiDocument.rootVisualElement.Q<TextElement>("title");
            storyDesc = uiDocument.rootVisualElement.Q<TextElement>("description");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : MainMenuUI - Element Query Failed.");
        }
        storyTitle.text = stories.story[stories.level+1].title;
        Debug.Log(storyDesc);
        Debug.Log(stories.story[stories.level+1].description);
        storyDesc.text = stories.story[stories.level+1].description;

        continueButton.clickable.clicked += () => {
            SceneManager.LoadScene("MenuSelectionScene");
        };
    }
}
