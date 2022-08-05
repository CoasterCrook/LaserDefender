using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayPoints;
    int wayPointIndex = 0;
    
    void Awake() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();    
    }
    
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            
            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
