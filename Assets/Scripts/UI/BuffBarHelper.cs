using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Helper class for the buff bar.
/// Contains a static dictionary of all buffs and their corresponding images.
/// </summary>
public class BuffBarHelper : MonoBehaviour
{
    private static Dictionary<string, VectorImage> buffBarDict = new ();

    /// <summary>
    /// Gets the buff bar dictionary.
    /// The key is the buff name and the value is the corresponding vector image.
    /// </summary>
    public static Dictionary<string, VectorImage> BuffBarDict { get => buffBarDict; private set => buffBarDict = value; }

    private static void LoadIcons()
    {
        buffBarDict.Add("permAttack", Resources.Load<VectorImage>("UI/Icons/Perm Attack"));
        buffBarDict.Add("permDefence", Resources.Load<VectorImage>("UI/Icons/Perm Defence"));
        buffBarDict.Add("attack", Resources.Load<VectorImage>("UI/Icons/Attack"));
        buffBarDict.Add("defence", Resources.Load<VectorImage>("UI/Icons/Defence"));
        buffBarDict.Add("accuracy", Resources.Load<VectorImage>("UI/Icons/Accuracy"));
        buffBarDict.Add("thorns", Resources.Load<VectorImage>("UI/Icons/Thorns"));
    }

    private void Awake()
    {
        InitialLoader.onLoaded += LoadIcons;
        Destroy(gameObject);
    }
}
