using System.Collections.Generic;
using UnityEngine;
using PhEngine.Core;
using Random = UnityEngine.Random;

namespace SuperGame
{
    public class ObstacleSpawner : Singleton<ObstacleSpawner>
    {
        [SerializeField] float maxDelay = 5f;
        [SerializeField] float minDelay = 5f;
        [SerializeField] float currentDelay;
        [SerializeField] List<Obstacle> obstacleList = new List<Obstacle>();
       
        protected override void InitAfterAwake()
        {
            currentDelay = Random.Range(minDelay, maxDelay);
        }

        void Update()
        {
            if (currentDelay >= 0)
            {
                currentDelay -= Time.deltaTime;
            }
            else
            {
                currentDelay = Random.Range(minDelay, maxDelay);
                Spawn();
            }
        }

        void Spawn()
        { 
            var randomIndex = Random.Range(0, obstacleList.Count);
            var randomObstacle = obstacleList[randomIndex];
            randomObstacle.Play();
        }
    }
}