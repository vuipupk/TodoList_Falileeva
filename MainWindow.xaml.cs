using System;
using System.Windows;
using TodoListWPF.Models;
using TodoListWPF.Repositories;
using TodoListWPF.Services;

namespace TodoListWPF
{
    public partial class MainWindow : Window
    {
        private TodoService _service;

        public MainWindow()
        {
            InitializeComponent();

            
            var repository = new JsonTaskRepository();
            _service = new TodoService(repository);

            
            DgTasks.ItemsSource = _service.Tasks;

            
            CmbPriority.ItemsSource = Enum.GetValues(typeof(TaskPriority));
            CmbPriority.SelectedIndex = 0;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtTitle.Text))
            {
                MessageBox.Show("Введите название задачи");
                return;
            }

            var newTask = new TodoModel
            {
                Title = TxtTitle.Text,
                Description = TxtDescription.Text,
                DueDate = DpDueDate.SelectedDate ?? DateTime.Now.AddDays(1),
                Priority = (TaskPriority)CmbPriority.SelectedItem
            };

            _service.AddTask(newTask);

            TxtTitle.Text = "";
            TxtDescription.Text = "";
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DgTasks.SelectedItem is TodoModel selectedTask)
            {
                _service.DeleteTask(selectedTask);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _service.Save();
            MessageBox.Show("Задачи сохранены в файл tasks.json");
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            _service.Load();
            MessageBox.Show("Задачи загружены!");
        }
    }
}















