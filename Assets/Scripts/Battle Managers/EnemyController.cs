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

	FieldController fieldController;
	void Start () {
		fieldController = FieldController.main;
	}

	void SwitchPositions () {

		int vanguardStickScore;
		int supportLeftSwitchScore;
		int supportRightSwitchScore;

		// No support enemies
		if (enemySupportLeft == null && enemySupportRight == null) {
			GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
			return;
		}

		// Only left support
		if (enemySupportLeft != null && enemySupportRight == null) {
			if(enemyVanguard != null) {
				vanguardStickScore = enemyVanguard.GetStickScore();
				supportLeftSwitchScore = enemySupportLeft.GetSwitchScore();
				if (vanguardStickScore > supportLeftSwitchScore) {
					GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
					return;
				} else {
					fieldController.SwapEnemyUnit(enemySupportLeft);
					return;
				}
			} else {
				fieldController.SwapEnemyUnit(enemySupportLeft);
				return;
			}
		}
		
		// Only right support
		if (enemySupportLeft == null && enemySupportRight != null) {
			if (enemyVanguard != null) {
				vanguardStickScore = enemyVanguard.GetStickScore();
				supportRightSwitchScore = enemySupportRight.GetSwitchScore();
				if (vanguardStickScore > supportRightSwitchScore) {
					GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
					return;
				} else {
					fieldController.SwapEnemyUnit(enemySupportRight);
					return;
				}
			} else {
				fieldController.SwapEnemyUnit(enemySupportRight);
				return;
			}
		}

		// Have both supports
		vanguardStickScore = enemyVanguard.GetStickScore();
		supportLeftSwitchScore = enemySupportLeft.GetSwitchScore();
		supportRightSwitchScore = enemySupportRight.GetSwitchScore();

		// TODO: SIMPLIFY CODE BELOW (Compare supports together first and then compare results to vanguard)

		// E.G.		V=5  L=1  R=2	(Vanguard greatest)
		if (vanguardStickScore > supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
			return;
		}
		// E.G.		V=2  L=9  R=1	(Support Left greatest)
		else if (supportLeftSwitchScore > vanguardStickScore && supportLeftSwitchScore > supportRightSwitchScore) {
			fieldController.SwapEnemyUnit(enemySupportLeft);
		}
		// E.G.		V=2  L=1  R=6	(Support Right greatest)
		else if (supportRightSwitchScore > vanguardStickScore && supportRightSwitchScore > supportLeftSwitchScore) {
			fieldController.SwapEnemyUnit(enemySupportRight);
		}
		// E.G.		V=5  L=5  R=2	(Vanguard & Support Left equal)
		else if (vanguardStickScore == supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			int chance = Random.Range(0,100);
			if(chance >= 49) {
				fieldController.SwapEnemyUnit(enemySupportLeft);
			} else {
				GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
			}
		}
		// E.G.		V=5  L=2  R=5	(Vanguard & Support Right equal)
		else if (vanguardStickScore == supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			int chance = Random.Range(0, 100);
			if (chance >= 49) {
				fieldController.SwapEnemyUnit(enemySupportRight);
			} else {
				GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
			}
		}
		// E.G.		V=5  L=5  R=5	(All score equal)
		else if (vanguardStickScore == supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			int chance = Random.Range(0, 100);
			if (chance >= 66) {
				GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
			} else if (chance >= 33) {
				fieldController.SwapEnemyUnit(enemySupportLeft);
			} else {
				fieldController.SwapEnemyUnit(enemySupportRight);
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

	bool SetEnemySupportRight() {
		Unit supportRight = fieldController.GetUnit(FieldController.Position.SupportRight, false);
		// If there is a right support...
		if (supportRight != null) {
			//... Set the right support
			enemySupportRight = supportRight;
			return true;
		}
		return false;
	}

	protected override void SubscribeListeners () {
		throw new System.NotImplementedException();
	}

	protected override void UnsubscribeListeners () {
		throw new System.NotImplementedException();
	}
}
