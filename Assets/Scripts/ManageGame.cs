using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{

  public GameObject start;
  public GameObject player = null;

  // Start is called before the first frame update
  void Start()
  {
    start = GameObject.FindWithTag("Start");
    
    if (SceneManager.GetActiveScene().name == "Master")
      SceneManager.SetActiveScene(SceneManager.GetSceneByName("Title"));
  }

  // Update is called once per frame
  void Update()
  {
    if (player == null && SceneManager.GetActiveScene().name == "Outside")
    {
      player = GameObject.FindWithTag("Player");
    }
    if (player != null)
    {
      print("Found~!");
    }

    if (start != null)
    {
      //print(start.gameObject.GetComponent<StartGame>().GetChange());
      if (start.gameObject.GetComponent<StartGame>().GetChange())
      {
        ChangeScene("Outside");
      }
    }

  }

    public void ChangeScene(string name)
    {
      if(SceneManager.GetActiveScene().name == "Title")
        SceneManager.UnloadSceneAsync(sceneName: "Title");
      SceneManager.LoadSceneAsync(sceneName: name);
    }
}
