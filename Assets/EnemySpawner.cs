using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(enemyPrefab, MapGenerator.path[0].transform.position, new Quaternion());
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
