using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject zombie;
    public GameObject zombieLeel2;
    public Transform[] ZombiePos;

    public GameObject Clip;
    private void Start()
    {
        InvokeRepeating("SpawnZombie", 0, 4);
        InvokeRepeating("SpawnZombieLevel2",0,40);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
        InvokeRepeating("SpawnClip", 0, 35);
    }
    void SpawnZombie()
    {
        int randumPos = Random.Range(0, ZombiePos.Length);
        Vector3 spawnPos = ZombiePos[randumPos].position;
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(zombie, spawnPos, spawnRotation);
    }
    void SpawnZombieLevel2()
    {
        int randumPos = Random.Range(0, ZombiePos.Length);
        Vector3 spawnPos = ZombiePos[randumPos].position;
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(zombieLeel2, spawnPos, spawnRotation);
    }
    void SpawnClip()
    {
        float x = Random.Range(-50, 200);
        byte y = 2;
        float z = Random.Range(0, 170);
        Vector3 randumPos = new Vector3(x,y,z);
        Instantiate(Clip, randumPos, Clip.transform.rotation);
    }
}