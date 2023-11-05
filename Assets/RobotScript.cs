using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public SwerveControl movement;
    private Vector2 driveForce;
    private float torque;
    public float acceleration;
    public float angularAcceleration;
    private float leftStickX;
    private float leftStickY;
    private float rightStickX;

    private bool hasCube;

    public GameObject cubeInBot;

    private float initAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        movement = new SwerveControl();
        movement.Enable();
        initAcceleration = acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        driveForce = new Vector2(Input.GetKey("d")?Time.deltaTime:0, Input.GetKey("w")? Time.deltaTime:0);
        driveForce = new Vector2(Input.GetKey("a")?-Time.deltaTime:driveForce.x, Input.GetKey("s")? -Time.deltaTime:driveForce.y);

        if(Input.GetAxis("LeftStickX") != 0 || Input.GetAxis("LeftStickY") != 0){
        driveForce = new Vector2(Input.GetAxis("LeftStickX")* Time.deltaTime, Input.GetAxis("LeftStickY")* Time.deltaTime);
        }

        torque = Input.GetKey("left")?Time.deltaTime:0;
        torque = Input.GetKey("right")?-Time.deltaTime:torque;

        // torque = Input.GetAxis("RightStickX")*Time.deltaTime;

        rigidBody.AddForce(driveForce*acceleration);
        rigidBody.AddTorque(torque*angularAcceleration);

        leftStickX = Input.GetAxis("LeftStickX");
        leftStickY = Input.GetAxis("LeftStickY");
        rightStickX = Input.GetAxis("RightStickX");

        cubeInBot.SetActive(hasCube);
    }

    public void addCube(){
        hasCube = true;
    }

    public void removeCube(){
        hasCube = false;
    }

    public bool HasCube(){
        return hasCube;
    }

    public float getRotation(){
        return this.transform.rotation.eulerAngles.z;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "SlowDown"){
        acceleration = initAcceleration * 0.5f;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "SlowDown"){
        acceleration = initAcceleration;
        }
    }
}
