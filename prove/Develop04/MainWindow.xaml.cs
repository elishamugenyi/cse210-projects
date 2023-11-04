using System;
using System.Collections.Generic;
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

namespace Develop04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            int choice;
            if (int.TryParse(userInput.Text, out choice))
            {
                if (choice == 1)
                {
                    // Start the breathing activity
                    Breathing breathing = new Breathing();
                }
                else if (choice == 2)
                {
                    // Run the reflection activity
                    Console.Write("Enter the duration for the reflection activity in seconds: ");
                    if (int.TryParse(Console.ReadLine(), out int durationInSeconds))
                    {
                        Reflection reflection = new Reflection(durationInSeconds);
                        reflection.StartActivity();
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number of seconds.");
                    }
                }
                else if (choice == 3)
                {
                    // Run the listing exercise
                    Listing listing = new Listing();
                    string prompt = listing.ChoosePrompt();
                    MessageBox.Show(prompt, "Exercise Prompt");
                }
                else if (choice == 4)
                {
                    // Exit program
                    Application.Current.Shutdown();
                }
                else
                {
                    MessageBox.Show("Invalid option. Please Try Again", "Error");
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a number.", "Error");
            }
        }
    }
}
