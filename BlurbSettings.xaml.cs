using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Speedtools
{
    /// <summary>
    /// Interaction logic for BlurbSettings.xaml
    /// </summary>
    public partial class BlurbSettings : Window
    {
        public BlurbSettings()
        {
            InitializeComponent();
            BlurbsLocationtxt.Text = Properties.Settings.Default.BlurbsFilePath;
        }

        private void BlurbTemplateBtn_Click(object sender, RoutedEventArgs e)
        {
            string template = "Layer 1,Layer 2,Layer 3,Layer 4" +
                "\nExample Category,Example SubCategory,Example Blurb 1,Some Copied Text" +
                "\nExample Category,Example SubCategory,Example Blurb 2,Some Other Copied Text" +
                "\nExample Category,Example SubCategory,Example Blurb 3,Another Copied Text" +
                "\nExample Category,Example SubCategory 2,Example Blurb 4,Happy Blurbing" +
                "\n" +
                "\n" +
                "\nDELETE THIS TEXT BEFORE SAVING:" +
                "\nThe blurbs functionality of Speedtools allows to categorize and save frequently used text blurbs." +
                "\nBlurbs with the same Layer hierarchy will be bulked into a singular button." +
                "\nFeel free to create as many as you'd like and share with your team. Network folders can be used as route but could slow down boot." +
                "\nThe names of the Layers can also be changed but the number of layers (4) cannot be changed.";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save template";
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, template);
            }
        }

        private void BlurbCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BlurbSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                BlurbsLocationtxt.Text = openFileDialog.FileName;
            }
        }

        private void BlurbSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BlurbsFilePath = BlurbsLocationtxt.Text;
            Properties.Settings.Default.Save();
            this.DialogResult = true;
        }
    }
}
