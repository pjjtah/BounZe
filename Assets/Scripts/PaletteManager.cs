using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaletteManager : MonoBehaviour {

    public Material ball;
    public Material wall;
    public Material handle;
    public Material goal;
    private Color color;
    // Use this for initialization
    void Start () {
        if(SceneManager.GetActiveScene().buildIndex < 11)
        {
            ball.color = new Color32(134, 0, 41, 255);
            wall.color = new Color32(222, 0, 78, 255);
            handle.color = new Color32(134, 0, 41, 126);
            goal.color = new Color32(26, 254, 73, 255);
        }
        else if (SceneManager.GetActiveScene().buildIndex < 21)
        {
            ball.color = new Color32(233, 109, 94, 255);
            wall.color = new Color32(255, 230, 157, 255);
            handle.color = new Color32(255, 151, 96, 126);
            goal.color = new Color32(26, 254, 73, 255);
        }
        else if (SceneManager.GetActiveScene().buildIndex < 31)
        {
            ball.color = new Color32(255, 110, 39, 255);
            wall.color = new Color32(115, 255, 254, 255);
            handle.color = new Color32(98, 135, 248, 126);
            goal.color = new Color32(26, 254, 73, 255);
        }
        else if (SceneManager.GetActiveScene().buildIndex < 41)
        {
            ball.color = new Color32(231, 104, 34, 255);
            wall.color = new Color32(244, 206, 159, 255);
            handle.color = new Color32(199, 199, 186, 126);
            goal.color = new Color32(26, 254, 73, 255);
        }



    }

    // Update is called once per frame
    void Update () {
		
	}
}
