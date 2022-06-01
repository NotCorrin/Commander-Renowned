using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenuController : Listener
{
    // Start is called before the first frame update
    void EndScene(bool win)
    {
        if(win) Invoke("WinSceneDelay", 3);
        else Invoke("LoseSceneDelay", 3);
    }
    void WinSceneDelay()
    {
        LevelManager.instance.LoadScene(SceneIndex.AddUnitScene);
    }

    void LoseSceneDelay()
    {
        LevelManager.instance.LoadScene(SceneIndex.EndScene);
    }

    // Update is called once per frame
    protected override void SubscribeListeners()
    {
        GameEvents.onGameEnd += EndScene;
    }
    protected override void UnsubscribeListeners()
    {
        GameEvents.onGameEnd -= EndScene;
    }
}
