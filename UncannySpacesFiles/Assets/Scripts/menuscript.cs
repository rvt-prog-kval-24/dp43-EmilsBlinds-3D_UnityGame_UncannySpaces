using UnityEngine;

public class menuscript : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
