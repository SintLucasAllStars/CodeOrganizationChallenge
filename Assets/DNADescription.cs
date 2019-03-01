using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNADescription : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		CreatureManager.Instance.RegisterCreature(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
