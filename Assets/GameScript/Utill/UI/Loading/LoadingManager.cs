using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : SingletonObject<LoadingManager>
{

    [SerializeField]
    Image progressBar;
    [SerializeField]
    Text progressText;
    [SerializeField]
    Text subText;
    [SerializeField]
    Sprite doneProgress;

    private static string nextScene;
    private static string context;
    private static List<ILoader> loaders;



    private void Start()

    {
        
        StartCoroutine(LoadScene(loaders));

       
    }

    


    public static void LoadScene(string sceneName, string context="씬 로딩 중",List<ILoader> loaders=null)
    {

        nextScene = sceneName;
        LoadingManager.context = context;
        LoadingManager.loaders = loaders;
        SceneManager.LoadScene("Progress");

     

    }
    public void setText(string LoadContext)

    {
        context = LoadContext;
    }

    IEnumerator LoadScene(List<ILoader> loaders=null)

    {

        yield return null;

        Debug.Log("nextScene: "+ nextScene);
        float timer = 0.0f;


        if (loaders !=null)
        {
            Debug.Log("로더 실행");

            foreach(ILoader loader in loaders)
            {
                loader.Clear();
                progressBar.fillAmount = 0;
                progressText.text = loader.getContext();
                timer = 0.0f;
              

                Debug.Log("loader 테스트" + loader.IsDone());



                loader.Load();


                Debug.Log("loader 테스트" + loader.IsDone());


                while (!loader.IsDone())
                {
     
                    yield return null;
                    timer =(timer+Time.deltaTime)*0.1f;
                    progressText.text = loader.getContext();
                   // Debug.Log("로더 루프 확인"+ loader.isDone());
                    if (loader.IsDone())
                    {
                        progressBar.fillAmount = 1.0f;
                        subTextProgress(progressBar.fillAmount,100);
                        
                        break;
                       
                    }
                    else
                    {
                        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, 0.08f);
                        subTextProgress(progressBar.fillAmount,100);
                    }

                    
                }
                
                Debug.Log("로더 종료");
            }

            loaders.Clear();
        }



        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        op.allowSceneActivation = false;


        progressBar.fillAmount = 0;
        progressText.text = context;
        timer = 0.0f;

        while (!op.isDone)

        {

            yield return null;


            timer += Time.deltaTime;

            progressText.text = context;
            if (op.progress < 0.9f)

            {

                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);//거리와 거리 사이의 시간 계산
                Debug.Log(op.progress);
                if (progressBar.fillAmount >= op.progress)

                {
              
                    timer = 0f;

                }

            }

            else

            {
                Debug.Log(op.progress);
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                subTextProgress(progressBar.fillAmount, 100);

                if (progressBar.fillAmount == 1.0f)

                {
                    Debug.Log("마지막?");
                    
                    progressBar.sprite = doneProgress;
                    progressText.text = "Done";
                    subTextProgress(1.11f, 111);

                    Thread.Sleep(1000);
                    yield return null;
                    Thread.Sleep(1000);
                    op.allowSceneActivation = true;
                    yield break;

                }

            }

        }

 

    }

    private void subTextProgress(float number,int max)
    {

         subText.text = "(" + Convert.ToInt32(number * 100) + " / "+max+")";

    }



}
