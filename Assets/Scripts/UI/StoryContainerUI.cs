using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StoryContainerUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private Button continueButton;
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
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : MainMenuUI - Element Query Failed.");
        }

        continueButton.clickable.clicked += () => {
            SceneManager.LoadScene("MenuSelectionScene");
        };
    }
}
