# Glossary

**Active Mobility**

The transport of people or goods through non-motorized means, based on human physical activity. Examples include walking, cycling, skateboarding, and wheelchair use. Active mobility is a sustainable transportation mode that promotes physical health, reduces environmental impact, and enhances urban livability.

**Agent**

In the context of simulation and game development, an autonomous entity that can perceive its environment and make decisions to achieve specific goals. Agents typically use navigation systems (such as NavMesh) to move through virtual environments while avoiding obstacles and following paths.

**Animation**

The process of creating motion and shape changes in 3D models over time. In character animation, this involves manipulating bones within an armature to create realistic movements such as walking, running, or cycling. Animations can be keyframe-based, procedural, or physics-driven.

**Armature**

A hierarchical skeleton structure used for rigging and animating 3D models. An armature consists of interconnected bones that define how a mesh deforms during animation. By controlling the armature, animators can create complex, realistic movements while maintaining the model's volume and proportions.

**Blend Tree**

A Unity animation feature that smoothly blends between multiple animation clips based on parameter values. Blend trees enable fluid transitions between different movement states (e.g., walking to running) and allow for directional movement by combining multiple animations.

**Bone**

An individual element within an armature that represents a joint or skeletal segment. Bones are connected in parent-child relationships to form a hierarchical structure. When a bone moves or rotates, all of its children move with it, allowing for coordinated motion similar to a real skeleton.

**Built Environment**

The human-made surroundings that provide the setting for human activity, ranging from buildings and parks to neighborhoods and cities. In this thesis, the built environment refers to the 3D digital representation of urban spaces used for simulating active transport scenarios.

**Cesium**

A platform for creating 3D geospatial applications. Cesium for Unity enables the integration of real-world terrain, imagery, and 3D tiles into Unity projects, allowing for accurate geographic visualization and simulation of real-world locations.

**Mesh**

The foundational geometric structure of a 3D object, consisting of vertices (points in 3D space), edges (lines connecting vertices), and faces (flat polygons enclosed by edges). The mesh defines the object's shape and surface, and can be manipulated through modeling, sculpting, or procedural generation.

**NavMesh (Navigation Mesh)**

A data structure that represents the walkable surfaces in a 3D environment. The NavMesh is used by navigation agents to calculate efficient paths while avoiding obstacles. It defines where characters can move and is essential for realistic autonomous movement in simulations and games.

**NavMesh Agent**

A Unity component that enables autonomous navigation using the NavMesh. NavMesh Agents can pathfind to destinations, avoid obstacles, and navigate complex environments. They have configurable parameters such as speed, acceleration, radius, and height that define their movement characteristics.

**Rigging**

The process of creating a skeletal structure (armature) for a 3D model and binding the model's mesh to that structure. Rigging involves defining bones, setting up hierarchies, creating constraints, and painting weight maps that determine how the mesh deforms when bones move.

**Simulation**

A computer-based representation of a real-world system or process. In this thesis, simulation refers to the virtual modeling of active transport scenarios in urban environments, including the behavior and interactions of cyclists and pedestrians within the built environment.

**Unity**

A cross-platform game engine and development environment used for creating 3D and 2D interactive content. Unity provides tools for rendering, physics simulation, animation, scripting, and more. In this thesis, Unity serves as the simulation engine for modeling active transport scenarios.

**Vertex (plural: Vertices)**

A point in 3D space defined by X, Y, and Z coordinates. Vertices are the fundamental building blocks of 3D meshes. Connected vertices form edges, and enclosed edges form faces. The position and manipulation of vertices determine the shape of 3D objects.
