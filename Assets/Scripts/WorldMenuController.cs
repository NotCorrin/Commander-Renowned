using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenuController : Listener
{
    public string winScene;
    private bool win;
    // Start is called before the first frame update
    void EndScene(bool _win)
    {
        win = _win;
        Invoke("EndSceneDelay", 3);
    }
    void EndSceneDelay()
    {
        SceneManager.LoadScene(win?winScene:"EndScene");
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
