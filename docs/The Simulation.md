# The Simulation

The active mobility simulation provides an interactive environment for studying and analyzing the movement patterns of pedestrians and cyclists in urban settings. The simulation combines realistic 3D environments with configurable agent behaviors to create scenarios that mirror real-world active mobility situations.

## Simulation Overview

The simulation is built as an interactive Unity application that allows users to place, configure, and observe different types of mobility agents within a realistic urban environment. The system leverages Unity's NavMesh navigation system to provide intelligent pathfinding and movement behaviors for all agents in the scene.

## Agent Placement and Selection

```{figure} ../Images/simulation.png
---
name: Simulation Interface
---
The main simulation interface showing agent placement options
```

### Initial Setup Phase

When the simulation loads, users are presented with a clean urban environment featuring a university campus setting. The interface provides two primary agent placement options:

- **Human Agent Placement**: Allows users to place pedestrian agents throughout the scene
- **Bicycle Agent Placement**: Enables placement of cyclist agents at desired locations

To place an agent in the scene:

1. Select either the human or bicycle button from the placement interface
2. Click on any accessible location within the 3D environment
3. The selected agent type will be instantiated at the clicked position
4. Multiple agents of each type can be placed as needed

### Agent Configuration

Once an agent is placed in the scene, clicking on it reveals a configuration panel specific to that agent type. Each agent can be individually customized with the following parameters:

#### Human Agent Options

```{figure} ../Images/humanoptions.png
---
name: Human Options Panel
---
Configuration panel for human agent parameters
```

- **Speed**: Controls the walking pace of the pedestrian (units per second)
- **Angular Speed**: Determines how quickly the agent can change direction (degrees per second)
- **Acceleration**: Sets how rapidly the agent reaches target speed
- **Stop Distance**: Defines how close the agent gets to its destination before stopping
- **Auto Brake**: Toggle for automatic deceleration when approaching destinations

#### Bicycle Agent Options

```{figure} ../Images/bicycle_options.png
---
name: Bicycle Options Panel
---
Configuration panel for bicycle agent parameters
```

- **Speed**: Sets the cycling speed of the bicycle agent (units per second)
- **Angular Speed**: Controls turning speed and maneuverability (degrees per second)
- **Acceleration**: Determines how quickly the bicycle reaches target speed
- **Stop Distance**: Sets the stopping distance from target destinations
- **Auto Brake**: Automatic braking behavior when approaching stops

These configuration options allow for realistic differentiation between agent types, with bicycles typically configured for higher speeds and different turning characteristics compared to pedestrians.

## Simulation Execution

### Starting the Simulation

Once all desired agents have been placed and configured, the simulation can be initiated by clicking the "Start Simulation" button. This action triggers several important changes:

1. **UI Transition**: The placement and configuration interface disappears, providing an unobstructed view of the simulation environment
2. **Agent Activation**: All placed agents begin their navigation behaviors according to their configured parameters
3. **Pathfinding Initialization**: Agents start calculating and following optimal paths through the environment
4. **Interactive Mode**: The simulation enters its active phase where real-time observation and interaction are possible

### Runtime Behavior

During simulation execution, agents demonstrate intelligent navigation behaviors:

- **Pathfinding**: Agents automatically calculate routes to their destinations using the underlying NavMesh
- **Obstacle Avoidance**: Dynamic collision avoidance between different agent types
- **Realistic Movement**: Speed and acceleration parameters create natural-looking movement patterns
- **Environmental Interaction**: Agents navigate around static obstacles and terrain features

## Interactive Camera System

### Free Camera Movement

While the simulation runs, users can freely navigate through the 3D environment to observe agent behaviors from different perspectives. The camera system provides:

- **Position Control**: Move through the scene to focus on specific areas of interest
- **Rotation Control**: Adjust viewing angles to observe interactions and movement patterns
- **Zoom Capabilities**: Get close-up views of individual agents or wide shots of group behaviors

### Agent-Specific Views

A key feature of the simulation is the ability to switch to first-person perspectives of individual agents:

```{figure} ../Images/human_view.png
---
name: Human Agent First-Person View
---
First-person perspective from a human agent showing the campus environment
```

```{figure} ../Images/bicycle_view.png
---
name: Bicycle Agent First-Person View
---
First-person perspective from a bicycle agent navigating through the simulation
```

1. **Agent Selection**: Click on any human or bicycle agent during simulation runtime
2. **View Transition**: The camera automatically switches to that agent's perspective
3. **Agent Experience**: Experience the simulation from the viewpoint of the selected agent
4. **Immersive Observation**: Understand movement patterns and environmental interactions from the agent's perspective

This feature provides valuable insights into:
- How different agent types perceive and navigate the environment
- The effectiveness of pathfinding algorithms from an agent's viewpoint
- Spatial relationships and proximity interactions between agents
- Environmental factors that influence navigation decisions