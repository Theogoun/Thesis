import yaml

# The Frame parts' info needed
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
TR = input("Give the tire radius in mm \n")
TT = input("Give Tire Thickness in mm \n")

# Creating the dict that will be turned into the yaml file
A = [{'Frame':{'Seat Angle':SA,'Seat Tube':ST,'Stack':STA,'Reach':RE,'Head Angle':HA,'Head Tube':HT,'Fork Length':FL,'Rake Offset':RO,'Wheelbase':WB},
      'Tires':{'Tire Radius':TR}}]


# Still just print for testing
print(yaml.dump(A))