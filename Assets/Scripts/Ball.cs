using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    Vector3 position;
    public Vector3 force;
    SpriteRenderer ms;
    ParticleSystem ps;
    float goalTime = 0f;
    bool exploded = false;
    Rigidbody2D rb;
    public bool started;
    private Vector3 direction;
    private GameObject BreakableWalls;
    private AudioManager audioManager;
    private int bounces;
    public GameObject startCollider;

    private int fails;
    LevelUI levelUI;

    public ParticleSystem sparkles;
    public GlitchEffect glitchEffect;

	// Use this for initialization
	void Start () {
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        ms = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        started = false;
        audioManager = FindObjectOfType<AudioManager>();
        if(audioManager != null)
        {
            audioManager.ResetPitch();
        }
        BreakableWalls = GameObject.Find("BreakableWalls");

        levelUI = GameObject.Find("Canvas").GetComponent<LevelUI>();

        glitchEffect = Camera.main.GetComponent<GlitchEffect>();
        glitchEffect.enabled = false;

        if (PlayerPrefs.GetInt("ConsentGiven") == 1)
        {
            GameAnalytics.Initialize();
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Level" + SceneManager.GetActiveScene().buildIndex, fails);
        }
        fails = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(goalTime != 0 && !exploded)
        {
            if(Time.time > goalTime + 0.1f)
            {
                exploded = true;
                ms.enabled = false;
                ps.Play();

                ps.transform.parent = null;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Goal"))
        {
            if(goalTime == 0)
            {
                if(audioManager != null)
                {
                    audioManager.PlayGoalEffect();
                }

                levelUI.Show();
                goalTime = Time.time;
                if (PlayerPrefs.GetInt("ConsentGiven") == 1)
                {
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level" + SceneManager.GetActiveScene().buildIndex, fails);
                }
            }
        }
        else if (collision.CompareTag("Reset"))
        {
            if (audioManager != null)
            {
                audioManager.PlayResetEffect();
                audioManager.ResetPitch();
            }

            startCollider.SetActive(true);
            transform.position = position;
            rb.velocity = Vector3.zero;
            started = false;
            levelUI.PlayButtonPressed();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            if (BreakableWalls != null)
            {
                foreach(Transform child in BreakableWalls.transform)
                {
                    child.gameObject.SetActive(true);
                    child.gameObject.GetComponent<BreakingWall>().Reset();
                }
            }
            glitchEffect.enabled = true;
            glitchEffect.activateGlitch();
            Invoke("resetGlitch", 0.3f);

            fails += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounces += 1;
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (audioManager != null)
            {
                audioManager.PlayBounceEffect(bounces);
            }

            Instantiate(sparkles, collision.contacts[0].point, transform.rotation);
        }
    }

    private void OnMouseDown()
    {
        StartMoving();
    }

    public void StartMoving()
    {
        if (!started)
        {
            startCollider.SetActive(false);
            levelUI.PlayButtonPressed();
            started = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    void resetGlitch()
    {
        glitchEffect.intensity = 0;
        glitchEffect.flipIntensity = 0;
        glitchEffect.enabled = false;
    }
}
