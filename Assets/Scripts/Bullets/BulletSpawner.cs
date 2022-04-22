using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletSpawnData[] spawnDatas;
    public int index = 0;
    public bool isAttackTypeRandom;
    public bool spawningAutomatically;

    BulletSpawnData GetSpawnData()
    {
        return spawnDatas[index];
    }

    float timer;
    
    float[] rotations;

    void Start()
    {
        timer = GetSpawnData().cooldown;
        rotations = new float[GetSpawnData().numberOfBullets];
        if (!GetSpawnData().isRandom)
        {
            
        }
    }

    
    void Update()
    {
        if (spawningAutomatically)
        {
            if (timer <= 0)
            {
                SpawnBullets();
                timer = GetSpawnData().cooldown;

                if (isAttackTypeRandom)
                {
                    index = Random.Range(0, spawnDatas.Length);
                }
                else
                {
                    index += 1;
                    if (index >= spawnDatas.Length)
                    {
                        index = 0;
                    }
                }
                rotations = new float[GetSpawnData().numberOfBullets];
            }
            timer -= Time.deltaTime;
        }
    }

    // Select random rotation from min to max for each bullet
    public float[] RandomRotations()
    {
        for ( int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            rotations[i] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;
    }

    //distributes the bullets evenly between min and max bullet rotation
    public float[] DistributedRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            var fraction = (float)i / ((float)GetSpawnData().numberOfBullets - 1);
            var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + GetSpawnData().minRotation;
        }
        return rotations;
    }

    public GameObject[] SpawnBullets()
    {
        rotations = new float[GetSpawnData().numberOfBullets];
        if (GetSpawnData().isRandom)
        {
            RandomRotations();
        }
        else
        {
            DistributedRotations();
        }

        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            spawnedBullets[i] = BulletManager.GetBulletFromPool();
            if (spawnedBullets[i] == null)
            {
                spawnedBullets[i] = Instantiate(GetSpawnData().bulletResource, transform);
            } 
            else
            {
                spawnedBullets[i].transform.SetParent(transform);
                spawnedBullets[i].transform.localPosition = Vector2.zero;
            }
            

            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = GetSpawnData().bulletSpeed;
            b.direction = GetSpawnData().bulletDirection;

            if (GetSpawnData().isNotParent)
            {
                spawnedBullets[i].transform.SetParent(null);
            }
        }
        return spawnedBullets;
    }
}
