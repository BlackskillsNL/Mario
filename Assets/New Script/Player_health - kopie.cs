using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Player_health : MonoBehaviour
{

	public int health;
	

	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.y < -7)
		{
			Die();
		}

	}
		

    void Die()
	{
		SceneManager.LoadScene ("level1");
	}
}
