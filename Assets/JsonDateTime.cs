using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonDateTime : ISerializationCallbackReceiver
{
    [NonSerialized]
    public DateTime DateTime;

    [SerializeField]
    private int millisecond;
    [SerializeField]
    private int second;
    [SerializeField]
    private int minute;
    [SerializeField]
    private int hour;
    [SerializeField]
    private int day;
    [SerializeField]
    private int month;
    [SerializeField]
    private int year;

    public JsonDateTime()
    {
        DateTime = DateTime.MinValue;
        OnBeforeSerialize();
    }

    public JsonDateTime(DateTime dateTime)
    {
        DateTime = dateTime;
        OnBeforeSerialize();
    }

    public void OnBeforeSerialize()
    {
        year = DateTime.Year;
        month = DateTime.Month;
        day = DateTime.Day;
        hour = DateTime.Hour;
        minute = DateTime.Minute;
        second = DateTime.Second;
        millisecond = DateTime.Millisecond;
    }

    public void OnAfterDeserialize()
    {
        DateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
    }

    public override string ToString()
    {
        return DateTime.ToString();
    }
}
