using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ChoosePlayer : MonoBehaviour
{
    public SpriteRenderer player;
    public List<Sprite> image = new List<Sprite>();
    private int chosenPlayer = 0;
    public GameObject playerSprite;
    public string sceneLoad;

    public void Next(){
        chosenPlayer = chosenPlayer + 1;
        if(chosenPlayer == image.Count){
            chosenPlayer = 0;
        }
        player.sprite = image[chosenPlayer];
    }

    public void Back(){
        chosenPlayer = chosenPlayer - 1;
        if(chosenPlayer < 0){
            chosenPlayer = image.Count - 1;
        }
        player.sprite = image[chosenPlayer];
    }

    public void LoadGame(){
        PrefabUtility.SaveAsPrefabAsset(playerSprite, "Assets/Entities/Player/Prefabs/player1_0.prefab");
        SceneManager.LoadScene(sceneLoad);
    }
}
