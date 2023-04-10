using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake(){
        current = this;
    }

    public event Action OnButtonClick;

    public event Action<string> OnGameOver;
    public void ButtonClick(){
        OnButtonClick?.Invoke();
    }

    public void GameOver(string winner){
        OnGameOver?.Invoke(winner);
    }
}
