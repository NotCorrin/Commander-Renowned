using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAutoFireAtTarget : MonoBehaviour
{
    public ParticleSystem startWavePS;
    public ParticleSystem startParticles;
    public ParticleSystem smallMissiles;
    public int smallMissilesCount = 100;
    public ParticleSystem bigMissileOne;
    public ParticleSystem bigMissileTwo;
    public ParticleSystem bigMissileThree;
    public int bigMissileThreeCount = 6;

    public float smallMissilesPerSecond;

    public float bigMissilesPerSecond;
    float bigMissileFireTimer;

    public bool limitedSmallMissileFireTime;
    public bool limitedBigMissileFireTime;

    public float smallMissileMaxFireTime;
    float smallMissileMaxFireTimer;

    public float bigMissileMaxFireTime;
    float bigMissileMaxFireTimer;


    [SerializeField] HomingParticles smallMissilesHoming;
    [SerializeField] HomingParticles bigMissile1Homing;
    [SerializeField] HomingParticles bigMissile2Homing;
    [SerializeField] HomingParticles bigMissile3Homing;

    [SerializeField] Transform smallMissilesTarget;
    [SerializeField] Transform bigMissilesTarget;
    // Start is called before the first frame update

    void Awake()
    {
        if (smallMissilesTarget)
        {
            SetSmallMissilesHoming(smallMissilesTarget);
        }
        else
        {
            if (smallMissilesHoming) smallMissilesHoming.enabled = false;
            if (smallMissiles) smallMissiles.enableEmission = false;
        }

        if (bigMissilesTarget)
        {
            SetBigMissilesHoming(bigMissilesTarget);
        }
        else
        {
            if (bigMissile1Homing) bigMissile1Homing.enabled = false;
            if (bigMissile2Homing) bigMissile2Homing.enabled = false;
            if (bigMissile3Homing) bigMissile3Homing.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((smallMissileMaxFireTimer -= Time.deltaTime) <= 0 && limitedSmallMissileFireTime)
        {
            smallMissiles.enableEmission = false;
        }
        if (smallMissiles) smallMissiles.emissionRate = smallMissilesPerSecond;

        if ((bigMissileMaxFireTimer -= Time.deltaTime) >= 0 || !limitedBigMissileFireTime)
        {
            if (bigMissilesTarget)
            {
                if ((bigMissileFireTimer -= Time.deltaTime) <= 0)
                {
                    if (bigMissileOne)
                    {
                        bigMissileOne.Emit(1);
                    }

                    if (bigMissileTwo)
                    {
                        bigMissileTwo.Emit(1);
                    }

                    if (bigMissileThree)
                    {
                        bigMissileThree.Emit(bigMissileThreeCount);
                    }

                    bigMissileFireTimer = 1 / bigMissilesPerSecond;

                    EmitFiringParticles();
                }
            }
        }

    }

    void EmitFiringParticles()
    {
        if (startWavePS) startWavePS.Emit(1);
        if (startParticles) startParticles.Emit(smallMissilesCount);
    }

    public void SetSmallMissilesHoming(Transform target)
    {
        smallMissilesTarget = target;
        if (smallMissilesHoming)
        {
            smallMissilesHoming.target = target;
            smallMissilesHoming.enabled = true;

            EmitFiringParticles();
            smallMissiles.enableEmission = true;
            smallMissiles.emissionRate = smallMissilesPerSecond;
            smallMissileMaxFireTimer = smallMissileMaxFireTime;
        }
    }

    public void SetBigMissilesHoming(Transform target)
    {
        Debug.Log("Assigned target for big missiles");

        bigMissileMaxFireTimer = bigMissileMaxFireTime;
        bigMissileFireTimer = -1;
        bigMissilesTarget = target;
        if (bigMissile1Homing)
        {
            bigMissile1Homing.target = target;
            bigMissile1Homing.enabled = true;
        }

        if (bigMissile2Homing)
        {
            bigMissile2Homing.target = target;
            bigMissile2Homing.enabled = true;
        }

        if (bigMissile3Homing)
        {
            bigMissile3Homing.target = target;
            bigMissile3Homing.enabled = true;
        }
    }
}
