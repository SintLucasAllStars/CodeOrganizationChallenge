Hi, and sorry for the late pull. (I was sick and emailed you about it)


So what was my experience with this assignment?

To be fair I thought it was pretty hard. Because it was hard I did learn a lot of things and 
how usefull classes can be. I first thought that the puzzle assignment would be easy.
But after I jumped into it there were a lot of things I had problems with.

The first thing was saving the scene.
I fixed it by using singletons to save the important props in the mainscene.
And when the scene changes just setactive(false).

Because I was using clones it was hard making the portals work (If puzzle 1 is complete
you can enter 2 etc). I managed to fix it by saving the static int in a private int for every
portal.

Anyways I completed the assignment and (hope) I used the classes correctly.

KNOWN BUGS:

1: Sometimes when starting the game portals will spawn in eachother.

2: In the EscapeRoom puzzle you wont die when the room gets too small.


Also when finishing all the available puzzles nothing happens.
