using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : Listener
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float moveSpeed = 0.5f;
    private CinemachineTrackedDolly dolly;

    protected override void SubscribeListeners()
    {
        GameEvents.onChangePhase += CameraHandler;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onChangePhase -= CameraHandler;
    }

    void Start()
    {
        dolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void CameraHandler(RoundController.Phase phase)
    {
        if ((phase == RoundController.Phase.PlayerSupport ||
             phase == RoundController.Phase.PlayerSwap ||
             phase == RoundController.Phase.EnemySupport ||
             phase == RoundController.Phase.EnemySwap) &&
             dolly.m_PathPosition != 1)
        {
            StartCoroutine(MoveCameraUp());
        }

        else if ((phase == RoundController.Phase.EnemyVangaurd ||
                 phase == RoundController.Phase.PlayerVanguard) &&
                 dolly.m_PathPosition != 0)
        {
            StartCoroutine(MoveCameraDown());
        }
    }

    IEnumerator MoveCameraUp()
    {
        float startTime = Time.time;

        while (Time.time < startTime + moveSpeed)
        {
            dolly.m_PathPosition = (Time.time - startTime) / moveSpeed;
            yield return null;
        }
        dolly.m_PathPosition = 1f;
    }

    IEnumerator MoveCameraDown()
    {
        float startTime = Time.time;

        while (Time.time < startTime + moveSpeed)
        {
            dolly.m_PathPosition = 1f - (Time.time - startTime) / moveSpeed;
            yield return null;
        }
        dolly.m_PathPosition = 0f;
    }
}
