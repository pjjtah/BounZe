using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Toggle[] toggles;
    public ImageEffect[] effects;

    public Canvas LevelSelectCanvas;
    public Canvas MainMenuCanvas;
    public Canvas SettingsCanvas;

    public Button[] LevelButtons;

    public Slider MusicSlider;

    public AudioManager audioManager;
    public RectTransform CRTBorder;

    public int completedLevels;

    public GameObject consentPanel;
    // Use this for initialization
    void Start () {

        audioManager = FindObjectOfType<AudioManager>();

        UpdateEffects();
        completedLevels = PlayerPrefs.GetInt("completed")+1;
        EnableLevelSelectButtons();

        MusicSlider.value = PlayerPrefs.GetFloat("Audio");
        if(MusicSlider.value == 0f)
        {
            MusicSlider.value = 0.3f;
        }
        MusicSliderChanged();

        if(PlayerPrefs.GetInt("ConsentAsked") == 0)
        {
            consentPanel.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateEffects()
    {
        if (PlayerPrefs.GetInt("Scanlines") == 0)
        {
            toggles[0].isOn = true;
            effects[0].enabled = true;
        }
        else
        {
            toggles[0].isOn = false;
            effects[0].enabled = false;
        }
        if (PlayerPrefs.GetInt("Grain") == 0)
        {
            toggles[1].isOn = true;
            effects[1].enabled = true;
        }
        else
        {
            toggles[1].isOn = false;
            effects[1].enabled = false;
        }
        if (PlayerPrefs.GetInt("Border") == 0)
        {
            toggles[2].isOn = true;
            CRTBorder.gameObject.SetActive(true);
        }
        else
        {
            toggles[2].isOn = false;
            CRTBorder.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Glitch") == 0)
        {
            toggles[3].isOn = true;
        }
        else
        {
            toggles[3].isOn = false;
        }
    }

    public void OnSettingsToggle(int i)
    {
        if (toggles[i].isOn)
        {
            if(i == 0)
            {
                PlayerPrefs.SetInt("Scanlines", 0);
            }
            else if(i == 1)
            {
                PlayerPrefs.SetInt("Grain", 0);
            }
            else if (i == 2)
            {
                PlayerPrefs.SetInt("Border", 0);
            }
            else if (i == 3)
            {
                PlayerPrefs.SetInt("Glitch", 0);
            }
        }
        else
        {
            if (i == 0)
            {
                PlayerPrefs.SetInt("Scanlines", 1);
            }
            else if (i == 1)
            {
                PlayerPrefs.SetInt("Grain", 1);
            }
            else if (i == 2)
            {
                PlayerPrefs.SetInt("Border", 1);
            }
            else if (i == 3)
            {
                PlayerPrefs.SetInt("Glitch", 1);
            }
        }
        PlayerPrefs.Save();
        UpdateEffects();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotoLevelSelect(bool t)
    {
        MainMenuCanvas.gameObject.SetActive(!t);
        LevelSelectCanvas.gameObject.SetActive(t);
    }

    public void Continue()
    {
        SceneManager.LoadScene(completedLevels);
    }

    public void SelectLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    private void EnableLevelSelectButtons()
    {
        for(int i = 0; i < completedLevels; i++)
        {
            LevelButtons[i].interactable = true;
        }

    }

    public void MusicSliderChanged()
    {
        audioManager.Music.volume = MusicSlider.value * 0.3f;
        audioManager.BounceEffect.volume = MusicSlider.value;
        audioManager.ShatterEffect.volume = MusicSlider.value;
        audioManager.ResetEffect.volume = MusicSlider.value;
        PlayerPrefs.SetFloat("Audio", MusicSlider.value);
        PlayerPrefs.Save();
    }

    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("https://pages.flycricket.io/bounze-0/privacy.html");
    }

    public void DeclinePrivacyPolicy()
    {
        PlayerPrefs.SetInt("ConsentAsked", 1);
        PlayerPrefs.SetInt("ConsentGiven", 0);
        consentPanel.SetActive(false);
    }

    public void AcceptPrivacyPolicy()
    {
        PlayerPrefs.SetInt("ConsentAsked", 1);
        PlayerPrefs.SetInt("ConsentGiven", 1);
        consentPanel.SetActive(false);
    }

    public void ShowConsentPanel()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        consentPanel.SetActive(true);
        SettingsCanvas.gameObject.SetActive(false);
    }

    public void GoToSettings(bool t)
    {
        MainMenuCanvas.gameObject.SetActive(t);
        SettingsCanvas.gameObject.SetActive(!t);
    }
}
