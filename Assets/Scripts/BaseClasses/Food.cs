using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public bool poisoness;
    public GameObject mesh;
    private MeshRenderer m_MR;

    // Start is called before the first frame update
    void Start()
    {

        m_MR = mesh.GetComponent<MeshRenderer>();

        if (Random.Range(0, 2) == 1)
        {
            poisoness = true;
            m_MR.material.color = Color.black;
        }
        else
        {
            poisoness = false;
            m_MR.material.color = Color.red;
        }
    }

  
}
