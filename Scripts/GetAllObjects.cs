using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Используется на объекте MainCamera
public class GetAllObjects : MonoBehaviour
{
    [SerializeField]
	private GameObject[] allObjects;
	public List<GameObject> selectable;
	public List<GameObject> ourunit;
	public List<GameObject> mines;
	public List<GameObject> enemies;

	void Update()
	{
		allObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		
		//Определение объектов по профессии
		selectable.Clear();
		ourunit.Clear();
		mines.Clear();
		enemies.Clear();
		
		foreach (GameObject i in allObjects)
		{
			if (i.GetComponent<Selectable>())
			{
				selectable.Add(i);
			}
			
			if (i.GetComponent<OurUnit>())
			{
				ourunit.Add(i);
			}
			
			if (i.GetComponent<MineBehavior>())
			{
				mines.Add(i);
			}
			
			if (i.GetComponent<EnemyBehavior>())
			{
				enemies.Add(i);
			}
		}
	}
}
