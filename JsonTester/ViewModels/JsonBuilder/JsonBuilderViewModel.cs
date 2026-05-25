using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;

namespace JsonTester.ViewModels.JsonBuilder;

public class JsonBuilderViewModel : ViewModelBase
{
    public ObservableCollection<JsonNodeViewModel> Nodes { get; } = [];
    
    public ICommand AddNodeCommand { get; set; }

    public JsonBuilderViewModel()
    {
        AddNodeCommand = ReactiveCommand.Create(AddNode);
    }
    
    private void AddNode()
    {
        Nodes.Add(new JsonNodeViewModel());
    }
    
    private void Clear()
    {
        Nodes.Clear();
    }
}