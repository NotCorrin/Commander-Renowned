using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public enum SceneIndex
{
    StartMenuScene = 0,
    StoryScene = 1,
    MenuSelectionScene = 2,
    TerrainTestScene = 3,
    AddUnitScene = 4,
    EndScene = 5
}
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private UIDocument uiDocument;
    private VisualElement container;
    private TextElement loading;

    void Awake()
    {
        if(instance == null)
		{
            instance = this;
		}
		else
		{
            Destroy(gameObject);
            return;
		}

        try
        {
            container = uiDocument.rootVisualElement.Q<VisualElement>("container");
            loading = container.Q<TextElement>("loading");
            Invoke("LateStart", 0.5f);
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : Level Manager - Element Query Failed.");
        }

        container.RegisterCallback<TransitionEndEvent>(OnTransitionEnd);

    }

	void LateStart()
	{
        container.style.opacity = 0;
        loading.style.opacity = 0;
    }

    void OnTransitionEnd(TransitionEndEvent evt)
	{
        container.style.scale = Vector2.zero;
        container.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

	public void LoadScene(SceneIndex index)
    {
        container.style.scale = new Vector2(1, 1);
        StartCoroutine(StartLoading((int)index));
	}

    IEnumerator StartLoading(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        operation.allowSceneActivation = false;

        while (operation.isDone == false)
        {
            yield return null;
            if(operation.progress >= 0.9f)
            {
                container.style.opacity = 1;
                loading.style.opacity = 1;
                yield return new WaitForSeconds(1f);
                operation.allowSceneActivation = true;
            }
        }
	}
}
