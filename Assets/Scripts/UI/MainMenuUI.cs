using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the main menu.
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LevelManager.instance.LoadScene(SceneIndex.StoryScene);
        }
    }
}
