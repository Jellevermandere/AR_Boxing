using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperateGlove : MonoBehaviour
{
    public ParticleSystem hitParticle;
    public float impulseTreshhold = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag + collision.impulse.magnitude);

        if(collision.impulse.magnitude > impulseTreshhold && collision.gameObject.tag == "HitObject")
        {
            hitParticle.Play();
        }

        
    }
}
