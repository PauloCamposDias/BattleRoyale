using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorManager : MonoBehaviour
{
	[SerializeField] Renderer renderer;
	public void SetColor(Color color)
	{
		renderer.material.SetColor("_FabricioColor", color);
	}
	
	public void SetRandomColor()
	{
		Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		SetColor(color);
	}
}
