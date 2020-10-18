using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player01Base;
    public GameObject player02Base;
    public GameObject player01;
    public Vector3 player01RP;
    public GameObject player02;
    public Vector3 player02RP;

    [SerializeField]
    public int xMaxPos = 40;
    public int xMinPos = 10;
    public int zMaxPos = 40;
    public int zMinPos = 5;
    public int yPos = 4;
    public float spawnRate = 2f;
    public int maxAmmoBox = 2;
    private int spawnedBox = 0 ;
    public GameObject[] ammoBox;

    protected float Timer;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!player01Base.GetComponent<HealthBar>().alive || !player02Base.GetComponent<HealthBar>().alive){
            EndGame();
        }
        
        if(!player01.GetComponent<HealthBar>().alive || !player02.GetComponent<HealthBar>().alive){
            Respawning();
        }

        if(spawnedBox <= maxAmmoBox ){
        Timer += Time.deltaTime;
            if(Timer >= spawnRate){
                Timer = 0;
                spawnedBox += 1;
                Instantiate(RandomBox(),RandomPos(),Quaternion.identity);
            }
        }
        
    }

    void EndGame(){
        if(player01Base.GetComponent<HealthBar>().alive == false){
            Debug.Log("base has been destroyed");
            Manager.Instance.result.text = "Red Wins";
            SceneManager.LoadScene("ResultScene");
        }else if(player02Base.GetComponent<HealthBar>().alive == false){
            Manager.Instance.result.text = "Blue Wins";
            SceneManager.LoadScene("ResultScene");
        }
    }
    
    void Respawning(){
        if(!player01.GetComponent<HealthBar>().alive){
            Respawn(player01, player01RP);
        }
        if(!player02.GetComponent<HealthBar>().alive){
            Respawn(player02, player02RP);
        }
    }

    void Respawn(GameObject obj, Vector3 RP){
        obj.GetComponent<HealthBar>().alive = true;
        obj.GetComponent<Transform>().position = RP;
        obj.GetComponent<HealthBar>().SetHealth(obj.GetComponent<HealthBar>().maxHealth);
        obj.SetActive(true);

    }

    GameObject RandomBox(){
        GameObject tempBox;
        tempBox = ammoBox[Random.Range(0, ammoBox.Length)];
        return tempBox;
    }
    Vector3 RandomPos(){
        Vector3 randomPos = new Vector3(Random.Range(xMinPos,xMaxPos),yPos,Random.Range(zMinPos,zMaxPos));
        return randomPos;
    }
}
