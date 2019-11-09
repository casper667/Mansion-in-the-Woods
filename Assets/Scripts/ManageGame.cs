using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
	public GameObject start;
 	public GameObject player = null;
	public string nextScene = "Outside";

  	// Start is called before the first frame update
  	void Start()
  	{
		//Find start button on title screen
		start = GameObject.FindWithTag("Start");
		DontDestroyOnLoad(this.gameObject);
    }

  	// Update is called once per frame
  	void Update()
  	{
		if (player == null && SceneManager.GetActiveScene().name == "Outside"){
			player = GameObject.FindWithTag("Player"); 
		}

		if(Input.GetKeyDown(KeyCode.Return)){
			switch(SceneManager.GetActiveScene().name){
				case "Title":
					nextScene = "Outside";
					break;
				case "Outside":
					nextScene = "PatrolDemo";
					break;
				case "PatrolDemo":
					nextScene = "SecondFloor";
					break;
                case "SecondFloor":
                    nextScene = "Title";
                    break;
            }
			ChangeScene(nextScene);
		}

		if (start != null){
			//print(start.gameObject.GetComponent<StartGame>().GetChange());
			if (start.gameObject.GetComponent<StartGame>().GetChange()){
				ChangeScene("Outside");
				start = null;
			}
		}
  	}

    public void ChangeScene(string name)
    {
		SceneManager.UnloadSceneAsync(sceneName: SceneManager.GetActiveScene().name);
		SceneManager.LoadScene(sceneName: name);
    }

}
