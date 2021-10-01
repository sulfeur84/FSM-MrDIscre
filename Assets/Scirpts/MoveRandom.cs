using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MoveRandom : MonoBehaviour
{
    private NavMeshAgent NVM;
    private NavMeshPath Path;
    public float TimerForNewPath;
    private bool InCoRoutine;
    private Vector3 Target;
    private bool ValidPath;
    private void Start()
    {
        NVM = GetComponent<NavMeshAgent>();
        Path = new NavMeshPath();
    }

    private void Update()
    {
        if (!InCoRoutine)
        {
            StartCoroutine(DoSomething());
        }
    }

    Vector3 getNewRandomsPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator DoSomething()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(TimerForNewPath);
        GetNewPath();
        ValidPath = NVM.CalculatePath(Target, Path);
        if (!ValidPath) Debug.Log("Invalid Path");

        while (!ValidPath)
        {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            ValidPath = NVM.CalculatePath(Target, Path);
        }
        InCoRoutine = false;
    }

    void GetNewPath()
    {
        Target = getNewRandomsPosition();
        NVM.SetDestination(Target);
    }
}
