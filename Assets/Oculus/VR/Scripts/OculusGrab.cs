using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrab : MonoBehaviour
{
    public GameObject CollidingObject;
    public GameObject objectInHand;
    public Rigidbody rig;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>())
        {
            CollidingObject = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        CollidingObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") > 0.2f && CollidingObject)
        {
            GrabObject();
        }
        if(Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") < 0.2f && objectInHand)
        {
            ReleaseObject();
        }
        Debug.Log("obj in hand "+objectInHand);
        Debug.Log("colliding object: "+CollidingObject);
    }

    public void GrabObject()
    {
        objectInHand = CollidingObject;
        objectInHand.transform.SetParent(this.transform);
        rig = objectInHand.GetComponent<Rigidbody>();
        rig.isKinematic = true;
    }

    public void ReleaseObject()
    {
        rig = objectInHand.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
    }
}
