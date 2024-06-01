using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ElapsedTime : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI elapsedTimeText;

    void Start()
    {
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        string minutesText = (minutes == 1) ? "minute" : "minutes";

        string secondsText = (seconds == 1) ? "second" : "seconds";

        if (minutes > 0)
        {
            elapsedTimeText.text = string.Format("You escaped in {0} {1} and {2} {3}", minutes, minutesText, seconds, secondsText);
        }
        else
        {
            elapsedTimeText.text = string.Format("You escaped in {0} {1}", seconds, secondsText);
        }
    }
}
