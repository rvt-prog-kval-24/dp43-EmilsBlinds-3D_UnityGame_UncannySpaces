using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ButtonOption : MonoBehaviour
{

	public FirstPersonControllerCustom playerController;
	public PauseScript PauseScript;

	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void MapSelect()
	{
		SceneManager.LoadScene(1);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Map1()
	{
		SceneManager.LoadScene(2);
		Time.timeScale = 1;
		playerController.canMove = true;
		PauseScript.Resume();

	}

	public void Map2()
	{
		SceneManager.LoadScene(3);
		Time.timeScale = 1;
		playerController.canMove = true;
		PauseScript.Resume();
	}

	public void Map3()
	{
		SceneManager.LoadScene(4);
		Time.timeScale = 1;
		playerController.canMove = true;
		PauseScript.Resume();
	}

	public void Controls()
	{
		SceneManager.LoadScene(7);
		PauseScript.Resume();
	}

	public void Tutorial()
	{
		SceneManager.LoadScene(8);
		PauseScript.Resume();
	}

	public void Exit()
	{
		Application.Quit();
	}
}
