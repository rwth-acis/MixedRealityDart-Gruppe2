using System.Collections;
using System.Collections.Generic;
using i5.Toolkit.Core.Spawners;
using Microsoft.MixedReality.Toolkit.OpenVR.Headers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    private float remainingTime;

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
                var pos = new Vector3(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2), 2);

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
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            remainingTime = spawnInterval;
            SpawnTarget();
        }
    }
}