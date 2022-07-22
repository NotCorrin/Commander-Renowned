using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuffBarHelper : MonoBehaviour
{
    private static Dictionary<string, VectorImage> buffBarDict = new ();

    public static Dictionary<string, VectorImage> BuffBarDict { get => buffBarDict; private set => buffBarDict = value; }

    private void Awake()
    {
        InitialLoader.onLoaded += LoadIcons;
        Destroy(gameObject);
    }

    private static void LoadIcons()
    {
        buffBarDict.Add("permAttack", Resources.Load<VectorImage>("UI/Icons/Perm Attack"));
        buffBarDict.Add("permDefence", Resources.Load<VectorImage>("UI/Icons/Perm Defence"));
        buffBarDict.Add("attack", Resources.Load<VectorImage>("UI/Icons/Attack"));
        buffBarDict.Add("defence", Resources.Load<VectorImage>("UI/Icons/Defence"));
        buffBarDict.Add("accuracy", Resources.Load<VectorImage>("UI/Icons/Accuracy"));
        buffBarDict.Add("thorns", Resources.Load<VectorImage>("UI/Icons/Thorns"));
    }
}
