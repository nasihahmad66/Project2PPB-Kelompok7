using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

    public GameObject pausePanel,exitPanel;

    public void Start()
    {
        OnUnPause();
    }

	public void OnPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnUnPause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnSetExit()
    {
        exitPanel.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnCancel()
    {
        exitPanel.SetActive(false);
    }
}
