using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;
    [Header("Movement Settings")]
    [SerializeField] private NavMeshPathCreator path;
    [SerializeField] private bool loop = false;
    [SerializeField] private float randomDestinationRadius = 10f;
    [SerializeField] private Vector2 randomWaitTimeRange = new Vector2(1f, 3f);
    
    private int _currentPathIndex = 0;
    private NavMeshAgent _agent;
    private Animator _animator;
    private Coroutine _movementCoroutine;

    #region Unity Lifecycle Methods
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Simulation)
        {
            StartMovement();
        }
    }
    
    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        StopMovement();
    }

    private void Update()
    {
        UpdateAnimationValues();

        if (Input.GetKeyDown(KeyCode.R))
            vCam.Priority = 0;
    }
    
    #endregion

    #region Movement Control
    
    private void OnGameStateChanged()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Simulation)
        {
            StartMovement();
        }
        else
        {
            StopMovement();
        }
    }

    private void StartMovement()
    {
        StopMovement();
        
        if (path != null)
        {
            _currentPathIndex = 0;
            _agent.SetDestination(path.GetPoint(0));
            _movementCoroutine = StartCoroutine(FollowPathCoroutine());
        }
        else
        {
            _movementCoroutine = StartCoroutine(RandomMovementCoroutine());
        }
    }
    
    private void StopMovement()
    {
        if (_movementCoroutine != null)
        {
            StopCoroutine(_movementCoroutine);
            _movementCoroutine = null;
        }
    }
    
    #endregion

    #region Movement Coroutines
    
    /// <summary>
    /// Sets a random destination for the NavMesh agent within the specified radius.
    /// </summary>
    private IEnumerator RandomMovementCoroutine()
    {
        while (true)
        {
            var randomDirection = Random.insideUnitSphere * randomDestinationRadius;
            randomDirection += transform.position;
            
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, randomDestinationRadius, 1))
            {
                _agent.SetDestination(hit.position);
            }

            yield return new WaitForSeconds(Random.Range(randomWaitTimeRange.x, randomWaitTimeRange.y));
        }
    }

    /// <summary>
    /// Follows the predefined path points in sequence.
    /// </summary>
    private IEnumerator FollowPathCoroutine()
    {
        const float arrivalDistance = 2.5f;
        
        while (true)
        {
            var targetPoint = path.GetPoint(_currentPathIndex);
            
            if (Vector3.Distance(transform.position, targetPoint) < arrivalDistance)
            {
                _currentPathIndex++;

                if (_currentPathIndex >= path.GetPointsCount())
                {
                    if (loop)
                    {
                        _currentPathIndex = 0;
                    }
                    else
                    {
                        yield break;
                    }
                }

                _agent.SetDestination(path.GetPoint(_currentPathIndex));
            }
            yield return null;
        }
    }
    
    #endregion

    /// <summary>
    /// Updates the animator parameters based on the agent's velocity.
    /// </summary>
    private void UpdateAnimationValues()
    {
        if (_animator != null && _agent != null)
        {
            Vector3 localVelocity = transform.InverseTransformDirection(_agent.velocity);
            _animator.SetFloat("MoveX", localVelocity.x);
            _animator.SetFloat("MoveY", localVelocity.z); 
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.SetingUp)
        {
            OptionSetter.Instance.SetCurrentAgent(_agent);
        }
        else if (GameManager.Instance.CurrentGameState == GameManager.GameState.Simulation)
        {
            vCam.Priority = 101;
        }
    }
}