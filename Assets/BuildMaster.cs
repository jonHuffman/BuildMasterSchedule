using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMaster : MonoBehaviour
{
    public Text date;
    public Text firstName;
    public Text secondName;
    public Text thirdName;
    public Text fourthName;

    // Start is called before the first frame update
    void Awake()
    {
        TextAsset scheduleJson = Resources.Load<TextAsset>("Schedule");
        Schedule schedule = JsonUtility.FromJson<Schedule>(scheduleJson.text);

        int weeksSinceStart = (int)((DateTime.Now - schedule.startDate.DateTime).TotalDays / 7);
        SetBuildMaster(weeksSinceStart, schedule.people);

        date.text = DateTime.Today.ToShortDateString();
    }

    private void SetBuildMaster(int weeksSinceStart, string[] people)
    {
        int buildMasterIndex = weeksSinceStart % people.Length;
        firstName.text = people[SafeIndex(buildMasterIndex, people.Length)];
        secondName.text = people[SafeIndex(buildMasterIndex + 1, people.Length)];
        thirdName.text = people[SafeIndex(buildMasterIndex + 2, people.Length)];
        fourthName.text = people[SafeIndex(buildMasterIndex + 3, people.Length)];
    }

    private int SafeIndex(int targetIndex, int maxIndex)
    {
        if (targetIndex >= maxIndex)
        {
            targetIndex = targetIndex % maxIndex;
        }

        return targetIndex;
    }
}
