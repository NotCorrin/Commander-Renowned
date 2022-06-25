using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code for the billboard.
/// Is applied to GameObjects that should look at the camera.
/// </summary>
public class Billboard : MonoBehaviour
{
    private Transform camTransform;
    private Vector3 originEuler;
    [SerializeField] private bool useStaticBillboard;

    /// <summary>
    /// Switches between static and dynamic billboards.
    /// </summary>
    /// <param name="toSwitch">False if the billboard should be dynamic, true if it should be static.</param>
    public void SwitchBillboardState(bool toSwitch)
    {
        useStaticBillboard = toSwitch;
    }

    private void Start()
    {
        camTransform = Camera.main.transform;
        originEuler = transform.eulerAngles;
    }

    private void Update()
    {
        // if spacebar is pressed //no
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchBillboardState();
        }*/
    }

    private void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            Vector3 direction = new Vector3(originEuler.x, camTransform.eulerAngles.y, originEuler.z);
            Quaternion toRotation = Quaternion.Euler(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
        }
        else
        {
            Quaternion endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f);

            transform.rotation = camTransform.rotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, Time.deltaTime);
        }
    }
}
