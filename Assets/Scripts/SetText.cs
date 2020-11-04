using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SetText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text result;
    void Start()
    {
        result.GetComponent<Text>().text = Manager.Instance.result.text;
        if(result.GetComponent<Text>().text == "Red"){
            GameObject.FindGameObjectWithTag("RedWin").SetActive(true);
            GameObject.FindGameObjectWithTag("BlueWin").SetActive(false);

        }
        else{
            GameObject.FindGameObjectWithTag("RedWin").SetActive(false);
            GameObject.FindGameObjectWithTag("BlueWin").SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            SceneManager.LoadScene("TitleScene");
        }
        
    }

    public void SetWinnerText(){
    }
}
