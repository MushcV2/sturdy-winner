using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThreeDManager : MonoBehaviour
{
    [SerializeField] GameObject organModel;
    [SerializeField] GameObject showerButton;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

  

    private void Update()
    {
        CheckNull();
    }

    void CheckNull()
    {
        organModel = GameObject.FindGameObjectWithTag("Organ");
        if (organModel != null)
        {
            textMeshProUGUI.text = "Clique";
            organModel.SetActive(!Organ.instance.disableObject);
        }

        else
        {
            textMeshProUGUI.text = "Invisivel";
        }
        Debug.Log(textMeshProUGUI.text);
    }
}
