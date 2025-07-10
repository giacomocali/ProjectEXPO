using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPortfolio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject portfolioLink;

    public void OpenPortfolio(string url)
    {
        Application.OpenURL(url);
    }

    public void OnPointerEnter(PointerEventData eventdata)
    {
        portfolioLink.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventdata) 
    {
        portfolioLink.SetActive(false);
    }
}
