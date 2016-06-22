using System.Collections.Generic;

/// <summary>
/// Copyright (C) 2009 - 2013 SC 4ViewSoft SRL
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
///      http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// </summary>

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using Sample.AChartEngine.Demo.Charts;
using Android.Views;
using Android.Runtime;


namespace Sample.AChartEngine.Demo.Charts
{

	[Activity (Label="ChartDemo", MainLauncher=true, Icon="@drawable/achartengine")] 
	public class ChartDemo : ListActivity
	{
	  private IDemoChart[] mCharts = new IDemoChart[]
	  {
		  new AverageTemperatureChart(),
		  new AverageCubicTemperatureChart(),
		  new SalesStackedBarChart(),
		  new SalesBarChart(),
		  new TrigonometricFunctionsChart(),
		  new ScatterChart(),
		  new SalesComparisonChart(),
		  new ProjectStatusChart(),
		  new SalesGrowthChart(),
		  new BudgetPieChart(),
		  new BudgetDoughnutChart(),
		  new ProjectStatusBubbleChart(),
		  new TemperatureChart(),
		  new WeightDialChart(),
		  new SensorValuesChart(),
		  new CombinedTemperatureChart(),
		  new MultipleTemperatureChart()
	  };

	  private string[] mMenuText;

	  private string[] mMenuSummary;

	  /// <summary>
	  /// Called when the activity is first created. </summary>
	  protected override void OnCreate(Bundle savedInstanceState)
	  {
		base.OnCreate(savedInstanceState);
		int length = mCharts.Length;
		mMenuText = new string[length + 3];
		mMenuSummary = new string[length + 3];
		mMenuText[0] = "Embedded line chart demo";
		mMenuSummary[0] = "A demo on how to include a clickable line chart into a graphical activity";
		mMenuText[1] = "Embedded pie chart demo";
		mMenuSummary[1] = "A demo on how to include a clickable pie chart into a graphical activity";
		for (int i = 0; i < length; i++)
		{
		  mMenuText[i + 2] = mCharts[i].Name;
		  mMenuSummary[i + 2] = mCharts[i].Desc;
		}
		mMenuText[length + 2] = "Random values charts";
		mMenuSummary[length + 2] = "Chart demos using randomly generated values";
		ListAdapter = 
            new SimpleAdapter
                (
                    this, 
                    ListValues, 
                    Android.Resource.Layout.SimpleListItem2, 
                    new string[] 
                    {
                        IDemoChart_Fields.NAME, 
                        IDemoChart_Fields.DESC
                    }, 
                    new int[] 
                    {
                        Android.Resource.Id.Text1, 
                        Android.Resource.Id.Text2
                    }
                );

		return;
	  }

        private JavaList<IDictionary<string, object>> ListValues
        {
            get
            {
                JavaList<IDictionary<string, object>> values = new JavaList<IDictionary<string, object>>();
                int length = mMenuText.Length;
                for (int i = 0; i < length; i++)
                {
                    JavaDictionary<string, object> v = new JavaDictionary<string, object>();
                    v[IDemoChart_Fields.NAME] = mMenuText[i];
                    v[IDemoChart_Fields.DESC] = mMenuSummary[i];
                    values.Add(v);
                }
                return values;
            }
        }

	  protected override void OnListItemClick(ListView l, View v, int position, long id)
	  {
		base.OnListItemClick(l, v, position, id);
		Intent intent = null;
		if (position == 0)
		{
		  intent = new Intent(this, typeof(XYChartBuilder));
		}
		else if (position == 1)
		{
		  intent = new Intent(this, typeof(PieChartBuilder));
		}
		else if (position <= mCharts.Length + 1)
		{
		  intent = mCharts[position - 2].Execute(this);
		}
		else
		{
		  intent = new Intent(this, typeof(GeneratedChartDemo));
		}
		StartActivity(intent);
	  }
	}
}