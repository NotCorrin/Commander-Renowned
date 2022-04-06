using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingUnits : MonoBehaviour
{
    public GameObject selectedUnit;
    public GameObject frontUnit;
    public GameObject backUnit1;
    public GameObject backUnit2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    if (hit.transform.gameObject.tag == "Military" && hit.transform.gameObject.transform.position.x < 3)
                    {
                        Debug.Log("military");

                        selectedUnit = hit.transform.gameObject;
                    }
                    else if (hit.transform.gameObject.tag == "Magic" && hit.transform.gameObject.transform.position.x < 3)
                    {
                        Debug.Log("magic");

                        selectedUnit = hit.transform.gameObject;
                    }
                    else if (hit.transform.gameObject.tag == "Renowned" && hit.transform.gameObject.transform.position.x < 3)
                    {
                        Debug.Log("renowned");

                        selectedUnit = hit.transform.gameObject;
                    }
                }
            }
        }
    }

    public void SwapUnits()
    {
        Vector3 selectedUnitPos = selectedUnit.transform.position;
        Vector3 frontUnitPos = frontUnit.transform.position;

        selectedUnit.transform.position = frontUnitPos;
        frontUnit.transform.position = selectedUnitPos;

        if (backUnit1 == selectedUnit)
        {
            GameObject temp = backUnit1;
            backUnit1 = frontUnit;
            frontUnit = temp;
        }
        else if(backUnit2 == selectedUnit)
        {
            GameObject temp = backUnit2;
            backUnit2 = frontUnit;
            frontUnit = temp;
        }
    }
}
