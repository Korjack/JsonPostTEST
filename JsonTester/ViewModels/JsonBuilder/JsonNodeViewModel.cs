using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;

namespace JsonTester.ViewModels.JsonBuilder;

public record JsonTypeItem(string TypeName, string Color, string Example);

public class JsonNodeViewModel : ViewModelBase
{
    public static JsonTypeItem[] Types { get; } =
    [
        new("문자열", "#107c10", "\"abc\""),
        new("숫자",   "#0067c0", "42"),
        new("참/거짓",   "#8764b8", "true"),
        new("객체",   "#b25400", "{ .. }"),
        new("비어있음",   "#9a9a9a", "null"),
    ];

    private JsonTypeItem _selectedType = Types[0];
    
    public JsonTypeItem SelectedType
    {
        get => _selectedType;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedType, value);
            this.RaisePropertyChanged(nameof(IsStringType));
            this.RaisePropertyChanged(nameof(IsNumberType));
            this.RaisePropertyChanged(nameof(IsBoolType));
            this.RaisePropertyChanged(nameof(IsObjectType));
            this.RaisePropertyChanged(nameof(IsNullType));
        }
    }
    
    public ObservableCollection<JsonNodeViewModel> Children { get; } = [];

    public ICommand AddChildrenNodeCommand { get; }
    public JsonNodeViewModel()
    {
        AddChildrenNodeCommand = ReactiveCommand.Create(AddChildrenNode);
    }

    public void AddChildrenNode()
    {
        Children.Add(new JsonNodeViewModel());
    }
    
    public bool HasChildren => Children.Count > 0;
    public bool IsStringType => SelectedType == Types[0];
    public bool IsNumberType => SelectedType == Types[1];
    public bool IsBoolType => SelectedType == Types[2];
    public bool IsObjectType => SelectedType == Types[3];
    public bool IsNullType => SelectedType == Types[4];
}
