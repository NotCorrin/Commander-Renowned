using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            LevelManager.instance.LoadScene(SceneIndex.StoryScene);
        }
    }
}
