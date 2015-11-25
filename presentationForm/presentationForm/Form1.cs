using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Int64 Total = 0;
        public static readonly int NUMBER_OF_POWERUPS_ALLOWED = 10;
        
        // ID of each Powerup
        public const int POWERUP_1_ID = 1;
        public const int POWERUP_2_ID = 2;
        public const int POWERUP_3_ID = 3;
        public const int POWERUP_4_ID = 4;
        public const int POWERUP_5_ID = 5;
        public const int POWERUP_6_ID = 6;
        
        // Number of each powerup
        public short numberOfPowerup1 = 0;
        public short numberOfPowerup2 = 0;
        public short numberOfPowerup3 = 0;
        public short numberOfPowerup4 = 0;
        public short numberOfPowerup5 = 0;
        public short numberOfPowerup6 = 0;
        
        // Names for each Powerup
        public string nameOfPowerup1 = "Stuffing";
        public string nameOfPowerup2 = "Cranberries";
        public string nameOfPowerup3 = "Mashed Potatoes";
        public string nameOfPowerup4 = "Candied Yams";
        public string nameOfPowerup5 = "Green Bean Casserole";
        public string nameOfPowerup6 = "Pumpkin Pie";
        
        // Costs of each powerup
        public const int costOfPowerup1 = 10;
        public const int costOfPowerup2 = 100;
        public const int costOfPowerup3 = 1000;
        public const int costOfPowerup4 = 10000;
        public const int costOfPowerup5 = 100000;
        public const int costOfPowerup6 = 1000000;

        // Costs of each powerup
        public const int scoreForPowerup1 = 1;
        public const int scoreForPowerup2 = 10;
        public const int scoreForPowerup3 = 100;
        public const int scoreForPowerup4 = 1000;
        public const int scoreForPowerup5 = 10000;
        public const int scoreForPowerup6 = 100000;

        private void buttonClicker_Click(object sender, EventArgs e)
        {
            addToTotal(1);
            enableButtons();
        }

        public void addToTotal(Int64 amount)
        {
            this.Total += amount;
            updateTotalDisplay();
        }

        public void subFromTotal(Int64 amount)
        {
            this.Total -= amount;
            updateTotalDisplay();
        }

        public void updateTotalDisplay()
        {
            txbxTotalClicks.Text = Total.ToString();
        }

        public void updateUpgradeCounts()
        {

            lblTotal1.Text = numberOfPowerup1.ToString();
            lblTotal2.Text = numberOfPowerup2.ToString();
            lblTotal3.Text = numberOfPowerup3.ToString();
            lblTotal4.Text = numberOfPowerup4.ToString();
            lblTotal5.Text = numberOfPowerup5.ToString();
            lblTotal6.Text = numberOfPowerup6.ToString();

        }

        public void initButtonsAndLabels()
        {

            btnPowerup1.Text = nameOfPowerup1;
            lblCost1.Text = "Cost: " + costOfPowerup1;

            btnPowerup2.Text = nameOfPowerup2;
            lblCost2.Text = "Cost: " + costOfPowerup2;

            btnPowerup3.Text = nameOfPowerup3;
            lblCost3.Text = "Cost: " + costOfPowerup3;

            btnPowerup4.Text = nameOfPowerup4;
            lblCost4.Text = "Cost: " + costOfPowerup4;

            btnPowerup5.Text = nameOfPowerup5;
            lblCost5.Text = "Cost: " + costOfPowerup5;

            btnPowerup6.Text = nameOfPowerup6;
            lblCost6.Text = "Cost: " + costOfPowerup6;
            

        }

        public void enableButtons()
        {
            if (Total >= costOfPowerup1 && numberOfPowerup1 < NUMBER_OF_POWERUPS_ALLOWED)
            {
                btnPowerup1.Enabled = true;
            }
            else
            {
                btnPowerup1.Enabled = false;
            }

            if(Total >= costOfPowerup2 && numberOfPowerup2 < NUMBER_OF_POWERUPS_ALLOWED)
            {
                btnPowerup2.Enabled = true;
            }
            else
            {
                btnPowerup2.Enabled = false;
            }

            if(Total >= costOfPowerup3 && numberOfPowerup3 < NUMBER_OF_POWERUPS_ALLOWED)
            {
                btnPowerup3.Enabled = true;
            }
            else
            {
                btnPowerup3.Enabled = false;
            }

            if (Total >= costOfPowerup4 && numberOfPowerup4 < NUMBER_OF_POWERUPS_ALLOWED)
            {
                btnPowerup4.Enabled = true;
            }
            else
            {
                btnPowerup4.Enabled = false;
            }

            if (Total >= costOfPowerup5 && numberOfPowerup5 < NUMBER_OF_POWERUPS_ALLOWED)
            {
                btnPowerup5.Enabled = true;
            }
            else
            {
                btnPowerup5.Enabled = false;
            }

            if(Total >= costOfPowerup6 && numberOfPowerup6 < NUMBER_OF_POWERUPS_ALLOWED)
            {
                btnPowerup6.Enabled = true;
            }
            else
            {
                btnPowerup6.Enabled = false;
            }
        }

        public bool buyUpgrade(Int64 cost, int powerUpID)
        {
            if(Total >= cost)
            {
                switch (powerUpID)
                {
                    case POWERUP_1_ID:
                        numberOfPowerup1++;
                        break;
                    case 2:
                        numberOfPowerup2++;
                        break;
                    case 3:
                        numberOfPowerup3++;
                        break;
                    case 4:
                        numberOfPowerup4++;
                        break;
                    case 5:
                        numberOfPowerup5++;
                        break;
                    case 6:
                        numberOfPowerup6++;
                        break;
                    default:
                        break;
                }
                subFromTotal(cost);
                enableButtons();
                return true;
            }
            else
            {
                enableButtons();
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tempTotal = 0;

            tempTotal += numberOfPowerup1 * scoreForPowerup1;
            tempTotal += numberOfPowerup2 * scoreForPowerup2;
            tempTotal += numberOfPowerup3 * scoreForPowerup3;
            tempTotal += numberOfPowerup4 * scoreForPowerup4;
            tempTotal += numberOfPowerup5 * scoreForPowerup5;
            tempTotal += numberOfPowerup6 * scoreForPowerup6;

            addToTotal(tempTotal);
            enableButtons();
        }

        private void btnPowerup1_Click(object sender, EventArgs e)
        {
            buyUpgrade(costOfPowerup1, POWERUP_1_ID);
            updateUpgradeCounts();
        }

        private void btnPowerup2_Click(object sender, EventArgs e)
        {
            buyUpgrade(costOfPowerup2, POWERUP_2_ID);
            updateUpgradeCounts();
        }

        private void btnPowerup3_Click(object sender, EventArgs e)
        {
            buyUpgrade(costOfPowerup3, POWERUP_3_ID);
            updateUpgradeCounts();
        }

        private void btnPowerup4_Click(object sender, EventArgs e)
        {
            buyUpgrade(costOfPowerup4, POWERUP_4_ID);
            updateUpgradeCounts();
        }

        private void btnPowerup5_Click(object sender, EventArgs e)
        {
            buyUpgrade(costOfPowerup5, POWERUP_5_ID);
            updateUpgradeCounts();
        }

        private void btnPowerup6_Click(object sender, EventArgs e)
        {
            buyUpgrade(costOfPowerup6, POWERUP_6_ID);
            updateUpgradeCounts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initButtonsAndLabels();
        }
    }
}
