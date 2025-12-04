# Agent Navigation

A NavMesh Agent is a Unity component that enables game objects to navigate intelligently across a NavMesh (Navigation Mesh). The NavMesh Agent acts as the "brain" for movement, allowing objects to pathfind, avoid obstacles, and move through complex environments automatically.

## What is a NavMesh Agent?

In Unity's navigation system, a NavMesh Agent represents any entity that needs to move through the environment autonomously. The agent uses the underlying NavMesh to calculate optimal paths from its current position to a target destination, taking into account obstacles, terrain variations, and other environmental factors.

The NavMesh Agent component abstracts the complexity of pathfinding and movement, providing a high-level interface for controlling navigation behavior. Instead of manually programming movement logic, developers can simply set a destination, and the agent will automatically navigate to that location using the most efficient route available.

## Core Properties and Configuration

The NavMesh Agent component includes several key categories of properties that define how the agent behaves:

### Agent Configuration
- **Agent Type**: Defines the size and movement characteristics template for the agent
- **Base Offset**: Vertical offset from the NavMesh surface to the agent's pivot point
- **Speed**: Maximum movement speed in Unity units per second
- **Angular Speed**: How fast the agent can rotate (degrees per second)
- **Acceleration**: Rate at which the agent reaches its target speed
- **Stopping Distance**: Distance from the target at which the agent will stop

### Steering Behavior
- **Auto Braking**: Whether the agent slows down when approaching the destination
- **Radius**: The agent's collision radius for navigation purposes
- **Height**: The agent's height for clearance calculations
- **Quality**: Level of detail for obstacle avoidance calculations (None, Low, Medium, High)
- **Priority**: Relative importance when multiple agents need to resolve navigation conflicts (0-99)

### Pathfinding Settings
- **Auto Traverse Off Mesh Link**: Automatically moves across NavMesh connections and jumps
- **Auto Repath**: Recalculates path when the current route becomes invalid
- **Area Mask**: Defines which NavMesh areas the agent can traverse

## Applications in Active Mobility Simulation

In the context of this thesis's active mobility simulation, NavMesh Agents serve as the foundation for realistic movement behavior of both cyclists and pedestrians. By configuring agents with appropriate parameters that reflect real-world movement characteristics, the simulation can accurately model:

- **Pathfinding**: Agents find optimal routes through urban environments
- **Obstacle Avoidance**: Dynamic collision avoidance between different types of mobility agents
- **Mixed Traffic Scenarios**: Interaction between bicycles, pedestrians, and other mobility modes
- **Environmental Navigation**: Realistic movement across varied terrain and infrastructure

The flexibility of the NavMesh Agent system allows for fine-tuning movement parameters to match different mobility types, from the faster, wider turning radius of bicycles to the more agile movement patterns of pedestrians.
