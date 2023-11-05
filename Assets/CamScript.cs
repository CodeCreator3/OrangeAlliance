using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    private bool mode = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r")){
            mode = !mode;
        }
        if(mode){
            transform.rotation = new Quaternion(0,0,0,0);
            this.GetComponent<Camera>().orthographicSize = 29.04f;
        } else{
            transform.rotation = new Quaternion(0,0,0.7071068f,0.7071068f);
            this.GetComponent<Camera>().orthographicSize = 16.1f;
        }
    }
}
