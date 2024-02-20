using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Service;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Kreta.Desktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class TeacherViewModel : BaseViewModelWithAsyncInitialization
    {
        private readonly ITeacherService? _teacherService;

        [ObservableProperty]
        private ObservableCollection<Teacher> _teachers = new();

        [ObservableProperty]
        private Teacher _selectedTeacher;

        public TeacherViewModel()
        {
            SelectedTeacher = new Teacher();
        }

        public TeacherViewModel(ITeacherService? teacherService)
        {
            SelectedTeacher = new Teacher();
            _teacherService = teacherService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
        }

        [RelayCommand]
        public async Task DoSave(Teacher newTeacher)
        {
            if (_teacherService is not null)
            {
                ControllerResponse result = new();
                if (newTeacher.HasId)
                    result = await _teacherService.UpdateAsync(newTeacher);
                else
                    result = await _teacherService.InsertAsync(newTeacher);

                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        public async Task DoRemove(Teacher teacherToDelete)
        {
            if (_teacherService is not null)
            {
                ControllerResponse result = await _teacherService.DeleteAsync(teacherToDelete.Id);
                if (result.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        private async Task UpdateView()
        {
            if (_teacherService is not null)
            {
                List<Teacher> students = await _teacherService.SelectAllTeacher();
                Teachers = new ObservableCollection<Teacher>(students);
            }
        }

        [RelayCommand]
        void DoNewStudent()
        {
            SelectedTeacher = new Teacher();
        }

    }
}
