using UnityEngine;
using UnityEngine.UI;

public class Intarface : MonoBehaviour
{
    [SerializeField] private Text _fish;
    [SerializeField] private Text _gold;
    [SerializeField] private Image _heals;
    [SerializeField] private Image _energy;
    public void SetTextInFish(int fish)
    {
        _fish.text = $"X {fish}";
    }
    public void SetTextIndGold(int gold)
    {
        _gold.text = $"X {gold}";
    }

}
