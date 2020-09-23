using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string Score;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setScore(string score)
    {
        this.Score = score;
    }
}
