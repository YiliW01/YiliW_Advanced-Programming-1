using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private DetectorScript _detector;
    [SerializeField]
    private NavMeshAgent navAgent;
    [SerializeField]
    private Vector3 _playerpos;


    [SerializeField]
    public EnemyState _currentState;
    [SerializeField]
    private EnemyState _defaultState;


    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    private void Start()
    {
        _detector = GetComponentInChildren<DetectorScript>();
        _currentState = _defaultState;
        navAgent = GetComponentInChildren<NavMeshAgent>();

        _playerpos = _detector._playerCollider.transform.position;
    }

    public void ChangeState(EnemyState newState)
    {
        switch (newState)
        {
            case EnemyState.Idle:
                StartCoroutine(IdleState());
                break;
            case EnemyState.Chase:
                StartCoroutine(ChaseState());
                break;
            case EnemyState.Attack:
                StartCoroutine(AttackState());
                break;
        }
    }

    IEnumerator IdleState()
    {
        Debug.Log("Idling");
        yield return null;
    }

    IEnumerator ChaseState()
    {
        Debug.Log("Chasing");
        navAgent.speed = 3f;
        navAgent.SetDestination(_playerpos);

        yield return null;
    }

    IEnumerator AttackState()
    {
        yield return null;
    }
}
