using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text result;
    void Start()
    {
        result.GetComponent<Text>().text = Manager.Instance.result.text;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWinnerText(){
    }
}
