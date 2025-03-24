import yaml

# The Frame parts info needed
# Frame
FL = 470
HA = 69.5
HT = 130
RO = 40
RE = 480
SA = 73
ST = 375
STA = 620
WB = 1080

# Frame Details
M = "Metal"
D = 0.2
T = 0.002
TT = True
DT = True

# Handlebar
HBH = 50
HBL = 400

# Seat info needed
SP = 150

# Wheels
TR = 700
TW = 40


# Creating the dict that will be turned into the yaml file
A = {
      'Frame':
      {'Seat Angle':SA,'Head Angle':HA,'Stack':STA,'Reach':RE,'Seat Tube':ST,'Head Tube':HT,'Fork Length':FL,'Rake Offset':RO,'Wheelbase':WB},
      'Frame Details':
      {'Material':M,'Diameter':D,'Thickness':T,'Top Tube':TT,'Down Tube':DT},
      'Wheels':
      {'Tire Radius':TR,'Tire Width':TW},
      'Seat':
      {'Seat Post':SP},
      'Handlebar':
      {'Handlebar Length':HBL,'Handlebar Height':HBH}
      }


# Still just print for testing
print(yaml.dump(A))

#with open("bike.yaml", "w") as file:
#    yaml.dump(bike_data, file, default_flow_style=False)