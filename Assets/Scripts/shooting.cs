using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed = 100f;
 
    public bool shootCD = true;
    public int shootTimer = 4;
    protected float Timer;
    public GameObject ShootSign;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= shootTimer){
            Timer = 0;
            shootCD = true;
            ShootSign.SetActive(true);
        }
        if(Input.GetButtonDown("ShootKey")){
            if(shootCD){
                shootCD = false;
                ShootSign.SetActive(false);
                GameObject TemporaryBullethandler;
                TemporaryBullethandler = Instantiate(bullet,bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

                TemporaryBullethandler.transform.Rotate(Vector3.left * 90);

                Rigidbody TempRigidbody;
                TempRigidbody = TemporaryBullethandler.GetComponent<Rigidbody>();
                TempRigidbody.AddForce(transform.forward * bulletSpeed);

                Destroy(TemporaryBullethandler, 7.0f);
                
            }
            else{

                print("shooting is on cooldown");
            }
        }
        
            
           
           
        
    }
   
}
