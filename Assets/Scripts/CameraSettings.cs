using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour {

    public ImageEffect[] effects;
    public RectTransform CRTBorder;
    public GlitchEffect glitchEffect;

    // Use this for initialization
    void Start () {
        CRTBorder = GameObject.Find("crt_border").GetComponent<RectTransform>();
        int aspect = (int) (Camera.main.aspect * 100f);
        switch (aspect)
        {
            case 44:
                CRTBorder.sizeDelta = new Vector2(1000, 2080);
                break;
            case 45:
                CRTBorder.sizeDelta = new Vector2(1000, 2080);
                break;
            case 56:
                CRTBorder.sizeDelta = new Vector2(1160, 2080);
                break;
            case 62:
                CRTBorder.sizeDelta = new Vector2(1300, 2080);
                break;
            case 66:
                CRTBorder.sizeDelta = new Vector2(1450, 2080);
                break;
            case 75:
                CRTBorder.sizeDelta = new Vector2(1630, 2080);
                break;
            case 80:
                CRTBorder.sizeDelta = new Vector2(1750, 2080);
                break;

        }

        /*
        if (Screen.height == 1280)
        {
            CRTBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1267);
        }
        if (Screen.height == 1440)
        {
            CRTBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1180);
        }
        if (Screen.height == 1920)
        {
            CRTBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1258);
        }
        if (Screen.height == 2160)
        {
            CRTBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1111);
        }
        */
        if(glitchEffect != null)
        {
            UpdateEffects();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateEffects()
    {
        if (PlayerPrefs.GetInt("Scanlines") == 0)
        {
            effects[0].enabled = true;
        }
        else
        {
            effects[0].enabled = false;
        }
        if (PlayerPrefs.GetInt("Grain") == 0)
        {
            effects[1].enabled = true;
        }
        else
        {
            effects[1].enabled = false;
        }
        if (PlayerPrefs.GetInt("Border") == 0)
        {
            CRTBorder.gameObject.SetActive(true);
        }
        else
        {
            CRTBorder.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Glitch") == 0)
        {
            glitchEffect.activated = true;
        }
        else
        {
            glitchEffect.activated = false;
        }
    }
}
