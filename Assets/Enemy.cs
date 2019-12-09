using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Waypoint current;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        current = MapGenerator.path[0];
        transform.position = current.transform.position;
        Waypoint next = MapGenerator.path[1];

        transform.rotation = Quaternion.LookRotation((next.transform.position - current.transform.position).normalized);
    }

    // Update is called once per frame
    void Update()
    {
        if(current.index < MapGenerator.path.Count-1)
        {
            Waypoint next = MapGenerator.path[current.index + 1];
            transform.position += (next.transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation((next.transform.position - transform.position).normalized), 15f);

            if(Vector3.Distance(transform.position, next.transform.position) <= speed * Time.deltaTime)
            {
                current = next;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
