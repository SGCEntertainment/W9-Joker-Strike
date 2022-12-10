using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameFinsihed += (IsWin) =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(IsWin, () =>
            {
                GameManager.Instance.RestartGame();
            });
        };
    }
}