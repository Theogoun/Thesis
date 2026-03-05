using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionSetter : Singleton<OptionSetter>
{
    [Header("Agent Options Ui")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI nameUi;
    [SerializeField] private TMP_InputField speed;
    [SerializeField] private TMP_InputField angularSpeed;
    [SerializeField] private TMP_InputField acceleration;
    [SerializeField] private TMP_InputField stoppingDistance;
    [SerializeField] private Toggle autoBraking;

    private NavMeshAgent _currentAgent;

    private void Start()
    {
        // Connect all input field OnSubmit events
        speed.onEndEdit.AddListener(UpdateAgentSpeed);
        angularSpeed.onEndEdit.AddListener(UpdateAgentAngularSpeed);
        acceleration.onEndEdit.AddListener(UpdateAgentAcceleration);
        stoppingDistance.onEndEdit.AddListener(UpdateAgentStoppingDistance);
        autoBraking.onValueChanged.AddListener(UpdateAgentAutoBraking);
    }

    // Method to set the current NavMeshAgent
    public void SetCurrentAgent(NavMeshAgent agent)
    {
        panel.SetActive(false);

        _currentAgent = agent;

        if (_currentAgent.gameObject.name.Contains("Bike"))
            nameUi.text = "Bicycle Options";
        else
            nameUi.text = "Human Options";

        UpdateUIFromAgent();

        panel.SetActive(true);
    }

    // Update UI values from the current agent
    private void UpdateUIFromAgent()
    {
        if (_currentAgent == null) return;

        speed.text = _currentAgent.speed.ToString();
        angularSpeed.text = _currentAgent.angularSpeed.ToString();
        acceleration.text = _currentAgent.acceleration.ToString();
        stoppingDistance.text = _currentAgent.stoppingDistance.ToString();
        autoBraking.isOn = _currentAgent.autoBraking;
    }

    // OnSubmit handlers for each UI element
    private void UpdateAgentSpeed(string value)
    {
        if (_currentAgent == null || string.IsNullOrEmpty(value)) return;

        if (float.TryParse(value, out float result))
        {
            _currentAgent.speed = result;
            Debug.Log($"Updated {_currentAgent.name} speed to {result}");
        }
    }

    private void UpdateAgentAngularSpeed(string value)
    {
        if (_currentAgent == null || string.IsNullOrEmpty(value)) return;

        if (float.TryParse(value, out float result))
        {
            _currentAgent.angularSpeed = result;
            Debug.Log($"Updated {_currentAgent.name} angular speed to {result}");
        }
    }

    private void UpdateAgentAcceleration(string value)
    {
        if (_currentAgent == null || string.IsNullOrEmpty(value)) return;

        if (float.TryParse(value, out float result))
        {
            _currentAgent.acceleration = result;
            Debug.Log($"Updated {_currentAgent.name} acceleration to {result}");
        }
    }

    private void UpdateAgentStoppingDistance(string value)
    {
        if (_currentAgent == null || string.IsNullOrEmpty(value)) return;

        if (float.TryParse(value, out float result))
        {
            _currentAgent.stoppingDistance = result;
            Debug.Log($"Updated {_currentAgent.name} stopping distance to {result}");
        }
    }

    private void UpdateAgentAutoBraking(bool value)
    {
        if (_currentAgent == null) return;

        _currentAgent.autoBraking = value;
        Debug.Log($"Updated {_currentAgent.name} auto braking to {value}");
    }
}
