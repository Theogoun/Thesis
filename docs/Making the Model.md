## Frame
Aiming for simplicity at first the base prototype bike was made to have anything practical applied to it's generalized frame. This prototype was just some cylinders, each of them being one of the six parts of the bike frame as seen below. They were aligned and measured by tracing them over the example taken from the research paper mentioned in the [[#Research]] section.

```{figure} ../Images/Modeling.png
---
name: Modeling
---
Screenshot taken in Blender
```

After making this standard frame, the parts that would be holding the back tire (Seat Stays and Chain Stays) were split in half to accommodate the wheels, completing the frame. Following that the Fork of the bike was created and split to also be able to hold the front wheel. Having all the needed parts for it, the wheels, seat and handlebars were also added to the bike making it although simple, complete and fully functional for the rigging process. 

```{figure} ../Images/Modeling_Final.png
---
name: Modeling_Final
---
Screenshot taken in Blender
```

## Wheels
As for the wheels, in order to not be as bland they were made before the bike was finished as they do not interfere with the design of the bike and are practically added after everything. In order to do that the "Wireframe" modifier was used in the spokes of the bike to avoid having a mesh for each spoke, while also separating the spokes to left and right ones to curve them in the usual bike tire fashion. After that a simple Rim was made and the Tire was added on top of it giving the following result. An important part of the Wheels that isn't visible is a mesh that controls the size of each wheel to make it simpler for the script to scale all parts, SizeF for the front wheel and SizeB for the back wheel.

```{figure} ../Images/Wheel.png
---
name: Wheel
---
Screenshot taken in Blender
```

## Drivetrain Parts
In order to make the pedals work as intended they had to be split into a lot of parts, a single pedal is composed of 4 parts, one to make space for the pedal to the left or right of the bike (the top part in the picture), another that is the "arm" of the pedal, a mesh to hold the pedal on the mentioned "arm" (The short cylinder at the lower end) and of course the actual pedal. These extra parts will have their importance explained later in in the [[Setting the Rig]] section.

```{figure} ../Images/Pedal.png
---
name: Pedal
---
Screenshot taken in Blender
```

Due to the complexity of the parts the chain needed to be cut into 4 pieces and was made stationary, as in it doesn't work mechanically to spin the wheels. For simplicity the 4 parts will be explained as left, right, top and down as seen in the image below. 

```{figure} ../Images/Chain.png
---
name: Chain
---
Screenshot taken in Blender
```

After all of these things were finished, with some minor refinements like adding the rake part to not have the wheel float when it was put in the correct spot due to the lack of a curve in the fork, adding the Crankset and Cassette and making the saddle look better the final result of the actual model of the bike, that would later be transformed according to our data, was this:

```{figure} ../Images/Model.png
---
name: Model
---
Screenshot taken in Blender
```