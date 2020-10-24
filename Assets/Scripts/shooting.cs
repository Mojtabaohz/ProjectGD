using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletEmitter;
    public GameObject bullet;
    public int dmg;
    public float bulletSpeed = 100f;
    public bool shootCD = true;
    public int ammoCount = 0 ;
    public float reloadSpeed = 4;
    protected float Timer;
    public GameObject shootSign;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ShootSign(shootCD); 
    }
    public void Shoot(){
        if(ammoCount>=1){
            Shooting();
        }
        else if(ammoCount <= 0){
            SetDefaultWeapon(this.gameObject);
            Shooting();
        }
    }

    void Shooting(){
        if(shootCD){
            ammoCount -= 1;
            shootCD = false;
            shootSign.SetActive(false);


            GameObject TemporaryBullethandler;
            TemporaryBullethandler = Instantiate(bullet,bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

            TemporaryBullethandler.transform.Rotate(Vector3.left * 90);

            Rigidbody TempRigidbody;
            TempRigidbody = TemporaryBullethandler.GetComponent<Rigidbody>();
            TempRigidbody.AddForce(transform.forward * bulletSpeed);
            TemporaryBullethandler.GetComponent<Bullet>().collisionEnable = true;
            Destroy(TemporaryBullethandler, 4.0f);
                
            }
            else{

                print("shooting is on cooldown");
            }
    }

    void ShootSign(bool SCD){
        if(!SCD){
            Timer += Time.deltaTime;
            if(Timer >= reloadSpeed){
                Timer = 0;
                shootCD = true;
                shootSign.SetActive(true);
            }
        }
    }

    public void SetDefaultWeapon(GameObject player){
        player.GetComponent<shooting>().ammoCount = FindObjectOfType<ResultManager>().defaultWeapon.GetComponent<AmmoBox>().ammoCount;
        player.GetComponent<shooting>().bulletSpeed = FindObjectOfType<ResultManager>().defaultWeapon.GetComponent<AmmoBox>().bulletSpeed;
        player.GetComponent<shooting>().bullet = FindObjectOfType<ResultManager>().defaultWeapon.GetComponent<AmmoBox>().bullet;
        player.GetComponent<shooting>().dmg = FindObjectOfType<ResultManager>().defaultWeapon.GetComponent<AmmoBox>().dmg;
        player.GetComponent<shooting>().reloadSpeed = FindObjectOfType<ResultManager>().defaultWeapon.GetComponent<AmmoBox>().reloadSpeed;      
    }
   
}
