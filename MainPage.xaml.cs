using Microsoft.Maui.Layouts;
using System;

namespace FinanceKeeperApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	public DateTime nextPeriodBegin { get ; private set; }
	public float initialPeriodBudget { get; private set; }
	public float periodExpenses { get; private set; }
	public string currency { get; private set; } = string.Empty;

	private string currencyFormatter(float value)
	{
		return value.ToString("F2") + " " + currency;
	}

	public MainPage()
	{
		InitializeComponent();
		//Begin by using a dummy initializer of the properties
		DateTime today = DateTime.Today;
        nextPeriodBegin = today.AddDays(30);
		int daysToNextPeriod = (nextPeriodBegin - today).Days;
		
        initialPeriodBudget = 320;
		periodExpenses = 20;
        currency = "€";

		float availablePeriodBudget = (initialPeriodBudget - periodExpenses);

        dailyBudgetLabel.Text = currencyFormatter(availablePeriodBudget / daysToNextPeriod);
		periodBudgetLabel.Text = currencyFormatter(availablePeriodBudget);

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

