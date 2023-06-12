using Speedtools.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Speedtools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class buttonContent
    {
        public string content { get; set; }
    }

    public class radioButtonContent
    {
        public string content { get; set; }
        public int tag { get; set; }
    }

    public partial class MainWindow : Window
    {
        public int linkSelected;
        public int blurbLayer = 0;
        public string orgPressed = string.Empty;
        public string areaPressed = string.Empty;
        public string blurbPressed = string.Empty;
        public string blurbToClipboard = string.Empty;
        public BlurbsLogic blurbsOpened;
        public LinksLogic linksOpened;
        public string labelContent = string.Empty;

        public void openBlurbs()
        {
            try
            {
                blurbsOpened = new BlurbsLogic();
                blurbsOpened.filePath = Properties.Settings.Default.BlurbsFilePath;
                blurbsOpened.readBlurbsFromFile();

            }
            catch (Exception)
            {
                return;
            }
        }

        public void openLinks()
        {
            try
            {
                linksOpened = new LinksLogic();
                linksOpened.filePath = Properties.Settings.Default.LinksFilePath;
                linksOpened.readLinksFromFile();
            }
            catch (Exception)
            {
                return;
            }
        }


        public void displayBlurbs()
        {
            List<buttonContent> buttons = new List<buttonContent>();
            if (blurbLayer == 0)
            {
                btnBlurbBack.Content = "Settings";
            }
            if (blurbLayer != 0)
            {
                btnBlurbBack.Content = "Back";
            }
            if (blurbsOpened is null || blurbsOpened.matrix.Count == 0)
            {
                displayInStatusBar("No blurbs found, check settings");
                lblBlurbs.Content = "No blurbs found";
                icBlurbs.ItemsSource = buttons;
                return;
            }
            switch (blurbLayer)
            {
                case 0:
                    foreach (string element in blurbsOpened.uniqueOrg())
                    {
                        if (blurbsOpened.matrix.Count == 0)
                        {
                            break;
                        }
                        lblBlurbs.Content = blurbsOpened.firstLayerName;
                        buttons.Add(new buttonContent() { content = element });
                    }
                    icBlurbs.ItemsSource = buttons;
                    break;
                case 1:
                    lblBlurbs.Content = orgPressed;
                    blurbsOpened.orgSelection = orgPressed;
                    foreach (string element in blurbsOpened.uniqueArea())
                    {
                        buttons.Add(new buttonContent() { content = element });
                    }
                    icBlurbs.ItemsSource = buttons;
                    break;
                case 2:
                    lblBlurbs.Content = areaPressed;
                    blurbsOpened.orgSelection = orgPressed;
                    blurbsOpened.areaSelection = areaPressed;
                    foreach (string element in blurbsOpened.blurbList())
                    {
                        buttons.Add(new buttonContent() { content = element });
                    }
                    icBlurbs.ItemsSource = buttons;
                    break;
                case 3:
                    blurbsOpened.orgSelection = orgPressed;
                    blurbsOpened.areaSelection = areaPressed;
                    blurbsOpened.blurbSelection = blurbPressed;
                    blurbToClipboard = blurbsOpened.textToCopy();
                    break;
            }

        }

        public void displayLinks()
        {
            List<radioButtonContent> buttons = new List<radioButtonContent>();
            if (linksOpened is null || linksOpened.matrix.Count == 0)
            {
                displayInStatusBar("No links found, check settings");
                btnOpenLinks.Content = "No links found";
                btnOpenLinks.IsEnabled = false;
                lbLinks.ItemsSource = buttons;
                return;
            }

            for (int i = 0; i < linksOpened.linkNames().Count; i++)
            {
                buttons.Add(new radioButtonContent() { content = linksOpened.linkNames()[i], tag = i });
            }
            lbLinks.ItemsSource = buttons;
            btnOpenLinks.Content = "Open in Browser";
            btnOpenLinks.IsEnabled = true;
        }

        public void displayInStatusBar(string entry)
        {
            lblStatusBar.Opacity = 10;
            lblStatusBar.Content = entry;
            var animation = new DoubleAnimation
            {
                To = 0,
                BeginTime = TimeSpan.FromSeconds(4),
                Duration = TimeSpan.FromSeconds(1),
                FillBehavior = FillBehavior.Stop
            };

            animation.Completed += (s, a) => lblStatusBar.Opacity = 0;

            lblStatusBar.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        public string translateDelimiter(string selectedDelim)
        {
            string output = string.Empty;

            switch (selectedDelim)
            {
                case "Column":
                    output = Environment.NewLine;
                    break;
                case "Comma":
                    output = ",";
                    break;
                case "Semicolon":
                    output = ";";
                    break;
                
            }

            return output;
        }

        public MainWindow()
        {
            InitializeComponent();
            openBlurbs();
            openLinks();
            displayBlurbs();
            displayLinks();
            callSplash();
        }

        public void callSplash()
        {
            if (Properties.Settings.Default.ShowSplash == true)
            {
                var splash = new Splash();
                splash.ShowDialog();
                if (splash.DialogResult == true)
                {
                    Properties.Settings.Default.ShowSplash = false;
                }
            }
        }

        private void chkOnTop_Checked(object sender, RoutedEventArgs e)
        {
            Topmost = true;
            displayInStatusBar("Speedtools will now stay on top");
        }

        private void chkOnTop_Unchecked(object sender, RoutedEventArgs e)
        {
            Topmost = false;
            displayInStatusBar("Speedtools will no longer stay on top");
        }

        private void btnTrimBlanks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.trimBlanks(entry);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnNukeBlanks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.nukeBlanks(entry);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnRemoveDuplicates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.removeDuplicates(entry);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnAlphabeticalOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.alphabeticalOrder(entry);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnOpenLinks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                linksOpened.raw = txtLinkOpener.Text;
                new Thread(() =>
                {
                    linksOpened.engage(linkSelected);
                }).Start();

                displayInStatusBar("Opening tabs");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void rdiLinksDynamic_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            linkSelected = (int)button.Tag;
        }

        private void btnClearTextManipulator_Click(object sender, RoutedEventArgs e)
        {
            txtTextManipulatorInOut.Text = string.Empty;
        }

        private void btnClearLinkOpener_Click(object sender, RoutedEventArgs e)
        {
            txtLinkOpener.Text = string.Empty;
        }

        private void btnBlurbDynamic_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string buttonPressed = (string)button.Content;
            switch (blurbLayer)
            {
                case 0:
                    orgPressed = buttonPressed;
                    blurbLayer += 1;
                    displayBlurbs();
                    break;
                case 1:
                    areaPressed = buttonPressed;
                    blurbLayer += 1;
                    displayBlurbs();
                    break;
                case 2:
                    blurbPressed = buttonPressed;
                    blurbLayer += 1;
                    displayBlurbs();
                    blurbLayer -= 1;
                    Clipboard.SetText(blurbToClipboard);
                    displayInStatusBar("Blurb copied to clipboard");

                    break;
                default:
                    break;
            }
        }

        private void btnBlurbBack_Click(object sender, RoutedEventArgs e)
        {
            var blurbSettings = new BlurbSettings();

            if (blurbLayer == 0)
            {
                blurbSettings.ShowDialog();
                if (blurbSettings.DialogResult == true)
                {
                    openBlurbs();
                    displayInStatusBar("Loaded Blurbs");
                    displayBlurbs();
                }
            }
            else
            {
                blurbLayer -= 1;
                displayBlurbs();
            }
        }

        private void btnLinkSettings_Click(object sender, RoutedEventArgs e)
        {
            var linkSettings = new LinkSettings();

            linkSettings.ShowDialog();
            if (linkSettings.DialogResult == true)
            {
                openLinks();
                displayInStatusBar("Loaded Links");
                displayLinks();
            }

        }

        private void btnListConvert_Click(object sender, RoutedEventArgs e)
        {
            string pre = cmbPreDelim.Text;
            string post = cmbPostDelim.Text;

            string translatedPre = translateDelimiter(pre);
            string translatedPost = translateDelimiter(post);

            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.textReplacer(entry, translatedPre, translatedPost);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }

        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {
            int pre = cmbPreDelim.SelectedIndex;
            int post = cmbPostDelim.SelectedIndex;

            cmbPostDelim.SelectedIndex = pre;
            cmbPreDelim.SelectedIndex = post;

        }

        private void btnLower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.lowerCase(entry);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnUpper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.upperCase(entry);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            string pre = txtPreReplace.Text;
            string post = txtPostReplace.Text;

            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.textReplacer(entry, pre, post);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnPrepend_Click(object sender, RoutedEventArgs e)
        {
            string add = txtAttacher.Text;

            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.prepend(entry, add);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }

        }

        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            string add = txtAttacher.Text;

            try
            {
                TextManipulation logic = new TextManipulation();
                string entry = txtTextManipulatorInOut.Text;
                txtTextManipulatorInOut.Text = logic.append(entry, add);
                Clipboard.SetText(txtTextManipulatorInOut.Text);
                txtTextManipulatorInOut.SelectAll();
                txtTextManipulatorInOut.Focus();
                displayInStatusBar("New text copied to clipboard");
            }
            catch (Exception)
            {
                displayInStatusBar("An error ocurred, try again");
                return;
            }
        }

        private void btnUndoTextManipulator_Click(object sender, RoutedEventArgs e)
        {
            txtTextManipulatorInOut.Undo();
        }

        private void btnRedoTextManipulator_Click(object sender, RoutedEventArgs e)
        {
            txtTextManipulatorInOut.Redo();
        }
    }

}
