using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    int a,b;
    public GameObject endline;
    // Start is called before the first frame update
    void Start()
    {
        a=(int)Random.Range(1,3);
        b=(int)Random.Range(1,4);
        this.transform.position=new Vector3(15+(a-1)*20,1,16+21*b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision co){
        Debug.Log("test");
        if(co.gameObject.tag=="Player"){
            endline.SetActive(false);
            this.transform.gameObject.SetActive(false);
        }
    }
}
