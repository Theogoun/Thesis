# Rig Explanation
To transform the bike into the desired measurements, a system was needed to interpret these values and apply them effectively. The final system used "key points", by placing these points at the locations where the most important parts of the bike begin or end, the model can take shape and fill in the gaps, as explained below.

The key points where condensed into 5 points in the 3D environment, for simplicity the Y axis will be 0 and any action will be done in the Z and X axes, the height and length of the bike respectively:
  
## Key Points and Their Coordinates

### A: Bottom Bracket (BB) Point
The origin of the bike's geometry, where the crank axle sits:

$$
\begin{aligned}
A_x &= 0 \\
A_z &= 0
\end{aligned}
$$

### B: End of Seat Tube (C-C Measurement)
Calculated from the BB using the seat tube length and seat angle:

$$
\begin{aligned}
B_x &= -\cos(\theta_{seat}) \cdot L_{seat} \\
B_z &= \sin(\theta_{seat}) \cdot L_{seat}
\end{aligned}
$$
Where $\theta_{seat}$ is the seat tube angle, $L_{seat}$ is the seat tube length.

### C: Top of the Head Tube
Defined directly by the reach and stack measurements:

$$
\begin{aligned}
C_x &= \text{Reach} \\
C_z &= \text{Stack}
\end{aligned}
$$

### D: Front Tire Contact Point
Found by extending from the head tube using fork length, head angle, and rake (offset):

$$
\begin{aligned}
D_x &= C_x + \cos(\theta_{head}) \cdot L_{fork} - \sin(\theta_{head}) \cdot R_{rake} \\
D_z &= C_z - \sin(\theta_{head}) \cdot L_{fork} - \cos(\theta_{head}) \cdot R_{rake}
\end{aligned}
$$
Where $\theta_{head}$ is the head tube angle, $L_{fork}$ is the fork length, $R_{rake}$ is the fork rake (offset).

### E: Rear Tire Contact Point
Located by subtracting the wheelbase from the front tire's x-position:

$$
\begin{aligned}
E_x &= D_x - \text{Wheelbase} \\
E_z &= D_z
\end{aligned}
$$
```{figure} ../Images/Points.png
---
name: Points
---
Simple illustration of the points' position.
```

- **Point A:** Through the A point which will always be set at the (0,0) mark, the B point can be found using the Seat Tube C-C and the Seat Angle measurements using the polar-to-Cartesian coordinate transformation equations as seen above. It is also possible to find the C point by adding the Stack measurement to the Z axis and the Reach measurement to the X axis.
  
- **Point B:** Knowing the location of the B point allows us to fully form the Seat Tube, which is needed to be the originator 4 main components of the bike, those being the Chain Stays, Seat Stays, Top Tube and Down Tube.
  
- **Point C:** This point is important because it will be the reference point for the Heat Tube and Fork while also completing the Top and Down Tube, it will also act as a reference for the D point. Similarly to how the location for the second point (B), the polar-to-Cartesian coordinate transformation equations will be used to find the D point using the measurements: Head Tube, Fork Length, Head Angle with some small corrections using the Rake/Offset.
  
- **Point D:** This point will help in placing the wheel and complete the whole front of the bike, that being anything from the Fork to the front wheel, completing the Fork and giving us enough information to complete the rest, it will also help as a reference to find the final point.
  
- **Point E:** The final point is needed to place the second wheel and complete the Seat Stays and Chain Stays

# Constraints and Bone connection
The constraints will help the editing process by allowing certain behaviors of the parts while prohibiting unwanted distortion. The list of what constraints will be used and their use is as follows:

- **Limit Scale:** This forbids the mesh to be scaled in certain axis, for example it can limit the scale of the X axis to minimum=1 and maximum=1 making it unable to be scaled up or down in the X axis.
  
- **Stretch to:** This constrain is more of a guide, setting a point to which the item will stretch to to have it reach that point whatever happens to that guide object, this can of course lead to various unwanted distortion which is why it will always be paired with the "Limit Scale" constraint.
  
- **Track to:** This constraint works similarly to the "Stretch to" constraint without scaling it into the point, making it just face towards the target.
  
- **Child of:** By setting one mesh to be the child of another it sets it to copy everything done to the parent, for example if the parent is moved 10 cm to the right, the child will do the same, the same is applied when scaling, rotating and most other actions.
  
- **Copy Location:** By having a mesh copy the location of another mesh, it will simply be at the same coordinates as the mesh it is set to, the points of reference that will be in the same place are their individual origin points (usually the center of the object).
  
- **Copy Rotation:** Similarly to the "Copy Location" constraint it is possible to set a mesh to copy the exact rotation of a mesh in any selected axes.

Similarly the way the bones are connected in an armature is very important as it would be completely different if even one bone is reversed or altered. For example if there are 2 bones linked together in a line like so:

