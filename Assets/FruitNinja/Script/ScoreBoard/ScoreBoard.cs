using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class ScoreBoard : MonoBehaviour
{
    private string filePath;
    private EntityType gameType;
    private string timeGameScore = "TimeGameScore.xml";
    private string lifeGameScore = "LifeGameScore.xml";
    private static ScoreBoard instance = null;
    private List<ScoreElem> scoreList;
    private int capacityOfScoreBoard = 5;

    //public int MaxScore { get; set; }
    public int CurrentScoreId { get; set; }

    void Awake()
    {
        instance = this;
        filePath = Application.dataPath + "/Score/";
        gameType = Singleton.gameType;
        Initialize();
    }

    private void Initialize()
    {
        XmlSerializer xmlHandler = new XmlSerializer(type: typeof(List<ScoreElem>));
        if (Directory.Exists(filePath) == false)
        {
            Directory.CreateDirectory(filePath);
        }
        if (gameType == EntityType.TimeGamePanelEntity)
        {
            if (File.Exists(filePath + timeGameScore) == false)
            {
                scoreList = new List<ScoreElem>{
                    new ScoreElem{
                        Date = new DateTime(9999, 12, 31),
                        Score = 0
                    }
                };
                FileStream scoreBoardFile = File.Create(filePath + timeGameScore);
                xmlHandler.Serialize(scoreBoardFile, scoreList);
                scoreBoardFile.Close();
                Debug.Log("NoFile!");
            }
            else
            {
                FileStream scoreBoardFile = File.OpenRead(filePath + timeGameScore);
                scoreList = xmlHandler.Deserialize(scoreBoardFile) as List<ScoreElem>;
                scoreBoardFile.Close();
                //MaxScore = scoreList[0].Score;
                Debug.Log("IsFile!");
            }
        }
        else if (gameType == EntityType.LifeGamePanelEntity)
        {
            if (File.Exists(filePath + lifeGameScore) == false)
            {
                scoreList = new List<ScoreElem>
                {
                    new ScoreElem
                    {
                        Date = new DateTime(9999, 12, 31),
                        Score = 0
                    }
                };
                FileStream scoreBoardFile = File.Create(filePath + lifeGameScore);
                xmlHandler.Serialize(scoreBoardFile, scoreList);
                scoreBoardFile.Close();
                Debug.Log("NoFile!");
            }
            else
            {
                FileStream scoreBoardFile = File.OpenRead(filePath + lifeGameScore);
                scoreList = xmlHandler.Deserialize(scoreBoardFile) as List<ScoreElem>;
                scoreBoardFile.Close();
                //MaxScore = scoreList[0].Score;
                Debug.Log("IsFile!");
            }

        }
        //else
        //{
        //    //FileStream scoreBoardFile = File.OpenRead(filePath + timegames);
        //    //scoreList = xmlHandler.Deserialize(scoreBoardFile) as List<ScoreElem>;
        //    Debug.Log("IsFile!");
        //}
    }

    private void SaveScoreBoardFile()
    {
        XmlSerializer xmlWriter = new XmlSerializer(scoreList.GetType());
        //StreamWriter scoreBoardFile = new StreamWriter(filePath + fileName, false);
        //xmlWriter.Serialize(scoreBoardFile, scoreList);
        //scoreBoardFile.Close();
        StreamWriter scoreBoardFile;
        switch (gameType)
        {
            case EntityType.TimeGamePanelEntity:
                scoreBoardFile = new StreamWriter(filePath + timeGameScore, false);
                xmlWriter.Serialize(scoreBoardFile, scoreList);
                scoreBoardFile.Close();
                break;
            case EntityType.LifeGamePanelEntity:
                scoreBoardFile = new StreamWriter(filePath + lifeGameScore, false);
                xmlWriter.Serialize(scoreBoardFile, scoreList);
                scoreBoardFile.Close();
                break;
        }
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