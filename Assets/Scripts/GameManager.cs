using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject panel;

    private void Start()
    {
        startButton.onClick.AddListener(Join);
        exitButton.onClick.AddListener(Exit);

        panel.SetActive(true);
    }

    private void Join()
    {
        panel.SetActive(false);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
