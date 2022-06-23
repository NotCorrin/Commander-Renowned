using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Listener
{
	[SerializeField] Unit enemyVanguard;
	[SerializeField] Unit enemySupportLeft;
	[SerializeField] Unit enemySupportRight;

	[SerializeField] Ability vanguardBestAbility;
	[SerializeField] Ability supportLeftBestAbility;
	[SerializeField] Ability supportRightBestAbility;

	int vanguardBestAbilityIndex;
	int supportLeftBestAbilityIndex;
	int supportRightBestAbilityIndex;

	int vanguardStickScore;
	int supportLeftSwitchScore;
	int supportRightSwitchScore;

	FieldController fieldController;
	public static EnemyController main;
	void Start ()
	{
		fieldController = FieldController.main;
		main = this;
	}
	void SetupUnits(List<Unit> playerUnits, List<Unit> enemyUnits)
    {
        enemyVanguard = enemyUnits[0];
        enemySupportLeft = enemyUnits[1];
        enemySupportRight = enemyUnits[2];
    }

	public void SwitchPositions () {
		CalculateSwitchStickScores();
		// No support enemies
		if (enemySupportLeft == null && enemySupportRight == null)
		{
			GoToNextPhase();
			return;
		}
		
        vanguardStickScore = -999;
		if (enemyVanguard)
		{
			// Get vanguard stick score
			vanguardStickScore = enemyVanguard.GetStickScore();
		}

        if (enemySupportLeft)
        {
			// Has left support
			int leftSwitchScore = enemySupportLeft.GetSwitchScore();
            if (enemySupportRight)
            {
				// Has both support
				int rightSwitchScore = enemySupportRight.GetSwitchScore();
				if (rightSwitchScore > leftSwitchScore)
				{
					// Right > Left
					if (rightSwitchScore > vanguardStickScore)
					{
						SwapUnit(enemySupportRight);
					}
					else
					{
						GoToNextPhase();
					}
					return;
				}
				else if(leftSwitchScore > rightSwitchScore)
				{
					// Left > Right
					if (leftSwitchScore > vanguardStickScore)
					{
						SwapUnit(enemySupportLeft);
					}
					else
					{
						GoToNextPhase();
					}
					return;
				}
				else
				{
					// Left == Right
					if (Random.Range(0, 100) <= 50)
					{
						// Randomly choose left
						if (leftSwitchScore > vanguardStickScore)
						{
							SwapUnit(enemySupportLeft);
						}
						else
						{
							GoToNextPhase();
						}
						return;
					}
					else
					{
						// Randomly choose right
						if (rightSwitchScore > vanguardStickScore)
						{
							SwapUnit(enemySupportRight);
						}
						else
						{
							GoToNextPhase();
						}
						return;
					}
				}
            }
			else
			{
				// Has only left
				if (leftSwitchScore > vanguardStickScore)
				{
					SwapUnit(enemySupportLeft);
				}
				else
				{
					GoToNextPhase();
				}
				return;
			}
        }
        else
		// Has no left
        {
			//Has only right
			int rightSwitchScore = enemySupportRight.GetSwitchScore();
			if (rightSwitchScore > vanguardStickScore)
			{
				SwapUnit(enemySupportRight);
			}
			else
			{
				GoToNextPhase();
			}
			return;
        }
	}

	void SwapUnit(Unit unitToSwap)
    {
        fieldController.SwapEnemyUnit(unitToSwap);

        SetEnemyVanguard();
        SetEnemySupportLeft();
        SetEnemySupportRight();
    }

	void FindBestVanguardAbilityIndex () {
		// Determine if there is an enemy in that position
		if (SetEnemyVanguard() == false) {
			return;
		}
		// Get the best ability's index
		int highestAbilityWeight = enemyVanguard.VanguardAbilities[0].GetMoveWeight(enemyVanguard);
        vanguardBestAbility = enemyVanguard.VanguardAbilities[0];
		int index = 0;
        for (int i = 0; i < enemyVanguard.VanguardAbilities.Length; i++)
        {
            Ability currentAbility = enemyVanguard.VanguardAbilities[i];
            if (currentAbility)
            {
                int currentWeight = currentAbility.GetMoveWeight(enemyVanguard);
                if (currentWeight > highestAbilityWeight)
                {
                    highestAbilityWeight = currentWeight;
                    vanguardBestAbility = currentAbility;
                    index = i;
                }
                if (currentWeight == highestAbilityWeight)
                {
                    if (Random.Range(0, 100) < 50)
                    {
                        highestAbilityWeight = currentWeight;
                        vanguardBestAbility = currentAbility;
                        index = i;
                    }
                }
            }
        }
		vanguardBestAbilityIndex = index + 1;
	}

	void FindBestSupportLeftAbility ()
	{
		// Determine if there is an enemy in that position
		if (SetEnemySupportLeft() == false)
		{
			return;
		}
		// Get the best ability's index
		int highestAbilityWeight = enemySupportLeft.SupportAbilities[0].GetMoveWeight(enemySupportLeft);
        supportLeftBestAbility = enemySupportLeft.SupportAbilities[0];
        int index = 0;
		if (enemySupportLeft.SupportAbilities.Length > 1)
		{
            Debug.Log ("Has an ability");
			for (int i = 0; i < enemySupportLeft.SupportAbilities.Length; i++)
			{
				Ability currentAbility = enemySupportLeft.SupportAbilities[i];
				if (currentAbility == null)
				{
					continue;
				}
				int currentWeight = currentAbility.GetMoveWeight(enemySupportLeft);
				if (currentWeight > highestAbilityWeight)
				{
					highestAbilityWeight = currentWeight;
					supportLeftBestAbility = currentAbility;
					index = i;
				}
				if (currentWeight == highestAbilityWeight)
				{
					if (Random.Range(0, 100) < 50) {
						highestAbilityWeight = currentWeight;
						supportLeftBestAbility = currentAbility;
						index = i;
					}
				}
			}
		}
		else
		{
			Debug.Log("only 1 support ability, what a loser");
			supportLeftBestAbility = enemySupportLeft.SupportAbilities[0];
			index = 0;
		}
		supportLeftBestAbilityIndex = index + 1;
	}

	void FindBestSupportRightAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemySupportRight() == false)
		{
			return;
		}
        // Get the best ability's index
        int highestAbilityWeight = enemySupportRight.SupportAbilities[0].GetMoveWeight(enemySupportRight);
        supportRightBestAbility = enemySupportRight.SupportAbilities[0];
        int index = 0;
		if (enemySupportRight.SupportAbilities[1] != null)
		{
			for (int i = 0; i < enemySupportRight.SupportAbilities.Length; i++)
			{
				Ability currentAbility = enemySupportRight.SupportAbilities[i];
				if (currentAbility == null)
				{
					continue;
				}
				int currentWeight = currentAbility.GetMoveWeight(enemySupportRight);
				if (currentWeight > highestAbilityWeight)
				{
					highestAbilityWeight = currentWeight;
					supportRightBestAbility = currentAbility;
					index = i;
				}
				if (currentWeight == highestAbilityWeight)
				{
					if (Random.Range(0, 100) < 50)
					{
						highestAbilityWeight = currentWeight;
						supportRightBestAbility = currentAbility;
						index = i;
					}
				}
			}
		}
		else
		{
			supportRightBestAbility = enemySupportRight.SupportAbilities[0];
			index = 0;
		}
		supportRightBestAbilityIndex = index + 1;
	}

	bool SetEnemyVanguard ()
	{
		Unit vanguard = fieldController.GetUnit(FieldController.Position.Vanguard, false);
		// If there is a vanguard...
		enemyVanguard = vanguard;
		if (vanguard != null)
		{
			return true;
		}
		return false;
	}

	bool SetEnemySupportLeft ()
	{
		Unit supportLeft = fieldController.GetUnit(FieldController.Position.SupportLeft, false);
		enemySupportLeft = supportLeft;
		// If there is a left support...
		if (supportLeft != null)
		{
			return true;
		}
		return false;
	}

	bool SetEnemySupportRight ()
	{
		Unit supportRight = fieldController.GetUnit(FieldController.Position.SupportRight, false);
		enemySupportRight = supportRight;
		// If there is a right support...
		if (supportRight != null)
		{
			return true;
		}
		return false;
	}

	void CalculateSwitchStickScores ()
	{
		// If there is an enemy, grab there switch/stick scores
		if (enemyVanguard != null)
		{
			vanguardStickScore = enemyVanguard.GetStickScore();
		}
		if (enemySupportLeft != null)
		{
			supportLeftSwitchScore = enemySupportLeft.GetSwitchScore();
		}
		if (enemySupportRight != null)
		{
			supportRightSwitchScore = enemySupportRight.GetSwitchScore();
		}
	}

	protected override void SubscribeListeners ()
	{
		GameEvents.onPhaseChanged += EnemyTurn;
		GameEvents.OnSetupUnits += SetupUnits;
		GameEvents.onKill += Kill;
	}

	protected override void UnsubscribeListeners ()
	{
		GameEvents.onPhaseChanged -= EnemyTurn;
		GameEvents.OnSetupUnits -= SetupUnits;
		GameEvents.onKill -= Kill;
	}

	void Kill(Unit unit)
	{
		if(!fieldController.IsUnitPlayer(unit)) 
		{
			//unit.DestroyUnit();
		}
	}

	void EnemyTurn (RoundController.Phase phase)
	{
		switch (phase)
		{
			case RoundController.Phase.EnemyVangaurd:
				Invoke("UseVanguardAbility", 0.8f);
				break;
			case RoundController.Phase.EnemySwap:
				Invoke("SwitchPositions", 0.8f);
				break;
			case RoundController.Phase.EnemySupport:
				Invoke("UseSupportAbility", 0.8f);
				break;
			default:
				break;
		}
	}

	void UseVanguardAbility ()
	{
		// UNCOMMENT LINES FOR TARGETING MULTIPLE CHARACTERS
		FindBestVanguardAbilityIndex();
		if ((enemyVanguard && vanguardBestAbility) == false)
		{
			GoToNextPhase();
			return;
		}
        // Use ability on single target
        List<Unit> validTargets = fieldController.GetValidTargets(enemyVanguard, vanguardBestAbility);
		if (validTargets.Count > 0)
		{
			Unit target = validTargets[Random.Range(0, validTargets.Count)];

			if (vanguardBestAbility.IsAbilityValid(enemyVanguard, target))
				GameEvents.UseAbility(enemyVanguard, target, vanguardBestAbilityIndex);
			else
				GoToNextPhase();
		}
		else
		{
			GoToNextPhase();
		}
		//Debug.Log("Enemy vanguard attack: Ability - " + vanguardBestAbility.AbilityName + " Target - " + target);

        /*
		int numOfTargets = [SET VALUE HERE];
		for (int i = 0; i < numOfTargets; i++) {
			target = validTargets[Random.Range(0, validTargets.Count)];
			GameEvents.UseAbility(enemyVanguard, target, vanguardBestAbilityIndex);
			validTargets.Remove(target);
		}
		*/
    }
	void UseSupportAbility ()
	{
        Invoke("GoToNextPhase", 0.85f);
        UseSupportLeftAbility();
		Invoke("UseSupportRightAbility", 0.65f);
    }

	void UseSupportLeftAbility ()
	{
		// UNCOMMENT LINES FOR TARGETING MULTIPLE CHARACTERS
		FindBestSupportLeftAbility();
		if (enemySupportLeft)
		{
			// Support left ability on single target
			List<Unit> leftAbilityValidTargets = fieldController.GetValidTargets(enemySupportLeft, supportLeftBestAbility);
			if (leftAbilityValidTargets.Count > 0)
			{
				Unit leftTarget = leftAbilityValidTargets[Random.Range(0, leftAbilityValidTargets.Count)];
                if (supportLeftBestAbility.IsAbilityValid(enemySupportLeft, leftTarget))
                {
                    GameEvents.UseAbility(enemySupportLeft, leftTarget, supportLeftBestAbilityIndex);
                }// Remove this line for multi targets
			}
			/*
			int leftAbilityNumOfTargets = [SET VALUE HERE]; <<<<< IMPORTANT THING TO ADD
			for (int i = 0; i < leftAbilityNumOfTargets; i++) {
			leftTarget = leftAbilityValidTargets[Random.Range(0, leftAbilityValidTargets.Count)];
				GameEvents.UseAbility(enemySupportLeft, leftTarget, supportLeftBestAbilityIndex);
				leftAbilityValidTargets.Remove(leftTarget);
			}
			*/
		}
	}

	void UseSupportRightAbility ()
	{
		// UNCOMMENT LINES FOR TARGETING MULTIPLE CHARACTERS
		FindBestSupportRightAbility();
		if (enemySupportRight)
		{
			// Support right ability on single target
			List<Unit> rightAbilityValidTargets = fieldController.GetValidTargets(enemySupportRight, supportRightBestAbility);
			if (rightAbilityValidTargets.Count > 0)
			{ 
				Unit rightTarget = rightAbilityValidTargets[Random.Range(0, rightAbilityValidTargets.Count)];
                if (supportRightBestAbility.IsAbilityValid(enemySupportRight, rightTarget))
                {
                    GameEvents.UseAbility(enemySupportRight, rightTarget, supportRightBestAbilityIndex);
                }// Remove this line for multi targets
			}

			/*
			int rightAbilityNumOfTargets = [SET VALUE HERE]; <<<<< IMPORTANT THING TO ADD
			for (int i = 0; i < rightAbilityNumOfTargets; i++) {
			rightTarget = rightAbilityValidTargets[Random.Range(0, rightAbilityValidTargets.Count)];
				GameEvents.UseAbility(enemySupportRight, rightTarget, supportRightBestAbilityIndex);
				rightAbilityValidTargets.Remove(rightTarget);
			}
			*/
		}
    }

	void GoToNextPhase ()
	{
		GameEvents.EndPhase();
	}
}
