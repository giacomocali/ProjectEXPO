using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ControllerNPC : MonoBehaviour
{
    public Transform[] WayPoints;
    public float speed = 3.5f;

    [Header("Tempo di attesa randomico (in secondi)")]
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;

    [Header("Raggio casuale attorno ai waypoint")]
    public float randomRadius = 2f;

    private int targetPoint = 0;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isWaiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = speed;
        agent.stoppingDistance = 0.5f;        // aumenta la soglia per evitare jitter :contentReference[oaicite:1]{index=1}
        agent.autoBraking = false;            // disattiva l’autobraking per evitare continui rallentamenti bruschi :contentReference[oaicite:2]{index=2}

        if (WayPoints.Length > 0)
        {
            SetNextDestination();
        }
    }

    void Update()
    {
        float currentSpeed = agent.velocity.magnitude;
        animator.SetFloat("speed", currentSpeed);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting)
        {
            // forza velocità zero per evitare spostamenti residui
            agent.velocity = Vector3.zero;

            StartCoroutine(WaitAndMove());
        }
    }

    IEnumerator WaitAndMove()
    {
        isWaiting = true;
        agent.isStopped = true;

        float randomWait = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(randomWait);

        IncreaseTargetValue();
        SetNextDestination();
        agent.isStopped = false;

        isWaiting = false;
    }

    void IncreaseTargetValue()
    {
        targetPoint++;
        if (targetPoint >= WayPoints.Length)
            targetPoint = 0;
    }

    void SetNextDestination()
    {
        Vector3 basePos = WayPoints[targetPoint].position;
        Vector2 randOff = Random.insideUnitCircle * randomRadius;
        Vector3 randomPos = new Vector3(basePos.x + randOff.x, basePos.y, basePos.z + randOff.y);

        agent.SetDestination(randomPos);
    }
}
