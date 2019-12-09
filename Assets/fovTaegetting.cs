using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fovTaegetting : MonoBehaviour
{
    GameObject targetInRange = null;
    GameObject bulletPrefab;
    public float shotDelay;
    public Transform bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(targetInRange == null)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                targetInRange = other.gameObject;
                Debug.Log("Enemy in Range");
                StartCoroutine("Shoot");
            }
        }
    }

    private void OnTriggerStay(Collider other)  //happens every frame they're in there
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && targetInRange == other.gameObject) //are they the same one
        {
            findNewTarget();
            Debug.Log("Enemy out of Range");
            StopCoroutine("Shoot");

        }
    }

    public GameObject getTarget()
    {
        return targetInRange;
    }

    public void findNewTarget()
    {
        targetInRange = null;
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, new Quaternion());
            //bullet.GetComponent<Rigidbody>().AddForce
        }
    }
}
