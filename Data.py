import yaml

# The Frame parts info needed
C = input("Give the color of the bike \n")
M = input("Give the Material of the bike \n")
D = input("Give the Diameter of the Tubes in mm \n")
T = input("Give the Thickness of the Tubes in mm \n")
SA = input("Give the Seat Angle in degrees \n")
ST = input("Give the Seat Tube Lenght in mm \n")
STA = input("Give the Stack in mm \n")
RE = input("Give the Reach in mm \n")
HA = input("Give the Head Angle in degrees \n")
HT = input("Give the Head Tube Lenght in mm \n")
FL = input("Give the Fork Length in mm \n")
RO = input("Give the Rake/Offset in mm \n")
WB = input("Give the Wheelbase in mm \n")

# The Tire info needed
TR = input("Give the tire radius \n")
TW = input("Give Tire Width \n")

# Seat info needed
SH = input("Give the Seat Height in mm \n")

# Handlebar info needed
HBL = input("Give the Handlebar length in mm \n")
HBH = input("Give the Handlebar height in mm \n")

# Creating the dict that will be turned into the yaml file
A = {
      'Frame':
      {'Color':C,'Material':M,'Diameter':D,'Thickness':T,'Seat Angle':SA,'Head Angle':HA,'Stack':STA,'Reach':RE,'Seat Tube':ST,'Head Tube':HT,'Fork Length':FL,'Rake Offset':RO,'Wheelbase':WB},
      'Wheels':
      {'Tire Radius':TR,'Tire Width':TW},
      'Seat':
      {'Seat Height':SH},
      'Handlebar':
      {'Handlebar Length':HBL,'Handlebar Height':HBH}
      }


# Still just print for testing
print(yaml.dump(A))