using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EjectorScript : MonoBehaviour
{
    public GameObject robot;
    private RobotScript robotScript;
    public GameObject cubePrefab;
    private GameObject newCube;

    private float velX;
    private float velY;

    private float rot;

    public float deploySpeed;
    // Start is called before the first frame update
    void Start()
    {
        robotScript = robot.GetComponent<RobotScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("down") && robotScript.HasCube()){
            robotScript.removeCube();
            newCube = Instantiate(cubePrefab, this.transform, true);
            newCube.transform.position = this.transform.position;
            newCube.GetComponent<Rigidbody2D>().velocity =robot.GetComponent<Rigidbody2D>().velocity;
            newCube.GetComponent<Rigidbody2D>().velocity += new Vector2(-math.sin(math.radians(robot.transform.rotation.eulerAngles.z)),math.cos(math.radians(robot.transform.rotation.eulerAngles.z)))*deploySpeed;
            
        }
        rot  = robot.transform.rotation.eulerAngles.z;
        velX = math.sin(math.radians(robot.transform.rotation.eulerAngles.z));
        velY = math.cos(math.radians(robot.transform.rotation.eulerAngles.z));
    }
}
