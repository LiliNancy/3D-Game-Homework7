using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsersAction{
    int StatueChange(int s);
    int GetScore();
    void Pause();
}
public class NewGUI : MonoBehaviour
{
    private IUsersAction action;
    int score = 0;
    GUIStyle style,bigstyle;
    string gameMessage = "";
    int statue=0;
    void Start()
    {
        action = SDirector.getInstance().currentScenceController as IUsersAction;
        style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 50;

        bigstyle = new GUIStyle();
        bigstyle.normal.textColor = Color.black;
        bigstyle.fontSize = 20;
    }
    void OnGUI(){
        if(GUI.Button(new Rect(20,40,100,20), "暂停")){
            action.Pause();
        }
        if(statue==0){
            if(GUI.Button(new Rect(200,100,200,50), "游戏开始")){
                statue=1;
                action.StatueChange(statue);
            }
        }
        GUI.Label(new Rect(350, 200, 180, 200), gameMessage,style);
        GUI.Label(new Rect(Screen.width - 150,30,100,50), "Score: " + score, bigstyle);
    }
    // Update is called once per frame
    void Update()
    {
        score=action.GetScore();
        statue=action.StatueChange(-1);
        if(statue==5){
            gameMessage="GameOver";
        }
        if(statue==4){
            gameMessage="You win!!";
        }
    }
}
