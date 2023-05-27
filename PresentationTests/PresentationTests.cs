using Presentation;
using Presentation.Model.API;
using Presentation.ViewModel;
using Service.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.API;
using DataLayer.Implementation;
using System.Reflection.Emit;
using PresentationTests.TestItems;

namespace PresentationTests;

[TestClass]
public class PresentationTests
{
    private readonly IErrorInformer _informer = new TextErrorInformer();
    private readonly IDataRepository _repository = IDataRepository.CreateDatabase();

    [TestMethod]
    public void UserMasterViewModelTests()
    {
        //IUserCRUD fakeUserCrud = new FakeUserCRUD();
        IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

        IUserModelOperation operation = IUserModelOperation.CreateModelOperation(userCrud);

        IUserMasterViewModel viewModel = IUserMasterViewModel.CreateViewModel(operation, _informer);
        viewModel.FirstName = "John";
        viewModel.LastName = "Doe";

        Assert.IsNotNull(viewModel.CreateUser);
        Assert.IsNotNull(viewModel.RemoveUser);

        Assert.IsTrue(viewModel.CreateUser.CanExecute(null));

        Assert.IsTrue(viewModel.RemoveUser.CanExecute(null));
    }

    [TestMethod]
    public void UserDetailViewModelTests()
    {
        //IUserCRUD fakeUserCrud = new FakeUserCRUD();
        IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

        IUserModelOperation operation = IUserModelOperation.CreateModelOperation(userCrud);

        IUserDetailViewModel detail = IUserDetailViewModel.CreateViewModel(1, "John", "Doe", operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual("John", detail.FirstName);
        Assert.AreEqual("Doe", detail.LastName);

        Assert.IsTrue(detail.UpdateUser.CanExecute(null));
    }

    [TestMethod]
    public void ProductMasterViewModelTests()
    {
        //IProductCRUD fakeProductCrud = new FakeProductCRUD();
        IProductCRUD productCrud = new TestProductCRUD();

        IProductModelOperation operation = IProductModelOperation.CreateModelOperation(productCrud);

        IProductMasterViewModel master = IProductMasterViewModel.CreateViewModel(operation, _informer);

        master.Name = "Black Coffee";
        master.Description = "Strong blend";
        master.Price = 3.5f;

        Assert.IsNotNull(master.CreateProduct);
        Assert.IsNotNull(master.RemoveProduct);

        Assert.IsTrue(master.CreateProduct.CanExecute(null));

        master.Price = -1;

        Assert.IsFalse(master.CreateProduct.CanExecute(null));

        Assert.IsTrue(master.RemoveProduct.CanExecute(null));
    }

    [TestMethod]
    public void ProductDetailViewModelTests()
    {
        //IProductCRUD fakeProductCrud = new FakeProductCRUD();
        IProductCRUD productCrud = new TestProductCRUD();

        IProductModelOperation operation = IProductModelOperation.CreateModelOperation(productCrud);

        IProductDetailViewModel detail = IProductDetailViewModel.CreateViewModel(1, "Black Coffee", "Strong blend", 3.5f,
            operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual("Black Coffee", detail.ProductName);
        Assert.AreEqual("Strong blend", detail.Description);
        Assert.AreEqual(3.5f, detail.Price);

        Assert.IsTrue(detail.UpdateProduct.CanExecute(null));
    }

    [TestMethod]
    public void StateMasterViewModelTests()
    {
        //IStateCRUD fakeStateCrud = new FakeStateCRUD();
        IStateCRUD stateCrud = new TestStateCRUD();

        IStateModelOperation operation = IStateModelOperation.CreateModelOperation(stateCrud);

        IStateMasterViewModel master = IStateMasterViewModel.CreateViewModel(operation, _informer);

        master.Id = 1;
        master.ProductId = 1;
        master.Available = true;

        Assert.IsNotNull(master.CreateState);
        Assert.IsNotNull(master.RemoveState);

        Assert.IsTrue(master.CreateState.CanExecute(null));

    }

    [TestMethod]
    public void StateDetailViewModelTests()
    {
        //IStateCRUD fakeStateCrud = new FakeStateCRUD();
        IStateCRUD stateCrud = new TestStateCRUD();

        IStateModelOperation operation = IStateModelOperation.CreateModelOperation(stateCrud);

        IStateDetailViewModel detail = IStateDetailViewModel.CreateViewModel(1, 1, true, operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual(1, detail.ProductId);
        Assert.IsTrue(detail.Available);

        Assert.IsTrue(detail.UpdateState.CanExecute(null));
    }

    [TestMethod]
    public void EventMasterViewModelTests()
    {
        //IEventCRUD fakeEventCrud = new FakeEventCRUD();
        IEventCRUD eventCrud = new TestEventCRUD();

        IEventModelOperation operation = IEventModelOperation.CreateModelOperation(eventCrud);

        IEventMasterViewModel master = IEventMasterViewModel.CreateViewModel(operation, _informer);

        master.StateId = 1;
        master.UserId = 1;
    }

    [TestMethod]
    public void EventDetailViewModelTests()
    {
        //IEventCRUD fakeEventCrud = new FakeEventCRUD();
        IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);

        IEventModelOperation operation = IEventModelOperation.CreateModelOperation(eventCrud);

        IEventDetailViewModel detail = IEventDetailViewModel.CreateViewModel(1, 1, 1, "PlacedEvent", operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual(1, detail.StateId);
        Assert.AreEqual(1, detail.UserId);
        Assert.AreEqual("PlacedEvent", detail.Type);

        Assert.IsTrue(detail.UpdateEvent.CanExecute(null));
    }

    [TestMethod]
    public void DataFixedGenerationMethodTests()
    {
        IGenerator fixedGenerator = new FixedGenerator();

        //IUserCRUD fakeUserCrud = new FakeUserCRUD();
        IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);
        IUserModelOperation userOperation = IUserModelOperation.CreateModelOperation(userCrud);
        IUserMasterViewModel userViewModel = IUserMasterViewModel.CreateViewModel(userOperation, _informer);

        //IProductCRUD fakeProductCrud = new FakeProductCRUD();
        IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);
        IProductModelOperation productOperation = IProductModelOperation.CreateModelOperation(productCrud);
        IProductMasterViewModel productViewModel = IProductMasterViewModel.CreateViewModel(productOperation, _informer);


        //IStateCRUD fakeStateCrud = new FakeStateCRUD();
        IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);
        IStateModelOperation stateOperation = IStateModelOperation.CreateModelOperation(stateCrud);
        IStateMasterViewModel stateViewModel = IStateMasterViewModel.CreateViewModel(stateOperation, _informer);

        //IEventCRUD fakeEventCrud = new FakeEventCRUD();
        IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);
        IEventModelOperation eventOperation = IEventModelOperation.CreateModelOperation(eventCrud);
        IEventMasterViewModel eventViewModel = IEventMasterViewModel.CreateViewModel(eventOperation, _informer);

