using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ManabarUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement manabarContainer;
    private TextElement manabarValue;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        if (uiDocument == null)
        {
            Debug.Log($"{gameObject.name} : HealthbarUI - has no UIDocument assigned in the inspector. Script will still work, but is not 100% safe.");
            uiDocument = GetComponentInParent<UIDocument>();
        }

        try
        {
            manabarContainer = uiDocument.rootVisualElement.Query<VisualElement>("container");
            manabarValue = manabarContainer.Query<TextElement>("value");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : ManabarUI - Element Query Failed.");
        }
    }
    
    void LateUpdate()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(manabarContainer.panel, transform.position, cam);
        manabarContainer.transform.position = new Vector3(newPosition.x - manabarContainer.layout.width / 2, newPosition.y - manabarContainer.layout.height / 2, 0);
    }
}
