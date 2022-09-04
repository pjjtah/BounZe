using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BounceEffect;
    public AudioSource GoalEffect;
    public AudioSource ResetEffect;
    public AudioSource ShatterEffect;
    public AudioSource Music;
    public float initalPitch = 0.6f;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBounceEffect(int bounce)
    {
        BounceEffect.pitch += 0.05f;
        BounceEffect.Play();
    }

    public void PlayGoalEffect()
    {
        GoalEffect.Play();
    }

    public void PlayResetEffect()
    {
        ResetEffect.Play();
    }
    public void PlayShatterEffect(float pitch)
    {
        ShatterEffect.pitch = pitch;
        ShatterEffect.Play();
    }

    public void ResetPitch()
    {
        BounceEffect.pitch = initalPitch;
    }

    public void StopAllEffects()
    {
        BounceEffect.Stop();
        GoalEffect.Stop();
        ResetEffect.Stop();
        ShatterEffect.Stop();
    }
}
