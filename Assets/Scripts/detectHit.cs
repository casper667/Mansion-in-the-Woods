using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class detectHit : MonoBehaviour
{
    public Slider healthbar;
    Animator anim;
    public string opponent; //Note: the opponent changes for each character/enemy

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != opponent) //if what collides isn't the opponent's weapon collider
        {
            return; //don't detect a hit
        }
        
        //Debug.Log("Hit");
        healthbar.value -= 20;

        if(healthbar.value <= 0)
        {
            anim.SetBool("isDead", true); //if health reaches 0 play death anim.
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
