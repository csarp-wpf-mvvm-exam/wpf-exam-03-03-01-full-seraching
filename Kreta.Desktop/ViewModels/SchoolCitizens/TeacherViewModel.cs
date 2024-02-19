﻿using CommunityToolkit.Mvvm.ComponentModel;
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
            _teacherService = studentService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
        }

        [RelayCommand]
        public async Task DoSave(Teacher newStudent)
        {
            if (_teacherService is not null)
            {
                ControllerResponse result = new();
                if (newStudent.HasId)
                    result = await _teacherService.UpdateAsync(newStudent);
                else
                    result = await _teacherService.InsertAsync(newStudent);

                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        public async Task DoRemove(Teacher studentToDelete)
        {
            if (_teacherService is not null)
            {
                ControllerResponse result = await _teacherService.DeleteAsync(studentToDelete.Id);
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
