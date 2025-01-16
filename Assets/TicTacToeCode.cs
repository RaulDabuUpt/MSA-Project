using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class TicTacToeCode : MonoBehaviour
{
    Boolean checker;
    bool gameOver = false;
    int plusone;
    public Text btnText1 = null;
    public Text btnText2 = null;
    public Text btnText3 = null;
    public Text btnText4 = null;
    public Text btnText5 = null;
    public Text btnText6 = null;
    public Text btnText7 = null;
    public Text btnText8 = null;
    public Text btnText9 = null;

    public Text btnResetGame = null;
    public Text btnNewGame = null;
    public Text msgFeedback = null;

    public Text playerX;
    public Text player0;

    public void score()
    {
        if (btnText1.text == "X" && btnText2.text == "X" && btnText3.text == "X")
        {
            btnText3.color = Color.red;
            btnText2.color = Color.red;
            btnText1.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText1.text == "X" && btnText4.text == "X" && btnText7.text == "X")
        {
            btnText7.color = Color.red;
            btnText4.color = Color.red;
            btnText1.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText1.text == "X" && btnText5.text == "X" && btnText9.text == "X")
        {
            btnText9.color = Color.red;
            btnText5.color = Color.red;
            btnText1.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText2.text == "X" && btnText5.text == "X" && btnText8.text == "X")
        {
            btnText2.color = Color.red;
            btnText5.color = Color.red;
            btnText8.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText3.text == "X" && btnText6.text == "X" && btnText9.text == "X")
        {
            btnText3.color = Color.red;
            btnText6.color = Color.red;
            btnText9.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText3.text == "X" && btnText5.text == "X" && btnText7.text == "X")
        {
            btnText3.color = Color.red;
            btnText5.color = Color.red;
            btnText7.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText4.text == "X" && btnText5.text == "X" && btnText6.text == "X")
        {
            btnText4.color = Color.red;
            btnText5.color = Color.red;
            btnText6.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText7.text == "X" && btnText8.text == "X" && btnText9.text == "X")
        {
            btnText7.color = Color.red;
            btnText8.color = Color.red;
            btnText9.color = Color.red;
            msgFeedback.text = "Player X wins!";
            plusone = int.Parse(playerX.text);
            playerX.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }

        //Player X

        if (btnText1.text == "0" && btnText2.text == "0" && btnText3.text == "0")
        {
            btnText3.color = Color.red;
            btnText2.color = Color.red;
            btnText1.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText1.text == "0" && btnText4.text == "0" && btnText7.text == "0")
        {
            btnText7.color = Color.red;
            btnText4.color = Color.red;
            btnText1.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText1.text == "0" && btnText5.text == "0" && btnText9.text == "0")
        {
            btnText9.color = Color.red;
            btnText5.color = Color.red;
            btnText1.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText2.text == "0" && btnText5.text == "0" && btnText8.text == "0")
        {
            btnText2.color = Color.red;
            btnText5.color = Color.red;
            btnText8.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText3.text == "0" && btnText6.text == "0" && btnText9.text == "0")
        {
            btnText3.color = Color.red;
            btnText6.color = Color.red;
            btnText9.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText3.text == "0" && btnText5.text == "0" && btnText7.text == "0")
        {
            btnText3.color = Color.red;
            btnText5.color = Color.red;
            btnText7.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText4.text == "0" && btnText5.text == "0" && btnText6.text == "0")
        {
            btnText4.color = Color.red;
            btnText5.color = Color.red;
            btnText6.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }
        else if (btnText7.text == "0" && btnText8.text == "0" && btnText9.text == "0")
        {
            btnText7.color = Color.red;
            btnText8.color = Color.red;
            btnText9.color = Color.red;
            msgFeedback.text = "Player 0 wins!";
            plusone = int.Parse(player0.text);
            player0.text = Convert.ToString(plusone + 1);
            gameOver = true;
        }

        //Player 0
    }

    public void btnText1_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText1.text = "X";
            checker = true;
        }
        else
        {
            btnText1.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText2_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText2.text = "X";
            checker = true;
        }
        else
        {
            btnText2.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText3_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText3.text = "X";
            checker = true;
        }
        else
        {
            btnText3.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText4_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText4.text = "X";
            checker = true;
        }
        else
        {
            btnText4.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText5_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText5.text = "X";
            checker = true;
        }
        else
        {
            btnText5.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText6_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText6.text = "X";
            checker = true;
        }
        else
        {
            btnText6.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText7_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText7.text = "X";
            checker = true;
        }
        else
        {
            btnText7.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText8_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText8.text = "X";
            checker = true;
        }
        else
        {
            btnText8.text = "0";
            checker = false;
        }
        score();
    }

    public void btnText9_Click()
    {
        if (gameOver == true)
        {
            return;
        }
        if (checker == false)
        {
            btnText9.text = "X";
            checker = true;
        }
        else
        {
            btnText9.text = "0";
            checker = false;
        }
        score();
    }

    public void btnResetGame_Click()
    {
        btnText1.text = "";
        btnText2.text = "";
        btnText3.text = "";
        btnText4.text = "";
        btnText5.text = "";
        btnText6.text = "";
        btnText7.text = "";
        btnText8.text = "";
        btnText9.text = "";
        btnText1.color = Color.black;
        btnText2.color = Color.black;
        btnText3.color = Color.black;
        btnText4.color = Color.black;
        btnText5.color = Color.black;
        btnText6.color = Color.black;
        btnText7.color = Color.black;
        btnText8.color = Color.black;
        btnText9.color = Color.black;
        msgFeedback.text = "";
        gameOver = false;
    }

    public void ExitGame(){
        SceneManager.LoadScene("GameSelection");
    }
    public void btnNewGame_Click()
    {
        btnResetGame_Click();
        playerX.text = "0";
        player0.text = "0";
    }

}
