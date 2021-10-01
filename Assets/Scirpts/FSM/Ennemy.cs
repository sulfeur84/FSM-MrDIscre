using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Ennemy : MonoBehaviour
{
    public Static CurrentStat;
    private bool PlayerDetected = false;
    private bool SearchFinished = true;

    public List<Transform> Point = new List<Transform>();

    private Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        foreach (GameObject point in GameObject.FindGameObjectsWithTag("Point"))
        {
            Point.Add(point.transform);
        }
    }

    public void Update()
    {
        switch (CurrentStat)
        {
            case Static.Idle: 
                Idle();
                if (PlayerDetected) CurrentStat = Static.Chase;
                break;
            
            case Static.Chase:
                Chase();
                if (!PlayerDetected) CurrentStat = Static.Search;
                break;
            
            case Static.Search:
                Search();
                if (PlayerDetected) CurrentStat = Static.Chase;
                if (SearchFinished) CurrentStat = Static.Idle;
                break;
            
        }

    }
    void Idle()
    {
        agent.speed = 4f;
        if(!agent.hasPath)
        {
            int ind = Random.Range(0, Point.Count);
            agent.SetDestination(Point[ind].position);
            
        }
        
    }
    void Chase()
    {
        agent.speed = 4f;
        agent.SetDestination(target.position);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void Search()
    {
        agent.speed = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected = false;
            SearchFinished = false;
            Invoke("StopSearch",3f);
        }
    }
    void StopSearch()
    {
        SearchFinished = true;
    }
}
