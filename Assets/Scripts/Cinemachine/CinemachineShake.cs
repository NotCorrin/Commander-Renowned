using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

/// <summary>
/// Controls the camera shake of the main camera through cinemachine.
/// </summary>
public class CinemachineShake : Listener
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin;

    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    /// <summary>
    /// Subscribes 'ShakeCamera' into GameEvents.onUnitAttack.
    /// </summary>
    protected override void SubscribeListeners()
    {
        GameEvents.onUnitAttack += ShakeCamera;
    }

    /// <summary>
    /// Unsubscribes 'ShakeCamera' into GameEvents.onUnitAttack.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        GameEvents.onUnitAttack -= ShakeCamera;
    }

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera)
        {
            basicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        else
        {
            Debug.LogError("There is no Cinemachine Virtual Camera component!");
        }
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                basicMultiChannelPerlin.m_AmplitudeGain = 0;
                Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
            }
        }
    }

    private void ShakeCamera(Unit attacker, Unit defender, int value)
    {
        if (Mathf.Abs(value) > 5)
        {
            ShakeCameraBig();
            return;
        }

        ShakeCameraSmall();
    }

    private void ShakeCameraSmall()
    {
        float intensity = 0.5f;
        float duration = 0.2f;
        basicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = duration;
        shakeTimerTotal = duration;
        startingIntensity = intensity;
    }

    private void ShakeCameraBig()
    {
        float intensity = 3f;
        float duration = 0.35f;
        basicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = duration;
        shakeTimerTotal = duration;
        startingIntensity = intensity;
    }
}
