﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Service;
using Kreta.Desktop.ViewModels.Base;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class SchoolCitizensViewModel : BaseViewModel
    {
        private readonly StudentViewModel _studentViewModel;
        private readonly ParentViewModel _parentViewModel;
        private readonly TeacherViewModel _teacherViewModel;

        public SchoolCitizensViewModel()
        {
            IStudentService studentService = new StudentService(null);
            _studentViewModel = new StudentViewModel(studentService);
            IParentService parent = new ParentService(null);
            _parentViewModel = new ParentViewModel(parent);
            ITeacherService teacher = new TeacherService(null);
            _teacherViewModel = new TeacherViewModel(teacher);

            CurrentChildViewModel = new TeacherViewModel();
        }

        public SchoolCitizensViewModel(StudentViewModel studentViewModel, ParentViewModel parentViewModel, TeacherViewModel teacherViewModel)
        {
            _studentViewModel = studentViewModel;
            _parentViewModel = parentViewModel;
            _teacherViewModel = teacherViewModel;

            CurrentChildViewModel = new TeacherViewModel();
        }

        [ObservableProperty]
        private BaseViewModel _currentChildViewModel;

        [RelayCommand]
        public async Task ShowStudentView()
        {
            await _studentViewModel.InitializeAsync();
            CurrentChildViewModel = _studentViewModel;
        }


        [RelayCommand]
        public async Task ShowTeacherView()
        {
            await _teacherViewModel.InitializeAsync();
            CurrentChildViewModel = _teacherViewModel;
        }

        [RelayCommand]
        public async Task ShowParentView()
        {
            await _parentViewModel.InitializeAsync();
            CurrentChildViewModel = _parentViewModel;
        }
    }
}
