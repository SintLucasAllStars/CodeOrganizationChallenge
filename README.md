# CodeOrganizationChallenge
**By Kars van den Eijnde & Martynas Gestautas**

## Escape Room Framework Usage Instructions

### How to add your own puzzle to the room
1. In the "Main" scene, add a "painting to start puzzle" prefab.
2. In the "Puzzle Loader (Script)" component, fill in the "Scene Name" field with the filename of your puzzle's scene file
2.1. _(Optional)_ If you want your puzzle to be only accessible after completing other puzzles, fill in the "Dependencies" list field with the desired puzzle scene file names
2.2. _(Optional)_ If you want the door to only open after your puzzle has been completed, add your puzzle's scene file name into the "Dependencies" field in the "Door Controller (Script)" component of a door
3. Once your puzzle is completed, use the following line to load back into the main scene and set your puzzle's state as completed: 
```
GameObject.Find("MainController").GetComponent<MainScript>().FinishPuzzle("<scene name goes here>");
```


