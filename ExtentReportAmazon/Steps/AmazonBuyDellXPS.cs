using BoDi;
using ExtentReportAmazon.Common;
using ExtentReportAmazon.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExtentReportAmazon.Steps
{
	[Binding]
	public sealed class AmazonBuyDellXPS : Bootstrapper
	{
		private readonly AmazonPage _amazonPage;

		public AmazonBuyDellXPS(IObjectContainer objectContainer) : base(objectContainer)
		{
			_amazonPage = new AmazonPage(this.Driver);
		}

		[Given(@"I open Amazon website")]
		public void DadoQueAbrirSiteAmazon()
		{
			_amazonPage.AbraSiteAmazon();
		}

		[Given(@"I search by Soap Dove")]
		public void DadoQueEuPesquiseiPorProduto()
		{
			_amazonPage.ProcurarPor("dell xps");
		}

		[Given(@"I press enter key for submit")]
		public void DadoQueEuPressioneATeclaEnteParaEnviar()
		{
			_amazonPage.PressioneTeclaEnterParaEnviar();
		}

		[Given(@"I choose the first item of list")]
		public void DadoQueEuEscolhiOPrimeiroItemDaLista()
		{
			_amazonPage.EscolhaPrimeiroItemLista();
		}

		[When(@"I click in Add to Cart button")]
		public void QuandoClicoEmAdicionarAoCarrinho()
		{
			_amazonPage.CliqueAdicionarCarrinho();
		}

		[Then(@"Must have one item in cart")]
		public void FinalizarCompra()
		{
			_amazonPage.FinalizarCompra();
		}
	}
}
