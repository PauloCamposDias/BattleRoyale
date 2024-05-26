using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
	public static PlayerStatsManager instance;
	public int VictoryCount;
	
	void Awake()
	{
		if(instance != null  && instance != this)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}
		transform.SetParent(null);
		DontDestroyOnLoad(gameObject);
	}
	
	void Start()
	{
		try
		{
			VictoryCount = PlayerPrefsManager.instance.LoadValueI("Victory");			
		}
		catch (KeyNotFoundException)
		{
			PlayerPrefsManager.instance.SaveValue("Victory", 0);
		}
	}
	
	public Color GetPlayerColor()
	{
		try
		{
			float r = PlayerPrefsManager.instance.LoadValueF("PColorR");
			float g = PlayerPrefsManager.instance.LoadValueF("PColorG");
			float b = PlayerPrefsManager.instance.LoadValueF("PColorB");
		
			return new Color(r,g,b);			
		}
		catch (KeyNotFoundException)
		{
			SavePlayerColor(Color.white);
			return Color.white;
		}
		
	}
	
	public void AddVictory()
	{
		VictoryCount ++;
		PlayerPrefsManager.instance.SaveValue("Victory", VictoryCount);
	}
	
	public void SavePlayerColor(Color c)
	{
		PlayerPrefsManager.instance.SaveValue("PColorR", c.r);
		PlayerPrefsManager.instance.SaveValue("PColorG", c.g);
		PlayerPrefsManager.instance.SaveValue("PColorB", c.b);
	}
	
	public Vector3 GetSliderVolumes()
	{
		try
		{
			float master = PlayerPrefsManager.instance.LoadValueF("MasterVol");
			float music = PlayerPrefsManager.instance.LoadValueF("MusicVol");
			float sfx = PlayerPrefsManager.instance.LoadValueF("SFXVol");
			
			return new Vector3(master,music,sfx);
		}
		catch (KeyNotFoundException)
		{
			SaveSliderVolumes(Vector3.zero);
			return Vector3.zero;
		}
		
	}
	
	public void SaveSliderVolumes(Vector3 volumes)
	{
		PlayerPrefsManager.instance.SaveValue("MasterVol", volumes.x);
		PlayerPrefsManager.instance.SaveValue("MusicVol", volumes.y);
		PlayerPrefsManager.instance.SaveValue("SFXVol", volumes.z);
	}
}
