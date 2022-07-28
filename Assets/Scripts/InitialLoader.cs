using System;
using UnityEngine;

public class InitialLoader : MonoBehaviour
{
    public static Action onLoaded;

    public static void Load()
    {
        onLoaded?.Invoke();
    }

    private void Start()
    {
        Load();
    }
}
