using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour
{

    
    // Start is called before the first frame update

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player01"){
            print("Item pick up");
            //gameObject.SetActive(false);

        }
    }

    
}
