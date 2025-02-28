import yaml

# The Frame parts info needed
C = "Blue"
M = "Metal"
D = 0.2
T = 0.002
SA = 75
ST = 390
STA = 620
RE = 480
HA = 73
HT = 115
FL = 480
RO = 40
WB = 1250

# The Tire info needed
TR = input("Give the tire radius \n")
TW = input("Give Tire Width \n")

# Seat info needed
SP = input("Give the Seat Post in mm \n")

# Handlebar info needed
HBL = input("Give the Handlebar length in mm \n")
HBH = input("Give the Handlebar height in mm \n")

# Creating the dict that will be turned into the yaml file
A = {
      'Frame':
      {'Seat Angle':SA,'Head Angle':HA,'Stack':STA,'Reach':RE,'Seat Tube':ST,'Head Tube':HT,'Fork Length':FL,'Rake Offset':RO,'Wheelbase':WB},
      'Frame Details':
      {'Color':C,'Material':M,'Diameter':D,'Thickness':T,'Top Tube':0,'Down Tube':1},
      'Wheels':
      {'Tire Radius':TR,'Tire Width':TW},
      'Seat':
      {'Seat Post':SP},
      'Handlebar':
      {'Handlebar Length':HBL,'Handlebar Height':HBH}
      }


# Still just print for testing
print(yaml.dump(A))