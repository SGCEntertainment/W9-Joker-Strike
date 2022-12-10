using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
    [SerializeField] Sprite lose;
    [SerializeField] Sprite win;

    public void SetData(bool IsWin, UnityAction action)
    {
        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = IsWin ? win : lose;
        transform.GetChild(0).GetChild(0).GetComponent<Image>().SetNativeSize();

        GameObject.Find("again").GetComponent<Button>().onClick.AddListener(action);
        GameObject.Find("again").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }
}
