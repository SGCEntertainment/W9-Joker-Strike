using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        LoadingGO.OnLoadingFinished += () =>
        {
            GameManager.Instance.RestartGame();
        };

        GameManager.OnGameFinsihed += (IsWin) =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(IsWin, () =>
            {
                GameManager.Instance.RestartGame();
            });
        };
    }
}