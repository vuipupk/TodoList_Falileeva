using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoListWPF.Models
{
    public class TodoModel : INotifyPropertyChanged
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; OnPropertyChanged(); }
        }

        private TaskPriority _priority;
        public TaskPriority Priority
        {
            get { return _priority; }
            set { _priority = value; OnPropertyChanged(); }
        }

        private TaskStatus _status;
        public TaskStatus Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}



