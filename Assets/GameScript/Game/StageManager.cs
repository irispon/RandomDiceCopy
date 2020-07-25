using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : SingletonObject<StageManager>
{
   private int stageLevel=0;
    [SerializeField]
    int maxLevel;
    List<Spwan> spwans;

    [SerializeField]
    TextMeshProUGUI level, timer;
     public GameObject Out;

  
   public override void Init()
    {
        if(spwans ==null)
        spwans = new List<Spwan>();

    }

    public void Start()
    {
        maxLevel = maxLevel - 1;
        StartCoroutine(Timer());
    }

    private void LevelScaleing()
    {

        if (stageLevel<maxLevel)
        {
            LevelUP();
            StartCoroutine(Timer());
        }
        else
        {

            Debug.Log("stageLevel>maxLevel");
            foreach(Spwan spwan in spwans)
            {
                
                spwan.SpwanBoss();
           
            }
            StartCoroutine(Timer(30));
        }
   



    }
    IEnumerator Timer(int time =15)
    {
        
        while (time >= 0)
        {
            if (time < 10)
            {
                timer.text = "Time: 0" + time.ToString();
            }
            else
            {
                timer.text = "Time: " + time.ToString();
            }
            yield return new WaitForSeconds(1);
            time--;

            
        }
       
        LevelScaleing();
    }

    public void NextStage()
    {
        stageLevel = maxLevel;
        maxLevel += maxLevel;
        StartCoroutine(Timer());
    }
    public void Join(Spwan spwan)
    {
        if (spwans == null)
        {
            spwans = new List<Spwan>();
        }
        spwans.Add(spwan);
    }

    public void LevelUP()
    {
        stageLevel++;
        level.text = "Level: " + (stageLevel+1).ToString();
        foreach (Spwan spwan in spwans)
        {
            spwan.SetEnemy(stageLevel);
        }
        
    }

    public void Quite()
    {
        Time.timeScale = 1;
    
          #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
          #endif
        Application.Quit(); //어플리케이션 종료

    }

   public void ReGame()
    {
        LoadingManager.LoadScene("Game", "게임 다시 시작중");
        Time.timeScale = 1;
    }
}
