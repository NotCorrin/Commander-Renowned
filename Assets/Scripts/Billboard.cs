using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    #region Variables

    private Transform camTransform;
    private Vector3 originEuler;
    [SerializeField] private bool useStaticBillboard;

    #endregion

    void Start()
    {
        camTransform = Camera.main.transform;
        originEuler = transform.eulerAngles;
    }

    void Update()
    {
        // if spacebar is pressed //no
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchBillboardState();
        }*/
    }

    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            Vector3 direction = new Vector3(originEuler.x, camTransform.eulerAngles.y, originEuler.z);
            //Quaternion.
            // transform.LookAt(camTransform);
            // transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y - 180f, 0f);
            //direction.x = transform.right;
            Quaternion toRotation = Quaternion.Euler(direction);
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

    public void SwitchBillboardState(bool toSwitch)
    {
        useStaticBillboard = toSwitch;

        // Lerp 
        //transform.rotation = Quaternion.Lerp(transform.rotation, camTransform.rotation, Time.deltaTime);
    }
}
