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
        yield return new WaitForSeconds(0.4f);

        AttackBuff attackBuffRemove = new ();
        attackBuffRemove.AddEffect(unit, -5);
        yield return new WaitForSeconds(0.4f);

        // Assert
        Assert.AreEqual(0, container.childCount);
        yield return null;
    }

    [UnityTest] public IEnumerator OnUnitStatusAddStacks()
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
        AttackBuff initialAttackBuff = new ();
        initialAttackBuff.AddEffect(unit, 1);
        yield return new WaitForSeconds(0.5f);

        AttackBuff addAttackBuff = new ();
        addAttackBuff.AddEffect(unit, 2);
        yield return new WaitForSeconds(0.5f);

        AttackBuff add2AttackBuff = new ();
        add2AttackBuff.AddEffect(unit, 2);
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.AreEqual(1, container.childCount);
        Assert.AreEqual("attack", container.Q<VisualElement>("attack").name);
        Assert.AreEqual("5", container.Q<VisualElement>("attack").Q<Label>("label").text);
        yield return null;
    }

    [UnityTest] public IEnumerator OnUnitStatusRemoveStacks()
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
        AttackBuff initialAttackBuff = new ();
        initialAttackBuff.AddEffect(unit, 2);
        yield return new WaitForSeconds(0.5f);

        AttackBuff addAttackBuff = new ();
        addAttackBuff.AddEffect(unit, -1);
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.AreEqual(1, container.childCount);
        Assert.AreEqual("attack", container.Q<VisualElement>("attack").name);
        Assert.AreEqual("1", container.Q<VisualElement>("attack").Q<Label>("label").text);
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusAdd()
    {
        // Arrange
        GameObject gameObject1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit1 = gameObject1.GetComponent<Unit>();
        VisualElement container1 = gameObject1.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject2 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit2 = gameObject2.GetComponent<Unit>();
        VisualElement container2 = gameObject2.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject3 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit3 = gameObject3.GetComponent<Unit>();
        VisualElement container3 = gameObject3.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.2f);

        AttackBuff attackBuff1 = new ();
        attackBuff1.AddEffect(unit1, 5);
        DefenseBuff defenseBuff2 = new ();
        defenseBuff2.AddEffect(unit2, 5);
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.AreEqual(1, container1.childCount);
        Assert.AreEqual("attack", container1.Q<VisualElement>("attack").name);
        Assert.AreEqual("5", container1.Q<VisualElement>("attack").Q<Label>("label").text);
        Assert.AreEqual(1, container2.childCount);
        Assert.AreEqual("defence", container2.Q<VisualElement>("defence").name);
        Assert.AreEqual("5", container2.Q<VisualElement>("defence").Q<Label>("label").text);
        Assert.AreEqual(0, container3.childCount);
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusRemove()
    {
        // Arrange
        GameObject gameObject1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit1 = gameObject1.GetComponent<Unit>();
        VisualElement container1 = gameObject1.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject2 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit2 = gameObject2.GetComponent<Unit>();
        VisualElement container2 = gameObject2.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject3 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit3 = gameObject3.GetComponent<Unit>();
        VisualElement container3 = gameObject3.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.2f);

        AttackBuff attackBuffAdd = new ();
        attackBuffAdd.AddEffect(unit1, 5);

        DefenseBuff defenseBuffAdd = new ();
        defenseBuffAdd.AddEffect(unit2, 5);

        AccuracyBuff accuracyBuffAdd = new ();
        accuracyBuffAdd.AddEffect(unit3, 5);
        yield return new WaitForSeconds(0.4f);

        AttackBuff attackBuffRemove = new ();
        attackBuffRemove.AddEffect(unit1, -5);

        DefenseBuff defenseBuffRemove = new ();
        defenseBuffRemove.AddEffect(unit2, -5);
        yield return new WaitForSeconds(0.4f);

        // Assert
        Assert.AreEqual(0, container1.childCount);
        Assert.AreEqual(0, container2.childCount);
        Assert.AreEqual(1, container3.childCount);
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusAddStacks()
    {
        // Arrange
        GameObject gameObject1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit1 = gameObject1.GetComponent<Unit>();
        VisualElement container1 = gameObject1.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject2 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit2 = gameObject2.GetComponent<Unit>();
        VisualElement container2 = gameObject2.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject3 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit3 = gameObject3.GetComponent<Unit>();
        VisualElement container3 = gameObject3.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.2f);

        AttackBuff initialAttackBuff = new ();
        initialAttackBuff.AddEffect(unit1, 1);
        yield return new WaitForSeconds(0.5f);

        AttackBuff addAttackBuff = new ();
        addAttackBuff.AddEffect(unit1, 2);
        yield return new WaitForSeconds(0.5f);

        AttackBuff add2AttackBuff = new ();
        add2AttackBuff.AddEffect(unit1, 2);
        yield return new WaitForSeconds(0.5f);

        DefenseBuff initialDefenseBuff = new ();
        initialDefenseBuff.AddEffect(unit2, 1);
        yield return new WaitForSeconds(0.5f);

        DefenseBuff addDefenseBuff = new ();
        addDefenseBuff.AddEffect(unit2, 2);
        yield return new WaitForSeconds(0.5f);

        DefenseBuff add2DefenseBuff = new ();
        add2DefenseBuff.AddEffect(unit2, 2);
        yield return new WaitForSeconds(0.5f);

        AccuracyBuff initialAccuracyBuff = new ();
        initialAccuracyBuff.AddEffect(unit3, 1);
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.AreEqual(1, container1.childCount);
        Assert.AreEqual("attack", container1.Q<VisualElement>("attack").name);
        Assert.AreEqual("5", container1.Q<VisualElement>("attack").Q<Label>("label").text);
        Assert.AreEqual(1, container2.childCount);
        Assert.AreEqual("defence", container2.Q<VisualElement>("defence").name);
        Assert.AreEqual("5", container2.Q<VisualElement>("defence").Q<Label>("label").text);
        Assert.AreEqual(1, container3.childCount);
        Assert.AreEqual("accuracy", container3.Q<VisualElement>("accuracy").name);
        Assert.AreEqual("1", container3.Q<VisualElement>("accuracy").Q<Label>("label").text);
        yield return null;
    }

    [UnityTest] public IEnumerator MultipleUnitsOnStatusRemoveStacks()
    {
        // Arrange
        GameObject gameObject1 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit1 = gameObject1.GetComponent<Unit>();
        VisualElement container1 = gameObject1.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject2 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit2 = gameObject2.GetComponent<Unit>();
        VisualElement container2 = gameObject2.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject gameObject3 = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit"));
        Unit unit3 = gameObject3.GetComponent<Unit>();
        VisualElement container3 = gameObject3.transform.Find("Buff Bar").gameObject.GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("container");

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.2f);

        AttackBuff initialAttackBuff = new ();
        initialAttackBuff.AddEffect(unit1, 5);
        yield return new WaitForSeconds(0.5f);

        AttackBuff addAttackBuff = new ();
        addAttackBuff.AddEffect(unit1, -2);
        yield return new WaitForSeconds(0.5f);

        AttackBuff add2AttackBuff = new ();
        add2AttackBuff.AddEffect(unit1, -2);
        yield return new WaitForSeconds(0.5f);

        DefenseBuff initialDefenseBuff = new ();
        initialDefenseBuff.AddEffect(unit2, 5);
        yield return new WaitForSeconds(0.5f);

        DefenseBuff addDefenseBuff = new ();
        addDefenseBuff.AddEffect(unit2, -2);
        yield return new WaitForSeconds(0.5f);

        DefenseBuff add2DefenseBuff = new ();
        add2DefenseBuff.AddEffect(unit2, -2);
        yield return new WaitForSeconds(0.5f);

        AccuracyBuff initialAccuracyBuff = new ();
        initialAccuracyBuff.AddEffect(unit3, 5);
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.AreEqual(1, container1.childCount);
        Assert.AreEqual("attack", container1.Q<VisualElement>("attack").name);
        Assert.AreEqual("1", container1.Q<VisualElement>("attack").Q<Label>("label").text);
        Assert.AreEqual(1, container2.childCount);
        Assert.AreEqual("defence", container2.Q<VisualElement>("defence").name);
        Assert.AreEqual("1", container2.Q<VisualElement>("defence").Q<Label>("label").text);
        Assert.AreEqual(1, container3.childCount);
        Assert.AreEqual("accuracy", container3.Q<VisualElement>("accuracy").name);
        Assert.AreEqual("5", container3.Q<VisualElement>("accuracy").Q<Label>("label").text);
        yield return null;
    }
}
