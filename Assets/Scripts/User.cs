using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UserI
{
    public string userName;
    public int userScore;

    public UserI()
    {
        userName = PlayerScores.playerName;
        userScore = PlayerScores.playerScore;

    }
}

