using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed = 100f;
 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject TemporaryBullethandler;
            TemporaryBullethandler = Instantiate(bullet,bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

            TemporaryBullethandler.transform.Rotate(Vector3.left * 90);

            Rigidbody TempRigidbody;
            TempRigidbody = TemporaryBullethandler.GetComponent<Rigidbody>();
            TempRigidbody.AddForce(transform.forward * bulletSpeed);


            Destroy(TemporaryBullethandler, 7.0f);
           
           
        }
    }
   
}
