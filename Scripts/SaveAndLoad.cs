using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Используется на объекте Canvas
public class SaveAndLoad : MonoBehaviour
{
	[SerializeField]
	private GameObject[] allObjects;
	[SerializeField]
	private List<GameObject> warriors;
	[SerializeField]
	private List<GameObject> slaves;
	[SerializeField]
	private List<GameObject> enemies;
	public GameObject warrior;
	public GameObject slave;
	public GameObject enemy;
	[SerializeField]
	private MainStocks mainStocks;
	
	void Start()
	{
		mainStocks = Camera.main.GetComponent<MainStocks>(); //Получение информации о ресурсах
	}
	
	//Сохранение игры
	public void Save()
	{
		allObjects = SceneManager.GetActiveScene().GetRootGameObjects(); //Поиск всех объектов на сцене
		
		warriors.Clear();
		slaves.Clear();
		enemies.Clear();
		
		//Распределение всех объектов по профессиям
		foreach (GameObject i in allObjects)
		{
			if (i.GetComponent<WarriorBehavior>())
			{
				warriors.Add(i);
			}
			
			if (i.GetComponent<SlaveBehavior>())
			{
				slaves.Add(i);
			}
			
			if (i.GetComponent<EnemyBehavior>())
			{
				enemies.Add(i);
			}
		}
		
		//Сохранение текущего количества золота
		PlayerPrefs.SetFloat("Gold", mainStocks.gold);
		
		//Сохранение определенных типов юнитов
		SaveUnit(warriors, "Warrior");
		SaveUnit(slaves, "Slave");
		SaveUnit(enemies, "Enemy");
	}
	
	//Загрузка игры
	public void Load()
	{
		allObjects = SceneManager.GetActiveScene().GetRootGameObjects(); //Поиск всех объектов на сцене
		
		warriors.Clear();
		slaves.Clear();
		enemies.Clear();
		
		//Распределение всех объектов по профессиям
		foreach (GameObject i in allObjects)
		{
			if (i.GetComponent<WarriorBehavior>())
			{
				warriors.Add(i);
			}
			
			if (i.GetComponent<SlaveBehavior>())
			{
				slaves.Add(i);
			}
			
			if (i.GetComponent<EnemyBehavior>())
			{
				enemies.Add(i);
			}
		}
		
		//Загрузка и обновление показателя текущего количества золота
		mainStocks.SetGold(PlayerPrefs.GetFloat("Gold"));
		
		//Загрузка определенных типов юнитов
		LoadUnit(warriors, warrior, "Warrior");
		LoadUnit(slaves, slave, "Slave");
		LoadUnit(enemies, enemy, "Enemy");
	}
	
	//Сохранение юнитов определенной профессии
	void SaveUnit(List<GameObject> units, string unitsName)
	{
		//Сохранение количества юнитов определенной профессии
		PlayerPrefs.SetInt("" + unitsName + "Count", units.Count);
		
		//Сохранение статов и позиции юнитов определенной профессии
		for (int i=0; i<units.Count; i++)
		{
			PlayerPrefs.SetFloat("" + unitsName + "PosX" + i, units[i].transform.position.x);
			PlayerPrefs.SetFloat("" + unitsName + "PosY" + i, units[i].transform.position.y);
			PlayerPrefs.SetFloat("" + unitsName + "PosZ" + i, units[i].transform.position.z);
			PlayerPrefs.SetFloat("" + unitsName + "Health" + i, units[i].GetComponent<Stats>().health);
		}
	}
	
	//Загрузка юнитов определенной профессии
	void LoadUnit (List<GameObject> units, GameObject unit, string unitName)
	{
		//Очистить поле от юнитов определенной профессии
		foreach (GameObject i in units)
		{
			Destroy(i);
		}
		
		GameObject currentObject;
		
		//Расставление юнитов определенной профессии
		for (int i=0; i<PlayerPrefs.GetInt("" + unitName + "Count"); i++)
		{
			currentObject = Instantiate(unit, new Vector3(PlayerPrefs.GetFloat("" + unitName + "PosX" + i), 
			PlayerPrefs.GetFloat("" + unitName + "PosY" + i), 
			PlayerPrefs.GetFloat("" + unitName + "PosZ" + i)), Quaternion.identity);
			currentObject.GetComponent<Stats>().health = PlayerPrefs.GetFloat("" + unitName + "Health" + i);
		}
	}
}
