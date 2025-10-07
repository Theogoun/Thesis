
# The Script

This section explains the structure and logic of the Blender editing script used to transform the bike model based on external data.

## Key Parts of the Script

### 1. The Rig
The ability to use values and transform the bike relies on the rig setup, especially the key points.

### 2. Bpy Library
The script uses Blender's `bpy` library, accessed through Blender's scripting section, to manipulate the model with Python.

### 3. Data Acquisition
All measurements and angles for the bike are stored in an external YAML file, which is loaded into Blender. The YAML structure is as follows (all values in millimeters except angles in degrees, `Material` as a string, and `Top Tube`/`Down Tube` as booleans):

```yaml
Frame:
	Fork Lenght: 470
	Head Angle: 69.5
	Head Tube: 130
	Rake Offset: 40
	Reach: 380
	Seat Angle: 73
	Seat Tube: 375
	Stack: 620
	Wheelbase: 1080
Frame Details:
	Diameter: 40
	Down Tube: True
	Material: 'Metal'
	Thickness: 2
	Top Tube: True
Handlebar:
	Handlebar Height: 50
	HandleBar Lenght: 400
Seat:
	Seat Post: 150
Wheels:
	Tire Radius: 700
	Tire Width: 40
```

### 4. Set_Point("name", X, Z) Function
Moves any object to a specified location. Takes the object's name and X, Z coordinates (Y remains 0), sets the coordinates, selects and moves the object, then deselects everything to avoid accidental multi-object moves.

### 5. Set_Scale("name", X, Y, Z) Function
Scales objects to the required size. Receives the object's name and scale for each axis. A value of 0 (or less) leaves that axis unchanged, allowing selective scaling. After scaling, the function resets the scale to default and deselects everything.

### 6. Small Corrections/Adjustments
Some parts need to be offset from main points for design reasons. These are moved last and follow the rest of the parts, using the two functions above.

### 7. Wheel Adjustments
The script includes a section focused on adjusting the tires and wheels to match the data using the `Set_Scale()` function.

---

## Editing Process

> **Note:** The code below is simplified for clarity. Variable names are shown directly (e.g., `Head Angle`), but in the actual code, they are accessed as `data['Frame']['Head Angle']`. In `Set_Scale`, X and Y are written on separate lines for readability.

### Step 1: Data Preparation
Read and adjust the data for calculations—convert angles to radians and add the Head Tube size to the Fork Length for accurate front wheel placement:

```python
with open(yaml_file_path, "r") as file:
		data = yaml.safe_load(file)

Head_Angle = math.radians(Head_Angle)
Seat_Angle = math.radians(Seat_Angle)
Fork_Length = Fork_Length + Head_Tube
```

### Step 2: Placing Key Points
Assign X and Z values for each point and use `Set_Point()` to move them. For example, to move the B point (see [Setting the Rig](Setting%20the%20Rig.md)):

```python
X = -math.cos(Seat_Angle) * (Seat_Tube / 1000)
Z = math.sin(Seat_Angle) * (Seat_Tube / 1000)
Set_Point("B", X, Z)
```

### Step 3: Small Adjustments
Make corrections for the Head Tube and D point to account for Rake/Offset:

```python
X = Reach / 1000 + math.cos(Head_Angle) * (Fork_Length / 1000)
Z = Stack / 1000 - math.sin(Head_Angle) * (Fork_Length / 1000)
Set_Point("D", X, Z)

X = X - math.cos(Head_Angle + 90) * (Rake / 1000)
Z = Z - math.sin(Head_Angle + 90) * (Rake / 1000)
Set_Point("SizeF", X, Z)
```

### Step 4: Placing and Scaling Non-Frame Parts
Move and scale parts like the handle and seat:

```python
X = -math.cos(Seat_Angle) * ((Seat_Tube + Seat_Post) / 1000)
Z = math.sin(Seat_Angle) * ((Seat_Tube + Seat_Post) / 1000)
Set_Point("Seat Post", X, Z)

Set_Scale("Seat Post", 0, 0, Seat_Post / 1000)
```

### Step 5: Wheel Transformations
Transform wheels as needed using `Set_Scale()`:

```python
Set_Scale("FTire", 0, 0, Wheel_Thickness / 1000)
Set_Scale("BTire", 0, 0, Wheel_Thickness / 1000)

Set_Scale("SizeF", Wheel_Size / 1000, Wheel_Size / 1000, 0)
Set_Scale("SizeB", Wheel_Size / 1000, Wheel_Size / 1000, 0)
```

## Examples

```{figure} ../Images/examples.png
---
name: examples
---
Four example bikes made with the code.
```
