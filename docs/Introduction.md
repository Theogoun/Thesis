# Introduction

## Project Summary
This thesis focuses on the development of an **active movement simulation in a built environment** using the **cesium SDK, Unity, and Blender**. The project involves creating a **simplified 3D representation of a real environment** by integrating **geospatial data** from **google maps** retrieved via the **cesium SDK**. Through **Blender**, a modifiable bike model is created, allowing for the simulation of various bike designs based on specific measurements, along with a rider.

## Purpose

The goal of this tool is to create a simulation that allows for the study of various cases by simulating different scenarios, providing insights into the dynamics of [active mobility](glossary.md#active-mobility) in built environments, , enabling researchers and urban planners to analyze and optimize infrastructure for active mobility, fostering safer and more efficient urban environments.

## Pipeline 


```{figure} ../Images/plan.png
---
name: Pipeline
---
Pipeline of project
```


1. **Google 3D Maps**  
   - Retrieve map data from Google 3D Maps for the target location.

2. **Cesium**  
   - Use Cesium to convert the map data into a 3D mesh compatible with Unity.

3. **YAML File**  
   - Define bicycle properties (e.g., dimensions, measurements) in the YAML file to ensure accurate modeling in Blender.

4. **Blender**  
   - Creation of a modifiable 3D model of a bike and rider that will change based on the specifications provided in the YAML file.

5. **Unity**  
   - Integrate the 3D map from Cesium and the bicycle model from Blender into Unity.
   - Use Unity to simulate the environment and interactions.

6. **Simulation**  
   - Run the simulation in Unity to test and analyze movement mobility.




