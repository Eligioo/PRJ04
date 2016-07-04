using BikeDataModels;
using Project_4_desktop.Graphs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_4_desktop
{
    public partial class Question3NeighborhoodPicker : Form
    {
        IEnumerable<CombinationofTheftTrommelAreaMonth> data;
        Question3 question3;
        public Question3NeighborhoodPicker(Question3 question)
        {
            InitializeComponent();

            var loader = new QuestionDataLoader<IEnumerable<CombinationofTheftTrommelAreaMonth>>("questions/q3");
            loader.OnLoaded += Loader_OnLoaded;
            question3 = question;
        }

        private void Loader_OnLoaded(object sender, EventArgs e)
        {
            data = sender as IEnumerable<CombinationofTheftTrommelAreaMonth>;
            neigborhoodComboBox.DataSource = data;
            neigborhoodComboBox.Refresh();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            var selectedRow = neigborhoodComboBox.SelectedItem as CombinationofTheftTrommelAreaMonth;

            question3.RefreshData(selectedRow);
        }
    }
}
