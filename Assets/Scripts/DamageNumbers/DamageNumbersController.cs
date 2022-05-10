using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumbersController : MonoBehaviour
{
    [SerializeField] TextMeshPro damageText;
    static Color healthGainColour = Color.green;
    static Color healthLostColour = Color.red;
    static Color neutralChangeColour = Color.grey;

    private void Awake()
    {
        if (!damageText)
        {
            damageText = GetComponent<TextMeshPro>();
        }
    }

    public void SetHealthChangeAmount(int healthChanged)
    {
        damageText.text = healthChanged.ToString();
        SetColour(healthChanged);
    }

    private void Update()
    {
        damageText.transform.LookAt(Camera.main.transform);
        damageText.transform.Rotate(Vector3.up, 180);
    }

    private void SetColour (int healthChanged)
    {
        if (healthChanged > 0)
        {
            damageText.color = healthGainColour;
        }
        else if (healthChanged < 0)
        {
            damageText.color = healthLostColour;
        }
        else
        {
            damageText.color = neutralChangeColour;
        }
    }
}
