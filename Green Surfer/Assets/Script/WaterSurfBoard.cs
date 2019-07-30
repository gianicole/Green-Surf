using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GreenSurfPhysics;

public class WaterSurfBoard : MonoBehaviour
{

    public Transform Motor;
    public float TurnPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;

    public void Awake() {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        var forceDirection = transform.forward;
        var  steer = 0; 

        if (Input.GetKey(KeyCode.A))
            steer = 1;
        if (Input.GetKey(KeyCode.D))
            steer = -1;
            

            //Rotational Force
            Rigidbody.AddForceAtPosition(steer *transform.right * TurnPower/ 100f, Motor.position);

            //Compute Vectors
            var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);


        //forward/backwordPower
        if (Input.GetKey(KeyCode.W))
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        if (Input.GetKey(KeyCode.S))
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * -MaxSpeed, Power);
}
}
