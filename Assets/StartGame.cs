using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void GameStart(){
		SceneManager.LoadScene("Game");
	}
}
