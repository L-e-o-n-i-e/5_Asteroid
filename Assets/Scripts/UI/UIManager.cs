using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : IFlow
{
    #region Singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }

    }
    private UIManager() { }
    #endregion

    private int currentShipHp;
    public RectTransform score;
    public RectTransform panelLife;
    public GameObject imgLifePrefab;


    public void PreInitialize()
    {
        currentShipHp = ShipManager.Instance.getShipHp();
        ResetLifes();
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
    }

    public void PhysicsRefresh()
    {
    }

    public void EndGame()
    {

    }

    public void LoseOneLifeUnit(int remainingLifes)
    {
        if (remainingLifes >= 0)
        {
            if (panelLife.childCount != 0)
            {
                RectTransform lifeUnit = panelLife.GetChild(remainingLifes).GetComponent<RectTransform>();
                GameObject.Destroy(lifeUnit.gameObject);
            }
        }
    }

    public void ResetLifes()
    {
        //int nbChild = panelLife.childCount;

        //startingShipHp = ShipManager.Instance.getShipHp();
        //int nbToAdd = startingShipHp - nbChild;
        currentShipHp = ShipManager.Instance.getShipHp();

        for (int i = 0; i < currentShipHp; i++)
        {
            GameObject go = GameObject.Instantiate<GameObject>(imgLifePrefab);
            RectTransform img = go.GetComponent<RectTransform>();
            img.SetParent(panelLife);

        }


    }

    public void UpdateScore(int pointsToAdd)
    {
        Text score = UIManager.Instance.score.GetComponent<Text>();
        score.text = (System.Int32.Parse(score.text) + pointsToAdd).ToString();
        Debug.Log(score.text);
    }

    public void ResetScore()
    {
        Text scoreUpdate = UIManager.Instance.score.GetComponent<Text>();
        scoreUpdate.text = "0";
    }
}
