using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class PhasePanelTests
{
    private GameObject battleManager;

    private GameObject phasePanel;
    private TextElement currentPhaseLabel;
    private VisualElement currentPhaseFill;

    private StyleColor playerColor = new StyleColor(new Color(12f / 255f, 241f / 255f, 1f, 0.69f));
    private StyleColor enemyColor = new StyleColor(new Color(245f / 255f, 85f / 255f, 93f / 255f, 0.69f));

    /// <summary>
    /// SetUp is run before each test.
    /// </summary>
    [SetUp] public void SetUp()
    {
        // Create the battle manager with a round controller.
        battleManager = new GameObject("Battle Manager");
        battleManager.AddComponent<RoundController>();

        // Create the phase panel.
        phasePanel = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/Phase Panel"));

        // Get the phase panel's components.
        currentPhaseLabel = phasePanel
            .GetComponent<UIDocument>()
            .rootVisualElement
            .Q<VisualElement>("container")
            .Q<TextElement>("current-phase-label");

        currentPhaseFill = phasePanel
            .GetComponent<UIDocument>()
            .rootVisualElement
            .Q<VisualElement>("container")
            .Q<VisualElement>("current-phase-fill");
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

    [UnityTest] public IEnumerator OnNoPhaseChange()
    {
        yield return new WaitForSeconds(1f);

        // Act
        GameEvents.BattleStart();
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.AreEqual("Swap Phase", currentPhaseLabel.text);
        Assert.AreEqual(playerColor, currentPhaseFill.style.unityBackgroundImageTintColor);
        yield return null;
    }

    [UnityTest] public IEnumerator OnSinglePhaseChange()
    {
        yield return new WaitForSeconds(1f);

        // Act
        GameEvents.BattleStart();
        yield return new WaitForSeconds(1f);

        GameEvents.roundcontrollerEndPhase();
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.AreEqual("Swap Phase", currentPhaseLabel.text);
        Assert.AreEqual(enemyColor, currentPhaseFill.style.unityBackgroundImageTintColor);
        yield return null;
    }

    [UnityTest] public IEnumerator OnThreePhaseChanges()
    {
        yield return new WaitForSeconds(1f);

        // Act
        GameEvents.BattleStart();
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            GameEvents.roundcontrollerEndPhase();
            yield return new WaitForSeconds(1.2f);
        }

        // Assert
        Assert.AreEqual("Support Phase", currentPhaseLabel.text);
        Assert.AreEqual(enemyColor, currentPhaseFill.style.unityBackgroundImageTintColor);
        yield return null;
    }

    [UnityTest] public IEnumerator OnFourPhaseChanges()
    {
        yield return new WaitForSeconds(1f);

        // Act
        GameEvents.BattleStart();
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 4; i++)
        {
            GameEvents.roundcontrollerEndPhase();
            yield return new WaitForSeconds(1.2f);
        }

        // Assert
        Assert.AreEqual("Vanguard Phase", currentPhaseLabel.text);
        Assert.AreEqual(playerColor, currentPhaseFill.style.unityBackgroundImageTintColor);
        yield return null;
    }
}
