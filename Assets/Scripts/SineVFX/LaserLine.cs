using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLine : MonoBehaviour
{
    public float maxLength = 1.0f;

    public AnimationCurve shaderProgressCurve;
    public AnimationCurve lineWidthCurve;

    public float globalProgressSpeed = 0.1f;

    public GameObject explosionPrefab;
    public ParticleSystem psEmbers;
    public int trailParticleCount = 5;
    public float moveHitToSource = 0.5f;

    private float AnimationProgress;
    private float HitLength;
    private LineRenderer lr;
    private Vector3 positionForExplosion;
    private bool spawnExplosion = false;
    private Vector3[] particleSpawnPositions;
    private Vector3 endPoint;
    float globalProgress;

    // Updating and Fading
    void DrawLine() 
    {
        float progress = shaderProgressCurve.Evaluate(globalProgress);
        lr.material.SetFloat("_Progress", progress);

        float width = lineWidthCurve.Evaluate(globalProgress);
        lr.widthMultiplier = width;
    }

    // Initialize Laser Line
    void CastLaserRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxLength))
        {
            HitLength = hit.distance;
            positionForExplosion = Vector3.MoveTowards(hit.point, transform.position, moveHitToSource);
            spawnExplosion = true;
            particleSpawnPositions = new Vector3[Mathf.RoundToInt(hit.distance*2)];
            endPoint = hit.point;
        }

        lr.SetPosition(0, transform.position);

        if (HitLength != 0)
        {
            lr.SetPosition(1, transform.position + (transform.forward * HitLength));
        }
        else
        {
            lr.SetPosition(1, transform.position + (transform.forward * maxLength));
        }
    }

    void Start()
    {
        
        spawnExplosion = false;
        lr = GetComponent<LineRenderer>();
        HitLength = 0;
        CastLaserRay();
        DrawLine();
       

        if (spawnExplosion)
        {
            Instantiate(explosionPrefab, positionForExplosion, new Quaternion(0, 0, 0, 0));
        }

        float n = 0f;
        for (int i = 0; i < particleSpawnPositions.Length; i++)
        {
            particleSpawnPositions[i] = Vector3.Lerp(transform.position, endPoint, n);
            psEmbers.transform.position = particleSpawnPositions[i];
            psEmbers.Emit(trailParticleCount);
            n += (1f / particleSpawnPositions.Length);
        }

    }

    void Update()
    {
        if (globalProgress < 1f)
        {
            globalProgress += Time.deltaTime * globalProgressSpeed;
        }
        DrawLine();
    }
}
