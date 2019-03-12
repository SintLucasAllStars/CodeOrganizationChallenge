using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{
    //aparte DNA klas
    //voornamelijk buitenkant van Creature
    // gedrag word bepaald in de klas  van "Bunny"

    
        float color;
        float size;
        float speed;
        float curiosity;
        float aggression;
        float hungerSpeed;

        public bool aanuit;

        public DNA()
        {

        

            //Random everything
            color = Random.value;
            size = Random.Range(1f, 2f);
            speed = Random.Range(1f, 5f);
            curiosity = Random.Range(1f, 10f);
            aggression = Random.Range(1f, 10f);
            hungerSpeed = Random.Range(1f, 5f);
        }

        public DNA(DNA father, DNA mother)
        {
            //randomly mixes values from mother and father.
            color = mateValue(father.color, mother.color);
            size = mateValue(father.size, mother.size);
            speed = mateValue(father.size, mother.size);
            curiosity = mateValue(father.size, mother.size);
            aggression = mateValue(father.aggression, mother.aggression);
            hungerSpeed = mateValue(father.hungerSpeed, mother.hungerSpeed);

        }

        public DNA(DNA father, DNA mother, float mutationProbability)
        {
            //same as the one before but randomly changes some values.

        }




        float mateValue(float val1, float val2)
        {
            float r = Random.value;

            if (r > 0.5)
            {
                return val1;
            }
            else
            {
                return val2;
            }
        }
    }


