using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class FirebaseScript : MonoBehaviour
{
    public Text LeaderboardText;

    private System.Random random = new System.Random();

    public static int playerScore;
    public static string playerName;
    DatabaseReference reference;



    ArrayList LeaderBoards;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(scoreText.text);
        //Debug.Log(scoreText);
        //Debug.Log(RetrieveFromDatabase().userScore.ToString());
        //Debug.Log(RetrieveFromDatabase().userScore);
        LeaderBoards = new ArrayList();
        LeaderBoards.Add("Top Jugadores");
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unityfirebasebbdd.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance
        .GetReference("users").OrderByChild("score")
        .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        print(args.Snapshot.ToString());
        // Do something with the data in args.Snapshot
        String title = LeaderBoards[0].ToString();
        LeaderBoards.Clear();
        LeaderBoards.Add(title);
        if (args.Snapshot != null && args.Snapshot.ChildrenCount > 0)
        {
            foreach (var childSnapshot in args.Snapshot.Children)
            {
                print(childSnapshot.Key);
                LeaderBoards.Insert(1, childSnapshot.Child("username").Value.ToString() + "  - " + childSnapshot.Child("score").Value.ToString());
                LeaderboardText.text = "";
                foreach (string item in LeaderBoards)
                {
                    LeaderboardText.text += "\n" + item;
                }
            }
        }

    }

}

