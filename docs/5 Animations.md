#### Animation System and State Management in Unity

To enhance the realism of agent movement in the simulation, a custom **Animator Controller** is used. Below, two key elements of this controller are detailed:

- **Entry and Initial Movement**: The animation system begins at the Entry point and proceeds into the **Movement** state. This ensures that the animation logic is initiated when the simulation starts.

![Animation](../Images/animation.png)

- **Blend Tree for Dynamic Movements**: A **Blend Tree** allows for fluid transitions between different walking animations and an idle state. Controlled by the `MoveX` and `MoveY` parameters, the Blend Tree dynamically adjusts the character's animations to match the direction and speed of movement.

![Animation](../Images/blendtree.png)

The animations values of the blend tree are set through a script in the human controller 

   ```csharp
   private void SetAnimValues()
   {
       Vector3 velocity = transform.InverseTransformDirection(_agent.velocity);
       _animator.SetFloat("MoveX", velocity.x);
       _animator.SetFloat("MoveY", velocity.z); 
   }
   ```