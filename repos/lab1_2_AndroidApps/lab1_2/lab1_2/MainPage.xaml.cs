using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace lab1_2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        
        public MainPage()
        {
            InitializeComponent();
            picker1.SelectedItem = picker1.Items[0];
            
        }

        private void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            showList(picker1.SelectedIndex);
        }

        private void showList(int index)
        {
            listLabel.Text = null;
            foreach (Students s in Students.getStudents(picker1.SelectedItem.ToString()))
            {
                listLabel.Text += "\n" + s.GetName();
            }
        }

        private void button2_Clicked(object sender, EventArgs e)
        {

        }
    }
}
