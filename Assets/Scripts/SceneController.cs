using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : Listener
{
    public static SceneController main;
    public GameObject selectedObject;
    public Unit selectedUnit;
    public bool selected;
    public LayerMask clickLayer;

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
            Physics.Raycast(ray, out hit, clickLayer);

            if (hit.collider != null)
            {
                selectedObject = hit.transform.gameObject;
                if (selectedObject.GetComponent<Unit>())
                {
                    //Debug.Log(hit.collider.name);
                    if(selectedUnit != selectedObject.GetComponent<Unit>() || selected == false)
                    {
                        selectedUnit = selectedObject.GetComponent<Unit>();
                        UIEvents.UnitSelected(selectedUnit);
                    }
                    selected = true;
                    return;
                }
            }
            UIEvents.UnitSelected(null);
            selected = false;
        }
    }
}
