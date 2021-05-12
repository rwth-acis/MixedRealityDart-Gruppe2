using System.Collections;
using System.Collections.Generic;
using i5.Toolkit.Core.Spawners;
using Microsoft.MixedReality.Toolkit.OpenVR.Headers;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private int targetsPerGame;
    private int remainingTargets;
    private float remainingTime;
    private bool gameStarted = false;
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private PressableButtonHoloLens2 startButton;
    [SerializeField] private Interactable startButtonInteractability;
    [SerializeField] private TextMeshPro countDownText;
    // [SerializeField] private SpeechInputHandler speechInputHandler;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = spawnInterval;
    }

    void SpawnTarget()
    {
        
        Spawner spawner = gameObject.GetComponent(typeof(Spawner)) as Spawner;
        if (spawner != null)
        {
            if (spawner.Spawn())
            {
                Debug.Log("Spawner did spawning.");
                var pos = new Vector3(UnityEngine.Random.Range(0f, 3f), UnityEngine.Random.Range(0f, 3f), 2);

                var target = spawner.MostRecentlySpawnedObject;
                if (target)
                {
                    target.transform.position = pos;
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted){
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                remainingTime = spawnInterval;
                if (remainingTargets == 0){
                    EndGame();
                }
                else{
                    
                    SpawnTarget();
                    remainingTargets --;
                    countDownText.text = "Remaining Targets:" + remainingTargets;
                }
            }
        }
    }

    public void StartGame(){
        gameStarted = true;
        textMeshPro.text = "Get Ready!";
        startButtonInteractability.enabled = false;
        remainingTargets = targetsPerGame;
        countDownText.text = "Remaining Targets:" + remainingTargets;
    }

    public void EndGame(){
        gameStarted = false;
        textMeshPro.text = "Press Play!";
        startButtonInteractability.enabled = true;
        Spawner spawner = gameObject.GetComponent(typeof(Spawner)) as Spawner;
        GameObject.Destroy(spawner.MostRecentlySpawnedObject);
    }
}