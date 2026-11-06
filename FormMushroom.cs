using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bicycle_Mushroom_Forms
{
    public partial class FormMushroom : Form
    {

        private int step = 1;
        private bool hasGills;
        private bool inForest;
        private bool hasRing;
        public FormMushroom()
        {
            InitializeComponent();
            AskQuestion();
        }

        private void AskQuestion()
        {
            if (step == 1)
            {
                lblQuestion.Text = "Question 1: Does your mushroom have gills?";
            }
            else if (step == 2)
            {
                lblQuestion.Text = "Question 2: Does your mushroom grow in a forest?";
            }
            else if (step == 3)
            {
                
                if (!inForest)
                {
                    lblQuestion.Text = "Question 3: Does your mushroom have a ring?";
                }
                else
                {
                    lblQuestion.Text = "Question 3: Does your mushroom have a ring?";
                }
            }
            else if (step == 4)
            {
                
                lblQuestion.Text = "Question 3: Does your mushroom have a convex cap?";
            }
        }

        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void FormMushroom_Load(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ProcessAnswer(true);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            ProcessAnswer(false);
        }

        private void ProcessAnswer(bool answer)
        {
            if (step == 1)
            {
                hasGills = answer;
                if (!hasGills)
                {
                    ShowResult("Cepe de bordeaux");
                    return;
                }
                step = 2;
                AskQuestion();
            }
            else if (step == 2)
            {
                inForest = answer;
                step = 3;
                AskQuestion();
            }
            else if (step == 3)
            {
                hasRing = answer;

                if (!inForest) 
                {
                    if (hasRing)
                    {
                        ShowResult("Coprin chevelu");
                    }
                    else
                    {
                        ShowResult("Agaric jaunissant");
                    }
                }
                else 
                {
                    if (hasRing)
                    {
                        ShowResult("Amanite tue-mouche");
                    }
                    else
                    {
                        
                        step = 4;
                        AskQuestion();
                    }
                }
            }
            else if (step == 4)
            {
                bool hasConvexCap = answer;
                if (hasConvexCap)
                {
                    ShowResult("Pied bleu");
                }
                else
                {
                    ShowResult("Girolle");
                }
            }
        }

        private void ShowResult(string mushroomName)
        {
            MessageBox.Show($"Your mushroom is: {mushroomName}!", "Result Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblQuestion.Text = $"Found: {mushroomName}";
            btnYes.Enabled = false;
            btnNo.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            step = 1;
            btnYes.Enabled = true;
            btnNo.Enabled = true;
            AskQuestion();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 mainMenu = new Form2();
            mainMenu.Show();
            this.Close();
        }
    }
}
