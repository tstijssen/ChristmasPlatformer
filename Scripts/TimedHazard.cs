using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedHazard : MonoBehaviour {

    public float TimerWait;
    public float HazardDuration;
    public ParticleSystem[] ActivateAnimations;
    public GameObject HazardCollider;
    float timer;
    bool active;
	// Use this for initialization
	void Start () {
        timer = 0;
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        // activate hazard and reset timer
        if(timer <= 0)
        {
            if (active)
            {
                for (int i = 0; i < ActivateAnimations.Length; ++i)
                {
                    ActivateAnimations[i].Stop();
                    HazardCollider.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < ActivateAnimations.Length; ++i)
                {
                    ActivateAnimations[i].Play();
                    HazardCollider.SetActive(true);
                }
            }
            timer = TimerWait;
            active = !active;
        }
	}
}
