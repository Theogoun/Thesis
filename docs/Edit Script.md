## Key parts of the script

- **The Rig:** As explained the only reason we are able to use the values and transform the bike is because of the way the rig is set, mainly the key points.
  
- **Bpy library:** In order to edit the blender file with python the "bpy" library was used through the scripting section in Blender.
  
- **Data Acquisition:** Every measurement and angle needed for the bike is stored in a YAML file created externally and later added into Blender's compiler. The structure of the YAML is seen in the example below. Everything is in millimeters (mm) except the angles which are in degrees, Material being a string and Top Tube and Down Tube in the Frame Details being in boolean.

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

- **Set_Point("name",X,Z) Function:** This function allows us to move any object to wherever needed. It takes 3 variables, these being the name of the object and the X,Z coordinates of the target location (Y axis won't change therefore is always 0), after that input it sets the coordinates for the target location, it selects the object, it moves the object, and then deselects everything to avoid moving multiple objects.
  
- **Set_Scale("name",X,Y,Z) Function:** This function will scale objects to the needed size. The 4 variables it receives are the name of the object and the scale of each of the axes. By inputting a number on an axis the function scales it to the desired size, while inputting 0 (or less) leaves the axis unaltered to make it able to scale one, two or all three dimensions depending on what's needed, after everything it sets the scale to be the default size to avoid multiplicative scaling on future uses, then finally it deselects everything, similarly to avoid scaling multiple objects.
  
- **Small corrections/Adjustments:** For the sake of the design there are some parts that need to be around a main point and not on it, these will be moved last and will move according to the rest of the parts to ensure everything is where it should using the 2 functions mentioned above.
  
- **Wheel Adjustments:** There is a point in the Script that will focus just on the tires and wheels of the bike to match the data given with the **Set_Scale()** function.


## Editing process

**Disclaimer:** All the code seen below is a simplified version for the sake of understanding, namely every variable will be written with its name instead of the path needed to find it in the YAML file, for example the "Head Angle" measurement, in the actual code is written as "data\['Frame']\['Head Angle']" instead. Also in the Set_Scale function the X and Y coordinates will be written one under the other and after that added to the function instead of setting the values in the function directly for the sake of visual clarity.

1. The data is read and adjusted in order to be ready for the calculations needed to place each part in it's correct place, specifically turning degrees to radians for angles and adding the Head Tube size to the Fork Length to accurately place the front wheel as seen in the example below.
``` python
with open(yaml_file_path, "r") as file:
        data = yaml.safe_load(file)

Head Angle = math.radians(Head Angle)  
Seat Angle = math.radians(Seat Angle)
Fork Length = Fork Length + Head Tube
```
   
2. The X and Z axis are both appointed to the needed value for each point and the **Set_Point()** function is used to move them to the correct coordinates, which are shown in [Setting the Rig], as an example this is how it would move the B point:
``` python
X = -math.cos(Seat Angle)*(Seat Tube/1000)
Z = math.sin(Seat Angle)*(Seat Tube/1000)
Set_Point("B",X,Z)
```

3. Small adjustments are made during the second part using both functions, namely in the Head Tube and for the D point to account for the Rake/Offset which is shown as an example here.
``` python
X = Reach/1000 + math.cos(Head Angle)*(Fork Lenght/1000)
Z = Stack/1000 - math.sin(Head Angle)*(Fork Lenght/1000)
Set_Point("D",X,Z)

X = X - math.cos(Head Angle+90)*(Rake/1000)
Z = Z - math.sin(Head Angle+90)*(Rake/1000)
Set_Point("SizeF",X,Z)
```
   
4. Any part that isn't part of the bike frame is scaled as needed and is moved to the right place using the same functions, that includes parts like the handle and the seat which is shown below.
``` python
X = -math.cos(Seat Angle)*(Seat Tube/1000+Seat Post/1000)
Z = math.sin(Seat Angle)*(Seat Tube/1000+Seat Post/1000)
Set_Point("Seat Post",X,Z)

Set_Scale("Seat Post",0,0,Seat Post/1000)
```
   
5. The wheels will be transformed in any way needed using the Set_Scale() function.
``` python
Set_Scale("FTire",0,0,Wheel Thickness/1000)
Set_Scale("BTire",0,0,Wheel Thickness/1000)

Set_Scale("SizeF",Wheel Size/1000,Wheel Size/1000,0)
Set_Scale("SizeB",Wheel Size/1000,Wheel Size/1000,0)
```

