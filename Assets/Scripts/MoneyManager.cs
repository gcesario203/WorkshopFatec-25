using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private int Money = 0;

    public static MoneyManager Instance;

    private void Awake()
    {
        if (Instance is null)
            Instance = this;
    }

    public void AddMoney() => AddMoney(1);

    public void AddMoney(int value) => Money += value;
}