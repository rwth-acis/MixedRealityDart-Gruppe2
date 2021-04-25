using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0) {
            remainingTime = spawnInterval;
            Debug.Log("Spawn Interval Passed");
        }
    }
}
