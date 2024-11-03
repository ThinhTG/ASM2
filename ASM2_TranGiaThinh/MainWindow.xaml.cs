using Services;
using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BussinessObject;
using Task = BussinessObject.Task;

namespace ASM2_TranGiaThinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TaskService taskService;

        public MainWindow()
        {
            InitializeComponent();
            taskService = new TaskService();
            LoadTasks();
        }

        private void LoadTasks()
        {
            ArrayList tasks = taskService.GetAllTasks();
            dataGridTasks.ItemsSource = null;
            dataGridTasks.ItemsSource = tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(GetNextTaskId().ToString(),out int id))
            {
                string title = txtTitle.Text.Trim();
                string description = txtDescription.Text.Trim();
                string priority = txtPriority.Text.Trim();
                DateTime dueDate = dpDueDate.SelectedDate ?? DateTime.Now;
                string status = "Not Completed";

                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(priority))
                {
                    MessageBox.Show("Please enter Title and Priority.");
                    return;
                }

                Task newTask = new Task(id, title, description, priority, dueDate,status);
                taskService.AddTask(newTask);
                LoadTasks();
                ClearFields();
            }
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridTasks.SelectedItem is not Task selectedTask)
            {
                MessageBox.Show("Vui lòng chọn một công việc để cập nhật.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtPriority.Text) ||
                dpDueDate.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            DateTime dueDate;
            if (!DateTime.TryParse(dpDueDate.Text, out dueDate))
            {
                MessageBox.Show("Ngày đến hạn không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.");
                return;
            }
            selectedTask.Title = txtTitle.Text.Trim();
            selectedTask.Description = txtDescription.Text.Trim();
            selectedTask.Priority = txtPriority.Text.Trim();
            selectedTask.DueDate = dueDate;
            selectedTask.Status = selectedTask.Status; 
            taskService.UpdateTask(selectedTask);
            MessageBox.Show("Công việc đã được cập nhật thành công.");
            LoadTasks();
            ClearFields();
        }



        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridTasks.SelectedItem is Task selectedTask)
            {
                var result = MessageBox.Show($"Are you sure you want to delete task '{selectedTask.Title}'?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    taskService.DeleteTask(selectedTask.Id);
                    LoadTasks();
                    ClearFields() ;
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            txtPriority.Clear();
            dpDueDate.SelectedDate = null;
        }

        private int GetNextTaskId()
        {
            ArrayList tasks = taskService.GetAllTasks();
            if (tasks.Count == 0)
                return 1;
            else
                return ((Task)tasks[tasks.Count - 1]).Id + 1;
        }

        private void dataGridTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridTasks.SelectedItem is Task selectedTask)
            {
                txtTitle.Text = selectedTask.Title;
                txtDescription.Text = selectedTask.Description;
                txtPriority.Text = selectedTask.Priority;
                dpDueDate.SelectedDate = selectedTask.DueDate;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchTitle = txtTitle.Text.Trim().ToLower();
            string searchPriority = txtPriority.Text.Trim().ToLower();
            DateTime? searchDueDate = dpDueDate.SelectedDate;
            var filteredTasks = taskService.GetAllTasks().Cast<Task>()
                .Where(task =>
                    (string.IsNullOrEmpty(searchTitle) || task.Title.ToLower().Contains(searchTitle)) &&
                    (string.IsNullOrEmpty(searchPriority) || task.Priority.ToLower().Contains(searchPriority)) &&
                    (!searchDueDate.HasValue || task.DueDate.Date == searchDueDate.Value.Date)
                ).ToList();
            dataGridTasks.ItemsSource = filteredTasks;
        }

        private void MarkAsCompleted_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridTasks.SelectedItem is Task selectedTask)
            {
                selectedTask.Status = "Completed";
                taskService.UpdateTask(selectedTask);
                LoadTasks();
                MessageBox.Show("Task marked as completed.");
            }
            else
            {
                MessageBox.Show("Please select a task to mark as completed.");
            }
        }

    }
}