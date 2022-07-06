using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum SceneIndex
{
    /// <summary>
    /// Scene 0
    /// </summary>
    StartMenuScene = 0,

    /// <summary>
    /// Scene 1
    /// </summary>
    StoryScene = 1,

    /// <summary>
    /// Scene 2
    /// </summary>
    MenuSelectionScene = 2,

    /// <summary>
    /// Scene 3
    /// </summary>
    TerrainTestScene = 3,

    /// <summary>
    /// Scene 4
    /// </summary>
    BattleSceneTwo = 4,

    /// <summary>
    /// Scene 5
    /// </summary>
    BattleSceneThree = 5,

    /// <summary>
    /// Scene 6
    /// </summary>
    EndScene = 6,

    /// <summary>
    /// Scene 7
    /// </summary>
    AddMenuScene = 7,
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private UIDocument uiDocument;
    private VisualElement container;
    private TextElement loading;
    private bool startedLoading = false;

    public void LoadScene(SceneIndex index)
    {
        if (startedLoading == true)
        {
            return;
        }

        startedLoading = true;
        container.style.scale = new Vector2(1, 1);

        StartCoroutine(StartLoading((int)index));
    }

    private void Awake()
    {
        if (instance == null)
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

    private void LateStart()
    {
        container.style.opacity = 0;
        loading.style.opacity = 0;
    }

    private void OnTransitionEnd(TransitionEndEvent evt)
    {
        container.style.scale = Vector2.zero;
        container.UnregisterCallback<TransitionEndEvent>(OnTransitionEnd);
    }

    private IEnumerator StartLoading(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        operation.allowSceneActivation = false;

        while (operation.isDone == false)
        {
            yield return null;
            if (operation.progress >= 0.9f)
            {
                container.style.opacity = 1;
                loading.style.opacity = 1;
                yield return new WaitForSeconds(1f);
                AudioManager.Instance.Play("Swoosh");
                operation.allowSceneActivation = true;
            }
        }

        startedLoading = false;
    }
}
