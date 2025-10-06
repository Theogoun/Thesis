
# Biker

This section describes the setup and constraints used for the biker model and its armature, ensuring correct positioning and animation on any generated bike.

## Model Setup

The biker model (including its armature) is the same as the one used for pedestrians in the simulation. The focus here is on editing the armature so the biker sits correctly, with arms and legs in the right places for any bike created by the script. While not required for the simulation to function, the biker is used for the loading animation.

```{figure} ../Images/Biker.png
---
name: Biker
---
Screenshot taken in Blender showing the Armature of the biker
```

### Reference Points (Empties)
The model does not have collision, so to ensure the biker sits on or touches the bike (not inside it), several empties are created as reference points:

- **Seat:** An empty is placed slightly above the seat mesh, which becomes its parent. This ensures the seat reference is always in the correct place for the biker to sit.
- **Handlebars:** Two empties are placed over the handlebar (one for each hand), both parented to the handlebar so they move with it.
- **Pedals:** One empty is placed over each pedal, parented to the respective pedal, ensuring the biker's feet are always positioned correctly.

## Armature Constraints

The main constraints used are:

- **Inverse Kinematic (IK):** Allows the ends of limbs to follow a target point, with the rest of the limb (e.g., elbows, knees) bending naturally. This constraint appears orange in Blender's editor.
- **Limit Rotation:** Restricts rotation to a specified range, preventing unnatural movement.
- **Copy Location:** Used for the hip to follow the seat.

### Constraint Setup

- **Hands:** IK constraint targets the handlebar empties; Limit Rotation keeps hands perpendicular to the floor and prevents collision with the bar.
- **Hip:** Copy Location constraint targets the seat empty.
- **Head:** Limit Rotation constraint keeps the head facing forward.

```{figure} ../Images/Biker_Top.png
---
name: Biker_Top
---
Picture showcasing the upper body.
```

- **Feet:** IK constraint targets the pedal empties.
- **Shins:** Limit Rotation constraint prevents unnatural bending due to IK.
- **Toes:** Limit Rotation keeps toes facing forward (for realism, not function).

```{figure} ../Images/Biker_Bot.png
---
name: Biker_Bot
---
Picture showcasing the lower body.
```

## Final Result

```{figure} ../Images/Biker_All.png
---
name: Biker_All
---
Final result of biker.
```
