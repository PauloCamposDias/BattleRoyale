using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static PlayerPrefsManager instance;
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
	
	public void SaveValue(string key, int value)
	{
		PlayerPrefs.SetInt(key,value);
		PlayerPrefs.Save();
	}
	public void SaveValue(string key, float value)
	{
		PlayerPrefs.SetFloat(key,value);
		PlayerPrefs.Save();
	}
	public void SaveValue(string key, string value)
	{
		PlayerPrefs.SetString(key,value);
		PlayerPrefs.Save();
	}
	
	public int LoadValueI(string key)
	{
		if(PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetInt(key);
		}
		else
		{
			throw new KeyNotFoundException($"{key} does not exist in Player Prefs");
		}
	}
	public float LoadValueF(string key)
	{
		if(PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetFloat(key);
		}
		else
		{
			throw new KeyNotFoundException($"{key} does not exist in Player Prefs");
		}
	}
	public string LoadValueS(string key)
	{
		if(PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetString(key);
		}
		else
		{
			throw new KeyNotFoundException($"{key} does not exist in Player Prefs");
		}
	}
	
	public bool HasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}
	
	public void DeleteKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}
	
	public void ClearPrefs()
	{
		PlayerPrefs.DeleteAll();
	}
}