        fixedGenerator.GenerateUserModels(userViewModel);
        fixedGenerator.GenerateProductModels(productViewModel);
        fixedGenerator.GenerateStateModels(stateViewModel);
        fixedGenerator.GenerateEventModels(eventViewModel);

        Assert.AreEqual(2, userViewModel.Users.Count);
        Assert.AreEqual(2, productViewModel.Products.Count);
        Assert.AreEqual(2, stateViewModel.States.Count);
        Assert.AreEqual(2, eventViewModel.Events.Count);
    }

    [TestMethod]
    public void DataRandomGenerationMethodTests()
    {
        IGenerator randomGenerator = new RandomGenerator();

        IUserCRUD fakeUserCrud = new TestUserCRUD();
        IUserModelOperation userOperation = IUserModelOperation.CreateModelOperation(fakeUserCrud);
        IUserMasterViewModel userViewModel = IUserMasterViewModel.CreateViewModel(userOperation, _informer);

        IProductCRUD fakeProductCrud = new TestProductCRUD();
        IProductModelOperation productOperation = IProductModelOperation.CreateModelOperation(fakeProductCrud);
        IProductMasterViewModel productViewModel = IProductMasterViewModel.CreateViewModel(productOperation, _informer);


        IStateCRUD fakeStateCrud = new TestStateCRUD();
        IStateModelOperation stateOperation = IStateModelOperation.CreateModelOperation(fakeStateCrud);
        IStateMasterViewModel stateViewModel = IStateMasterViewModel.CreateViewModel(stateOperation, _informer);

        IEventCRUD fakeEventCrud = new TestEventCRUD();
        IEventModelOperation eventOperation = IEventModelOperation.CreateModelOperation(fakeEventCrud);
        IEventMasterViewModel eventViewModel = IEventMasterViewModel.CreateViewModel(eventOperation, _informer);

        randomGenerator.GenerateUserModels(userViewModel);
        randomGenerator.GenerateProductModels(productViewModel);
        randomGenerator.GenerateStateModels(stateViewModel);
        randomGenerator.GenerateEventModels(eventViewModel);

        Assert.AreEqual(10, userViewModel.Users.Count);
        Assert.AreEqual(10, productViewModel.Products.Count);
        Assert.AreEqual(10, stateViewModel.States.Count);
        Assert.AreEqual(10, eventViewModel.Events.Count);
    }


}