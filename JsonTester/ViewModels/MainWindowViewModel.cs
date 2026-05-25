using JsonTester.ViewModels.Inspector;
using JsonTester.ViewModels.JsonBuilder;

namespace JsonTester.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public PresetSidebarViewModel PresetSidebarViewModel { get; } = new();
    public JsonBuilderViewModel JsonBuilderViewModel { get; } = new();
    public InspectorViewModel InspectorViewModel { get; } = new();
}