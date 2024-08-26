using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FunctionabiliteOfTheBtn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI informacao;
    [SerializeField] string conteudoInfo;

    private void Awake()
    {
        informacao.gameObject.SetActive(false);
    }

    public void ShowText() 
    {
        informacao.text = conteudoInfo;
        informacao.gameObject.SetActive(!informacao.gameObject.activeSelf);
    }
}