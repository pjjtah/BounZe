using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingWall : Wall
{

    public int maxHP = 1;
    private int HP;
    public Material[] materials;
    private Renderer renderer;
    private AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        HP = maxHP;
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material = materials[HP-1];
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HP = HP - 1;
            if(audioManager != null)
            {
                audioManager.PlayShatterEffect(HP * 0.5f);
            }
            if (HP < 1)
            {
                gameObject.SetActive(false);
            }
            else
            {
                renderer.material = materials[HP-1];
            }
        }
    }

    public void Reset()
    {
        HP = maxHP;
        renderer.material = materials[HP - 1];
        gameObject.SetActive(true);
    }
}
