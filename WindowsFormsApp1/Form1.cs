using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IWebDriver driver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");
            driver = new ChromeDriver(@"C:\Browser_drivers\", options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.ebay.com";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebElement field = driver.FindElement(By.Id("gh-ac"));
            field.Clear();
            field.SendKeys(textBox1.Text);
            driver.FindElement(By.Id("gh-btn")).Click();

            string link = driver.Url;
            textBox2.Text = link;
            richTextBox1.AppendText(link + "\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            driver.Navigate().Back();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }
    }
}