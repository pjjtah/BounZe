using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

    public Button NextLevelButton;
    public Button BackButton;
    public Button ReturnButton;
    public Button PlayButton;
    public Image panel;
    private AudioManager audioManager;

    public Text timer;
    private bool paused;
    private float playPressed;

    // Use this for initialization
    void Start () {
        NextLevelButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(true);
        audioManager = FindObjectOfType<AudioManager>();
        paused = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!paused)
        {
            string s = (Time.time - playPressed).ToString("F2");
            if(s.Length < 5)
            {
                s = "0" + s;
            }
            s = s.Replace(',', ':');
            timer.text = s;
        }
	}

    public void NextLevel()
    {
        audioManager.StopAllEffects();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToLevelSelect()
    {
        audioManager.StopAllEffects();
        SceneManager.LoadScene(0);
    }

    public void Show()
    {
        NextLevelButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        PlayButton.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(false);
        SaveProgress();
    }

    public void PlayButtonPressed()
    {
        playPressed = Time.time;
        if (paused)
        {
            PlayButton.GetComponentInChildren<Text>().text = "Playing ⧐";
        }
        else
        {
            PlayButton.GetComponentInChildren<Text>().text = "Play ►";
        }
        paused = !paused;

    }

    private void SaveProgress()
    {
        if(PlayerPrefs.GetInt("completed") < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("completed", SceneManager.GetActiveScene().buildIndex);
        }

    }
}