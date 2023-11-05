using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class HumanPlayerScript : MonoBehaviour
{
    public GameObject cubePrefab;
    public float intervalSeconds;
    private float timeSinceCube;

    private GameObject newCube;

    private GameObject[] cubes;
    private int count = 1;
    private double distance;

    private bool lastCubeActive;
    // Start is called before the first frame update
    void Start()
    {
        cubes = new GameObject[10000];
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceCube+=Time.deltaTime;
        if(timeSinceCube>intervalSeconds){
            if(count==1){
            throwCube();
            } else{
                if(distance>=5||!cubes[count-1].activeInHierarchy){
                    throwCube();
                }
            }
        }
        if(count!=1){
            distance = Vector3.Distance(cubes[count-1].transform.position,new Vector3(this.transform.position.x, 3.9f, this.transform.position.z));
            lastCubeActive = cubes[count-1].activeInHierarchy;
            if(distance<=5&&cubes[count-1].activeInHierarchy){
                timeSinceCube = intervalSeconds-2;
            }
        }
        
    }

    private void throwCube(){
        cubes[count] = Instantiate(cubePrefab, this.transform);
        cubes[count].transform.position = this.transform.position;
        cubes[count].GetComponent<Rigidbody2D>().velocityY = -20;
        timeSinceCube = 0;
        count++;
    }
}
