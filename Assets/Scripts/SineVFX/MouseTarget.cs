using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour {

    public Transform ms;
    public float speed = 1f;
    public ParticleSystem startWavePS;
    public ParticleSystem startParticles;
    public ParticleSystem smallMissiles;
    public int smallMissilesCount = 100;
    public ParticleSystem bigMissileOne;
    public ParticleSystem bigMissileTwo;
    public ParticleSystem bigMissileThree;
    public int bigMissileThreeCount = 6;

    private Vector3 mouseWorldPosition;
    private Animator anim;
    
    void Start () {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startWavePS.Emit(1);
            startParticles.Emit(smallMissilesCount);
        }       

        if (Input.GetMouseButton(0))
        {
            var em = smallMissiles.emission;
            em.enabled = true;
            //smallMissiles.enableEmission = true;

            anim.SetBool("Fire", true);
        }
        else
        {
            var em = smallMissiles.emission;
            em.enabled = false;
            //smallMissiles.enableEmission = false;

            anim.SetBool("Fire", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Fire", true);
            bigMissileOne.Emit(1);
            if (bigMissileTwo)
            {
                bigMissileTwo.Emit(1);
            }                
            if (bigMissileThree)
            {
                bigMissileThree.Emit(bigMissileThreeCount);
            }            
            startWavePS.Emit(1);
            startParticles.Emit(smallMissilesCount);
        }
    }

    // Raycasting and positioning Cursor GameObject at Collision point
    void FixedUpdate () {  

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mouseWorldPosition = hit.point;
        }

        Quaternion toRotation = Quaternion.LookRotation(mouseWorldPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        ms.position = mouseWorldPosition;

    }
}
