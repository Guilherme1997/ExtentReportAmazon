using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace ExtentReportAmazon.ExtensionMethods
{
	public static class ScenarioExtensionMethod
	{
		private static ExtentTest CriarCenario(ExtentTest extent, StepDefinitionType stepDefinitionType)
		{
			var scenarioStepContext = ScenarioStepContext.Current.StepInfo.Text;

			switch (stepDefinitionType)
			{
				case StepDefinitionType.Given:
					return extent.CreateNode<Given>(scenarioStepContext);

				case StepDefinitionType.Then:
					return extent.CreateNode<Then>(scenarioStepContext);

				case StepDefinitionType.When:
					return extent.CreateNode<When>(scenarioStepContext);
				default:
					throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null);
			}
		}

		private static void CriarCenaroDeErro(ExtentTest extent, StepDefinitionType stepDefinitionType)
		{
			var error = ScenarioContext.Current.TestError;

			if (error.InnerException == null)
			{
				CriarCenario(extent, stepDefinitionType).Error(error.Message);
			}
			else
			{
				CriarCenario(extent, stepDefinitionType).Fail(error.InnerException);
			}
		}

		public static void DefinicaoEtapaFornecida(this ExtentTest extent)
		{
			if (ScenarioContext.Current.TestError == null)
				CriarCenario(extent, StepDefinitionType.Given);
			else
				CriarCenaroDeErro(extent, StepDefinitionType.Given);
		}

		public static void EtapaDefinicao(this ExtentTest extent)
		{
			if (ScenarioContext.Current.TestError == null)
				CriarCenario(extent, StepDefinitionType.When);
			else
				CriarCenaroDeErro(extent, StepDefinitionType.When);
		}

		public static void DefinicaoDaEtapa (this ExtentTest extent)
		{
			if (ScenarioContext.Current.TestError == null)
				CriarCenario(extent, StepDefinitionType.Then);
			else
				CriarCenaroDeErro(extent, StepDefinitionType.Then);
		}
	}
}