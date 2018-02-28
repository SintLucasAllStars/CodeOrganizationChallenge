# Team and Project
Tijn van den Broek & Jorrit Slaats
Evolution

# CodeOrganizationChallenge
Assignment for 2nd years Code Organization Challenge. 

## How to submit your work for grading
You should fork this repository. Develop your project on your forked version and when you are done you should submit a pull request. 

## The challenge
The challenge is to develop a framework for a game while prioritising modularity, organization and usability/re-usability of your code.

You should write all the needed classes and create test cases to show your classes actually work as expected.

## The context / the game
You can choose one of the 3 contexts:

### Escape Room
This should be a system that manages rooms, with sets of puzzles. 
* Each room has puzzles, It should be as easy as possible for a programmer to create/add new puzzles and new rooms and add them to the game.
* Within a room, puzzles can have dependencies, for example, you can only try puzzle 2 when puzzle one is completed successfully.
* The puzzles can be anything, including full fledged 2D or 3D mini-games, so each puzzle should load a new scene. When it is completed, it should return to the main room scene exactly as it was when we left it.

### Card game
A card game framework, your system should manage multiple decks of custom cards. 
* It should be as easy as possible for a programmer to create/add new cards to the game.
* There should be a controller that manages how many players there are, which decks they are using, their current hands and who's turn is it.
* Cards should have a value, a type.
* Within a deck, cards should be able to be combined with other cards. Combining two cards will generate a new card with the sum of the two values and one of the types chosen randomly.

### Evolution
A system to manage an evoutionary simulation.
* Little creatures have DNA, Their DNA defines their shape, type and behaviour (How they move through the world and what happens when they meet other creatures).
* It should be as easy as possible for a programmer to create/add new creatures to the game.
* When two creatures meet they can fight or mate.
* If they fight, one of them will die.
* If they mate then a new creature will appear that is a combination of their DNA.
* Each simulation has a World and a set of initial creatures.
* The world has obstacles and food. All Creatures can detect food when they get close enough to it. What they do about it depends on their DNA.

## The deadline
All pull requests should be sent before the end of Friday the 2nd of March 2018.


