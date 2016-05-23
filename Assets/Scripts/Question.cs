using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Question{
	public enum Answer{
		A,B,C,D
	}
	public Answer answer;
    public int ianswer;
	public Sprite question;
    public List<Sprite> answerSprite;


    public static GetNum(Answer a)
    {

    }

    public Question()
    {
        switch (answer)
        {
            case Answer.A:
                ianswer = 0;
                break;
            case Answer.B:
                ianswer = 1;
                break;
            case Answer.C:
                ianswer = 2;
                break;
            case Answer.D:
                ianswer = 3;
                break;
            default:
                break;
        }
    }
}
