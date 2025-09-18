# Bicycle Agent

The bicycle serves as the primary NavMesh Agent in this active mobility simulation, representing realistic cycling behavior within urban environments generated from real-world geospatial data.

## Overview

The bicycle agent leverages Unity's NavMesh system to navigate complex terrain, avoid obstacles, and follow both predefined paths and dynamically calculated routes based on CSV data or manual path creation.

## NavMesh Agent Configuration

```{figure} ../Images/bicycleagent.png
---
name: Bicycle Agent
---
Nav Mesh Agent - Bicycle Configuration
```

The **NavMesh Agent** component is configured with specific parameters that define realistic bicycle movement characteristics:

### Agent Properties
- **Base Offset**: `0.25` - Ensures proper positioning relative to the NavMesh surface, accounting for wheel contact
- **Speed**: `3.5` Unity units - Represents maximum cycling speed
- **Angular Speed**: `120` degrees/second - Allows smooth turning without unrealistic sharp changes
- **Acceleration**: `8` - Enables gradual speed changes for realistic movement
- **Stopping Distance**: `0` - Provides precise stopping behavior at destinations
- **Auto Braking**: Enabled - Smooth deceleration when approaching obstacles

### Obstacle Avoidance
- **Radius**: `0.5` - Defines collision boundary for navigation, accounting for bicycle width
- **Height**: `0.9` - Matches the bicycle's vertical clearance requirements
- **Quality**: High Quality - Prioritizes accuracy in obstacle detection and avoidance
- **Priority**: `50` - Balanced importance for navigation conflict resolution

### Pathfinding
- **Auto Traverse Off Mesh Link**: Enabled - Allows navigation over gaps and connections
- **Auto Repath**: Enabled - Dynamic route recalculation when paths become blocked
- **Area Mask**: Everything - Permits traversal across all walkable NavMesh areas

## Functionality and Behavior

### Movement Systems

The bicycle agent implements multiple movement modes:

#### 1. CSV Data Navigation
- Reads bicycle trip data from CSV files containing X, Y, Z coordinates
- Traverses real-world cycling routes imported as position data
- Provides realistic movement patterns based on actual cycling behavior

#### 2. Path-Based Navigation
- Follows predefined paths created using NavMeshPathCreator
- Supports looping behavior for continuous simulation
- Maintains smooth progression between waypoints

#### 3. Manual Control
- Keyboard input (E key) for manual waypoint advancement during testing
- Camera control (R key) for observation and debugging

### Obstacle Detection and Avoidance

The bicycle implements sophisticated obstacle detection:

```csharp
// Sphere casting for obstacle detection
Vector3 p1 = transform.position + _agent.height / 2 * Vector3.up;
float sphereDistance = _agent.stoppingDistance;
var mask = LayerMask.GetMask("Humans");

if(Physics.SphereCast(p1, sphereDistance, transform.forward, out RaycastHit hit, sphereDistance, mask)){
    _agent.isStopped = true; // Stop when humans detected
}
```

**Key Features:**
- **Sphere Casting**: Detects obstacles in the forward direction
- **Human Detection**: Specifically identifies pedestrian obstacles using layer masking
- **Dynamic Stopping**: Automatically stops when obstacles are detected
- **Resumption**: Continues movement when path is clear

### State Management

The bicycle agent responds to different simulation states:

- **Setup State**: Allows configuration and parameter adjustment
- **Simulation State**: Active navigation and movement
- **Camera Integration**: Cinemachine virtual camera for following and observation

### Interactive Features

- **Click Selection**: Mouse interaction for agent selection during setup
- **Camera Following**: Priority-based camera switching for observation
- **Visual Debugging**: Gizmos showing detection spheres and stopping distances

## Technical Implementation

### Key Components
- **NavMeshAgent**: Core navigation component
- **CSVReader**: Data import for real-world route following
- **CinemachineVirtualCamera**: Camera control for observation
- **NavMeshPathCreator**: Custom path definition tool

### Performance Considerations
- Efficient sphere casting for obstacle detection
- Optimized pathfinding with automatic rerouting
- Frame-rate independent movement using FixedUpdate for physics

### Integration with Simulation
The bicycle agent integrates seamlessly with the broader simulation system:
- Responds to GameManager state changes
- Interacts with human agents through obstacle detection
- Supports both scripted and data-driven movement patterns

This configuration enables realistic bicycle simulation within urban environments, supporting research into active mobility patterns and infrastructure optimization.
