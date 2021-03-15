using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RichTextBox = System.Windows.Controls.RichTextBox;

namespace NotePad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationView model;
        private static RichTextBox rich = new RichTextBox();
        bool winState = true;
        public static  RichTextBox RichTextBox { get => rich; set { rich = value; } }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = model =new ApplicationView();
            RichTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            dockPanel.Children.Add(rich);
            ResizeMode = ResizeMode.CanResizeWithGrip;
            AllowsTransparency = true;
            this.Closing += MainWindow_Closing;
        }
        public MainWindow(string filename)
        {
            InitializeComponent();
            DataContext = model = new ApplicationView(filename);
            RichTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            dockPanel.Children.Add(rich);
            ResizeMode = ResizeMode.CanResizeWithGrip;
            AllowsTransparency = true;
            this.Closing += MainWindow_Closing;
        }
        private void MenuItem_SetColor(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = new Color();
                color.A = dialog.Color.A;
                color.B = dialog.Color.B;
                color.G = dialog.Color.G;
                color.R = dialog.Color.R;
                Brush brush = new SolidColorBrush(color);
                RichTextBox.Selection.ApplyPropertyValue(ForegroundProperty, brush);
            }
        }

        private void MenuItem_SetFont(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog dialog = new System.Windows.Forms.FontDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RichTextBox.FontFamily = new FontFamily(dialog.Font.Name);
            }
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!model.IsSave && model.Text != "") 
            {
                MessageBoxButtons message = new MessageBoxButtons();
                message = MessageBoxButtons.YesNoCancel;
                DialogResult dialog = System.Windows.Forms.MessageBox.Show("Сохранить изменения в файле", model.FileName, message);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    if (model.Path != null)
                        model.SaveFile.Execute(sender);
                    else
                        model.SaveAs.Execute(sender);
                    e.Cancel = model.IsSave ? false : true;
                }
                else if (dialog == System.Windows.Forms.DialogResult.No)
                { e.Cancel = false; }
                else if (dialog == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void buttonGreen_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void buttonOrange_Click(object sender, RoutedEventArgs e)
        {
            if (winState)
            {
                this.WindowState = WindowState.Maximized;
                winState = false;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                winState = true;
            }
        }

        private void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
