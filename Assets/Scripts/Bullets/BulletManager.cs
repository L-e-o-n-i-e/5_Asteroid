using System.Collections.Generic;
using UnityEngine;

public class BulletManager : IFlow
{
    #region Singleton
    //SINGLETON! REMOVE MONOBEHAVIOR
    private static BulletManager instance;
    public static BulletManager Instance
    {
        get
        {
            if (instance == null)
                instance = new BulletManager();

            return instance;
        }

    }
    private BulletManager() { }
    #endregion

    GameObject bulletPrefab;
    List<IFlow> iflowList = new List<IFlow>();
    Stack<IFlow> toRemove = new Stack<IFlow>();

    public void PreInitialize()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");

        if (iflowList != null)
        {
            foreach (var iflow in iflowList)
            {
                iflow.PreInitialize();
            }
        }
    }

    public void Initialize()
    {
        if (iflowList != null)
        {
            foreach (var iflow in iflowList)
            {
                iflow.Initialize();
            }
        }
    }

    public void Refresh()
    {
        while (toRemove.Count > 0)
        {
            IFlow iflow = toRemove.Pop();
            iflowList.Remove(iflow);
        }

        for (int i = 0; i < iflowList.Count; i++)
        {
            iflowList[i].Refresh();
        }
    }

    public void PhysicsRefresh()
    {

    }

    public void EndGame()
    {
        foreach (var iflow in iflowList)
        {
            iflow.EndGame();
        }
    }

    public void SpawnBullet(Rigidbody2D shipRb, Transform tip)
    {
        Debug.Log("Bullet spawned");

        GameObject goClone = GameObject.Instantiate(bulletPrefab, tip.position, Quaternion.identity);
        IFlow iflow = goClone.GetComponent<IFlow>();

        float z = tip.eulerAngles.z;
        goClone.transform.localEulerAngles = new Vector3(0, 0, z);

        iflowList.Add(iflow);

        //TODO
        iflow.PreInitialize();
        iflow.Initialize();
    }

    public void PutOnTheRemoveList(IFlow todelete)
    {
        toRemove.Push(todelete);
    }

    public void ClearAllBUllets()
    {
        iflowList.Clear();
    }
}