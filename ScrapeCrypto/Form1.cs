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
        public int Count {get; set;}
        System.Windows.Forms.Timer mytimer;
        public CryptoPrice()
        {
            InitializeComponent();
           Count = 0;
           mytimer = new System.Windows.Forms.Timer();
           mytimer.Interval = 1800000;
           mytimer.Tick += timer_tick;
           mytimer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Database db = new Database();
            if (Count < 2)
            {
                Count++;
                ScrapeC();
                PriceCheck();

                string sqlEth = "Insert into CryptoData (CoinName, Price) VALUES ('Ethereum', '" + txtEthereum.Text + "');";
                string sqlBit = "Insert into CryptoData (CoinName, Price) VALUES ('Bitcoin', '" + txtBitcoin.Text + "');";
                db.DbConnect(sqlEth, sqlBit);
            }
            else
            {   
            } 
        }

        public void ScrapeC()
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
            SendMail sm = new SendMail();
            decimal Eth = decimal.Parse(txtEthereum.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
            decimal Bit = decimal.Parse(txtBitcoin.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));

            if (Bit < 1000 && Eth < 150 || Eth > 500 && Bit < 1000)
            {
                sm.SendEmail("Bitcoin and Ethereum");
            }
            else if (Eth < 150 || Eth > 500)
            {
                sm.SendEmail("Ethereum");
            }
            else if (Bit < 1000)
            {
                sm.SendEmail("Bitcoin");
            }
        }

        public void btnScrape_Click(object sender, EventArgs e)
        {
           
        }

        public void txtBitcoin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEthereum_TextChanged(object sender, EventArgs e)
        {

        } 
    }
}
