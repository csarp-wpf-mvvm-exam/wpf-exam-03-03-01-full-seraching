using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Service;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Kreta.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class ParentViewModel : BaseViewModel
    {
        private readonly IParentService? _parentService;

        [ObservableProperty]
        private ObservableCollection<Parent> _parents = new();

        [ObservableProperty]
        private Parent _selectedParent;

        public ParentViewModel()
        {
            SelectedParent = new Parent();
        }

        public ParentViewModel(IParentService? parentService)
        {
            SelectedParent = new Parent();
            _parentService = parentService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
        }

        [RelayCommand]
        private async Task DoSave(Parent newParent)
        {
            if (_parentService is not null)
            {
                ControllerResponse result = new();
                if (newParent.HasId)
                    result = await _parentService.UpdateAsync(newParent);
                else
                    result = await _parentService.InsertAsync(newParent);

                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        private async Task DoRemove(Parent parentToDelete)
        {
            if (_parentService is not null)
            {
                ControllerResponse result = await _parentService.DeleteAsync(parentToDelete.Id);
                if (result.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        private async Task UpdateView()
        {
            if (_parentService is not null)
            {
                List<Parent> parents = await _parentService.SelectAllParent();
                Parents = new ObservableCollection<Parent>(parents);
            }
        }

        [RelayCommand]
        private void DoNewParent()
        {
            SelectedParent = new Parent();
        }



    }
}
