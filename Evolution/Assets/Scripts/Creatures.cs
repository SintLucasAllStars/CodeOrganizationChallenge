using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour
{

    public GameObject[] m_shapes;
    public int shapeNum;
    private float m_speed;

    DNA creature;
    public Genes myGenes;
    public GameObject m_childPrefab;
    public float m_libido;

    public MeshRenderer m_mr;

    
    // Start is called before the first frame update
    void Start()
    {

        m_speed = Random.Range(0.5f, 2);

        Debug.Log(this.myGenes.m_gender);

        m_mr = GetComponent<MeshRenderer>();
        m_mr.material.color = myGenes.color;

        

    }

    // Update is called once per frame
    void Update()
    {

        Move();

        if(m_libido > 0)
        {
            m_libido -= 1 * Time.deltaTime;
        }

    }

    void Move()
    {

        GetComponent<Rigidbody>().AddForce(new Vector3(x: Random.Range(-1f, 1f), y: 0, z: Random.Range(-1f, 1f)).normalized * 100 * m_speed);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag != "World" && m_libido <= 0)
        {
            Creatures other = collision.gameObject.GetComponent<Creatures>();

            if (other.myGenes.m_gender != this.myGenes.m_gender) // If the genders are not the same, make a baby.
            {

                int t = Random.Range(0, 11);

                // The mother is guaranteed to spawn a child, but the father has a small chance to produce a twin
                if (this.myGenes.m_gender == Gender.Female || t == 1)
                {
                    m_libido = Random.Range(6, 9);

                    Debug.Log("Sex Time");

                    Creatures m_child = gameObject.GetComponent<Creatures>();
                    m_childPrefab.GetComponent<Creatures>().m_libido = 18;
                    m_childPrefab.GetComponent<Creatures>().myGenes.m_gender = ((Gender)Random.Range(0, 2));
                    m_childPrefab.GetComponent<Creatures>().myGenes.m_mood = ((Behaviour)Random.Range(0, 2));

                    if (t == 0)
                    {

                        m_childPrefab.GetComponent<Creatures>().myGenes.color = Random.ColorHSV(hueMin: 0f, hueMax: 1f, saturationMin: 0.5f, saturationMax: 1f, valueMin: 0.25f, valueMax: 1f);

                    }
                    else
                    {
                        m_childPrefab.GetComponent<Creatures>().myGenes.color = Color.Lerp(this.gameObject.GetComponent<Renderer>().material.color, other.gameObject.GetComponent<Renderer>().material.color, Mathf.PingPong(Time.time, 1));

                    }

                    Instantiate(m_childPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                }

                Debug.Log("It's a miracle!");

            }
            else if (this.myGenes.m_mood == Behaviour.Hostile) // If this object's behaviour is hostile, the other person dies.
            {

                Debug.Log("Someone got into a fight and died.");

                Destroy(collision.gameObject);
            }
        }

    }

    

}
