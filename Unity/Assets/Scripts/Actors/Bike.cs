using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Bike : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private NavMeshPathCreator path;
    [SerializeField] private GameObject nextPos;
    [SerializeField] private bool loop;
    private List<Vector3> _positions = new();
    private bool _usePath = false;
    private bool _canMove = true;
    private int _pointsIndex = 0;
    private int _index = 0;
    private NavMeshAgent _agent;
    private CSVReader _csvReader;

    private void Start()
    {
        _csvReader = GetComponent<CSVReader>();
        if (_csvReader != null)
        {
            foreach (var data in _csvReader.bikeTripDataList)
            {
                _positions.Add(new Vector3(data.X, data.Y, data.Z));
            }
        }
        else{
            _canMove = false;
            Debug.LogError("Couldn't retrieve csv");
        }

        _agent = GetComponent<NavMeshAgent>();

        if (!path) 
            return;
        
        _agent.SetDestination(path.GetPoint(0));
        StartCoroutine(nameof(FollowPath));
        _usePath = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _index++;
            //nextPos.transform.position = _positions[_index];
        }

        if (Input.GetKeyDown(KeyCode.R))
            vCam.Priority = 0;
        
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.CurrentGameState != GameManager.GameState.Simulation)
            return;

        if (!_usePath && _canMove)
            TraversePoints();
    }

    /// <summary>
    /// Make the bike traverse all the points in the positions list
    /// </summary>
    private void TraversePoints()
    {
        if (_index >= _positions.Count) {
            _usePath = false;
            return; // Stop if we have reached the end of the list
        }

        // Perform a sphere cast to detect obstacles in front of the bike
        Vector3 p1 = transform.position + _agent.height / 2 * Vector3.up; // Adjust the sphere cast start position
        float sphereDistance = _agent.stoppingDistance; // Use the agent's stopping distance for the sphere cast
        var mask = LayerMask.GetMask("Humans");

        if(Physics.SphereCast(p1, sphereDistance , transform.forward, out RaycastHit hit, sphereDistance, mask)){
            Debug.Log($"Obstacle detected: {hit.collider.name}");
            _agent.isStopped = true; // Stop the agent if an obstacle is detected
            return;
        }
        else
            _agent.isStopped = false; // Resume movement if no obstacle is detected
        

        _agent.SetDestination(_positions[_index]);

        // Adding a smaller threshold to account for minor discrepancies
        float threshold = 0.1f;

        if (_agent.remainingDistance <= _agent.stoppingDistance + threshold && !_agent.pathPending)
        {
            // Increment the index only if we haven't reached the last element
            if (_index < _positions.Count - 1){
                _index++;
                nextPos.transform.position = _positions[_index];
            }

            if(loop && _index == _positions.Count - 1) 
                _index = 0;
        }
    }

    private void OnDrawGizmos()
    {
        if(!Application.isPlaying)
            return;

        Gizmos.color = Color.red;

        Vector3 p1 = transform.position + _agent.height / 2 * Vector3.up; // Adjust the sphere cast start position
        // Draw the stopping distance sphere at the current position
        Gizmos.DrawSphere(p1 + transform.forward * _agent.stoppingDistance , _agent.stoppingDistance);
    }

    private IEnumerator FollowPath()
    {
        while (true)
        {
            var point = path.GetPoint(_pointsIndex);
            
            if (Vector3.Distance(transform.position, point) < 2.5)
            {
                _pointsIndex++;

                if (_pointsIndex >= path.GetPointsCount()){
                    if (loop)
                        _pointsIndex = 0;
                    else
                        yield break;
                }

                point = path.GetPoint(_pointsIndex);
                _agent.SetDestination(point);
            }
            yield return null;
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