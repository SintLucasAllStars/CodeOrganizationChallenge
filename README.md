# Project
Kylian Dekker
* Evolution and DNA - Spore is one of my childhood games, so I choose this one because I admire the features they have in the game.

#Instructions
To make your own creature you must make a script that inherits from the Creature script. Take a look at the example creatures
in the example folder. 

#What is done and what is not done
DNA is done with a lot of different variables like the name of the species, the speed, the strength, etc. Creatures fight each other and can mate each other.
Creatures can also refuse mating with other creatures, there is a random chance that this happens. Creatures can get hungry as well. Creatures can be Herbivorous, Carnivorous or Omnivorous. 
Depending on this, creatures who are Carnivorous might attack other creatures when they are hungry, even one of their own.
Herbivorous creatures will always look for plants around the map. These have the tag "Food" and you can just add colliders to different prefabs if you want and change the tag.
I have not done anything with age. It was not really a requirement, but I tried implementing this feature. I think all the features described at the lower part of this readme file are implemented.

#What I learned
It was fun working on this project. I initially worked with a type system, but figured out it was not really the best way to get what I wanted to achieve with this project.

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


