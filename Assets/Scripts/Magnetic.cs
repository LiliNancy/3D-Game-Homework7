using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public GameObject play;
    Animator ani;
    Vector3 player;
    int after=0;
    int i=0;
    void FixedUpdate ()
    {
        player=play.transform.position;
        float xx=player.x-this.transform.position.x;
        float zz=player.z-this.transform.position.z;
        ani=GetComponent<Animator>();
        float res=xx*xx+zz*zz;
        if(res<25){
            ani.SetBool("who",true);
            this.transform.LookAt(player);
            after=1;
        }
        else{
            ani.SetBool("who",false);
            if(after==1) {
                Singleton<SSEventManager>.Instance.Escape();
                after=0;
            }
        }
    }
    void OnCollisionEnter(Collision co){
        if(co.gameObject.tag=="Player"){
            Singleton<SSEventManager>.Instance.Gameover();
        }
        else{
            
            this.transform.rotation=Quaternion. Euler(new Vector3(0, 180*i, 0));
            i=1-i;
        }
    }
}
