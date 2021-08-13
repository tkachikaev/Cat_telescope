using UnityEngine;

public class Resources : MonoBehaviour
{
    private int _gold;
    private int _fish = 5;
    private Intarface ui;

    private void Awake()
    {
        ui = FindObjectOfType<Intarface>();
    }
    private void Start()
    {
        ReloadAllTextResources();
    }
    #region Gold
    public void AddGold(int count)
    {
        _gold += count;
        ui.SetTextIndGold(_gold);
    }
    public void TakeGold(int count)
    {
        _gold -= count;
        ui.SetTextIndGold(_gold);
    }
    public int GetGold()
    {
        return _gold;
    }
    #endregion
    #region Fish
    public void AddFish(int count)
    {
        _fish += count;
        ui.SetTextInFish(_fish);
    }
    public void TakeFish(int count)
    {
        _fish -= count;
        ui.SetTextInFish(_fish);
    }
    public int GetFish()
    {
        return _fish;
    }
    #endregion
    #region Other load
    private void ReloadAllTextResources()
    {
        ui.SetTextIndGold(_gold);
        ui.SetTextInFish(_fish);
    }
    #endregion
}
