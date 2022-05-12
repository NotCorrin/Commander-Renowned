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
	void Start () {
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
		if (enemySupportLeft == null && enemySupportRight == null) {
            //GameEvents.SetPhase();
            GameEvents.EndPhase();
			return;
		}

        int vanguardStickScore = -999;
        if (enemyVanguard) vanguardStickScore = enemyVanguard.GetStickScore();

        if (enemySupportLeft)
        {
            if (enemySupportRight)
            {
                if (enemySupportRight.GetSwitchScore() > enemySupportLeft.GetSwitchScore())
                {
                    //Has right, right > left
                    if (enemySupportRight.GetSwitchScore() > vanguardStickScore)
                        SwapUnit(enemySupportRight);
                    else
                        GameEvents.EndPhase();
                    return;
                }
            }
            //Left > Right
            if (enemySupportLeft.GetSwitchScore() > vanguardStickScore)
                SwapUnit(enemySupportLeft);
            else
                GameEvents.EndPhase();
            return;
        }
        else
        {
            //Has only right
            if (enemySupportRight.GetSwitchScore() > vanguardStickScore)
                SwapUnit(enemySupportRight);
            else
                GameEvents.EndPhase();
            return;
        }

        
		// Only has left support
		if (enemySupportLeft != null && enemySupportRight == null) {
			// If no enemy vanguard
			if (enemyVanguard == null) {
				fieldController.SwapEnemyUnit(enemySupportLeft);
				return;
			}
			// If yes enemy vanguard
			else {
				if (vanguardStickScore > supportLeftSwitchScore) {
					//GameEvents.SetPhase();
					fieldController.SwapEnemyUnit(enemyVanguard);
					return;
				} else if (vanguardStickScore < supportLeftSwitchScore) {
					fieldController.SwapEnemyUnit(enemySupportLeft);
					return;
				} else {
					if (Random.Range(0, 100) < 50) {
						//GameEvents.SetPhase();
						fieldController.SwapEnemyUnit(enemyVanguard);
						return;
					} else {
						fieldController.SwapEnemyUnit(enemySupportLeft);
						return;
					}
				}
			}
		}
		// Only has right support
		if (enemySupportLeft == null && enemySupportRight != null) {
			// If no enemy vanguard
			if (enemyVanguard == null) {
				fieldController.SwapEnemyUnit(enemySupportRight);
				return;
			}
			// If yes enemy vanguard
			else {
				if (vanguardStickScore > supportRightSwitchScore) {
					//GameEvents.SetPhase();
					fieldController.SwapEnemyUnit(enemyVanguard);
					return;
				} else if (vanguardStickScore < supportRightSwitchScore) {
					fieldController.SwapEnemyUnit(enemySupportRight);
					return;
				} else {
					if (Random.Range(0, 100) < 50) {
						//GameEvents.SetPhase();
						fieldController.SwapEnemyUnit(enemyVanguard);
						return;
					} else {
						fieldController.SwapEnemyUnit(enemySupportRight);
						return;
					}
				}
			}
		}
		
		// If we reach here there MUST be two support enemies

		// Determine which support enemy to switch
		Unit enemySupportToSwitch;
		if(supportLeftSwitchScore > supportRightSwitchScore) {
			enemySupportToSwitch = enemySupportLeft;
		} else if (supportLeftSwitchScore < supportRightSwitchScore) {
			enemySupportToSwitch = enemySupportRight;
		}else {
			if(Random.Range(0,100) < 50) {
				enemySupportToSwitch = enemySupportLeft;
			} else {
				enemySupportToSwitch = enemySupportRight;
			}
		}
		int enemySupportToSwitchScore = enemySupportToSwitch.GetSwitchScore();
		// Compare scores and switch
		if (enemyVanguard == null) {
			fieldController.SwapEnemyUnit(enemySupportToSwitch);
			return;
		} else {
			if(vanguardStickScore > enemySupportToSwitchScore) {
                GoToNextPhase();
                return;
			}else if (vanguardStickScore < enemySupportToSwitchScore) {
				fieldController.SwapEnemyUnit(enemySupportToSwitch);
				return;
			}else {
				if (Random.Range(0, 100) < 50) {
                    GoToNextPhase();
					return;
				} else {
					fieldController.SwapEnemyUnit(enemySupportToSwitch);
					return;
				}
			}
		}
	}

    void SwapUnit(Unit unitToSwap)
    {
        Unit swappedUnit = unitToSwap;

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
            if (currentAbility == null)
            {
                continue;
            }
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
		vanguardBestAbilityIndex = index + 1;
	}

	void FindBestSupportLeftAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemySupportLeft() == false) {
			return;
		}
		// Get the best ability's index
		int highestAbilityWeight = enemySupportLeft.SupportAbilities[0].GetMoveWeight(enemySupportLeft);
        supportLeftBestAbility = enemySupportLeft.SupportAbilities[0];
        int index = 0;
		if (enemySupportLeft.SupportAbilities.Length > 1) {
            Debug.Log ("Has an ability");
			for (int i = 0; i < enemySupportLeft.SupportAbilities.Length; i++) {
				Ability currentAbility = enemySupportLeft.SupportAbilities[i];
				if (currentAbility == null) {
					continue;
				}
				int currentWeight = currentAbility.GetMoveWeight(enemySupportLeft);
				if (currentWeight > highestAbilityWeight) {
					highestAbilityWeight = currentWeight;
					supportLeftBestAbility = currentAbility;
					index = i;
				}
				if (currentWeight == highestAbilityWeight) {
					if (Random.Range(0, 100) < 50) {
						highestAbilityWeight = currentWeight;
						supportLeftBestAbility = currentAbility;
						index = i;
					}
				}
			}
		} else {
			Debug.Log("only 1 support ability, what a loser");
			supportLeftBestAbility = enemySupportLeft.SupportAbilities[0];
			index = 0;
		}
		supportLeftBestAbilityIndex = index + 1;
	}

	void FindBestSupportRightAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemySupportRight() == false) {
			return;
		}
        // Get the best ability's index
        int highestAbilityWeight = enemySupportRight.SupportAbilities[0].GetMoveWeight(enemySupportRight);
        supportRightBestAbility = enemySupportRight.SupportAbilities[0];
        int index = 0;
		if (enemySupportRight.SupportAbilities[1] != null) {
			for (int i = 0; i < enemySupportRight.SupportAbilities.Length; i++) {
				Ability currentAbility = enemySupportRight.SupportAbilities[i];
				if (currentAbility == null) {
					continue;
				}
				int currentWeight = currentAbility.GetMoveWeight(enemySupportRight);
				if (currentWeight > highestAbilityWeight) {
					highestAbilityWeight = currentWeight;
					supportRightBestAbility = currentAbility;
					index = i;
				}
				if (currentWeight == highestAbilityWeight) {
					if (Random.Range(0, 100) < 50) {
						highestAbilityWeight = currentWeight;
						supportRightBestAbility = currentAbility;
						index = i;
					}
				}
			}
		} else {
			supportRightBestAbility = enemySupportRight.SupportAbilities[0];
			index = 0;
		}
		supportRightBestAbilityIndex = index + 1;
	}

	bool SetEnemyVanguard () {
		Unit vanguard = fieldController.GetUnit(FieldController.Position.Vanguard, false);
		// If there is a vanguard...
		if (vanguard != null) {
			//... Set the vanguard
			enemyVanguard = vanguard;
			return true;
		}
		return false;
	}

	bool SetEnemySupportLeft () {
		Unit supportLeft = fieldController.GetUnit(FieldController.Position.SupportLeft, false);
		enemySupportLeft = supportLeft;
		// If there is a left support...
		if (supportLeft != null) {
			//... Set the left support
			return true;
		}
		return false;
	}

	bool SetEnemySupportRight () {
		Unit supportRight = fieldController.GetUnit(FieldController.Position.SupportRight, false);
		enemySupportRight = supportRight;
		// If there is a right support...
		if (supportRight != null) {
			//... Set the right support
			return true;
		}
		return false;
	}

	void CalculateSwitchStickScores () {
		// If there is an enemy, grab there switch/stick scores
		if (enemyVanguard != null) {
			vanguardStickScore = enemyVanguard.GetStickScore();
		}
		if (enemySupportLeft != null) {
			supportLeftSwitchScore = enemySupportLeft.GetSwitchScore();
		}
		if (enemySupportRight != null) {
			supportRightSwitchScore = enemySupportRight.GetSwitchScore();
		}
	}

	protected override void SubscribeListeners () {
		GameEvents.onPhaseChanged += EnemyTurn;
		GameEvents.onSetupUnits += SetupUnits;
		GameEvents.onKill += Kill;
	}

	protected override void UnsubscribeListeners () {
		GameEvents.onPhaseChanged -= EnemyTurn;
		GameEvents.onSetupUnits -= SetupUnits;
		GameEvents.onKill -= Kill;
	}

	void Kill(Unit unit)
	{
		if(!fieldController.IsUnitPlayer(unit)) 
		{
			//unit.DestroyUnit();
		}
	}

	void EnemyTurn (RoundController.Phase phase) {
		switch (phase) {
			case RoundController.Phase.EnemyVangaurd:
			Invoke("UseVanguardAbility", 0.8f);
			break;
			case RoundController.Phase.EnemySwap:
			Invoke("SwitchPositions", 0.8f);
			Debug.Log("Swapping enemy positions!");
			break;
			case RoundController.Phase.EnemySupport:
			//UseSupportAbility();
			Invoke("UseSupportAbility", 0.8f);
			break;
			default:
			break;
		}
	}

	void UseVanguardAbility () {
		// UNCOMMENT LINES FOR TARGETING MULTIPLE CHARACTERS
		FindBestVanguardAbilityIndex();
        if (enemyVanguard && vanguardBestAbility)
        {
            // Use ability on single target
            List<Unit> validTargets = fieldController.GetValidTargets(enemyVanguard, vanguardBestAbility);
            Unit target = validTargets[Random.Range(0, validTargets.Count)];
            if (vanguardBestAbility.IsAbilityValid(enemyVanguard, target))
                GameEvents.UseAbility(enemyVanguard, target, vanguardBestAbilityIndex);
            else
                GoToNextPhase();
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
        else GoToNextPhase();
    }
	void UseSupportAbility () {
		// UNCOMMENT LINES FOR TARGETING MULTIPLE CHARACTERS
		FindBestSupportLeftAbility();
		if(enemySupportLeft)
		{
			// Support left ability on single target
			List<Unit> leftAbilityValidTargets = fieldController.GetValidTargets(enemySupportLeft, supportLeftBestAbility);
			if(leftAbilityValidTargets.Count > 0)
			{
				Unit leftTarget = leftAbilityValidTargets[Random.Range(0, leftAbilityValidTargets.Count)];
				GameEvents.UseAbility(enemySupportLeft, leftTarget, supportLeftBestAbilityIndex); // Remove this line for multi targets
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
        FindBestSupportRightAbility();
        if (enemySupportRight)
        {
            // Support right ability on single target
            List<Unit> rightAbilityValidTargets = fieldController.GetValidTargets(enemySupportRight, supportRightBestAbility);
            if (rightAbilityValidTargets.Count > 0)
            {
                Unit rightTarget = rightAbilityValidTargets[Random.Range(0, rightAbilityValidTargets.Count)];
                GameEvents.UseAbility(enemySupportRight, rightTarget, supportRightBestAbilityIndex);  // Remove this line for multi targets
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
        GoToNextPhase();
	}
	
	void GoToNextPhase () {
		GameEvents.EndPhase();
	}
}
