using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Static CurrentStat;
    private bool PlayerDetected = false;
    private bool SearchFinished = true;

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

        void Idle()
        {

        }
        void Chase()
        {

        }
        void Search()
        {

        }
        
    }
}
