using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Listener : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        SubscribeListeners();
    }

    private void OnDisable()
    {
        UnsubscribeListeners();
    }

    abstract protected void SubscribeListeners();

    abstract protected void UnsubscribeListeners();
}
