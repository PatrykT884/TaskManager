using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TaskManager.Domain.Models;

namespace TaskManager.App.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        private string _newTaskTitle;
        public string NewTaskTitle
        {
            get => _newTaskTitle;
            set
            {
                if (_newTaskTitle != value)
                {
                    _newTaskTitle = value;
                    OnPropertyChanged(nameof(NewTaskTitle));
                    _addTaskCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        private RelayCommand _addTaskCommand;
        public ICommand AddTaskCommand => _addTaskCommand;
        public ICommand DeleteTaskCommand { get; }

       /// <summary>
       /// Methods
       /// </summary>
        public MainViewModel()
        {
            _addTaskCommand = new RelayCommand(
                  _ => AddTask(),
                  _ => !string.IsNullOrWhiteSpace(NewTaskTitle));
            DeleteTaskCommand = new RelayCommand(task => DeleteTask(task as TaskItem));
        }

        private void AddTask()
        {
            Tasks.Add(new TaskItem { Title = NewTaskTitle, IsCompleted = false });
            NewTaskTitle = string.Empty;
        }

        private void DeleteTask(TaskItem? task)
        {
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
