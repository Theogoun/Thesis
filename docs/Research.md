# Research

To ensure accurate naming and placement of all components, a solid understanding of bicycle structure and geometry was required. This section summarizes the key research steps and sources used to inform the modeling process.

## Terminology: Anatomy and Geometry

The first step was to identify the correct terms for every part and measurement of the bike. This was accomplished using:

- **Bike Lock WIKI:** A security-oriented review and recommendation site for bicycles, which provides a comprehensive [diagram of bike parts](https://www.bikelockwiki.com/parts-of-a-bike-diagram/). The most important parts are shown below:

```{figure} ../Images/Bike_Parts.png
---
name: Bike_Parts
---
Bike parts found in [bikelockwiki.com](https://www.bikelockwiki.com)
```

- **GeometryGeeks.bike:** For geometry, the site [GeometryGeeks.bike](https://geometrygeeks.bike/understanding-bike-geometry/) offers a clear reference image and thorough explanations of all relevant measurements.

## Prototype Reference

To create a base prototype for the bike, a temporary template was needed. This was sourced from a [research paper](https://www.researchgate.net/publication/295675697_Multi-objective_optimization_of_an_on-road_bicycle_frame_by_uniform_design_and_compromise_programming) on bicycle frame optimization. The example image below, taken from the paper, provided reference values for the length and thickness of each bike part:

```{figure} ../Images/Bike_Reference.png
---
name: Bike_Reference
---
Image taken from the [research paper](https://www.researchgate.net/figure/Basic-dimensions-of-on-road-bicycle-frame-model_fig2_295675697)
```

## Key Dimensions 

To enable customization, it was necessary to determine which measurements should be editable. Research into Blender's capabilities and the most vital parts of the bike led to the following list of essential data:

1. Seat Angle
2. Seat Post
3. Seat Tube C-C
4. Stack
5. Reach
6. Head Angle
7. Head Tube
8. Handlebar Height
9. Fork Length
10. Rake/Offset
11. Wheelbase

More information on how these are used can be found in the [[Setting the Rig]] section.

```{figure} ../Images/Bike_Geometry.png
---
name: Bike_Geometry
---
Bike geometry found in [geometrygeeks.bike](https://geometrygeeks.bike)
```

## Data Collection

A single prototype is not sufficient to ensure the model's flexibility. Therefore, several examples were gathered from [geometrygeeks.bike](https://geometrygeeks.bike/) and its database of bikes and measurements. This allowed for a broader understanding of the range of possible geometries and ensured the model could accommodate various designs.
