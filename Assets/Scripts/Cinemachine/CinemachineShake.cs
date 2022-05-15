using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : Listener
{
	private CinemachineVirtualCamera virtualCamera;
	private CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin;

	private float shakeTimer;
	private float shakeTimerTotal;
	private float startingIntensity;

	void Awake () {
		virtualCamera = GetComponent<CinemachineVirtualCamera>();
		if (virtualCamera) {
			basicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		} else {
			Debug.LogError("There is no Cinemachine Virtual Camera component!");
		}
	}

	void Update () {
		if(shakeTimer > 0) {
			shakeTimer -= Time.deltaTime;
			if(shakeTimer <= 0) {
				basicMultiChannelPerlin.m_AmplitudeGain = 0;
				Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer/shakeTimerTotal));
			}
		}
	}

	void ShakeCamera (Unit attacker, Unit defender, int value) {
		if(Mathf.Abs(value) > 5) {
			ShakeCameraBig();
			return;
		}
		ShakeCameraSmall();
	}

	void ShakeCameraSmall () {
		float intensity = 0.5f;
		float duration = 0.2f;
		basicMultiChannelPerlin.m_AmplitudeGain = intensity;
		shakeTimer = duration;
		shakeTimerTotal = duration;
		startingIntensity = intensity;
	}

	void ShakeCameraBig () {
		float intensity = 3f;
		float duration = 0.3f;
		basicMultiChannelPerlin.m_AmplitudeGain = intensity;
		shakeTimer = duration;
		shakeTimerTotal = duration;
		startingIntensity = intensity;
	}

	protected override void SubscribeListeners () {
		GameEvents.onUnitAttack += ShakeCamera;
	}

	protected override void UnsubscribeListeners () {
		GameEvents.onUnitAttack -= ShakeCamera;
	}
}
