using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Zombie_Script : MonoBehaviour
{
    public TextMeshProUGUI Message_zombie;
    Animator Zombie_Anim;
    public Transform Target;
    NavMeshAgent Agent;
    public float distance;
    AudioSource audioSource;
    bool isPlayingSound;

    void Start()
    {
        Zombie_Anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        isPlayingSound = false;
    }

    void Update()
    {
        Zombie_Anim.SetFloat("speed", Agent.velocity.magnitude);
        distance = Vector3.Distance(transform.position, Target.position);

        if (distance <= 15)
        {
            Agent.enabled = true;
            Agent.destination = Target.position;

            if (distance <= 6 && !isPlayingSound)
            {
                audioSource.Play();
                isPlayingSound = true;
            }
            else if (distance > 6 && isPlayingSound)
            {
                audioSource.Stop();
                isPlayingSound = false;
            }

            if (distance <= 3)
            {
                Message_zombie.text = "Zombies are attacking!";
            }
            else
            {
                Message_zombie.text = "";
            }
        }
        else
        {
            Agent.enabled = false;
            Message_zombie.text = "";
            if (isPlayingSound)
            {
                audioSource.Stop();
                isPlayingSound = false;
            }
        }
    }
}