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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                if (File.ReadAllText(open.FileName).Length == 0)
                {
                }
                else
                {
                    Button button = new Button();
                    string[] filePath = open.FileName.Split('\\');
                    string filename = "";
                    for (int g = 0; g < filePath.Count(); g++)
                    {
                        if (g == filePath.Count() - 1)
                        {
                            filename = filePath[g];
                            if (filename.Contains("doc"))
                            {
                                button.Content = "📁";
                            }
                            if (filename.Contains("sql"))
                            {
                                button.Content = "🥔";
                            }
                        }
                    }
                    button.ToolTip = open.FileName.ToString();
                    //button.ToolTip = filename;
                    button.FontSize = 16;
                    button.Height = 40;
                    button.Width = 55;
                    button.MouseRightButtonDown += delete;
                    button.Click += path;
                    list.Items.Add(button);
                }
            }
        }

        public void delete(object sender, RoutedEventArgs e)
        {
            var body = sender as Button;
            list.Items.Remove(body);
        }
        public void path(object sender, RoutedEventArgs e)
        {
            var body = sender as Button;
            PathText.Text = body.ToolTip.ToString();
        }
    }
}
