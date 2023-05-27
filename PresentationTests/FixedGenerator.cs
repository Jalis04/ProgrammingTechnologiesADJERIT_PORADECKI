using Presentation;
using Presentation.Model.API;
using Presentation.ViewModel;
using Service.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.API;
using DataLayer.Implementation;
namespace PresentationTests;

internal class FixedGenerator : IGenerator
{
    private readonly IErrorInformer _informer = new TextErrorInformer();
    private readonly IDataRepository _repository = IDataRepository.CreateDatabase();

    public void GenerateUserModels(IUserMasterViewModel viewModel)
    {
        IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);
        IUserModelOperation operation = IUserModelOperation.CreateModelOperation(userCrud);

        viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(1, "John", "Doe", operation, _informer));
        viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(2, "Jane", "Doe", operation, _informer));
    }

    public void GenerateProductModels(IProductMasterViewModel viewModel)
    {
        IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);
        IProductModelOperation operation = IProductModelOperation.CreateModelOperation(productCrud);

        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(1, "Black Coffee", "Strong blend", 3.5f, operation, _informer));
        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(2, "Latte", "Flavorful", 4.5f, operation, _informer));

    }

    public void GenerateStateModels(IStateMasterViewModel viewModel)
    {
        IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);
        IStateModelOperation operation = IStateModelOperation.CreateModelOperation(stateCrud);

        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(1, 1, true, operation, _informer));
        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(2, 2, false, operation, _informer));
    }

    public void GenerateEventModels(IEventMasterViewModel viewModel)
    {
        IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);
        IEventModelOperation operation = IEventModelOperation.CreateModelOperation(eventCrud);
        //int id, int stateId, int userId, DateTime occurrenceDate, string type,
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(1, 1, 1, "PlacedEvent", operation, _informer));
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(2, 2, 2, "PayedEvent", operation, _informer));


    }
}