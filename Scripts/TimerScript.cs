using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float timer;

    // [SerializeField] is used on private fields to make them visible in the editor but they're stil private so they can't be
    // accessed by other scripts
    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerDisplay(timer);
    }

    // This function is used to reset the timer. This can be used for the void Start to make sure that the timer always starts
    // at a certain time
    private void ResetTimer()
    {
        timer = 0f;
    }

    // This function updates the timer display
    private void UpdateTimerDisplay(float time)
    {
        // First we need to find the value of the minutes and seconds. If 60 seconds passed it means 1 minute passed so we divde
        // the time by 60. For the seconds we still use the number 60 because they're still 60 seconds but we need to get the rest of the time (the rest is indicated by the %).
        // If 4 seconds passed and we divide it by 60 we'll get 0 but the rest is 4 which is the number that we'll show
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        // We first need to format the time to use the way we want it. We do that by using jokers (represented by the {})
        // {0:00} ---> the first 0 is the placeholder this means that the value shown here will be the 'minutes'
        // {1:00} ---> in this case we have a 1 so here the number of 'seconds' will be shown. After the ':' is how it will show
        // the variables. If the time is 2531 we'll take the first index (2) and use it for the first minute and so on
        string currentTime = string.Format("{0:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();   
        secondSecond.text = currentTime[3].ToString();
    }
}
