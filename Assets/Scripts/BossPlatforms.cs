using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatforms : MonoBehaviour
{
    public GameObject[] platforms;
    public int numberOfPlatformsOnScreen;
    public Transform player;

    private float xSpawnLocation;

    private void Start()
    {
        for(int i=0; i < numberOfPlatformsOnScreen; i++)
        {
            if (i == 0) SpawnFirstPlatform();
            SpawnTile();
        }
    }

    private void Update()
    {
        if (player.position.x > xSpawnLocation - (numberOfPlatformsOnScreen * 22))
        {
            SpawnTile();
        }
    }

    private void SpawnFirstPlatform()
    {
        Instantiate(platforms[0], transform.right * xSpawnLocation, transform.rotation);
        xSpawnLocation += 22;
    }

    private void SpawnTile()
    {
        Instantiate(platforms[Random.Range(0, platforms.Length)], transform.right * xSpawnLocation, transform.rotation);
        xSpawnLocation += 22;
    }
}
