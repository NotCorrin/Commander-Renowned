using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuUI : Listener
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement transitionElement;

    protected override void SubscribeListeners()
    {
        UIEvents.onMenuClicked += BeginTransition;
    }

    protected override void UnsubscribeListeners()
    {
        UIEvents.onMenuClicked -= BeginTransition;
    }

    void Start()
    {
        if (uiDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : MainMenuUI - has no uiDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            uiDocument = GetComponent<UIDocument>();
        }

        try
        {
            transitionElement = uiDocument.rootVisualElement.Q<VisualElement>("transition-element");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : MainMenuUI - Element Query Failed.");
        }

        transitionElement.style.opacity = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            UIEvents.OnMenuClicked();
        }
    }

    void BeginTransition()
    {
        transitionElement.style.opacity = 100;
        Debug.Log("Transitioning");
        // Register Callback on the transitionElement
        transitionElement.RegisterCallback<TransitionEndEvent>(OnTransitionComplete);
    }

    void OnTransitionComplete(TransitionEndEvent evt)
    {
        // Unregister Callback on the transitionElement
        transitionElement.UnregisterCallback<TransitionEndEvent>(OnTransitionComplete);

        // Load the next scene
        SceneManager.LoadScene("TerrainTestScene");
    }
}
