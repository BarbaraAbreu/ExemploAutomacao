using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Drawing.Imaging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NUnitTestProject3.Tests
{
    [TestFixture]
    class SeleniumTests
    {
        public IWebDriver driver;
        private string baseURL;
        public string screenshotsPasta;
        int contador = 1;

        ChromeDriver chrome;
        [TestMethod]
        public void AbrirNavegadorPesquisar()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://www.google.com/");
            chrome.FindElement(By.Name("q")).SendKeys("Meu nome");
            chrome.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }
        //Método para capturar screenshot da tela
        public void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://www.google.com.br";
            screenshotsPasta = @"C:\Users\Base2\Documents\Evidencias\";
        }

        public void CapturaImagem()
        {
            Screenshot(driver, screenshotsPasta + "Imagem_" + contador++ + ".png");
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [Test]
        public void NomeDoTeste()
        {
            driver.Navigate().GoToUrl(baseURL + "/intl/pt-BR/about/");
            AbrirNavegadorPesquisar();
            CapturaImagem();
        }

        [TestCleanup]
        public void TearDown()
        {
            chrome.Quit();
        }

    }
}
