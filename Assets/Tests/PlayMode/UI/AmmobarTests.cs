using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class AmmobarTests
{
    /// <summary>
    /// SetUp is run before each test.
    /// </summary>
    /// <remarks>
    /// Create a camera and assign it with the MainCamera tag.
    /// </remarks>
    [SetUp] public void SetUp()
    {
        Camera camera = new GameObject().AddComponent<Camera>();
        camera.tag = "MainCamera";
    }

    [UnityTest]
    public IEnumerator HideAmmobarOnUnitDeath()
    {
        // Arrange
        GameObject unit = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        GameObject ammobar = unit.transform.Find("Ammobar").gameObject;
        UIDocument uiDocument = ammobar.GetComponent<UIDocument>();

        VisualElement ammobarContainer = uiDocument.rootVisualElement.Query<VisualElement>("container");

        yield return new WaitForSeconds(1f);

        // Act
        GameEvents.Kill(unit.GetComponent<Unit>());
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.AreEqual(DisplayStyle.None, ammobarContainer.style.display.value);

        yield return null;
    }
}
