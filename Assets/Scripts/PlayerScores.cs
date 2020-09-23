using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class PlayerScores : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;
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
        GameObject GMScore = GameObject.Find("ScoreGlobal");
        ScoreScript ScoreS = (ScoreScript)GMScore.GetComponent(typeof(ScoreScript));
        LeaderBoards = new ArrayList();
        LeaderBoards.Add("Top Jugadores");
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unityfirebasebbdd.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        playerScore = Int32.Parse(ScoreS.Score);
        scoreText.text = "Puntuación: " + ScoreS.Score;
        Destroy(GMScore);

        /*
        FirebaseDatabase.DefaultInstance
          .GetReference("users")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot snapshot = task.Result;
                  snapshot
                  // Do something with snapshot...
              }
          });*/

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
        if(args.Snapshot != null && args.Snapshot.ChildrenCount > 0)
        {
            foreach(var childSnapshot in args.Snapshot.Children)
            {
                LeaderBoards.Insert(1, childSnapshot.Child("score").Value.ToString() + " " + childSnapshot.Child("username").Value.ToString());
                LeaderboardText.text = "";
                foreach(string item in LeaderBoards)
                {
                    LeaderboardText.text += "\n" + item;
                }
            }
        }

    }

    private void writeNewUser(string userId, string name, string score)
    {
        User user = new User(name, score);
        string json = JsonUtility.ToJson(user);

        reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
        print(reference.Push().ToString().Substring(41));
        writeNewUser(reference.Push().ToString().Substring(41), playerName, playerScore.ToString());
        //PostToDatabase();
    }
    public void OnGetScore()
    {
        scoreText.text = RetrieveFromDatabase().userScore.ToString();
    }
        

    public void PostToDatabase()
    {
        UserI user = new UserI();
        RestClient.Put("https://unityproyecto-12709.firebaseio.com/"+ playerName +".json", user);
        //RestClient.Put("https://unityproyecto-12709.firebaseio.com/.json", user);
        //RestClient.Post("https://unityproyecto-12709.firebaseio.com/.json", user);
    }

    private UserI RetrieveFromDatabase()
    {
        RestClient.Get <UserI>("https://unityproyecto-12709.firebaseio.com/" + playerName + ".json").Then(response =>
        {
            return response;

            });
        return null;
    }

}

public class User
{
    public string username;
    public string score;

    public User()
    {
    }

    public User(string username, string score)
    {
        this.username = username;
        this.score = score;
    }
}
