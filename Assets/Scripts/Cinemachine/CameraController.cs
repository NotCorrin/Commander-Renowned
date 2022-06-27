using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

/// <summary>
/// Controls the position of the camera.
/// </summary>
public class CameraController : Listener
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float moveSpeed = 0.5f;
    private CinemachineTrackedDolly dolly;

    /// <summary>
    /// Subscribes 'CameraHandler' into GameEvents.onPhaseChanged.
    /// </summary>
    protected override void SubscribeListeners()
    {
        GameEvents.onPhaseChanged += CameraHandler;
    }

    /// <summary>
    /// Unsubscribes 'CameraHandler' into GameEvents.onPhaseChanged.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        GameEvents.onPhaseChanged -= CameraHandler;
    }

    private void Start()
    {
        dolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void CameraHandler(RoundController.PhaseType phase)
    {
        if ((phase == RoundController.PhaseType.PlayerSupport ||
             phase == RoundController.PhaseType.PlayerSwap ||
             phase == RoundController.PhaseType.EnemySupport ||
             phase == RoundController.PhaseType.EnemySwap) &&
             dolly.m_PathPosition != 1)
        {
            StartCoroutine(MoveCameraUp());
        }
        else if ((phase == RoundController.PhaseType.EnemyVangaurd ||
                 phase == RoundController.PhaseType.PlayerVanguard) &&
                 dolly.m_PathPosition != 0)
        {
            StartCoroutine(MoveCameraDown());
        }
    }

    private IEnumerator MoveCameraUp()
    {
        float startTime = Time.time;

        while (Time.time < startTime + moveSpeed)
        {
            dolly.m_PathPosition = (Time.time - startTime) / moveSpeed;
            yield return null;
        }

        dolly.m_PathPosition = 1f;
    }

    private IEnumerator MoveCameraDown()
    {
        float startTime = Time.time;

        while (Time.time < startTime + moveSpeed)
        {
            dolly.m_PathPosition = 1f - ((Time.time - startTime) / moveSpeed);
            yield return null;
        }

        dolly.m_PathPosition = 0f;
    }
}
