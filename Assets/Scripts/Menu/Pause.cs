using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool _pauseActive;

    void Start()
    {
        pausePanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_pauseActive)
            {
                Time.timeScale = 1;
                _pauseActive = false;
                pausePanel.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                _pauseActive = true;
                pausePanel.gameObject.SetActive(true);
            }
    }
}