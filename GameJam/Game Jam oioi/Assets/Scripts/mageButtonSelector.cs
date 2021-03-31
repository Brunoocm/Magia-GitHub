using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class mageButtonSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string mago;
    public GameManager gameManager;

    public bool selecionado;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        selecionado = true;
        gameManager.botaoString = mago;
        gameManager.botaoSelecionado = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selecionado = false;
        gameManager.botaoSelecionado = false;
    }
}
