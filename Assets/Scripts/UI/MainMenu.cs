using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : UIManager
{
	public Color originalBGColor;
	public Transform[] cameraPositions;
	public Color sideBGColor;
	public TMP_Text title;
	public TMP_Text crowns;
	
	public CharacterColorManager cColor;
	
	public GameObject[] pageContent;
	public GameObject QuitModal;
	public Slider[] colorSliders;
	public Slider[] audioSliders;
	Vector3 dummyColor;
	Camera mainCamera;
	int currentPage;
	
	void Start()
	{
		mainCamera = Camera.main;
		mainCamera.transform.position = cameraPositions[0].position;
		
		SetupInterface();
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			QuitModal.SetActive(!QuitModal.activeInHierarchy);
		}
	}
	
	void SetupInterface()
	{
		Color pColor = PlayerStatsManager.instance.GetPlayerColor();
		cColor.SetColor(pColor);
		
		colorSliders[0].value = pColor.r * 255;
		colorSliders[1].value = pColor.g * 255;
		colorSliders[2].value = pColor.b * 255;
		
		Vector3 volumes = PlayerStatsManager.instance.GetSliderVolumes();
		audioSliders[0].value = volumes.x;
		audioSliders[1].value = volumes.y;
		audioSliders[2].value = volumes.z;
		
		crowns.text = PlayerStatsManager.instance.VictoryCount.ToString();
	}
	
	public void SetCurrentPage(int pageId)
	{
		currentPage = pageId;
		switch (currentPage)
		{
			case 0:
				title.text = "LOBBY";
			break;
			case 1:
				title.text = "VESTIMENTA";
			break;
			case 2:
				title.text = "CONFIGS";
			break;
			case 3:
				title.text = "CREDITOS";
			break;
		}
	}
	
	public void ChangePage(int desiredPage)
	{
		pageContent[currentPage].SetActive(false);
		pageContent[desiredPage].SetActive(true);
		
		LeanTween.move(mainCamera.gameObject, cameraPositions[desiredPage].position, .5f).setEase(LeanTweenType.easeOutElastic);
		switch (desiredPage)
		{
			case 0:
				LeanTween.value(mainCamera.gameObject, SetCameraBGColor, mainCamera.backgroundColor, originalBGColor, .15f);
			break;
			default:
				LeanTween.value(mainCamera.gameObject, SetCameraBGColor, mainCamera.backgroundColor, sideBGColor, .15f);
			break;
		}
	}
	
	void SetCameraBGColor(Color c)
	{
		mainCamera.backgroundColor = c;
	}
	
	public void ChangePlayerColor()
	{
		float r = colorSliders[0].value / 255;
		float g = colorSliders[1].value / 255;
		float b = colorSliders[2].value / 255;
		
		Color color = new Color(r,g,b);
		PlayerStatsManager.instance.SavePlayerColor(color);
		cColor.SetColor(color);
	}
	
	public void HandleVolumeSliders()
	{
		float master = audioSliders[0].value;
		float music = audioSliders[1].value;
		float sfx = audioSliders[2].value;
		
		Vector3 audio = new Vector3(master, music, sfx);
		PlayerStatsManager.instance.SaveSliderVolumes(audio);
		AudioManager.instance.SetMixer(audio);
	}
}
