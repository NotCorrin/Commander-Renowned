using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    #region Variables

    private Transform camTransform;
    [SerializeField] private bool useStaticBillboard;

    #endregion

    void Start()
    {
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        // if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchBillboardState();
        }
    }

    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            Vector3 direction = camTransform.position - transform.position;
            // transform.LookAt(camTransform);
            // transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y - 180f, 0f);
            direction.x = 0;
            direction.z = 0;
            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
        }
        else
        {
            Quaternion endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f);

            transform.rotation = camTransform.rotation;

            // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f);

            transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, Time.deltaTime);
        }
    }

    void SwitchBillboardState()
    {
        useStaticBillboard = !useStaticBillboard;

        // Lerp 
        transform.rotation = Quaternion.Lerp(transform.rotation, camTransform.rotation, Time.deltaTime);
    }
}
