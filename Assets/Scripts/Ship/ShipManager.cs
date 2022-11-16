using UnityEngine;

public class ShipManager : IFlow
{
    #region Singleton
    private static ShipManager instance;
    public static ShipManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ShipManager();

            return instance;
        }

    }
    private ShipManager() { }
    #endregion

    public GameObject shipPrefab;
    IFlow iflow;
    private int shipHp = 3;

    public void PreInitialize()
    {
        Debug.Log("Instance of ShipManager");
        GameObject ship = GameObject.Instantiate(shipPrefab);
        iflow = ship.GetComponent<IFlow>();
        iflow.PreInitialize();


        ship.transform.position = Vector2.zero;
    }

    public void Initialize()
    {
        iflow.Initialize();
    }

    public void Refresh()
    {
        iflow.Refresh();
    }

    public void PhysicsRefresh()
    {
        iflow.PhysicsRefresh();
    }

    public void EndGame()
    {
        iflow.EndGame();
    }

    public void SpawnShip()
    {
        GameObject ship = GameObject.Instantiate(shipPrefab);
       iflow = ship.GetComponent<IFlow>();
        iflow.PreInitialize();

    }

    public void ShipDied()
    {
        shipHp--;

        if (shipHp > 0)
        {
            LevelManager.Instance.ResetSameLevel(shipHp);
            SpawnShip();
        }
        else
        {
            //Lose the game and start over to Level 1.
            LevelManager.Instance.startLevelEntry();
        }
    }
}