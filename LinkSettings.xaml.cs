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
    /// Interaction logic for LinkSettings.xaml
    /// </summary>
    public partial class LinkSettings : Window
    {
        public LinkSettings()
        {
            InitializeComponent();
            LinkLocationtxt.Text = Properties.Settings.Default.LinksFilePath;
        }

        private void LinkSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                LinkLocationtxt.Text = openFileDialog.FileName;
            }
        }

        private void LinkTemplateBtn_Click(object sender, RoutedEventArgs e)
        {
            string template = "Name,\"Link (%s for where the search value will be replaced, %t for an optional date parameter)\",\"Date Format (optional, only required if %t parameter is defined)\"" +
                "\nGoogle Example,https://www.google.com/search?q=%s" +
                "\nYahoo Example,https://search.yahoo.com/search?p=%s" +
                "\nHistorical Weather Example,https://www.wunderground.com/history/daily/%s/date/%t,yyyy-M-d" +
                "\n" +
                "\n" +
                "\nDELETE THIS TEXT BEFORE SAVING:" +
                "\nThe links functionality of Speedtools allows to bulk open browser tabs based on a parameter." +
                "\nThe module will split an either comma or column separated list, and open tabs based on the input." +
                "\nPlease be mindful that there's no upper limit to how many tabs you can open. If too many parameters are inputted, it might crash." +
                "\nAdd an \"%s\" in the part of the URL where the parameter is located." +
                "\nAn optional parameter \"%t\" can also be added to the URL to add current date/time information to the URL. " +
                "\nIf this is added, please specify the format of the date/time. Valid formats are the ones specified in the following website: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save template";
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, template);
            }
        }

        private void LinkCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LinkSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LinksFilePath = LinkLocationtxt.Text;
            Properties.Settings.Default.Save();
            this.DialogResult = true;
        }
    }
}
