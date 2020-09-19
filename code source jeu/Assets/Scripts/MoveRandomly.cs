using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    bool inCoRoutine, validPath;
    Vector3 target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    void Update()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();

        if (!inCoRoutine)
            StartCoroutine(DoSomething());
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-300, 300);
        //   float y = Random.Range(-20, 20);
        float z = Random.Range(-300, 300);
        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);
        if (!validPath) Debug.Log("found invalid path");
        while (!validPath)
        {
            yield return new WaitForSeconds(0.01f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target, path);
        }

        inCoRoutine = false;
    }

    void GetNewPath()
    {
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }
}