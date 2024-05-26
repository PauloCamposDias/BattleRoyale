using UnityEngine;

public class ChildrenUnpacker : MonoBehaviour
{
	void Awake()
	{
		int iterations = transform.childCount;
		for (int i = 0; i < iterations; i++)
		{
			transform.GetChild(0).SetParent(null);
		}
		Destroy(gameObject);
	}
}
