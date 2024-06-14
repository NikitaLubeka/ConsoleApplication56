using System.Drawing;
using System.Windows.Forms;
using System;

public partial class Form1 : Form
{
    private Button[,] buttons = new Button[6, 6];
    private Label currentPlayerLabel;
    private Button restartButton;
    private char currentPlayer = 'X';

    public Form1()
    {
        InitializeComponent();
        InitializeGame();
    }

    private void InitializeGame()
    {
        currentPlayerLabel = new Label
        {
            Text = "Current Player: X",
            Location = new Point(10, 10),
            Size = new Size(150, 30)
        };
        this.Controls.Add(currentPlayerLabel);

        restartButton = new Button
        {
            Text = "Restart",
            Location = new Point(200, 10),
            Size = new Size(100, 30)
        };
        restartButton.Click += RestartButton_Click;
        this.Controls.Add(restartButton);

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                buttons[i, j] = new Button
                {
                    Location = new Point(10 + j * 50, 50 + i * 50),
                    Size = new Size(50, 50),
                    Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold)
                };
                buttons[i, j].Click += Button_Click;
                this.Controls.Add(buttons[i, j]);
            }
        }
    }

    private void RestartButton_Click(object sender, EventArgs e)
    {
        currentPlayer = 'X';
        currentPlayerLabel.Text = "Current Player: X";
        foreach (Button button in buttons)
        {
            button.Text = "";
            button.Enabled = true;
        }
    }

    private void Button_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            if (CheckWin())
            {
                MessageBox.Show("Player {currentPlayer} wins!");
                DisableButtons();
            }
            else
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                currentPlayerLabel.Text = "Current Player: {currentPlayer}";
            }
        }
    }

    private bool CheckWin()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (buttons[i, j].Text == currentPlayer.ToString() &&
                    CheckDirection(i, j, 1, 0) ||
                    CheckDirection(i, j, 0, 1) || 
                    CheckDirection(i, j, 1, 1) || 
                    CheckDirection(i, j, 1, -1)) 
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckDirection(int row, int col, int rowDir, int colDir)
    {
        int count = 0;
        for (int k = 0; k < 4; k++)
        {
            int r = row + k * rowDir;
            int c = col + k * colDir;
            if (r >= 0 && r < 6 && c >= 0 && c < 6 && buttons[r, c].Text == currentPlayer.ToString())
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count == 4;
    }

    private void DisableButtons()
    {
        foreach (Button button in buttons)
        {
            button.Enabled = false;
        }
    }
}
