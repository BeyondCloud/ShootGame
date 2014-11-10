using UnityEngine;
using UnityEngine.UI;

using System.Collections;
public class FireBtn: MonoBehaviour 
{
	public GameObject gunBarrelEnd;
	private PlayerShooting playerShooting;

	void Awake()
	{
		playerShooting = gunBarrelEnd.GetComponent<PlayerShooting>();
	
	}
	public void ClickButton(string buttonID){
		playerShooting.Shoot();

	}	


       
}
