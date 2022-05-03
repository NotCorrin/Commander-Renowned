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

	void SwitchPositions () {
		// If there are no support enemies, return
		if(enemySupportLeft == null && enemySupportRight == null) {
			// Go the next phase?
			return;
		}

		int vanguardStickScore = enemyVanguard.GetStickScore();
		int supportLeftSwitchScore = enemySupportLeft.GetSwitchScore();
		int supportRightSwitchScore = enemySupportRight.GetSwitchScore();
		// E.G.		V=5  L=1  R=2	(Vanguard greatest)
		if(vanguardStickScore > supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			// Do not switch, go to next phase
			return;
		}
		// E.G.		V=2  L=9  R=1	(Support Left greatest)
		else if (supportLeftSwitchScore > vanguardStickScore && supportLeftSwitchScore > supportRightSwitchScore) {
			// Swap the enemies, go to next phase
		}
		// E.G.		V=2  L=1  R=6	(Support Right greatest)
		else if (supportRightSwitchScore > vanguardStickScore && supportRightSwitchScore > supportLeftSwitchScore) {
			// Swap the enemies, go to next phase
		}
		// E.G.		V=5  L=5  R=2	(Vanguard & Support Left equal)
		else if (vanguardStickScore == supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			int chance = Random.Range(0,100);
			if(chance >= 49) {
				// Swap the enemies, go to next phase
			}
			// Go to next phase
		}
		// E.G.		V=5  L=2  R=5	(Vanguard & Support Right equal)
		else if (vanguardStickScore == supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			int chance = Random.Range(0, 100);
			if (chance >= 49) {
				// Swap the enemies, go to next phase
			}
			// Go to next phase
		}
		// E.G.		V=5  L=5  R=5	(All score equal)
		else if (vanguardStickScore == supportLeftSwitchScore && vanguardStickScore > supportRightSwitchScore) {
			int chance = Random.Range(0, 100);
			if (chance >= 66) {
				// Dont switch, go to next phase
			} else if (chance >= 33) {
				// Switch with left support, go to next phase
			} else {
				// Switch with right support, go to next phase
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
		Unit vanguard = FieldController.main.GetUnit(FieldController.Position.Vanguard, false);
		// If there is a vanguard...
		if (vanguard != null) {
			//... Set the vanguard
			enemyVanguard = vanguard;
			return true;
		}
		return false;
	}

	bool SetEnemySupportLeft () {
		Unit supportLeft = FieldController.main.GetUnit(FieldController.Position.SupportLeft, false);
		// If there is a left support...
		if (supportLeft != null) {
			//... Set the left support
			enemySupportLeft = supportLeft;
			return true;
		}
		return false;
	}

	bool SetEnemySupportRight() {
		Unit supportRight = FieldController.main.GetUnit(FieldController.Position.SupportRight, false);
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
