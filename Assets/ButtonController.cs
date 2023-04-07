using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private static bool isAalu = false;
    [SerializeField] private TMP_Text buttonText;

    public void OnClick(){
        if(isAalu){
            isAalu = !isAalu;
            buttonText.text = "X";
        }
        else if(!isAalu){
            isAalu  = !isAalu;
            buttonText.text = "O";
        }

        GetComponent<Button>().interactable = false;
    }
}
