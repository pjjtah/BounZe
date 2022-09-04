using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flavour : MonoBehaviour
{
    public string[] flavourTexts;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = flavourTexts[Random.Range(0, flavourTexts.Length)];
    }

}
