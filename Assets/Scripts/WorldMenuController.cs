using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMenuController : Listener
{
    public string winScene;
    // Start is called before the first frame update
    void EndScene(bool win)
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
