using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public AudioMixer mixer;
	[Header("Music")]
	[SerializeField] private AudioClip[] musicClips;
	private AudioSource musicSource;
	
	
	[Header("2D SFX")]
	[SerializeField] private GameObject sfxSourcePrefab2D;
	[SerializeField] private AudioClip[] sfx2DClips;
	[SerializeField] private int sourceAmount2D;
	private List<GameObject> source2DPool = new();
	
	[Header("3D SFX")]
	[SerializeField] private GameObject sfxSourcePrefab3D;
	[SerializeField] private AudioClip[] sfx3DClips;
	[SerializeField] private int sourceAmount3D;
	private List<GameObject> source3DPool = new();

	public static AudioManager instance {get; private set;}
	
	void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}
		transform.SetParent(null);
	}
	
	void Start()
	{
		for (int i = 0; i < sourceAmount2D; i++)
		{
			GameObject source = Instantiate(sfxSourcePrefab2D);
			source.SetActive(false);
			source2DPool.Add(source);
		}
		for (int i = 0; i < sourceAmount3D; i++)
		{
			GameObject source = Instantiate(sfxSourcePrefab3D);
			source.SetActive(false);
			source3DPool.Add(source);
		}
		
		musicSource = GetComponent<AudioSource>();
		if(musicClips.Length > 0)
		{
			ChangeMusic(0);
		}
	}
	
	public void ChangeMusic(int musicId)
	{
		musicSource.Stop();
		musicSource.clip = musicClips[musicId];
	}
	
	public void TryPlay2DEffect(int sfxId)
	{
		for (int i = 0; i < source2DPool.Count; i++)
		{
			if(!source2DPool[i].activeInHierarchy)
			{
				AudioSource source = source2DPool[i].GetComponent<AudioSource>();
				source.clip = sfx2DClips[sfxId];
				source.gameObject.SetActive(true);
				break;
			}
		}
	}
	
	public void TryPlay3DEffect(int sfxId, Vector3 audioPos)
	{
		for (int i = 0; i < source2DPool.Count; i++)
		{
			if(!source2DPool[i].activeInHierarchy)
			{
				AudioSource source = source2DPool[i].GetComponent<AudioSource>();
				source.clip = sfx2DClips[sfxId];
				source.gameObject.transform.position = audioPos;
				source.gameObject.SetActive(true);
				break;
			}
		}
	}
	
	public void SetMixer(Vector3 audioValues)
	{
		mixer.SetFloat("MasterVol", audioValues.x);
		mixer.SetFloat("MusicVol", audioValues.y);
		mixer.SetFloat("SFXVol", audioValues.z);
	}
}
