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

    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(camTransform);
        }
        else
        {
            transform.rotation = camTransform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
