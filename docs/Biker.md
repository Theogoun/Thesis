## Setup
The model of the biker, which includes the armature as well, is the same model used for the pedestrians seen later in the simulation. The focus will be the armature and how it will be edited in order for the biker to sit correctly with his arms and legs in the right places on any bike created by the script. The biker is not needed for the simulation to work but has been used in order to make the loading animation of the simulation.

```{figure} ../Images/Biker.png
---
name: Biker
---
Screenshot taken in Blender showing the Armature of the biker
```

The model itself does not have a concept of collision, so for the biker to not be in the bike mesh but rather on it or touching it, certain empties will be created as reference points (like the bike main points). Specifically there will be a total of 5 empties:
- **The Seat:** An empty is placed slightly above the seat mesh, it then later has that mesh become its parent so that it follows it around making sure it is always the correct place for the biker to sit.
  
- **The Handlebars:** 2 empties are created and placed over the handlebar, one in each side for each hand. They both have the handlebar as the parent making the sure they are always where the biker's hands should be.
  
- **The Pedals:** Similarly an empty is created over each pedal and has each respective pedal be it's parent to ensure the correct position of the biker's feet at any point.
## Constraints
The main constraints used are **Inverse Kinematic** which allows the ends of the limbs to follow a point while also having the rest of the body follow accordingly, like the elbows bending and the back hunching, this constraint is the only one that shows up as orange in the editor as seen below. The other constraint used is the **Limit Rotation** constraint which makes it so that a cone can only rotate up to the given values. More specifically the constraints are set up like so:

- **Hands:** The hands being the ends of the limbs have the **Inverse Kinematic** constraint targeted at the empties created at the handlebars, each hand in each end of the handlebar. The hands also have the **Limit Rotation** constraint to make sure they stay perpendicular to the floor and prevent them from colliding into the bar.
  
- **Hip:** The hip just has the **Copy Location** constraint targeting the empty on the seat.
  
- **Head:** The head has the **Limit Rotation** constraint keeping it always facing forwards.

```{figure} ../Images/Biker_Top.png
---
name: Biker_Top
---
Picture showcasing the upper body.
```

- **Feet:** The feet are the ends of the limbs so they also have the **Inverse Kinematic** constraint targeted at the empties of the pedals.
  
- **Shins:** As they are the parts most affected by the **Inverse Kinematic** constraint the **Limit Rotation** constraint is needed to keep them from bending in unnatural ways.
  
- **Toes:** The **Limit Rotation** constraint was added to have them always face forward. This is a small detail that helped the model not look so uncanny but doesn't serve and practical use

```{figure} ../Images/Biker_Bot.png
---
name: Biker_Bot
---
Picture showcasing the lower body.
```

```{figure} ../Images/Biker_All.png
---
name: Biker_All
---
Final result of biker.
```
