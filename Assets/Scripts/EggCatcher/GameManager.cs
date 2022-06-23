using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameEnd;
    public static GameManager inst = null;
    public Transform BeginPosGeneratorEgg;
    public Transform EndPosGeneratorEgg;
    public List<GameObject> Eggs;
    [SerializeField]
    protected float noiseTime = 1f;
    [SerializeField]
    protected float generateEggsTime;
    protected float generateEggsTimeCount = 1;
    [SerializeField]
    protected float gameTime = 30f;
    protected int gameTimeCount = 30;
    protected int oldGameTimeCount = 31;
    [SerializeField]
    protected TMP_Text scoreText;
    [SerializeField]
    protected TMP_Text timeText;
    [SerializeField]
    protected TMP_Text banner;

    bool gameStart = true;
    protected Vector2 oldPosGenerate = Vector2.zero;
    protected int ratio = 0;

    private int score = 0;
    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
            return;
        }
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Basket.OnAddScore += AddScore;
        ratio = Mathf.RoundToInt(Eggs.Count * (3f / 5));
        banner.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart)
        {
            banner.text = " Your Score: " + score;
            banner.gameObject.SetActive(true);
            OnGameEnd.Invoke();
            return;
        }

        if (generateEggsTimeCount <= 0)
        {
            GenerateEgg();
            generateEggsTimeCount = generateEggsTime + UnityEngine.Random.Range(-noiseTime, noiseTime);
        }
        else
        {
            generateEggsTimeCount -= Time.deltaTime;
        }
        UpdateGameTime();
    }

    private void UpdateGameTime()
    {
        gameTime -= Time.deltaTime;
        gameTimeCount = Mathf.RoundToInt(gameTime);
        if(gameTimeCount != oldGameTimeCount)
        {
            oldGameTimeCount = gameTimeCount;
            timeText.text = "Time: " + gameTimeCount;

            if(gameTimeCount <= 0)
            {
                gameStart = false;
            }
        }
    }

    private Vector2 GetGeneratePosEgg()
    {
        Vector2 posGenerate;
        do
        {
            float x = UnityEngine.Random.Range(BeginPosGeneratorEgg.position.x, EndPosGeneratorEgg.position.x);
            float y = BeginPosGeneratorEgg.position.y;
            posGenerate = new Vector2(x, y);
        }
        while ((posGenerate - oldPosGenerate).magnitude < 2);

        oldPosGenerate = posGenerate;
        
        return posGenerate;
    }

    private GameObject GetItem()
    {
        int value = UnityEngine.Random.Range(0, 100);
        int index;
        if (value < 70)
        {
            index = UnityEngine.Random.Range(0, ratio);
            //Debug.Log("OK " + index); //TEST
        }
        else
        {
            index = UnityEngine.Random.Range(ratio, Eggs.Count);
        }
         
        return Eggs[index];
    }
    void GenerateEgg()
    {
        Vector2 generatePos = GetGeneratePosEgg();
        Instantiate(GetItem(),generatePos,Quaternion.identity);
    }

    void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }

    private void OnDisable()
    {
        Basket.OnAddScore -= AddScore;
    }
}
