using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public GameObject[] cameraPrefab;
    //public GenerateLevel generator;
    int nextLevel = 0;

    public LevelManager lvl;

    //temporary fun
    public int RandomLevel(int min, int max){
        return Random.Range(min, max + 1);
    }

    private void Start() {
        //lvl = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<LevelManager>();
        //lvl.UpdateLevel(transform.position,0, -1, -1, -1);
        //Debug.Log("chuj");
    }


    private void OnTriggerEnter2D(Collider2D other){
        GameObject currentCamera = Camera.main.gameObject;
        nextLevel = RandomLevel(0,1);
        //Debug.Log("Cam = " + currentCamera.transform.position);
        //LevelChange level = cameraPrefab[nextLevel].GetComponent<LevelChange>();

        if (currentCamera.CompareTag("MainCamera") && other.CompareTag("Player"))
        {
            /*
            // changes the position (level)
            Debug.Log("bef function");
            level.CameraMove();
            Debug.Log("af function");
            */

            //change current camera prefab (doors placement)
            GameObject newCamera = Instantiate(cameraPrefab[nextLevel]);
            //Debug.Log(newCamera.transform.position);
            if(newCamera){
                Destroy(currentCamera);
                //Debug.Log(newCamera.name);
                //Debug.Log(newCamera.transform.position.x);
                //lvl.UpdateLevel(newCamera.transform.position,0, -1, -1, -1);
                newCamera.tag = "MainCamera";
                //Debug.Log(newCamera.transform.position);
            }
            
        }
    }

}
