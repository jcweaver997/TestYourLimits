using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	public List<Question> questions;
	public Image questionR, aR, bR, cR, dR;
	public RectTransform red, blue;

	private int currentQuestion = 0;
	private Vector3 move = new Vector3(0,15,0);


	public void AnswerA(){
		Answer(Question.Answer.A);
	}

	public void AnswerB(){
		Answer(Question.Answer.B);
	}

	public void AnswerC(){
		Answer(Question.Answer.C);
	}

	public void AnswerD(){
		Answer(Question.Answer.D);
	}


	private void Answer(Question.Answer a){
		if(a == questions[currentQuestion].answer){
			Right();
		}else{
			Wrong();
		}

		TheirTurn();
		NextQuestion();
	}

	private void Wrong(){
		red.position -= move;
	}

	private void Right(){
		red.position += move;
	}

	private void TheirTurn(){
		bool correct = Random.Range(0,4)!=0;
		if(correct){
			blue.position += move;
		}else{
			blue.position -= move;
		}
	}

	private void NextQuestion(){

		currentQuestion++;
		if(currentQuestion >= questions.Count){
			EndGame();
			return;
		}
		questionR.sprite = questions[currentQuestion].question;
		aR.sprite = questions[currentQuestion].a;
		bR.sprite = questions[currentQuestion].b;
		cR.sprite = questions[currentQuestion].c;
		dR.sprite = questions[currentQuestion].d;

	}

	private void EndGame(){
		GameOver.win = red.position.y >= blue.position.y;
		SceneManager.LoadScene("GameOver");
	}

}
