using UnityEngine;
using System;
using System.Collections;

public class ScoreElem
{
    public int Score { get; set; }
    public DateTime Date { get; set; }

    public bool IsValid
    {
        get
        {
            return Score != 0;
        }
    }

    public static bool operator >(ScoreElem s1, ScoreElem s2)
    {
        if (s1.Score != s2.Score)
        {
            return (s1.Score > s2.Score);
        }
        else
        {
            return (s1.Date < s2.Date);
        }
    }
    
    public static bool operator <(ScoreElem s1, ScoreElem s2)
    {
        if (s1.Score != s2.Score)
        {
            return (s1.Score < s2.Score);
        }
        else
        {
            return (s1.Date > s2.Date);
        }
    }
}