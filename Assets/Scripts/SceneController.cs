using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : Listener
{
    public static SceneController main;
    public GameObject selectedObject;
    public Unit selectedUnit;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        SelectUnit();
    }

    protected override void SubscribeListeners()
    {
        //throw new System.NotImplementedException();
    }

    protected override void UnsubscribeListeners()
    {
        //throw new System.NotImplementedException();
    }

    public void SelectUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                selectedObject = hit.transform.gameObject;

                if (selectedObject.CompareTag("Military"))
                {
                    selectedUnit = selectedObject.GetComponent<MilitaryUnit>();
                    UIEvents.onUnitSelected(selectedUnit);
                }
                else if (selectedObject.CompareTag("Magic"))
                {
                    selectedUnit = selectedObject.GetComponent<MagicUnit>();
                    UIEvents.onUnitSelected(selectedUnit);
                }
                else if (selectedObject.CompareTag("Renowned"))
                {
                    selectedUnit = selectedObject.GetComponent<CommanderUnit>();
                    UIEvents.onUnitSelected(selectedUnit);
                }
            }
        }
    }
}
