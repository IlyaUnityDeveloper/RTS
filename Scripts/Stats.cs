using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Используется на объектах Warrior, Slave и Enemy
public class Stats : MonoBehaviour
{
    public float health = 4.0f;
	
	//Нанесение урона объекту
	public void TakeDamage ()
	{
		health -= Time.deltaTime;
		
		if (health <= Mathf.Epsilon)
		{
			Destroy(gameObject);
		}
	}
}
