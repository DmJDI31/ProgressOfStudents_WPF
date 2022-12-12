using ProgressOfStudents.Models;
using ProgressOfStudents.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace ProgressOfStudents
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        StudentService students;
        public AddWindow()
        {
            InitializeComponent();
            students = new StudentService();
            CreditBookTextBox.MaxLength = 7;
            AverageScoreTextBox.MaxLength = 3;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите прервать запись в базу данных?\nНесохранённые записи будут удалены!", "MyDataGrid",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(AverageScoreTextBox.Text) || !String.IsNullOrEmpty(CreditBookTextBox.Text) || !String.IsNullOrEmpty(UserNameTextBox.Text))
                {
                    students.Create(new Students { FullName = UserNameTextBox.Text, CreditBook = CreditBookTextBox.Text, AverageScore = AverageScoreTextBox.Text });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreditBookTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AverageScoreTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
