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
    public partial class ParentViewModel : BaseViewModelWithAsyncInitialization
    {
        private readonly IParentService? _tService;

        [ObservableProperty]
        private ObservableCollection<Parent> _parent = new();

        [ObservableProperty]
        private Parent _selectedParent;

        private string _selectedEducationLevel = string.Empty;
        public string SelectedEducationLevel
        {
            get => _selectedEducationLevel;
            set
            {
                SetProperty(ref _selectedEducationLevel, value);
            }
        }

        public ParentViewModel()
        {
            SelectedParent = new Parent();
        }

        public ParentViewModel(IParentService? studentService)
        {
            SelectedParent = new Parent();
            _tService = studentService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
        }

        [RelayCommand]
        public async Task DoSave(Parent newStudent)
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
        public async Task DoRemove(Parent studentToDelete)
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
                List<Parent> students = await _tService.SelectAllParent();
                Parent = new ObservableCollection<Parent>(students);
            }
        }

        [RelayCommand]
        void DoNewStudent()
        {
            SelectedParent = new Parent();
        }



    }
}
