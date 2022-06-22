using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            LevelManager.instance.LoadScene(SceneIndex.StartMenuScene);
        }
    }
}
