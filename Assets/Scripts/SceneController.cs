using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : Listener
{
    public GameObject selectedObject;
    public Unit selectedUnit;

    // Start is called before the first frame update
    void Start()
    {
        
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

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                selectedObject = hit.transform.gameObject;

                if (selectedObject.CompareTag("Military"))
                {
                    selectedUnit = selectedObject.GetComponent<MilitaryUnit>();
                }
                else if (selectedObject.CompareTag("Magic"))
                {
                    selectedUnit = selectedObject.GetComponent<MagicUnit>();
                }
                else if (selectedObject.CompareTag("Renowned"))
                {
                    selectedUnit = selectedObject.GetComponent<CommanderUnit>();
                }
            }
        }
    }
}
