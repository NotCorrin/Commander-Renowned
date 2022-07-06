using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenuController : Listener
{
    public static bool End;
    public ScenarioScriptableObject scenarios;

    protected override void SubscribeListeners()
    {
        GameEvents.onGameEnd += EndScene;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onGameEnd -= EndScene;
    }

    private void EndScene(bool win)
    {
        End = true;
        if (win)
        {
            Invoke("WinSceneDelay", 3);
        }
        else
        {
            Invoke("LoseSceneDelay", 3);
        }
    }

    private void WinSceneDelay()
    {
        scenarios.Level++;

        LevelManager.instance.LoadScene(SceneIndex.AddMenuScene);

        // Debug.LogWarning("demo only");
        // LevelManager.instance.LoadScene(SceneIndex.EndScene);
    }

    private void LoseSceneDelay()
    {
        LevelManager.instance.LoadScene(SceneIndex.EndScene);
    }

}
