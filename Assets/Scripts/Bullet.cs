using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 1000;
    public int damage =  5;
    //public bool damageOverTime = false;
    //public float damageInterval = 1f;
    //public float damageOverTimeDuration = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    void OnTriggerEnter(Collider other){
        
        DoDamage(damage,other);
        gameObject.SetActive(false);
    }


    void DoDamage(int damage, Collider other){
        //if(damageOverTime){
        //    DoDamageOverTime(damageOverTimeDuration);
        //}
        other.gameObject.GetComponent<HealthBar>().TakeDamage(damage);
    }

    //void DoDamageOverTime(float duration){
        //float durationCounter = 0;
       // while(durationCounter<duration){
            //InvokeRepeating("DoDamage",0.5f,damageInterval);
            //durationCounter++;
        //}
        
    //}
}
