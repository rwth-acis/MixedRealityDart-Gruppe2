using System.Collections;
using System.Collections.Generic;
using i5.Toolkit.Core.Spawners;
using Microsoft.MixedReality.Toolkit.OpenVR.Headers;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    private float remainingTime;
    private bool gameStarted = false;

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
                var pos = new Vector3(UnityEngine.Random.Range(0, 3), UnityEngine.Random.Range(0, 3), 2);

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
                SpawnTarget();
            }
        }
    }

    public void StartGame(){
        gameStarted = true;
    }
}