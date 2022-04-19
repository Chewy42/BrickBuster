using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : DeathEffectObject
{
    private Transform paddleParent;
    private bool isInPlay = false;
    private Rigidbody physics;
    private float startSpeed = 300;
    void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
        paddleParent = transform.parent;
    }

    public void Reset(){
        gameObject.SetActive(true);
        isInPlay = false;
        physics.isKinematic = true;
        transform.parent = paddleParent;
        transform.position = new Vector3(0f, 1f, 0f);
    }

    void FixedUpdate()
    {
        if (isOkayToLaunch()){
            Launch();
        }
    }

    public void Disable(){
        gameObject.SetActive(false);
    }

    private bool isOkayToLaunch(){
        if(isInPlay == false && Input.GetButtonDown("Fire1")){
            return true;
        }
        return false;
    }

    private void Launch(){
        isInPlay = true;
        transform.parent = null;
        physics.isKinematic = false;
        physics.AddForce(new Vector3(startSpeed, startSpeed, 0f));
    }
    
}
