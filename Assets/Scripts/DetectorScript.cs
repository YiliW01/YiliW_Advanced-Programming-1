using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    [SerializeField]
    private EnemyScript _enemy;

    public Collider _playerCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerCollider = other;
            _enemy._currentState = EnemyScript.EnemyState.Chase;
            _enemy.ChangeState(_enemy._currentState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enemy._currentState = EnemyScript.EnemyState.Idle;
            _enemy.ChangeState(_enemy._currentState);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
