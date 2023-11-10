using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public Transform[] spawnPlaces;
    public GameObject bomb;
    public float minWait = 0.8f;
    public float maxWait = 2f;
    public float minForce = 4;
    public float maxForce = 8;
    public int bombPercentage = 10;
    
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            GameObject randomObj = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
            //bombPercentage의 확률로 Object에 bomb를 할당
            if (Random.Range(0, 100) < bombPercentage)
                randomObj = bomb;
            Transform spawnPoint = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject inst = Instantiate(randomObj, spawnPoint.position, spawnPoint.rotation);
            
            Rigidbody2D rb2D = inst.GetComponent<Rigidbody2D>();
            rb2D.AddForce(spawnPoint.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

            Destroy(inst, 5f);
        }
    }
}
