using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject organ;

    private void Update()
    {
        organ = GameObject.FindGameObjectWithTag("Organ");
        
        if (organ == null) 
            Debug.Log("Legal :)");

        organ.SetActive(Organ.instance.disableObject);
        /*else
        {*/
        //} 
    }
}
