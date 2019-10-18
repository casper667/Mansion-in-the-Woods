using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

  private bool changeScene = false;
  private RaycastHit hit;

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //print(gameObject.GetComponent<Button>().);
      OVRInput.Update();
      if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
      {
        Debug.Log("Button Down");
         SetChange(true);
      }
    }

  public void SetChange(bool val)
  {
    changeScene = val;
  }
  public bool GetChange()
  {
    return changeScene;
  }

}
