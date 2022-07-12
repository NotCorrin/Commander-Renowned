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
        Camera camera = new GameObject("Main Camera").AddComponent<Camera>();
        camera.tag = "MainCamera";
    }

    /// <summary>
    /// Destroys all GameObjects after every test is run.
    /// </summary>
    [TearDown] public void CleanUp()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject gameObject in gameObjects)
        {
            GameObject.Destroy(gameObject);
        }
    }

    /// <summary>
    /// One unit exists and dies.
    /// </summary>
    /// <returns>null.</returns>
    [UnityTest] public IEnumerator SingleUnitHideAmmobarOnDeath()
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

    /// <summary>
    /// Multiple units exist but one dies.
    /// </summary>
    /// <returns>null.</returns>
    [UnityTest] public IEnumerator MultipleUnitsHideAmmobarOnSingleDeath()
    {
        // Arrange
        GameObject unit1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        GameObject unit2 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        GameObject unit3 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));

        GameObject ammobar1 = unit1.transform.Find("Ammobar").gameObject;
        GameObject ammobar2 = unit2.transform.Find("Ammobar").gameObject;
        GameObject ammobar3 = unit3.transform.Find("Ammobar").gameObject;

        UIDocument uiDocument1 = ammobar1.GetComponent<UIDocument>();
        UIDocument uiDocument2 = ammobar2.GetComponent<UIDocument>();
        UIDocument uiDocument3 = ammobar3.GetComponent<UIDocument>();

        VisualElement ammobarContainer1 = uiDocument1.rootVisualElement.Query<VisualElement>("container");
        VisualElement ammobarContainer2 = uiDocument2.rootVisualElement.Query<VisualElement>("container");
        VisualElement ammobarContainer3 = uiDocument3.rootVisualElement.Query<VisualElement>("container");

        yield return new WaitForSeconds(1f);

        // Act
        GameEvents.Kill(unit1.GetComponent<Unit>());
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.AreEqual(DisplayStyle.None, ammobarContainer1.style.display.value);
        Assert.AreEqual(DisplayStyle.Flex, ammobarContainer2.style.display.value);
        Assert.AreEqual(DisplayStyle.Flex, ammobarContainer3.style.display.value);
    }

    /// <summary>
    /// Multiple units exists and one lives.
    /// </summary>
    /// <returns>null.</returns>
    [UnityTest] public IEnumerator MultipleUnitsHideAmmobarOnMultipleDeaths()
    {
        // Arrange
        GameObject unit1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        GameObject unit2 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        GameObject unit3 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));

        GameObject ammobar1 = unit1.transform.Find("Ammobar").gameObject;
        GameObject ammobar2 = unit2.transform.Find("Ammobar").gameObject;
        GameObject ammobar3 = unit3.transform.Find("Ammobar").gameObject;

        UIDocument uiDocument1 = ammobar1.GetComponent<UIDocument>();
        UIDocument uiDocument2 = ammobar2.GetComponent<UIDocument>();
        UIDocument uiDocument3 = ammobar3.GetComponent<UIDocument>();

        VisualElement ammobarContainer1 = uiDocument1.rootVisualElement.Query<VisualElement>("container");
        VisualElement ammobarContainer2 = uiDocument2.rootVisualElement.Query<VisualElement>("container");
        VisualElement ammobarContainer3 = uiDocument3.rootVisualElement.Query<VisualElement>("container");

        yield return new WaitForSeconds(1f);

        // Act
        GameEvents.Kill(unit1.GetComponent<Unit>());
        GameEvents.Kill(unit2.GetComponent<Unit>());
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.AreEqual(DisplayStyle.None, ammobarContainer1.style.display.value);
        Assert.AreEqual(DisplayStyle.None, ammobarContainer2.style.display.value);
        Assert.AreEqual(DisplayStyle.Flex, ammobarContainer3.style.display.value);
    }
}
