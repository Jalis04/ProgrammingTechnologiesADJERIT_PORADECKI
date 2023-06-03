using Presentation;
using Presentation.Model.API;
using Presentation.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Implementation;
using PresentationTests.MockItems;

namespace PresentationTests;

internal class FixedGenerator : IGenerator
{
    private readonly IErrorInformer _informer = new TextErrorInformer();

    public void GenerateUserModels(IUserMasterViewModel viewModel)
    {
        IUserModelOperation operation = new MockUserCRUD();

        viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(1, "John", "Doe", operation, _informer));
        viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(2, "Jane", "Doe", operation, _informer));
    }

    public void GenerateProductModels(IProductMasterViewModel viewModel)
    {
        IProductModelOperation operation = new MockProductCRUD();

        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(1, "Black Coffee", "Strong blend", 3.5f, operation, _informer));
        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(2, "Latte", "Flavorful", 4.5f, operation, _informer));

    }

    public void GenerateStateModels(IStateMasterViewModel viewModel)
    {
        IStateModelOperation operation = new MockStateCRUD();

        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(1, 1, true, operation, _informer));
        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(2, 2, false, operation, _informer));
    }

    public void GenerateEventModels(IEventMasterViewModel viewModel)
    {

        IEventModelOperation operation = new MockEventCRUD();
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(1, 1, 1, "PlacedEvent", operation, _informer));
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(2, 2, 2, "PayedEvent", operation, _informer));


    }
}