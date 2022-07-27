using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

/// <summary>
/// Tests for the BuffBarUI class.
/// </summary>
public class BuffBarTests
{
    [SetUp] public void Setup()
    {
        Camera camera = new GameObject("Main Camera").AddComponent<Camera>();
        camera.tag = "MainCamera";
    }

    [TearDown] public void CleanUp()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject gameObject in gameObjects)
        {
            GameObject.Destroy(gameObject);
        }
    }

    [UnityTest] public IEnumerator OnUnitStatusAdd()
    {
        // Arrange
        GameObject gameObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit = gameObject.GetComponent<Unit>();
        VisualElement container = gameObject.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.2f);
        AttackBuff attackBuff = new ();
        attackBuff.AddEffect(unit, 5);
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.AreEqual(1, container.childCount);
        Assert.AreEqual("attack", container.Q<VisualElement>("attack").name);
        Assert.AreEqual("5", container.Q<VisualElement>("attack").Q<Label>("label").text);
        yield return null;
    }

    [UnityTest] public IEnumerator OnUnitStatusRemove()
    {
        // Arrange
        GameObject gameObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit = gameObject.GetComponent<Unit>();
        VisualElement container = gameObject.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.2f);
        AttackBuff attackBuffAdd = new ();
        attackBuffAdd.AddEffect(unit, 5);
        yield return new WaitForSeconds(10f);

        AttackBuff attackBuffRemove = new ();
        attackBuffRemove.AddEffect(unit, -5);
        yield return new WaitForSeconds(10f);

        // Assert
        Assert.AreEqual(0, 0);
        yield return null;
    }

    [UnityTest] public IEnumerator OnUnitStatusAddStacks()
    {
        yield return null;
    }

    [UnityTest] public IEnumerator OnUnitStatusRemoveStacks()
    {
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusAdd()
    {
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusRemove()
    {
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusAddStacks()
    {
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusRemoveStacks()
    {
        yield return null;
    }
}
