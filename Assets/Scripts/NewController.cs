using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour,ISceneController,IUsersAction
{
    
    public SolidFactory fcc;
    int statue=0;
    int score=0;
    List<GameObject> solider =  new List<GameObject>();
    int snum=0;
    void Start()
    {
        SDirector director = SDirector.getInstance();
        director.currentScenceController = this;
        fcc = Singleton<SolidFactory>.Instance;
        LoadResources();
    }
    public void LoadResources(){
        fcc.player.GetComponent<Animator>().enabled=false;
        fcc.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled=false;
    }
    public int StatueChange(int s){
        if(s==1) {
            fcc.player.GetComponent<Animator>().enabled=true;
            fcc.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled=true;
        }
        if(s==-1) return statue;
        statue=s;
        return statue;
    }
    public void Pause(){
         Singleton<SSEventManager>.Instance.GamePause();
    }
    public void OnEnable(){
        SSEventManager.ScoreChange+=AddScore;
        SSEventManager.GameoverChange+=GameStop;
        SSEventManager.GamePauseChange+=GamePau;
    }
    public void OnDisable(){
        SSEventManager.ScoreChange-=AddScore;
        SSEventManager.GameoverChange-=GameStop;
        SSEventManager.GamePauseChange-=GamePau;
    }
    void AddScore(){
        score++;
    }
    void GameStop(){
        statue=5;
        fcc.player.GetComponent<Animator>().enabled=false;
        fcc.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled=false;
        for(int i=0;i<solider.Count;i++){
            solider[i].GetComponent<Animator>().enabled=false;
            solider[i].GetComponent<Rigidbody>().isKinematic=true;
        }
    }
    void GamePau(){
        if(statue==1){
            fcc.player.GetComponent<Animator>().enabled=false;
            fcc.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled=false;
            for(int i=0;i<solider.Count;i++){
                solider[i].GetComponent<Animator>().enabled=false;
                solider[i].GetComponent<Rigidbody>().isKinematic=true;
            }
            statue=2;
        }
        else if(statue==2){
            fcc.player.GetComponent<Animator>().enabled=true;
            fcc.player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled=true;
            for(int i=0;i<solider.Count;i++){
                solider[i].GetComponent<Animator>().enabled=true;
                solider[i].GetComponent<Rigidbody>().isKinematic=false;
            }
        }
    }
    public int GetScore(){ return score;}
    void Update()
    {
        if(snum<10&&statue==1){
            GameObject a = fcc.getSolid();
            solider.Add(a);
            snum++;
        }
        if(fcc.player.transform.position.z>97){
            Singleton<SSEventManager>.Instance.Gameover();
            statue=4;
        }
    }
}
