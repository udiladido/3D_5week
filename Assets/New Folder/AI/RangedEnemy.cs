using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


public enum AIState
{
    Idle,
    Wandering,
    Attacking,
    Fleeing
}


public class RangedEnemy : MonoBehaviour
{

    [Header("Stats")]
    public int health;
    public float walkSpeed;
    public float runSpeed;

    public float fieldOfView = 120f;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;


    [Header("AI")]
    private AIState aiState;
    public float detectDistance;
    public float safeDistance;

    [Header("Combat")]
    public int damage;
    public float attackRate;
    public float attackDistance;
    private float playerDistance;

    private NavMeshAgent agent;



    public GameObject testPrefab;
    [SerializeField] private Transform projectileSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        SetState(AIState.Wandering);
    }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {


        playerDistance = Vector3.Distance(transform.position, CharacterManager.Instance.Player.transform.position);

        switch (aiState)
        {
            case AIState.Idle:
                PassiveUpdate();
                break;
            case AIState.Wandering:
                PassiveUpdate();
                break;
            case AIState.Attacking:
                AttackingUpdate();
                break;
            case AIState.Fleeing:
                FleeingUpdate();
                break;
        }
    }



    void FleeingUpdate()
    {
        //플레이어와의 거리 범위 : 공격범위 보다 가까워지면 도망가야
        if (playerDistance < attackDistance)
        {
            agent.SetDestination(GetFleeLocation());
        }
        else
        {

            //충분히 멀어졌다면 공격
            SetState(AIState.Attacking);
        }

    }

    Vector3 GetFleeLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * safeDistance), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;
        while (GetDestinationAngle(hit.position) > 90 || playerDistance < safeDistance)
        {

            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * safeDistance), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30)
                break;
        }

        return hit.position;
    }



    float GetDestinationAngle(Vector3 targetPos)
    {
        return Vector3.Angle(transform.position - CharacterManager.Instance.Player.transform.position, transform.position + targetPos);
    }


    private void SetState(AIState state)
    {
        aiState = state;

        switch (aiState)
        {
            case AIState.Idle:
                agent.speed = walkSpeed;
                agent.isStopped = true;
                break;
            case AIState.Wandering:
                agent.speed = walkSpeed;
                agent.isStopped = false;
                break;
            case AIState.Attacking:
                agent.speed = runSpeed;
                agent.isStopped = true;
                break;
            case AIState.Fleeing:
                agent.speed = runSpeed;
                agent.isStopped = false;
                break;
        }

       
    }


    void AttackingUpdate()
    {
     
        if (playerDistance < attackDistance  && IsPlayerInFieldOfView())
        {
            agent.isStopped = true;
            // 공격 로직 추가 - 오브젝트 풀에서 불러오는 걸로 나중에 수정
            Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);

        }

        else 
        {
            // 도망
            SetState(AIState.Fleeing);


        }
    }

    bool IsPlayerInFieldOfView()
    {
        Vector3 directionToPlayer = CharacterManager.Instance.Player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return angle < fieldOfView * 0.5f;
    }


    void PassiveUpdate()
    {
        if (aiState == AIState.Wandering && agent.remainingDistance < 0.1f)
        {
            SetState(AIState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
        }

        if (playerDistance < detectDistance)
        {
            SetState(AIState.Attacking);
        }
    }




}
