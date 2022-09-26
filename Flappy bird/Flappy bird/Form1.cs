using System;
using System.Windows.Forms;

namespace Flappy_bird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 10;
        int Score = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void endGame()
        {
            // game end function, this function will end the game when the bird touches the ground or the pipes
            GameTimer.Stop(); // stops the main timer
            ScoreText.Text += " Game over!!!"; // show the game over text on the score text, += is used to add the new string of text next to the score instead of overriding it
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimeEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity; // Movement of the Bird
            PipeTop.Left -= pipeSpeed; // Movement of the top pipe
            PipeBottom.Left -= pipeSpeed; // Movement of the bottom pipe
            ScoreText.Text = "Score: " + Score; // show the current score on the score text label

            if (PipeBottom.Left < -150)
            {
                PipeBottom.Left = 800;
                Score++;
            }
            if (PipeTop.Left < -180)
            {
                PipeTop.Left = 950;
                Score++;
            }
            if (flappyBird.Bounds.IntersectsWith(PipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(PipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(Ground.Bounds) || flappyBird.Top < -25
                )
            {
                // if any of the conditions are met from above then we will run the end game function
                endGame();
            }


            // if score is greater then 5 then we will increase the pipe speed to 15
            if (Score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Space)
                {
                    gravity = 10;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
