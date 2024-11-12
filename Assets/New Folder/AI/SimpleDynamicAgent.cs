using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleDynamicAgent : MonoBehaviour
{

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    //<summary>
    //Target이 있다면 지정해주는 방법
    //</summary>
    [SerializeField]
    Transform target;

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(target.transform);
        agent.SetDestination(CharacterManager.Instance.Player.transform.position);
    }
}
