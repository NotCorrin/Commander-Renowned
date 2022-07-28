using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

/// <summary>
/// Tests for the BuffBarHelper class.
/// </summary>
public class BuffBarHelperTests
{
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
    /// Check if the BuffBarHelper's buffBarDict contains the correct buffs.
    /// </summary>
    /// <returns>null.</returns>
    [UnityTest] public IEnumerator BuffBarDictContainsAllResources()
    {
        // Arrange
        VectorImage permAttackIcon = Resources.Load<VectorImage>("UI/Icons/Perm Attack");
        VectorImage permDefenceIcon = Resources.Load<VectorImage>("UI/Icons/Perm Defence");
        VectorImage attackIcon = Resources.Load<VectorImage>("UI/Icons/Attack");
        VectorImage defenceIcon = Resources.Load<VectorImage>("UI/Icons/Defence");
        VectorImage accuracyIcon = Resources.Load<VectorImage>("UI/Icons/Accuracy");
        VectorImage thornsIcon = Resources.Load<VectorImage>("UI/Icons/Thorns");

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.AreEqual(permAttackIcon, BuffBarHelper.BuffBarDict["permAttack"]);
        Assert.AreEqual(permDefenceIcon, BuffBarHelper.BuffBarDict["permDefence"]);
        Assert.AreEqual(attackIcon, BuffBarHelper.BuffBarDict["attack"]);
        Assert.AreEqual(defenceIcon, BuffBarHelper.BuffBarDict["defence"]);
        Assert.AreEqual(accuracyIcon, BuffBarHelper.BuffBarDict["accuracy"]);
        Assert.AreEqual(thornsIcon, BuffBarHelper.BuffBarDict["thorns"]);
        yield return null;
    }
}
