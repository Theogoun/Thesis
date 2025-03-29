import yaml

# The Frame parts info needed
# Frame
FL = 470 # Fork Length (mm)
HA = 69.5 # Head Angle (Degrees)
HT = 130 # Head Tube (mm)
RO = 40 # Rake/Offset (mm)
RE = 480 # Reach (mm)
SA = 73 # Seat Angle (Degrees)
ST = 375 # Seat Tube (mm)
STA = 620 # Stack (mm)
WB = 1080 # Wheelbase (mm)

# Frame Details
M = "Metal" # Material (String)
D = 200 # Diameter (mm)
T = 2 # Thickness (mm)
TT = True # Top Tube (Boolean)
DT = True # Down Tube (Boolean)

# Handlebar
HBH = 50 # Handlebar Height (mm)
HBL = 400 # Handlebar Length (mm)

# Seat info needed
SP = 150 # Seat Post (mm)

# Wheels
TS = 700 # Tire Size (mm)
TW = 40 # Tire Width (mm)


# Creating the dict that will be turned into the yaml file
bike_data = {
      'Frame':
      {'Seat Angle':SA,'Head Angle':HA,'Stack':STA,'Reach':RE,'Seat Tube':ST,'Head Tube':HT,'Fork Length':FL,'Rake Offset':RO,'Wheelbase':WB},
      'Frame Details':
      {'Material':M,'Diameter':D,'Thickness':T,'Top Tube':TT,'Down Tube':DT},
      'Wheels':
      {'Tire Radius':TW,'Tire Size':TS},
      'Seat':
      {'Seat Post':SP},
      'Handlebar':
      {'Handlebar Length':HBL,'Handlebar Height':HBH}
      }


# Still just print for testing
#print(yaml.dump(A))

with open("bike_data.yaml", "w") as file:
    yaml.dump(bike_data, file, default_flow_style=False)