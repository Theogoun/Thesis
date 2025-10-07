
# Making the Model

This section describes the step-by-step process of constructing the 3D bike model, from the initial frame to the final assembly of all components.

## 1. Building the Frame

To begin, a simple prototype bike frame was created using cylinders, each representing one of the six main parts of the frame. These were aligned and measured by tracing over the example from the research paper referenced in the [Research](Research.md) section.

```{figure} ../Images/Modeling.png
---
name: Modeling
---
Screenshot taken in Blender
```

After establishing the standard frame, the Seat Stays and Chain Stays were split to accommodate the rear wheel, completing the frame structure. The fork was then created and split to hold the front wheel. With these elements in place, the wheels, seat, and handlebars were added, resulting in a simple but complete model ready for rigging.

```{figure} ../Images/Modeling_Final.png
---
name: Modeling_Final
---
Screenshot taken in Blender
```

## 2. Modeling the Wheels

The wheels were modeled early in the process, as they do not interfere with the frame design and can be added independently. The "Wireframe" modifier was used for the spokes to avoid creating a mesh for each one, and the spokes were separated into left and right to achieve the typical curvature. A simple rim and tire were then added. Each wheel also includes a hidden mesh (SizeF for the front, SizeB for the back) to control scaling in scripts.

```{figure} ../Images/Wheel.png
---
name: Wheel
---
Screenshot taken in Blender
```

## 3. Drivetrain Components

To ensure the pedals functioned as intended, each pedal was split into four parts: a spacer (for left/right positioning), the pedal arm, a mesh to hold the pedal on the arm (short cylinder at the lower end), and the pedal itself. The importance of these extra parts is discussed further in the [Setting the Rig](Setting%20the%20Rig.md) section.

```{figure} ../Images/Pedal.png
---
name: Pedal
---
Screenshot taken in Blender
```

Due to their complexity, the chain was divided into four stationary pieces (left, right, top, and down), as shown below. The chain does not function mechanically but visually completes the drivetrain.

```{figure} ../Images/Chain.png
---
name: Chain
---
Screenshot taken in Blender
```

## 4. Final Assembly and Refinements

With all major parts complete, minor refinements were made: adding the rake to prevent the wheel from floating (due to the fork's lack of curvature), including the crankset and cassette, and improving the saddle's appearance. The final result is a complete bike model, ready to be transformed according to the data.

```{figure} ../Images/Model.png
---
name: Model
---
Screenshot taken in Blender
```
