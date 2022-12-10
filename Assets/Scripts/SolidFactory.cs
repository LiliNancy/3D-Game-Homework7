using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidFactory : Singleton<SolidFactory>
{
    public GameObject player;
    List<GameObject> used = new List<GameObject>();
    List<GameObject> free = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public GameObject getSolid(){
        GameObject a;
        if(free.Count>0){
            a = free[0];
            free.Remove(a);
        }
        else{
           a = Instantiate(Resources.Load("solidex"),
                new Vector3(Random.Range(20,30),0,Random.Range(38,90)), Quaternion.identity, null) as GameObject;
                a.gameObject.tag = "solid";
                a.GetComponent<Magnetic>().play=player;
        }
        used.Add(a);
        return a;
    }
    public void FreeSolid(GameObject b){
        used.Remove(b);
        free.Add(b);
    }
}
