# RobotNavigation
Robot Navigation using searches through a map


SETUP:
Project Arguments -    
First Argument: String, ::Textfile Name - The textfile must be located within the maps folder in the project (May change later)    
Second Argument: String, ::Search Method - BFS, DFS, GBFS, AStar


Map Setup:   
. = empty node   
X = Wall   
A = Start position of Agent   
G = Goal of the agent

Map example:   
A . . X G   
. X . X .   
X . . X .   
X X . . .

Other environments could be added.
