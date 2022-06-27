using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingUnits : MonoBehaviour
{
    private GameObject selectedUnit;
    private GameObject vanguardUnit;
    private GameObject backUnit1;
    private GameObject backUnit2;

    public void SwapUnits()
    {
        Vector3 selectedUnitPos = selectedUnit.transform.position;
        Vector3 vanguardUnitPos = vanguardUnit.transform.position;

        selectedUnit.transform.position = vanguardUnitPos;
        vanguardUnit.transform.position = selectedUnitPos;

        if (backUnit1 == selectedUnit)
        {
            GameObject temp = backUnit1;
            backUnit1 = vanguardUnit;
            vanguardUnit = temp;
        }
        else if (backUnit2 == selectedUnit)
        {
            GameObject temp = backUnit2;
            backUnit2 = vanguardUnit;
            vanguardUnit = temp;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    selectedUnit = hit.transform.gameObject;
                }
            }
        }
    }
}
