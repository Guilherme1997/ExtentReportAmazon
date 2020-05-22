using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ExtentReportAmazon.Pages
{
    public class AmazonPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _inputSearchBox;

        public AmazonPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void AbraSiteAmazon()
        {
            _webDriver.Navigate().GoToUrl("http://www.amazon.com");
        }

        public void ProcurarPor(string text)
        {
            _inputSearchBox = _webDriver.FindElement(By.Id("twotabsearchtextbox"));
            _inputSearchBox.SendKeys(text);
        }

        public void PressioneTeclaEnterParaEnviar()
        {
            _inputSearchBox.Submit();
        }

        public void EscolhaPrimeiroItemLista()
        {
            _webDriver.FindElement(By.XPath("(//div[@class='a-section aok-relative s-image-fixed-height'])[1]")).Click();
        }

        public void CliqueAdicionarCarrinho()
        {
            _webDriver.FindElement(By.Id("addToCart_feature_div")).Click();
        }

        public void FinalizarCompra()
        {

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("attach-sidesheet-view-cart-button")));
            _webDriver.FindElement(By.Id("attach-sidesheet-view-cart-button")).Click();

            SelecionarQuantidadeDeItens();

            AlterarQuantidadeDeItens();

            ConfirmarCompra();

            DigitarInformacoesPessoais();
        }


        public void SelecionarQuantidadeDeItens()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("a-autoid-0-announce")));
            _webDriver.FindElement(By.Id("a-autoid-0-announce")).Click();
        }

        public void AlterarQuantidadeDeItens()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("dropdown1_3")));
            _webDriver.FindElement(By.Id("dropdown1_3")).Click();
        }

        public void ConfirmarCompra()
        {
    
            _webDriver.FindElement(By.Id("sc-buy-box-ptc-button")).Click();
        }

        public void DigitarInformacoesPessoais() 
        {
            _inputSearchBox = _webDriver.FindElement(By.Id("ap_email"));
            _inputSearchBox.SendKeys("guilherme@gmail.com");
        }
    }
}