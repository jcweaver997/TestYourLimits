using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	public List<Question> questions;
	public Image questionR, aR, bR, cR, dR;
	public RectTransform red, blue;
    

	private int currentQuestion = -1;
	private Vector3 move = new Vector3(0,15,0);

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
        Debug.Log(questions[currentQuestion].ianswer);
        if (questions[currentQuestion].ianswer == answerOrder[a])
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
		GameOver.win = red.position.y >= blue.position.y;
		SceneManager.LoadScene("GameOver");
	}

}