```{figure} ../Images/Bones.png
---
name: Bones
---
Screenshot taken in blender
```

Each sphere represents a point of a bone, in this case they are, in order, placed like this: Head of bone 1, Tail of bone 1 connected to Head of bone 2 and finally Tail of bone 2. If bone 1 is moved as a whole the whole armature will move with it, but if bone 2 is attempted to be moved, only it's tail will move because it is the "Child" of bone 1 and has less influence. Making it important to set the right bones are the parent bones and child bones.

# Constraints and settings for each part
A total of 2 armatures were made for this part, one for the frame of the bike and one for the fork and everything attached to it. As seen in the image below the bones highlighted in green make up the armature responsible for the frame and the gray bone is the separate armature for the rest. The armatures are named "AFrame" and "AFork" respectively.

```{figure} ../Images/Bike_Rigs.png
---
name: Bike_Rigs
---
Screenshot taken in Blender
```

**AFork:** The only bone in this is the Fork bone, making it unable to have a parent bone or child bone and needing only 3 simple constraints, these being **Copy Location** targeting at point C, **Stretch to** targeting point D practically making it start from C and end at D at any point. The final constraint is **Limit Scale** which makes it unable to become thinner or wider.

**AFrame:** For simplicity, for this section, each bone will be named after the part of the bike it represents:
- **Seat Tube:** As seen in the image it is the parent bone of every other bone having all of their heads pointing to it, this allows the seat tube to be transformed while having the rest follow it around. In order to edit it, the head point in set to **Copy Location** to point A and **Stretch to** point B while having the **Limit Scale** on X and Y axes to restrict it from widening or thinning.
  
- **Top Tube:** Being the child bone of the Seat Tube bone it's head will always follow the Seat Tubes tail, making it only need to **Stretch to** Point C, with some corrections to not meet the Down Tube directly and **Limit Scale** for the same reasons as the Seat Tube.
  
- **Down Tube:** Very similar to Top Tube, it follows the Seat Tube's head so it only needs to **Stretch to** point C again with similar corrections and for the same reasons have **Limit Scale** added.
  
- **Seat Stays:** Similarly it's head follows the tail end of the Seat Tube, only needing to **Stretch to** point E and **Limit Scale**.
  
- **Chain Stays:** Exactly the same as the Seat Stays but instead of following the tail end it follows the head of the Seat Tube.

**Drivetrain Parts:** First the chain will be explained as it needed 2 armatures to be completed and then the pedal mechanism which was simpler.
- **Left Chain part:** This part just needed the **Copy Location** constraint targeting the E point to ensure that it would stay on the Cassette.
  
- **Top Chain part:** An Armature with 1 bone was made with the bone constraints being similar to the ones for tubes, the only difference being this had the **Copy Location** and **Stretch to** constraints target custom Empties right above the main points instead of being directly on them to create the illusion that the chain is still 1 object, even though it wasn't possible. Lastly **Limit Scale** was added for the same reasons it was added to the tubes.
  
- **Down Chain part:** Similarly this part had an armature with the bone being guided with the same constraints to Empties targeting right bellow the main points.
  
- **Right Chain part:** This part didn't need any kind of editing as it will always stay in the (0,0,0) position right in the middle with the A point.

As seen in the [Making the Model](Making%20the%20Model.md) section, the pedals are made of 4 parts as well. Each pedal needs these 4 parts to make it so the pedals don't spin in ways that weren't possible while riding a bike. For simplicity, as shown in the picture in the section mentioned, the start of the pedal will be where it meets the bike and going down will be the end of the pedal.

- **Bottom Bracket:** This is a component that isn't easily visible but both arms of the pedals have the **Copy Rotation** targeted to this one object to make sure they are synchronized, of course with the corrections to make it so they are facing opposite directions at all points.
  
- **End part of the pedal:** On an actual bike this would be the screw between the arm and the pedal of the bike, but in this case a small cylinder is added and made the **Child of** it's respective arm. This allows it to always be in the same spot on the arm whatever happens to it during any transformation.
  
- **Pedal:** The actual pedal where the foot rests will only have the **Copy Location** constraint targeting the End part of the pedal, by having it copy only the location and not making a child to it the pedal always faces right side up.

**Other:** There are several parts that are not part of the frame, therefore not in the armatures, these parts also need certain constraints to function correctly.
- **Seat Post:** Needing the size for it to be placed in the right spot it will be scaled independently making it able to just have **Track to** with the target being the B point.
  
- **Seat:** Only has the **Copy Location** constraint targeting the Seat Post.
  
- **Headset:** Work exactly like the Seat Post so it also just has the **Track to** constraint with the target being the C point.
  
- **Stem and Handlebars:** The Stem only has the **Child of** constraint to the Headset part and the Handlebars only **Copy location** on the Stem making both move with the headset.



