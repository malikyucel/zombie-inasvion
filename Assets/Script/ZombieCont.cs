using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieCont : MonoBehaviour
{
    private Transform player_trans;
    NavMeshAgent agent;
    private CharCont player;
    private int health = 3;
    public GameObject[] heart;
    private int heartNext;
    BoxCollider boxcollider;

    Animator animator;

    int deathZompePoint;
    DeathToll deathToll;


    private void Start()
    {
        player = GameObject.Find("CowboyRio_Unity 1").GetComponent<CharCont>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.Play("Idle");
        boxcollider = GetComponent<BoxCollider>();
        deathToll = GameObject.Find("DeathToll").GetComponent<DeathToll>();
    }
    private void Update()
    {
        if (health > 0)
        {
            player_trans = player.transform;
            agent.destination = player_trans.position;
        }
    }
    IEnumerator Destroy_()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    IEnumerator Idle_()
    {
        yield return new WaitForSeconds(1);
        animator.Play("Idle");
        boxcollider.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && health == 0)
        {
            agent.enabled = false;
            boxcollider.enabled = false;
            animator.Play("dead");
            deathToll.Death_Toll++;
            StartCoroutine(Destroy_());
        }
        else if (other.gameObject.CompareTag("Bullet") && health > 0)
        {
            health --;
            Destroy(heart[heartNext]);
            heartNext++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player") && health > 0)
        {
            boxcollider.enabled = false;
            animator.Play("attack");
            StartCoroutine(Idle_());
        }
    }
}
