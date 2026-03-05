using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSim : MonoBehaviour
{
    [SerializeField] GameObject placeActor;

    public void StartSimulation()
    {
        GameManager.Instance.CurrentGameState = GameManager.GameState.Simulation;

        transform.parent.gameObject.SetActive(false);
        placeActor.SetActive(false);
    }
}
