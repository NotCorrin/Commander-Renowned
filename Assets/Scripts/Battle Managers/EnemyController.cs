using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Listener
{
	[SerializeField] Unit enemyVanguard;
	[SerializeField] Unit enemySupportLeft;
	[SerializeField] Unit enemySupportRight;

	[SerializeField] Ability vanguardBestAbility;
	Ability supportLeftBestAbility;
	Ability supportRightBestAbility;

	int vanguardBestAbilityIndex;
	int supportLeftBestAbilityIndex;
	int supportRightBestAbilityIndex;

	int vanguardStickScore;
	int supportLeftSwitchScore;
	int supportRightSwitchScore;

	FieldController fieldController;
	void Start () {
		fieldController = FieldController.main;
	}

	void SwitchPositions () {
		CalculateSwitchStickScores();
		// No support enemies
		if (enemySupportLeft == null && enemySupportRight == null) {
			GameEvents.SetPhase();
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
					GameEvents.SetPhase();
					return;
				} else if (vanguardStickScore < supportLeftSwitchScore) {
					fieldController.SwapEnemyUnit(enemySupportLeft);
					return;
				} else {
					if (Random.Range(0, 100) < 50) {
						GameEvents.SetPhase();
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
					GameEvents.SetPhase();
					return;
				} else if (vanguardStickScore < supportRightSwitchScore) {
					fieldController.SwapEnemyUnit(enemySupportRight);
					return;
				} else {
					if (Random.Range(0, 100) < 50) {
						GameEvents.SetPhase();
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
				GameEvents.SetPhase();
				return;
			}else if (vanguardStickScore < enemySupportToSwitchScore) {
				fieldController.SwapEnemyUnit(enemySupportToSwitch);
				return;
			}else {
				if (Random.Range(0, 100) < 50) {
					GameEvents.SetPhase();
					return;
				} else {
					fieldController.SwapEnemyUnit(enemySupportToSwitch);
					return;
				}
			}
		}
	}

	void FindBestVanguardAbilityIndex () {
		// Determine if there is an enemy in that position
		if (SetEnemyVanguard() == false) {
			return;
		}
		// Get the best ability's index
		int highestAbilityWeight = 0;
		int index = 0;
		if (enemyVanguard.VanguardAbilities.Length > 1) {
			for (int i = 0; i < enemyVanguard.VanguardAbilities.Length; i++) {
				Ability currentAbility = enemyVanguard.VanguardAbilities[i];
				if (currentAbility == null) {
					continue;
				}
				int currentWeight = currentAbility.GetMoveWeight(enemyVanguard);
				if (currentWeight > highestAbilityWeight) {
					highestAbilityWeight = currentWeight;
					vanguardBestAbility = currentAbility;
					index = i;
				}
				if (currentWeight == highestAbilityWeight) {
					if (Random.Range(0, 100) < 50) {
						highestAbilityWeight = currentWeight;
						vanguardBestAbility = currentAbility;
						index = i;
					}
				}
			}
		} else {
			vanguardBestAbility = enemyVanguard.VanguardAbilities[0];
			index = 0;
		}
		vanguardBestAbilityIndex = index;
	}

	void FindBestSupportLeftAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemySupportLeft() == false) {
			return;
		}
		// Get the best ability's index
		int highestAbilityWeight = 0;
		int index = 0;
		if (enemySupportLeft.SupportAbilities.Length > 1) {
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
			supportLeftBestAbility = enemySupportLeft.SupportAbilities[0];
			index = 0;
		}
		supportLeftBestAbilityIndex = index;
	}

	void FindBestSupportRightAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemySupportRight() == false) {
			return;
		}
		// Get the best ability's index
		int highestAbilityWeight = 0;
		int index = 0;
		if (enemySupportRight.SupportAbilities.Length > 1) {
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
		supportRightBestAbilityIndex = index;
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
		// If there is a left support...
		if (supportLeft != null) {
			//... Set the left support
			enemySupportLeft = supportLeft;
			return true;
		}
		return false;
	}

	bool SetEnemySupportRight () {
		Unit supportRight = fieldController.GetUnit(FieldController.Position.SupportRight, false);
		// If there is a right support...
		if (supportRight != null) {
			//... Set the right support
			enemySupportRight = supportRight;
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
	}

	protected override void UnsubscribeListeners () {
		GameEvents.onPhaseChanged -= EnemyTurn;
	}

	void EnemyTurn (RoundController.Phase phase) {
		switch (phase) {
			case RoundController.Phase.EnemyVangaurd:
			UseVanguardAbility();
			break;
			case RoundController.Phase.EnemySwap:
			Debug.Log("Swapping enemy positions!");
			SwitchPositions();
			break;
			case RoundController.Phase.EnemySupport:
			UseSupportAbility();
			break;
			default:
			break;
		}
	}

	void UseVanguardAbility () {
		// UNCOMMENT LINES FOR TARGETING MULTIPLE CHARACTERS
		FindBestVanguardAbilityIndex();
		
		// Use ability on single target
		List<Unit> validTargets = fieldController.GetValidTargets(enemyVanguard, vanguardBestAbility);
		Unit target = validTargets[Random.Range(0, validTargets.Count)];
		GameEvents.UseAbility(enemyVanguard, target, vanguardBestAbilityIndex);

		/*
		int numOfTargets = [SET VALUE HERE];
		for (int i = 0; i < numOfTargets; i++) {
			target = validTargets[Random.Range(0, validTargets.Count)];
			GameEvents.UseAbility(enemyVanguard, target, vanguardBestAbilityIndex);
			validTargets.Remove(target);
		}
		*/
	}
	void UseSupportAbility () {
		// UNCOMMENT LINES FOR TARGETING MULTIPLE CHARACTERS
		FindBestSupportLeftAbility();
		// Support left ability on single target
		List<Unit> leftAbilityValidTargets = fieldController.GetValidTargets(enemySupportLeft, supportLeftBestAbility);
		Unit leftTarget = leftAbilityValidTargets[Random.Range(0, leftAbilityValidTargets.Count)];
		GameEvents.UseAbility(enemySupportLeft, leftTarget, supportLeftBestAbilityIndex); // Remove this line for multi targets

		/*
		int leftAbilityNumOfTargets = [SET VALUE HERE]; <<<<< IMPORTANT THING TO ADD
		for (int i = 0; i < leftAbilityNumOfTargets; i++) {
		leftTarget = leftAbilityValidTargets[Random.Range(0, leftAbilityValidTargets.Count)];
			GameEvents.UseAbility(enemySupportLeft, leftTarget, supportLeftBestAbilityIndex);
			leftAbilityValidTargets.Remove(leftTarget);
		}
		*/

		FindBestSupportRightAbility();

		// Support right ability on single target
		List<Unit> rightAbilityValidTargets = fieldController.GetValidTargets(enemySupportRight, supportRightBestAbility);
		Unit rightTarget = rightAbilityValidTargets[Random.Range(0, rightAbilityValidTargets.Count)];
		GameEvents.UseAbility(enemySupportRight, rightTarget, supportRightBestAbilityIndex);  // Remove this line for multi targets

		/*
		int rightAbilityNumOfTargets = [SET VALUE HERE]; <<<<< IMPORTANT THING TO ADD
		for (int i = 0; i < rightAbilityNumOfTargets; i++) {
		rightTarget = rightAbilityValidTargets[Random.Range(0, rightAbilityValidTargets.Count)];
			GameEvents.UseAbility(enemySupportRight, rightTarget, supportRightBestAbilityIndex);
			rightAbilityValidTargets.Remove(rightTarget);
		}
		*/

		GameEvents.SetPhase();
	}
}
