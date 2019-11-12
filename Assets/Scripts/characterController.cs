using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour
{

    static Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    //to get a hold of our healthbar
    public Slider healthbar;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar.value <= 0) //if the skeleton is dead
        {
            return; //cease all function in the ai script (so it lays dead)
            //we probably want to call a death function
        }

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("isAttacking", true);
        }
        else
            anim.SetBool("isAttacking", false);

        if (translation != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

    }
}