using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    private VisualElement healthbarContainer;
    private TextElement healthbarValue;

    private Camera cam;

    void Start()
    {
        healthbarContainer = GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("Container");
        cam = Camera.main;

        if (healthbarContainer != null)
        {
            // healthbarValue = healthbarContainer.Query<TextElement>("HealthValue");
        }
        else
        {
            Debug.LogError("HealthbarUI: Could not find container");
        }
    }

    void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(healthbarContainer.panel, transformToFollow.position, cam);
        healthbarContainer.transform.position = new Vector3 (newPosition.x - healthbarContainer.layout.width / 2, newPosition.y - healthbarContainer.layout.height / 2, 0);
    }
}
