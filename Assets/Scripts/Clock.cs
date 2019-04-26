using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour 
{
    //References to updateable objects in the scene
    public Transform minuteClockHandTransform;
    public Transform hourClockHandTransform;
    public TMP_Text timeText;

    //The current day
    private float day;
    //Total number of real seconds per in game day
    public float realSecondsPerGameDay = 60.0f;

    //The total hours, minutes, and number of full rotations for the hour arm each day
    public float fullRotationsPerGameDay = 720.0f;
    public float hoursPerDay = 24.0f;
    public float minutesPerHour = 60.0f;

    /// <summary>
    /// Update this instance.
    /// </summary>
    private void Update()
    {
        //The current day time
        day += Time.deltaTime / realSecondsPerGameDay;

        //Normalize the day to show a whole value
        float dayNormalized = day % 1.0f;

        //Rotate the arms on the clock based on the time variables given
        hourClockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * fullRotationsPerGameDay);
        minuteClockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * fullRotationsPerGameDay * hoursPerDay);

        //Get the normalized time and trim it to represent the correct hour and minute
        string hoursString = Mathf.Floor(dayNormalized * 24.0f).ToString("00");
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1.0f) * minutesPerHour).ToString("00");

        //Update the time text to show the correct time based on the variables given
        timeText.text = hoursString + ":" + minutesString;
    }
}
