## NavMesh

A **NavMesh** (short for *Navigation Mesh*) is a data structure used in Unity and other game engines to facilitate pathfinding for characters or agents in a virtual environment. NavMeshes define the walkable areas of a scene, allowing non-player characters (NPCs), enemies, and other agents to navigate the environment realistically and avoid obstacles .

### How NavMesh Works In Unity? 

Τhe NavMesh is generated by marking the navigable areas on a terrain or game level. The NavMesh system uses this data to determine the shortest or most efficient path for an agent to move from one point to another. Unity's NavMesh system involves three key components:

1. **NavMesh Agent**: Represents the entity that will navigate the NavMesh, such as an NPC. Agents are assigned properties like speed and acceleration, which influence their movement behavior. The NavMesh Agent component is responsible for finding paths and moving the agent along them .

2. **NavMesh Surface**: Defines that the NavMesh covers. By baking the NavMesh Surface, Unity generates the navigation mesh based on obstacles, walkable surfaces, and other parameters defined within the NavMesh settings .

3. **NavMesh Obstacles**: Allow dynamic oo be added to the NavMesh. Obstacles are particularly useful for scenarios with moving objects that agents need to navigate around. Unity provides options to set obstacles as either static (stationary) or dynamic (movable), affecting the way agents interact with these objects .

