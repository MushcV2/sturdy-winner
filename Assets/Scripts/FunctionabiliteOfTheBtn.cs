using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FunctionabiliteOfTheBtn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI informacao;
    [SerializeField] private Button activeText;
    [SerializeField] string conteudoInfo;

    private void Awake()
    {
        informacao.gameObject.SetActive(false);
    }

    private void Start()
    {
        informacao.text = conteudoInfo;
        informacao.gameObject.SetActive(!informacao.gameObject.activeSelf);
    }
}