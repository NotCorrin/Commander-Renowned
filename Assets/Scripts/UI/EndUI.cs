using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains code for the end screen UI.
/// </summary>
public class EndUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LevelManager.instance.LoadScene(SceneIndex.StartMenuScene);
        }
    }
}
