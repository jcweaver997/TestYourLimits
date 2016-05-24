using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	public List<Question> questions;
	public Image questionR, aR, bR, cR, dR;
	public RectTransform red, blue;
	public Image speedup;
    
	private Color cClear = new Color(1f,1f,1f,0f);
	private Color cOpaque = new Color(1f,1f,1f,1f);
	private int currentQuestion = -1;
	private Vector3 move = new Vector3(0f,15f,0f);

    void Start()
    {
        NextQuestion();
    }

	public void AnswerA(){
		Answer(0);
	}

	public void AnswerB(){
		Answer(1);
	}

	public void AnswerC(){
		Answer(2);
	}

	public void AnswerD(){
		Answer(3);
	}


	private void Answer(int a){
        Debug.Log(answerOrder[a]);
		Debug.Log((int)questions[currentQuestion].answer);
		if (questions[currentQuestion].answer == (Question.Answer)answerOrder[a])
        {
			Right();
		}else{
			Wrong();
		}

		TheirTurn();
		NextQuestion();
	}

	private void Wrong(){
		red.position -= move;
		GameOver.win = false;
		SceneManager.LoadScene("GameOver");
	}

	private void Right(){
		red.position += move;
		StopCoroutine(Showspeed());
		StartCoroutine(Showspeed());
	}

	public IEnumerator Showspeed(){

		int counter = 10;

		while (counter > 0){
			speedup.color = cOpaque;
			yield return new WaitForSeconds(.05f*Mathf.Pow(counter,.75f));
			speedup.color = cClear;
			yield return new WaitForSeconds(.1f);
			counter--;
		}


	}


	private void TheirTurn(){
		bool correct = Random.Range(0,4)!=0;
		if(correct){
			blue.position += move;
		}else{
			blue.position -= move;
		}
	}

    List<int> avaliableNumbers;
    List<int> answerOrder;

	private void NextQuestion(){
        avaliableNumbers = new List<int>();
        answerOrder = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            avaliableNumbers.Add(i);
        }

        while (avaliableNumbers.Count>0)
        {
            int index = Random.Range(0,avaliableNumbers.Count);
            answerOrder.Add(avaliableNumbers[index]);
            avaliableNumbers.RemoveAt(index);
        }


        currentQuestion++;
		if(currentQuestion >= questions.Count){
			EndGame();
			return;
		}


		questionR.sprite = questions[currentQuestion].question;
		aR.sprite = questions[currentQuestion].answerSprite[answerOrder[0]];
		bR.sprite = questions[currentQuestion].answerSprite[answerOrder[1]];
        cR.sprite = questions[currentQuestion].answerSprite[answerOrder[2]];
        dR.sprite = questions[currentQuestion].answerSprite[answerOrder[3]];

    }

	private void EndGame(){
		GameOver.win = true;
		SceneManager.LoadScene("Win");
	}

}
