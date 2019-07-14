using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;

namespace ScrapeCrypto
{

    public partial class CryptoPrice : Form
    {
        //The amount of times the program will scrape
        public int Count {get; set;}

        System.Windows.Forms.Timer mytimer;
        public CryptoPrice()
        {
            InitializeComponent();
           Count = 0;

           //creating timer to execute scrape method every 30 minutes
           mytimer = new System.Windows.Forms.Timer();

           //1800000 milliseconds = 30 minutes
           mytimer.Interval = 1800000;
           mytimer.Tick += timer_tick;
           mytimer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Database db = new Database();
            if (Count < 100)
            {
                Count++;
                Scrape();
                PriceCheck();

                string sqlEth = "Insert into CryptoData (CoinName, Price) VALUES ('Ethereum', '" + txtEthereum.Text + "');";
                string sqlBit = "Insert into CryptoData (CoinName, Price) VALUES ('Bitcoin', '" + txtBitcoin.Text + "');";
                db.DbConnect(sqlEth, sqlBit);
            }
            else
            {   
            } 
        }

        public void Scrape()
        {
            FirefoxOptions option = new FirefoxOptions();
            option.AddArguments("--headless");
            IWebDriver driver = new FirefoxDriver(option);

            driver.Url = "http://coinbase.com";
            // TimeSpan time = TimeSpan.FromSeconds(10);

            var eth = driver.FindElement(By.CssSelector("tr.AssetTableRow__Wrapper-sc-1e35vph-0:nth-child(2) > td:nth-child(3) > div:nth-child(1) > h4:nth-child(1)"));
            string eth1 = eth.GetAttribute("innerHTML");
            txtEthereum.Text = eth1;

            var bit = driver.FindElement(By.CssSelector("tr.AssetTableRow__Wrapper-sc-1e35vph-0:nth-child(1) > td:nth-child(3) > div:nth-child(1) > h4:nth-child(1)"));
            string bit1 = bit.GetAttribute("innerHTML");
            txtBitcoin.Text = bit1;
            driver.Close();
            driver.Quit();
        }

        public void PriceCheck()
        {
            //this method sends an email if the price fits certain parameters
            Mail Ml = new Mail();
            decimal Eth = decimal.Parse(txtEthereum.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
            decimal Bit = decimal.Parse(txtBitcoin.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));

            if (Bit < 1000 && Eth < 150 || Eth > 500 && Bit < 1000)
            {
                Ml.SendEmail("Bitcoin and Ethereum");
            }
            else if (Eth < 150 || Eth > 500)
            {
                Ml.SendEmail("Ethereum");
            }
            else if (Bit < 1000)
            {
                Ml.SendEmail("Bitcoin");
            }
        }

        public void txtBitcoin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEthereum_TextChanged(object sender, EventArgs e)
        {

        } 
    }
}
