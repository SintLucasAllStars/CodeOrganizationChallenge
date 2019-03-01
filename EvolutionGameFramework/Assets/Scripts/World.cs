using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
	public GameObject m_CParent, m_CPrefab;
	public GameObject m_FParent, m_FPrefab;

	[Header("Initial")]
	public int m_SpawnAmount;

	private void Start()
	{
		for (int i = 0; i < m_SpawnAmount; i++)
		{
			GameObject creature = Instantiate(m_CPrefab, new Vector3(Random.Range(-22f, 22f), 0.15f, Random.Range(-12f, 12f)), Quaternion.identity, m_CParent.transform);
			creature.name = "Creature";
			creature.GetComponent<Creature>().SetUpR();
			Debug.Log("Iterations");
		}
	}

	private IEnumerator SpawnFood()
	{
		while (Application.isPlaying)
		{
			yield return new WaitForSeconds(Random.Range(3f, 6f));
			GameObject food = Instantiate(m_FPrefab, new Vector3(Random.Range(-22f, 22f), 0.15f, Random.Range(-12f, 12f)), Quaternion.identity, m_FParent.transform);
			food.name = "Food";
		}
	}

	public void MakeChild(Vector3 _pos, Genes _Dad, Genes _Mom)
	{
		GameObject creature = Instantiate(m_CPrefab, _pos, Quaternion.identity, m_CParent.transform);
		creature.name = "CreatureChild";
		creature.GetComponent<Creature>().SetUpP(_Dad, _Mom);
		Debug.Log("Iterations");
	}
}
