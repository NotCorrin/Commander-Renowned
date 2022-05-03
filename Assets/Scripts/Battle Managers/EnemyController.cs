using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Listener
{
	[SerializeField] Unit enemyVanguard;
	[SerializeField] Unit enemySupportLeft;
	[SerializeField] Unit enemySupportRight;

	Ability vanguardBestAbility;
	Ability supportLeftBestAbility;
	Ability supportRightBestAbility;

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
			GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
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
					GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
					return;
				} else if (vanguardStickScore < supportLeftSwitchScore) {
					fieldController.SwapEnemyUnit(enemySupportLeft);
					return;
				} else {
					if (Random.Range(0, 100) < 50) {
						GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
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
					GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
					return;
				} else if (vanguardStickScore < supportRightSwitchScore) {
					fieldController.SwapEnemyUnit(enemySupportRight);
					return;
				} else {
					if (Random.Range(0, 100) < 50) {
						GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
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
				GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
				return;
			}else if (vanguardStickScore < enemySupportToSwitchScore) {
				fieldController.SwapEnemyUnit(enemySupportToSwitch);
				return;
			}else {
				if (Random.Range(0, 100) < 50) {
					GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
					return;
				} else {
					fieldController.SwapEnemyUnit(enemySupportToSwitch);
					return;
				}
			}
		}
	}

	void FindBestVanguardAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemyVanguard() == false) {
			return;
		}
		// Get the best ability
		int highestAbilityWeight = 0;
		foreach (Ability ability in enemyVanguard.VanguardAbilities) {
			int currentWeight = ability.GetMoveWeight(enemyVanguard);
			if (currentWeight > highestAbilityWeight) {
				highestAbilityWeight = currentWeight;
				vanguardBestAbility = ability;
			}
		}
	}

	void FindBestSupportLeftAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemySupportLeft() == false) {
			return;
		}
		// Get the best ability
		int highestAbilityWeight = 0;
		foreach (Ability ability in enemySupportLeft.SupportAbilities) {
			int currentWeight = ability.GetMoveWeight(enemyVanguard);
			if (currentWeight > highestAbilityWeight) {
				highestAbilityWeight = currentWeight;
				supportLeftBestAbility = ability;
			}
		}
	}

	void FindBestSupportRightAbility () {
		// Determine if there is an enemy in that position
		if (SetEnemySupportRight() == false) {
			return;
		}
		// Get the best ability
		int highestAbilityWeight = 0;
		foreach (Ability ability in enemySupportRight.SupportAbilities) {
			int currentWeight = ability.GetMoveWeight(enemyVanguard);
			if (currentWeight > highestAbilityWeight) {
				highestAbilityWeight = currentWeight;
				supportRightBestAbility = ability;
			}
		}
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
		throw new System.NotImplementedException();
	}

	protected override void UnsubscribeListeners () {
		throw new System.NotImplementedException();
	}
}
