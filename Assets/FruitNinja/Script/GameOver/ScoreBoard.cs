using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class ScoreBoard : MonoBehaviour
{
    private string filePath;
    private string fileName;
    private static ScoreBoard instance = null;
    private List<ScoreElem> scoreList;
    private int capacityOfScoreBoard = 5;

    public int CurrentScoreId { get; set; }

    void Awake()
    {
        instance = this;
        filePath = Application.dataPath + "/Score/";
        fileName = "score.xml";
        Initialize();
    }

    public void Initialize()
    {
        XmlSerializer xmlHandler = new XmlSerializer(type: typeof(List<ScoreElem>));
        if (Directory.Exists(filePath) == false)
        {
            Directory.CreateDirectory(filePath);
        }
        if (File.Exists(filePath + fileName) == false)
        {
            scoreList = new List<ScoreElem>
            {
                new ScoreElem
                {
                    Date = new DateTime(9999, 12, 31),
                    Score = 0
                }
            };
            FileStream scoreBoardFile = File.Create(filePath + fileName);
            xmlHandler.Serialize(scoreBoardFile, scoreList);
            scoreBoardFile.Close();
            Debug.Log("NoFile!");
        }
        else
        {
            FileStream scoreBoardFile = File.OpenRead(filePath + fileName);
            scoreList = xmlHandler.Deserialize(scoreBoardFile) as List<ScoreElem>;
            Debug.Log("IsFile!");
        }
    }

    public void SaveScoreBoardFile()
    {
        XmlSerializer xmlWriter = new XmlSerializer(scoreList.GetType());
        StreamWriter scoreBoardFile = new StreamWriter(filePath + fileName, false);
        xmlWriter.Serialize(scoreBoardFile, scoreList);
        scoreBoardFile.Close();
    }

    public void SetScoreList(ScoreElem score)
    {
        CurrentScoreId = capacityOfScoreBoard;
        if (score.IsValid)
        {
            if (scoreList.Count == 0)
            {
                scoreList.Add(score);
            }
            else
            {
                foreach (ScoreElem scoreInList in scoreList)
                {
                    if (score > scoreInList)
                    {
                        CurrentScoreId = scoreList.IndexOf(scoreInList);
                        break;
                    }
                }
                scoreList.Insert(CurrentScoreId, score);
                if (scoreList.Count > capacityOfScoreBoard + 1)
                {
                    scoreList.RemoveAt(capacityOfScoreBoard);
                }

            }
        }
        SaveScoreBoardFile();
    }

    public static ScoreBoard Instance
    {
        get
        {
            return instance;
        }
    }

    public List<ScoreElem> ScoreList
    {
        get
        {
            return scoreList;
        }
    }
}