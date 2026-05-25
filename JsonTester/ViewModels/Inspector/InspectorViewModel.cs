using System.Collections.ObjectModel;
using ReactiveUI;

namespace JsonTester.ViewModels.Inspector;

public class InspectorViewModel : ViewModelBase
{
    public ObservableCollection<TabItemViewModel> Tabs { get; } = new()
    {
        new TabItemViewModel("미리보기", new PreviewViewModel())
    };
    
    private TabItemViewModel? _selectedTab;
    public TabItemViewModel? SelectedTab
    {
        get => _selectedTab;
        set => this.RaiseAndSetIfChanged(ref _selectedTab, value);
    }
}