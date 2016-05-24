using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Question{
	public enum Answer{
		A=0,B=1,C=2,D=3
	}
	public Answer answer;
	public Sprite question;
    public List<Sprite> answerSprite;
}
