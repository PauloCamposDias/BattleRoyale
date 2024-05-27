using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	void Start()
	{
		GameManager.instance.uiManager = this;
	}
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	
	public void Quit()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
