using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private NavMeshAgent _agent;

    private Transform _target;

    [HideInInspector]
    public bool isActive;

    public void Init(Transform target)
    {
        Debug.Log("nav mesh init");
            
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = _speed;
        
        _target = target;

        isActive = true;

        Debug.Log("nav mesh speed " + _speed);

    }

    private void Update()
    {
        if(isActive && _agent != null)
            _agent.SetDestination(_target.position);
    }

    private void OnDisable()
    {
        isActive = false;
    }
}
