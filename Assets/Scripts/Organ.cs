using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Organ : MonoBehaviour
{
    public static Organ instance;//Singleton

    [SerializeField] Transform cameraPos;//Catar a posicao da camera
    public bool disableObject; //Variavel publica para o script button desativar a porra do modelo 3d
    [SerializeField] GameObject button;
    //[SerializeField] GameObject text;

    private void Awake()
    {
        instance = this;//fazer o singleton pentecer a classe

        button.SetActive(false);//desabilitar a merda do botao para que ele nao fique piscando na cena

        //Pegar a porcaria da camera porque a droga da unity nao deixa os prefabs terem coisas fora de seu contexto
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    private void Update()
    {
        //Criar variavel da distancia dos gameobjects
        var _dist = transform.position - cameraPos.position;

        //Fazer o objeto sumir caso a distancia for maior que o valor pre determinado
        disableObject = _dist.magnitude < 0.8f;

        //No caso vou desabilitar o render da criatura
        gameObject.GetComponent<Renderer>().enabled = disableObject;
        
        //Habilitar o botao caso o player esteja perto da carta
        button.SetActive(disableObject);

        /*text.SetActive(disableObject);*/
    }
}
