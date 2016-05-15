using UnityEngine;
using System.Collections;

[System.Serializable]
public class Question{
	public enum Answer{
		A,B,C,D
	}
	public Answer answer;
	public Sprite question,a,b,c,d;
}
