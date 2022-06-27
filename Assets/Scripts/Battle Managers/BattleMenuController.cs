using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenuController : MonoBehaviour
{
    public FieldController fieldController;

    // Start is called before the first frame update
    void Awake()
    {
        fieldController = FieldController.Main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
