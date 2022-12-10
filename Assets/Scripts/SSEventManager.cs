using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSEventManager : MonoBehaviour
{
    public delegate void ScoreEvent();
    public static event ScoreEvent ScoreChange;

    public delegate void GameoverEvent();
    public static event GameoverEvent GameoverChange;

    public delegate void GameStopEvent();
    public static event GameStopEvent GamePauseChange;
    public void Escape(){
        if(ScoreChange!=null){
            ScoreChange();
        }
    }
    public void Gameover(){
        if(GameoverChange!=null){
            GameoverChange();
        }
    }
    public void GamePause(){
        if(GamePauseChange!=null){
            GamePauseChange();
        }
    }
}
