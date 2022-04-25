using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointController : MonoBehaviour
{
    [SerializeField] private int id;

    private void OnEnable()
    {
        SubscribeListeners();   
    }

    private void OnDisable()
    {
        UnsubscribeListeners();
    }

    private void SubscribeListeners()
    {
        CameraEventSystem.onCameraMove += MoveCamera;
    }

    private void UnsubscribeListeners()
    {
        CameraEventSystem.onCameraMove -= MoveCamera;
    }
    // Start is called before the first frame update
    private void MoveCamera(int id)
    {
        if (this.id == id)
        {
            Camera.main.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }
}
