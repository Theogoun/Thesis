# Introduction

## Topic and Context

Active mobility, encompassing modes like cycling and walking, plays a vital role in creating sustainable, healthy urban environments amid growing urbanization and climate concerns. Urban planners and researchers face challenges in evaluating how built environments influence active traveler safety, efficiency, and comfort due to the limitations of real-world data collection and ethical constraints on experiments.

## Research Gaps

Current research highlights gaps in understanding these dynamics, as traditional methods often rely on static models or simplified 2D representations that fail to capture realistic 3D interactions between users, vehicles, and infrastructure. While geospatial tools and game engines have advanced virtual simulations, few integrate parametric modeling of active mobility assets—like customizable bicycles—with high-fidelity urban 3D reconstructions for scenario testing.

## Aims and Objectives

This thesis addresses these gaps by developing a simulation framework for active movement in built environments. The central aim is to enable researchers and urban planners to explore diverse scenarios, revealing insights into mobility dynamics and informing infrastructure optimizations for safer cities.

## Research Focus

The research focuses on a specific pipeline using Cesium SDK for geospatial integration, Blender for parametric bike and rider modeling, and Unity for simulation, targeting real-world locations via Google Maps data. Key objectives include creating modifiable 3D assets driven by YAML configurations and demonstrating their application in Unity-based movement analysis.

## Pipeline

![Pipeline Plan](../Images/plan.png)

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



