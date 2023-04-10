using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridController : MonoBehaviour
{
    [SerializeField] private Button[] gridButtons;
    private Button[,] buttonMatrix = new Button[3,3];

    private int Row_X_Count = 0;
    private int Row_O_Count = 0;

    private int Column_X_Count = 0;
    private int Column_O_Count = 0;

    private int Diagonal_X_Count = 0;
    private int Diagonal_O_Count = 0;

    private int Negative_Diagonal_X_Count = 0;
    private int Negative_Diagonal_O_Count = 0;

    private void Start(){
        int k = 0;
        for(int i = 0; i<3;i++){
            for(int j = 0;j<3;j++){
                buttonMatrix[i,j] = gridButtons[k];
                // print(buttonMatrix[i,j]);
                k++;
            }
        }

        GameEvents.current.OnButtonClick += CheckResult;
    }

    private void CheckResult(){

        //loop for row checks
        for(int i = 0; i< 3; i ++){
            for(int j = 0;j<3; j++){
                string currentText = buttonMatrix[i,j].GetComponent<ButtonController>().ReturnText();
                if(currentText == "X"){
                    Row_X_Count++;
                    // Debug.Log("Horizontal X: " + X_Count);
                }
                else if(currentText == "O"){
                    Row_O_Count++;
                    // Debug.Log("Horizontal O: " + O_Count);
                }
            }
            if(Row_X_Count == 3){GameEvents.current.GameOver("X Wins");return;}
            else if(Row_O_Count == 3){GameEvents.current.GameOver("O Wins");return;}
            else{
                Row_X_Count = 0;
                Row_O_Count = 0;
            }
        }

        //loop for column checks
        for(int i = 0; i< 3; i ++){
            for(int j = 0;j<3; j++){
                string currentText = buttonMatrix[j,i].GetComponent<ButtonController>().ReturnText();
                if(currentText == "X"){
                    Column_X_Count++;
                    // Debug.Log("Vertical X: " + X_Count);
                }
                else if(currentText == "O"){
                    Column_O_Count++;
                    // Debug.Log("Vertical O: " + O_Count);
                }
            }
            if(Column_X_Count == 3){GameEvents.current.GameOver("X Wins");return;}
            else if(Column_O_Count == 3){GameEvents.current.GameOver("O Wins");return;}
            else{
                Column_X_Count = 0;
                Column_O_Count = 0;
            }
        }


        //loop for diagonal
        Diagonal_X_Count = 0;
        Diagonal_O_Count = 0;

        for(int i = 0;i<3;i++){
            for(int j = i;j<i+1;j++){
                string currentText = buttonMatrix[i,j].GetComponent<ButtonController>().ReturnText();
                if(currentText == "X"){
                    Diagonal_X_Count++;
                }
                else if(currentText == "O"){
                    Diagonal_O_Count++;
                }
            }
            if(Diagonal_X_Count == 3){GameEvents.current.GameOver("X Wins");return;}
            else if(Diagonal_O_Count == 3){GameEvents.current.GameOver("O Wins");return;}
        }

        //loop for negative diagonal
        Negative_Diagonal_O_Count = 0;
        Negative_Diagonal_X_Count = 0;
        
        for(int i = 0;i<3;i++){
            for(int j = 2-i;j > 1-i;j--){
                string currentText = buttonMatrix[i,j].GetComponent<ButtonController>().ReturnText();
                if(currentText == "X"){
                    Negative_Diagonal_X_Count++;
                }
                else if(currentText == "O"){
                    Negative_Diagonal_O_Count++;
                }
            }
            if(Negative_Diagonal_X_Count == 3){GameEvents.current.GameOver("X Wins");return;}
            else if(Negative_Diagonal_O_Count == 3){GameEvents.current.GameOver("O Wins");return;}
        }
    }
}
