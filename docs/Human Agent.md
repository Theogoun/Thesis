# Human Agent

Human agents represent pedestrians within the active mobility simulation, providing realistic pedestrian behavior and enabling the study of mixed mobility scenarios involving both cyclists and pedestrians.

## Overview

Human agents use Unity's NavMesh system to simulate realistic pedestrian movement patterns, including both structured path following and random wandering behavior. These agents interact dynamically with the environment and other mobility agents, particularly bicycles.

## NavMesh Agent Configuration

```{figure} ../Images/humanagent.png
---
name: Human Agent
---
Nav Mesh Agent - Human Configuration
```

The human **NavMesh Agent** component is configured to replicate realistic pedestrian movement characteristics:

### Agent Properties
- **Base Offset**: `0` - Direct alignment with NavMesh surface for natural walking
- **Speed**: `3.5` Unity units - Represents typical human walking speed
- **Angular Speed**: `120` degrees/second - Enables smooth and natural turning
- **Acceleration**: `8` - Gradual speed changes for realistic movement
- **Stopping Distance**: `0` - Accurate stopping behavior at destinations
- **Auto Braking**: Enabled - Smooth deceleration when obstacles are detected

### Obstacle Avoidance
- **Radius**: `0.25` - Smaller collision boundary suitable for human body width
- **Height**: `1.83` - Corresponds to average human height
- **Quality**: High Quality - Accurate obstacle avoidance calculations
- **Priority**: `50` - Equal importance with bicycle agents for conflict resolution

### Pathfinding
- **Auto Traverse Off Mesh Link**: Enabled - Navigation across separate NavMesh areas
- **Auto Repath**: Enabled - Dynamic path adjustment when routes become blocked
- **Area Mask**: Everything - Full access to all walkable areas

## Functionality and Behavior

### Movement Systems

The human agent implements multiple movement patterns:

#### 1. Random Movement
```csharp
var randomDirection = Random.insideUnitSphere * randomDestinationRadius;
randomDirection += transform.position;

if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, randomDestinationRadius, 1))
{
    _agent.SetDestination(hit.position);
}
```

**Features:**
- **Configurable Radius**: Adjustable area for random destination selection (`randomDestinationRadius`)
- **Wait Time Variation**: Random wait periods between movements (`randomWaitTimeRange`)
- **NavMesh Validation**: Ensures destinations are on walkable surfaces
- **Natural Behavior**: Simulates realistic pedestrian wandering patterns

#### 2. Path-Based Movement
- Follows predefined paths using NavMeshPathCreator
- Sequential waypoint navigation with smooth transitions
- Optional looping for continuous pedestrian flow
- Arrival detection with configurable distance threshold (2.5 units)

### Animation Integration

The human agent includes sophisticated animation control through a custom **Animator Controller** system designed to enhance the realism of agent movement in the simulation.

#### Animation System and State Management

The animation system is built around two key components:

- **Entry and Initial Movement**: The animation system begins at the Entry point and proceeds into the **Movement** state. This ensures that the animation logic is initiated when the simulation starts.

```{figure} ../Images/animation.png
---
name: Animation Controller
---
Animation Controller Entry and Movement State
```

- **Blend Tree for Dynamic Movements**: A **Blend Tree** allows for fluid transitions between different walking animations and an idle state. Controlled by the `MoveX` and `MoveY` parameters, the Blend Tree dynamically adjusts the character's animations to match the direction and speed of movement.

```{figure} ../Images/blendtree.png
---
name: Blend Tree
---
Blend Tree for Dynamic Movement Animations
```

#### Animation Value Updates

The animation values of the blend tree are set through a script in the human controller:

```csharp
private void UpdateAnimationValues()
{
    Vector3 localVelocity = transform.InverseTransformDirection(_agent.velocity);
    _animator.SetFloat("MoveX", localVelocity.x);
    _animator.SetFloat("MoveY", localVelocity.z); 
}
```

**Animation Features:**
- **Velocity-Based Animation**: Movement animations driven by actual agent velocity
- **Directional Movement**: Separate X and Y movement parameters for blend trees
- **Smooth Transitions**: Continuous animation updates for natural movement
- **Local Space Calculations**: Relative velocity for accurate directional animations
- **State-Driven Logic**: Animation states that respond to simulation flow
- **Blend Tree Control**: Dynamic animation blending based on movement direction and speed

### State Management

Human agents respond to simulation state changes:

#### Game State Integration
```csharp
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
```

**State Behaviors:**
- **Setup State**: Configuration and parameter adjustment mode
- **Simulation State**: Active movement and navigation
- **Automatic Control**: Starts/stops movement based on simulation state

### Interactive Features

- **Click Selection**: Mouse interaction for agent selection during setup phase
- **Camera Control**: Integration with Cinemachine virtual cameras
- **Visual Debugging**: Real-time movement visualization and parameter adjustment

## Technical Implementation

### Core Components
- **NavMeshAgent**: Primary navigation component
- **Animator**: Character animation control
- **CinemachineVirtualCamera**: Camera system integration
- **NavMeshPathCreator**: Path definition tool

### Movement Coroutines

The human agent uses efficient coroutine-based movement:

#### Random Movement Coroutine
- Non-blocking random destination selection
- Configurable wait times between movements
- Automatic NavMesh validation

#### Path Following Coroutine
- Sequential waypoint navigation
- Distance-based arrival detection
- Loop support for continuous flow

### Performance Optimizations

- **Coroutine-Based Logic**: Efficient non-blocking movement calculations
- **Event-Driven Updates**: Animation updates only when needed
- **Modular Design**: Clean separation of movement, animation, and interaction systems

## Integration with Mixed Mobility Simulation

### Bicycle Interaction
Human agents serve as dynamic obstacles for bicycle navigation:
- Detected by bicycle sphere casting on "Humans" layer
- Create realistic pedestrian-cyclist interaction scenarios
- Enable study of mixed traffic dynamics

