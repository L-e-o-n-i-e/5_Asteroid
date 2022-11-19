using UnityEngine;
using UnityEngine.UIElements;

public class UIConnector : AbstractConnector
{
    public RectTransform score;
    public RectTransform panelLife;
    public GameObject imgLifePrefab;

    public override void Connect()
    {
        Debug.Log("UIConnector");
        UIManager.Instance.panelLife = panelLife;
        UIManager.Instance.score = score;
        UIManager.Instance.imgLifePrefab = imgLifePrefab;
    }
}