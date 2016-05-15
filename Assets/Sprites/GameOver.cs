using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

	public static bool win = false;
	public Text text;
	float timer;
	// Use this for initialization
	void Start () {
		if(win){
			text.text = "YOU WIN!";
		}else{
			text.text = "YOU LOSE!";
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer>=2.5){
			SceneManager.LoadScene("Title");
		}
	}
}
