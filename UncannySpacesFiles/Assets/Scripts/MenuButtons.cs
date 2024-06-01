using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class MenuButtons : MonoBehaviour
{
	public GameObject PauseMenu, SettingsMenu, ControlsMenu;
	public FirstPersonControllerCustom playerController;
	public GameObject CameraOverlay, StaminaCanvas;


	public void Resume()
	{
		Debug.Log("Resumed");
        PauseMenu.SetActive(false);
		SettingsMenu.SetActive(false);
		Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		playerController.canMove = true;
		CameraOverlay.SetActive(true);
		StaminaCanvas.SetActive(true);
	}

	public void MapSelect()
	{
		SceneManager.LoadScene(1);
	}


	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Settings()
    {
		PauseMenu.SetActive(false);
		SettingsMenu.SetActive(true);
	}

	public void Back()
	{
		PauseMenu.SetActive(true);
		SettingsMenu.SetActive(false);
		ControlsMenu.SetActive(false);
	}

	public void Controls()
	{
		ControlsMenu.SetActive(true);
		PauseMenu.SetActive(false);
		SettingsMenu.SetActive(false);
	}
}
