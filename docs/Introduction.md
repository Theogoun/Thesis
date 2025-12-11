# Introduction

## Topic, Context, and Research Gaps

Active mobility, encompassing modes such as cycling and walking, plays a vital role in creating sustainable, healthy urban environments amid growing urbanization and climate concerns. Encouraging these modes can reduce emissions, improve air quality, and support physical and mental health, making them central to contemporary urban and transport policy. However, planners and researchers face significant challenges in evaluating how the built environment influences active traveller safety, efficiency, and comfort, as real-world experiments are constrained by ethics, safety risks, cost, and limited control over external conditions.

Existing approaches frequently rely on static models or simplified 2D representations that struggle to capture the complex, three-dimensional interactions between users, vehicles, and infrastructure. Important factors such as detailed geometry, elevation, visibility, and micro-scale layout are often either coarsely approximated or omitted. While geospatial tools and game engines have improved the ability to build virtual environments, few frameworks combine high-fidelity urban 3D reconstructions with parametric modeling of active mobility assets—such as customizable bicycles and riders—embedded in a dynamic simulation engine.

## Unity: Simulation Engine

**Unity** is adopted as the central simulation platform for this thesis, serving as the convergence point where geospatial data, parametric 3D models, and navigation systems integrate into a cohesive active mobility simulation. Originally designed for game development, Unity has evolved into a powerful, cross-platform engine for real-time 3D simulations and interactive applications across scientific research, urban planning, and mobility studies. Its robust physics engine, comprehensive C# scripting capabilities, and extensive asset pipeline make it uniquely suited for this work.

Unity's **real-time rendering** enables dynamic visualization of complex urban environments, while its **physics system** supports realistic bicycle movement and rider behavior. Crucially, Unity's **geospatial integration** through the Cesium for Unity plugin allows accurate representations of real-world built environments, such as the Geopolis Campus in Larisa, Greece, used as the primary test site. The engine's **NavMesh navigation system** provides intelligent pathfinding for agents, while **Cinemachine camera systems** enable immersive observation from both free-flight and agent-specific perspectives.

## Aims and Objectives

This thesis develops a Unity-based framework for active transport simulation, demonstrating an end-to-end pipeline from geospatial data to interactive 3D scenarios with parametric bicycles and pedestrian agents.

Specific objectives:
- Cesium conversion of Google Maps to Unity 3D meshes
- YAML-driven parametric bike/rider modeling in Blender
- NavMesh Agent implementation for mixed mobility
- Interactive simulation controls and analysis

## Pipeline

```{figure} ../Images/plan.png
---
name: pipeline-plan
alt: Pipeline Plan Diagram
---
Pipeline Plan
```

1. **Google 3D Maps**  
   - Retrieve map data from Google 3D Maps for the target location.

2. **Cesium**  
   - Use Cesium to convert the map data into a 3D mesh compatible with Unity.

3. **YAML File**  
   - Define bicycle properties (e.g., dimensions, material) in the YAML file to ensure accurate modeling in Blender.

4. **Blender**  
   - Import a bicycle 3D model and configure its properties based on the specifications provided in the YAML file.

5. **Unity**  
   - Integrate the 3D map from Cesium and the bicycle model from Blender into Unity.  
   - Use Unity to simulate the environment and interactions.

6. **Simulation**  
   - Run the simulation in Unity to test and analyze movement mobility.



