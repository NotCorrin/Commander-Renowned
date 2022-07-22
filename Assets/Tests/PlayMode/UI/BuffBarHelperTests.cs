using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

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

        KeyValuePair<string, VectorImage> permAttackPair = new ("permAttack", permAttackIcon);
        KeyValuePair<string, VectorImage> permDefencePair = new ("permDefence", permDefenceIcon);
        KeyValuePair<string, VectorImage> attackPair = new ("attack", attackIcon);
        KeyValuePair<string, VectorImage> defencePair = new ("defence", defenceIcon);
        KeyValuePair<string, VectorImage> accuracyPair = new ("accuracy", accuracyIcon);
        KeyValuePair<string, VectorImage> thornsPair = new ("thorns", thornsIcon);

        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Buff Bar Helper"));
        yield return new WaitForSeconds(0.2f);

        // Act
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Loading/Initial Loader"));
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.Contains(permAttackPair, BuffBarHelper.BuffBarDict);
        Assert.Contains(permDefencePair, BuffBarHelper.BuffBarDict);
        Assert.Contains(attackPair, BuffBarHelper.BuffBarDict);
        Assert.Contains(defencePair, BuffBarHelper.BuffBarDict);
        Assert.Contains(accuracyPair, BuffBarHelper.BuffBarDict);
        Assert.Contains(thornsPair, BuffBarHelper.BuffBarDict);
        yield return null;
    }
}
