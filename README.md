## Process of Bike Creation
- [[#Research]]
- [[#Making the model]]
- [[#Setting the rigs and constraints]]
- [[#Edit Script]]
- Drivetrain Parts

### Research
- **Terminology on Anatomy and Geometry:** To create the prototype the right  documentation was needed, finding the correct terms for every part and measurement of the bike was the first part of the research, which was found in a security oriented review and recommendation site for everything bicycle related called "Bike Lock WIKI" in their comprehensive diagram on bike parts found [here](https://www.bikelockwiki.com/parts-of-a-bike-diagram/). The geometry side was much simpler, being able to be condensed into one reference image with any details needed explained thoroughly in the site "GeometryGeeks.bike" in [this page](https://geometrygeeks.bike/understanding-bike-geometry/).

![image](Bike_Parts.png)

*Bike parts found in [bikelockwiki.com](https://www.bikelockwiki.com)* 

- **Prototype Reference:** A reference was needed to make the base prototype for the bike to take form, it would later be customized so a temporary template was needed which was found in a [research paper](https://www.researchgate.net/publication/295675697_Multi-objective_optimization_of_an_on-road_bicycle_frame_by_uniform_design_and_compromise_programming) about bicycle frame optimization by uniform design and compromise programming. From that paper the example given in the form of a picture that is shown below was taken for the length and thickness of each bike part.

![image](Bike_Reference.png)

*Image taken from the [research paper](https://www.researchgate.net/figure/Basic-dimensions-of-on-road-bicycle-frame-model_fig2_295675697)* 

- **Finding the "important" parts:** In order for the bike to be customized to our liking the ability to bend the frame was needed, but in order to do that the editable measurements should be assigned prior to the design of the bike to make sure everything was in order. By that we are ensuring that we are only editing the things that are able to be edited and we are unable to edit the parts of the bike that would ultimately deform the frame in ways its not intended. Through some research on the capabilities of the 3D modeling software that was used (Blender) and through consideration of the most vital parts of the bike, it was concluded that the minimum requirement of data needed were the following measurements:
 1. Seat Angle
 2. Seat Tube C-C
 3. Stack
 4. Reach
 5. Head Angle
 6. Head Tube
 7. Fork Length
 8. Rake/Offset
 9. Wheelbase
	More information on how they are used in [[#Edit Script]].

![image](Bike_Geometry.png)

*Bike geometry found in [geometrygeeks.bike](https://geometrygeeks.bike)* 

- **Gathering Data:** A single prototype or example is not enough to make sure that the bike can be fully formed into our standards is not enough. So several examples were gathered through the site mentioned beforehand: [geometrygeeks.bike](https://geometrygeeks.bike/) and it's selection of bikes and their measurements. Another way examples were acquired was from personal research on the bikes of people that volunteered to either have their bikes measured or measure it themselves and record the results. (whoever did is credited in the [[#Bibliography]] either anonymously or named)

**MORE IS TO BE ADDED**
### Making the model
Aiming for simplicity at first the base prototype bike was made to have anything practical applied to it's generalized frame. This prototype was multiple cylinders, each of them being one of the six parts of the bike frame as seen below. They were aligned and measured by tracing them over the example taken from the research paper mentioned in the [[#Research]] section.

![image](Modeling.png)

*Screenshot taken in Blender*

After making this standard frame, the parts that would be holding the back tire were split in half to accommodate the wheels while making sure to not have a hollow half-cylinder, completing the frame. Following that the Fork of the bike was created and split to be able to hold the front wheel. Having the all the needed parts for it, the wheels, seat and handle were also added to bike making it although simple, complete and fully functional for the editing process.

![image](Modeling_Final.png)

*Screenshot taken in Blender*

**NOT FINISHED YET REFINEMENT PENDING**

### Setting the rigs and constraints

**COMPLETED BUT PENDING DOCUMENTATION**

### Edit Script
There are 5 points in the 3D environment, for simplicity the Y axis will be 0 and any action will be done in the Z and X axis, the height and length of the bike respectively:
- A: BB point (where the axle is) 
- B: End of Seat Tube C-C measurement
- C: Top of the Head Tube
- D: Front Tire
- E: Back Tire

![image](Points.png)

*Image created by my brother using Illustrator*

- **Importance of Point A:** Through the first point (A) which will always be set at the (0,0) mark, the B point can be found using the Seat Tube C-C and the Seat Angle measurements using the polar-to-Cartesian coordinate transformation equations. It is also possible to find the C point by adding the Stack measurement to the Z axis and the Reach measurement to the X axis.
- **Importance of Point B:** Knowing the location of the B point allows us to fully form the Seat Tube, which is needed to be the originator 4 main components of the bike, those being the Chain Stays, Seat Stays, Top Tube and Down Tube.
- **Importance of Point C:** This point is important because it will be the originator for the Heat Tube and Fork, it will act as a reference for the D point . Similarly to how the location for the second point (B), the polar-to-Cartesian coordinate transformation equations will be used using the measurements: Head Tube, Fork Length, Head Angle with some small corrections using the Rake/Offset.
- **Importance of Point D:** This point will help in placing the wheel and complete the whole front of the bike, that being anything from the Handle to the Fork, completing the Fork and giving us enough information to complete the rest, it will also help as a reference to find the final point, which will be done by subtracting the Wheelbase measurement from the X axis.
- **Importance of Point E:** The final point is needed to place the second wheel and complete the Seat Stays and Chain Stays

**The process of editing is as follows:**
There is a function named "Set_Point()" which takes as input the name of the object and moves it to the location the X,Y and Z axis are currently leading, Y will stay at 0 while the X and Z axis will be modified as needed before running the function.
1. The X and Z axis are both appointed the value 0, then we run the function for the A point moving it to (0,0).
2. X is set at math.sin(SAngle)\*(Seat_Tube/1000) and Z at math.cos(SAngle)\*(Seat_Tube/1000) and the function is ran on B.
3. X is set at the Reach measurement while Z at the Stack measurement and the funtion is ran on C.
4. X = Reach/1000 + math.cos(HAngle)\*(Fork_Lenght/1000) and Z = Stack/1000 - math.sin(HAngle)\*(Fork_Lenght/1000) and the function is ran on D.
5. X = Reach/1000 + math.cos(HAngle)\*(Fork_Lenght/1000) - Wheelbase whilethe Z axis stays the same and the function is run on E.
6. Small corrections are done to fix alignment of the Head Tube in a similar fashion. 

**NOT FINISHED REFINEMENT OF THE BIKE PENDING**

## Bibliography:
### References
- https://www.bikelockwiki.com/parts-of-a-bike-diagram/ (part names)
- https://www.researchgate.net/publication/295675697_Multi-objective_optimization_of_an_on-road_bicycle_frame_by_uniform_design_and_compromise_programming (other thesis on bike frames)
- https://geometrygeeks.bike/understanding-bike-geometry/ (general geometry)
