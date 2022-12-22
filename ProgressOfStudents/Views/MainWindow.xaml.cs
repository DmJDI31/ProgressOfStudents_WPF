using ProgressOfStudents.Models;
using ProgressOfStudents.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ProgressOfStudents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentService _studentService;

        public MainWindow()
        {
            InitializeComponent();
            _studentService = new StudentService();
            StudentAcademicPerformanceDataGrid.ItemsSource = _studentService.Get();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var AddWindow = new AddWindow();
            AddWindow.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void UpdateGrid()
        {
            StudentAcademicPerformanceDataGrid.ItemsSource = null;
            StudentAcademicPerformanceDataGrid.ItemsSource = _studentService.Get();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (StudentAcademicPerformanceDataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвержение удаления", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < StudentAcademicPerformanceDataGrid.SelectedItems.Count; i++)
                {
                    Students student = StudentAcademicPerformanceDataGrid.SelectedItems[i] as Students;
                    if (student != null)
                    {
                        _studentService.Delete(student);
                    }
                }
            }
        }

        private void StudentAcademicPerformanceDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _studentService.Update(e.Row.Item as Students);
            UpdateGrid();
        }
    }
}
