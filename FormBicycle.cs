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
    public partial class FormBicycle : Form
    {
        public FormBicycle()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            
            if (!int.TryParse(txtStart.Text, out int startHour) || !int.TryParse(txtEnd.Text, out int endHour))
            {
                MessageBox.Show("Please enter valid integer numbers for both start and end hours.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (startHour < 0 || startHour > 23 || endHour < 1 || endHour > 24)
            {
                MessageBox.Show("Start hour must be between 0 and 23.\nEnd hour must be between 1 and 24.",
                                "Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startHour >= endHour)
            {
                MessageBox.Show("Starting time must be less than ending time.",
                                "Invalid Time Interval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int totalCost = 0;

            for (int hour = startHour; hour < endHour; hour++)
            {
                
                if ((hour >= 0 && hour < 7) || (hour >= 21 && hour < 24))
                {
                    totalCost += 500;
                }
                
                else if ((hour >= 7 && hour < 14) || (hour >= 19 && hour < 21))
                {
                    totalCost += 1000;
                }
                
                else if (hour >= 14 && hour < 19)
                {
                    totalCost += 1500;
                }
            }

            
            lblResult.Text = $"Total Rent: {totalCost} RWF";
        }

       

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            
            Form2 mainMenu = new Form2();
            mainMenu.Show();
            this.Close();

        }
    }
    
}
