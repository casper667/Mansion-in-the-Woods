using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTower : MonoBehaviour
{
    public GameObject towerPrefab;
    bool hasTower = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeTower()
    {
        if (!hasTower)
        {
            Instantiate(towerPrefab, gameObject.transform.position, new Quaternion());
            hasTower = true;
        }
    }
}
