using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveData
{
    public int money;
	public int score;
	public int highscore;
	
	public SaveData (CircleScript player)
	{
		money = player.money;
		score = player.score;
		highscore = player.highscore;
	}
}
