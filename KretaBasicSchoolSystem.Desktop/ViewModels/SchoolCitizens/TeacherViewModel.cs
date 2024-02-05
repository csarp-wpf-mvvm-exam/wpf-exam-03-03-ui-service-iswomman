using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Service;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using KretaBasicSchoolSystem.Desktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaBasicSchoolSystem.Desktop.ViewModels.SchoolCitizens
{
    public partial class TeacherViewModel : BaseViewModelWithAsyncInitialization
    {
        private readonly ITeacherService? _tService;

        [ObservableProperty]
        private ObservableCollection<Teacher> _teacher = new();

        [ObservableProperty]
        private Teacher _selectedTeacher;

        private string _selectedEducationLevel = string.Empty;
        public string SelectedEducationLevel
        {
            get => _selectedEducationLevel;
            set
            {
                SetProperty(ref _selectedEducationLevel, value);
            }
        }

        public TeacherViewModel()
        {
            SelectedTeacher = new Teacher();
        }

        public TeacherViewModel(ITeacherService? studentService)
        {
            SelectedTeacher = new Teacher();
            _tService = studentService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
        }

        [RelayCommand]
        public async Task DoSave(Teacher newStudent)
        {
            if (_tService is not null)
            {
                ControllerResponse result = new();
                if (newStudent.HasId)
                    result = await _tService.UpdateAsync(newStudent);
                else
                    result = await _tService.InsertAsync(newStudent);

                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        public async Task DoRemove(Teacher studentToDelete)
        {
            if (_tService is not null)
            {
                ControllerResponse result = await _tService.DeleteAsync(studentToDelete.Id);
                if (result.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        private async Task UpdateView()
        {
            if (_tService is not null)
            {
                List<Teacher> students = await _tService.SelectAllTeacher();
                Teacher = new ObservableCollection<Teacher>(students);
            }
        }

        [RelayCommand]
        void DoNewStudent()
        {
            SelectedTeacher = new Teacher();
        }

    }
}
