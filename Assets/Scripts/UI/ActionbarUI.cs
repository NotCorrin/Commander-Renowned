using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActionbarUI : MonoBehaviour
{
    #region variables
    [Header("Prompt Bar")]
    [SerializeField] private GameObject promptBar;
    [SerializeField] private UIDocument promptBarUIDocument;
    private VisualElement promptBarContainer;
    TextElement promptBarValue;

    [Header("Support Bar")]
    [SerializeField] private GameObject supportBar;
    [SerializeField] private UIDocument supportBarUIDocument;
    private VisualElement supportBarContainer;
    private Button abilityOneBtn;
    private TextElement abilityOneName;
    private TextElement abilityOneCost;
    private TextElement abilityOneDesc;
    private Button abilityTwoBtn;
    private TextElement abilityTwoName;
    private TextElement abilityTwoCost;
    private TextElement abilityTwoDesc;
    private Button abilityThreeBtn;
    private TextElement abilityThreeName;
    private TextElement abilityThreeCost;
    private TextElement abilityThreeDesc;
    private Button endSupportTurnBtn;

    [Header("Switch Bar")]
    [SerializeField] private GameObject switchBar;
    [SerializeField] private UIDocument switchBarUIDocument;
    private VisualElement switchBarContainer;
    private Button switchBtn;
    private Button endSwitchTurnBtn;
    #endregion

    void Start()
    {
        VerifyVariables();
        RunQueries();

        // Set the display to none on start
        promptBarContainer.style.display = DisplayStyle.None;
        supportBarContainer.style.display = DisplayStyle.None;
        switchBarContainer.style.display = DisplayStyle.None;
    }

    void VerifyVariables()
    {
        if (promptBar == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Prompt Bar Game Object assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBar = transform.Find("Prompt Bar").gameObject;
        }

        if (supportBar == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Support Bar Game Object assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBar = transform.Find("Support Bar").gameObject;
        }

        if (switchBar == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Switch Bar Game Object assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBar = transform.Find("Switch Bar").gameObject;
        }

        if (promptBarUIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Prompt Bar UIDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBarUIDocument = promptBar.GetComponent<UIDocument>();
        }

        if (supportBarUIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Support Bar UIDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            supportBarUIDocument = supportBar.GetComponent<UIDocument>();
        }

        if (switchBarUIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Switch Bar UIDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            switchBarUIDocument = switchBar.GetComponent<UIDocument>();
        }
    }

    void RunQueries()
    {
        try
        {
            // Prompt Bar
            promptBarContainer = promptBarUIDocument.rootVisualElement.Query<VisualElement>("container");
            promptBarValue = promptBarContainer.Query<TextElement>("prompt");

            // Support Bar
            supportBarContainer = supportBarUIDocument.rootVisualElement.Query<VisualElement>("container");
            abilityOneBtn = supportBarContainer.Query<Button>("ability-one");
            abilityOneName = abilityOneBtn.Query<TextElement>("name");
            abilityOneCost = abilityOneBtn.Query<TextElement>("cost");
            abilityOneDesc = abilityOneBtn.Query<TextElement>("desc");

            abilityTwoBtn = supportBarContainer.Query<Button>("ability-two");
            abilityTwoName = abilityTwoBtn.Query<TextElement>("name");
            abilityTwoCost = abilityTwoBtn.Query<TextElement>("cost");
            abilityTwoDesc = abilityTwoBtn.Query<TextElement>("desc");

            abilityThreeBtn = supportBarContainer.Query<Button>("ability-three");
            abilityThreeName = abilityThreeBtn.Query<TextElement>("name");
            abilityThreeCost = abilityThreeBtn.Query<TextElement>("cost");
            abilityThreeDesc = abilityThreeBtn.Query<TextElement>("desc");

            endSupportTurnBtn = supportBarContainer.Query<Button>("end-button");

            // Switch Bar
            switchBarContainer = switchBarUIDocument.rootVisualElement.Query<VisualElement>("container");

            switchBtn = switchBarContainer.Query<Button>("switch-button");
            endSwitchTurnBtn = switchBarContainer.Query<Button>("end-button");

        }
        catch
        {
            Debug.LogError($"{gameObject.name} : ActionbarUI - Element Query Failed.");
        }
    }

    void Update()
    {
        
    }
}
