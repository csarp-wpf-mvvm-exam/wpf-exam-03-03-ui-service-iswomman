using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Service;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using KretaBasicSchoolSystem.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace KretaBasicSchoolSystem.Desktop.ViewModels.SchoolCitizens
{
    public partial class StudentViewModel : BaseViewModelWithAsyncInitialization
    {        
        private readonly IStudentService? _studentService;

        [ObservableProperty]
        private ObservableCollection<Student> _students = new();

        [ObservableProperty]
        private Student _selectedStudent;

        private string _selectedEducationLevel = string.Empty;
        public string SelectedEducationLevel
        {
            get => _selectedEducationLevel;
            set
            {
                SetProperty(ref _selectedEducationLevel, value);
            }
        }

        public StudentViewModel()
        {
            SelectedStudent = new Student();
        }

        public StudentViewModel(IStudentService? studentService)
        {
            SelectedStudent = new Student();
            _studentService = studentService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
        }

        [RelayCommand]
        public async Task DoSave(Student newStudent)
        {
            if (_studentService is not null)
            {
                ControllerResponse result = new();
                if (newStudent.HasId)
                    result = await _studentService.UpdateAsync(newStudent);
                else
                    result = await _studentService.InsertAsync(newStudent);

                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        public async Task DoRemove(Student studentToDelete)
        {
            if (_studentService is not null)
            {
                ControllerResponse result = await _studentService.DeleteAsync(studentToDelete.Id);
                if (result.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        private async Task UpdateView()
        {
            if (_studentService is not null)
            {
                List<Student> students = await _studentService.SelectAllStudent();
                Students = new ObservableCollection<Student>(students);
            }
        }

        [RelayCommand]
        void DoNewStudent()
        {
            SelectedStudent = new Student();
        }

    }
}
