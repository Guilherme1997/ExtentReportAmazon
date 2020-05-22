using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using ExtentReportAmazon.ExtensionMethods;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace ExtentReportAmazon.Common
{
	[Binding]
	public class Hooks
	{
		private static ExtentTest _feature;
		private static ExtentTest _scenario;
		private static ExtentReports _extent;
		private static readonly string PathReport = $"{AppDomain.CurrentDomain.BaseDirectory}ExtentReportAmazon.html";

		[BeforeTestRun]
		public static void ConfigurarRelatorio()
		{
			var reporter = new ExtentHtmlReporter(PathReport);
			_extent = new ExtentReports();
			_extent.AttachReporter(reporter);
		}

		[BeforeFeature]
		public static void CriarFeature()
		{
			_feature = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
		}

		[BeforeScenario]
		public static void CriarCenario()
		{
			_scenario = _feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
		}

		[AfterStep]
		public static void InserirRelatorios()
		{
			switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
			{
				case StepDefinitionType.Given:
					_scenario.DefinicaoEtapaFornecida();
					break;

				case StepDefinitionType.Then:
					_scenario.DefinicaoEtapaFornecida();
					break;

				case StepDefinitionType.When:
					_scenario.DefinicaoEtapaFornecida();
					break;
			}
		}

		[AfterTestRun]
		public static void ExecutarProcessoRelatorio
()
		{
			_extent.Flush();
			System.Diagnostics.Process.Start(PathReport);
		}
	}
}