# Cesium

Cesium is an open platform for 3D geospatial data visualization. It allows developers to create highly accurate, real-world simulations using geographic data. Cesium provides tools for streaming, visualizing, and interacting with large-scale 3D geospatial datasets, such as terrain, building models, and map imagery, in a performant and dynamic way.

Key features of Cesium include:  
- **3D Tiles**: An open standard for streaming massive 3D datasets efficiently.  
- **Integration with Real-World Data**: It supports data from sources like Google 3D Maps, OpenStreetMap, and custom datasets.  
- **Cross-Platform Compatibility**: Cesium is accessible on web browsers, game engines like Unity, and standalone applications.   

In this project, Cesium is used to convert 3D map data into a Unity-compatible format.

## Cesium unity package

To utilize real-world geospatial data in Unity, we rely on the [**Cesium for Unity**](https://cesium.com/platform/cesium-for-unity/) plugin. This plugin facilitates the seamless integration of 3D geospatial data into Unity, allowing for accurate environmental simulations.

### Cesium ion Assets

```{figure} ../Images/cesium-ion-assets.png
---
name: Ion Assets
---
Cesium terrain options
```

The Cesium ion Assets menu in Unity provides quick access to various geospatial data assets. Below are the available options:

- **Cesium World Terrain + Bing Maps Aerial imagery**:  
  Combines high-resolution terrain data with Bing Maps' aerial imagery for realistic 3D landscapes.

- **Cesium World Terrain + Bing Maps Aerial with Labels imagery**:  
  Similar to the above but includes labels (e.g., place names, roads) over the aerial imagery for better context.

- **Cesium World Terrain + Bing Maps Road imagery**:  
  Displays terrain data with a road map overlay, useful for navigation-focused applications.

- **Cesium World Terrain + Sentinel-2 imagery**:  
  Uses satellite imagery from Sentinel-2, providing detailed and up-to-date Earth observation data.

- **Cesium OSM Buildings**:  
  Adds 3D building models sourced from OpenStreetMap, ideal for urban simulations or city planning.

