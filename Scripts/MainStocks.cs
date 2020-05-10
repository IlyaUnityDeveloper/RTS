using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Используется на объекте MainCamera
public class MainStocks : MonoBehaviour
{
    public Text goldCount; //Объект, на котором отображается запасы золота
	public float gold = 0f;
	
	void Start()
	{
		goldCount.text = "Золото: "+Mathf.Floor(gold);
	}
	
	//Пополнить казну золотом
	public void IncreaseGold ()
	{
		gold += Time.deltaTime;
		goldCount.text = "Золото: "+Mathf.Floor(gold);
	}
}
