using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player01Base;
    public GameObject player02Base;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player01Base.GetComponent<HealthBar>().alive == false){
            Debug.Log("base has been destroyed");
            Manager.Instance.result.text = "Red Wins";
            SceneManager.LoadScene("ResultScene");
        }else if(player02Base.GetComponent<HealthBar>().alive == false){
            Manager.Instance.result.text = "Blue Wins";
            SceneManager.LoadScene("ResultScene");
        }
        
    }
}
