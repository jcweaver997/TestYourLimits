using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

	public static bool win = false;

	public void End(){
		if(Time.timeSinceLevelLoad < .5){
			return;
		}
		SceneManager.LoadScene("Title");
	}
}
