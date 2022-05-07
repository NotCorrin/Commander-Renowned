using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionController : MonoBehaviour
{

    public MetaAudioController mac;
    public bool big;

    private ParticleSystem ps;
    List<ParticleCollisionEvent> colEvents;

    void Start()
    {

        ps = GetComponent<ParticleSystem>();
        colEvents = new List<ParticleCollisionEvent>();

    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(ps, other, colEvents);

        for (int i = 0; i < colEvents.Count; i++)
        {
            mac.EmitParticleExplosion(colEvents[i].intersection, big);
        }

    }
}
