using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IntakeScript : MonoBehaviour
{
    public Transform Transform;

    public RobotScript robotScript;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetKey("up")){
            Transform.SetLocalPositionAndRotation(new Vector3(0,50f,0), new Quaternion(0,0,0,0));
        } else{
            Transform.SetLocalPositionAndRotation(new Vector3(0,32.2f,0), new Quaternion(0,0,0,0));
        }
        up = Input.GetKey("up");
    }

    void OnCollisionEnter2D(Collision2D col){
        if(!robotScript.HasCube()&&col.collider.gameObject.tag == "Cube"&&Input.GetKey("up")){
        col.collider.gameObject.SetActive(false);
        robotScript.addCube();
        }
    }
}
