using Microsoft.Maui.Controls.Shapes;

namespace JsonPostTEST.CustomView;

public partial class JsonView : Frame
{
    public JsonView()
    {
        InitializeComponent();
    }

    private void AddJsonTempaltes(object sender, EventArgs e)
    {
        VerticalStackLayout root = ((sender as Button).Parent as HorizontalStackLayout).Parent as VerticalStackLayout;
        CreateJsonEntry(root);
    }

    private void CreateJsonEntry(VerticalStackLayout root)
    {
        Grid grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
            }
        };
        grid.ColumnSpacing = 10;
        grid.Padding = 10;

        Entry left = new Entry();
        Entry right = new Entry();
        
        grid.Add(left);
        grid.Add(right);
        grid.SetColumn(left, 0);
        grid.SetColumn(right, 1);
        
        root.Insert(root.Children.Count - 1, grid);
    }

    private void AddJsonChildTemplates(object sender, EventArgs e)
    {
        VerticalStackLayout root = ((sender as Button).Parent as HorizontalStackLayout).Parent as VerticalStackLayout;
        root.Margin = 10;
        
        Border border = new Border();
        border.Padding = 20;
        border.Stroke = Brush.Black;
        border.StrokeThickness = 2;
        border.StrokeShape = new RoundRectangle{
            CornerRadius = new CornerRadius(15, 15, 15, 15)
        };
        
        VerticalStackLayout child_root = new VerticalStackLayout();
        child_root.Spacing = 20;

        Entry child_title = new Entry();
        child_root.Add(child_title);
        child_root.Add(new JsonView());

        border.Content = child_root; 
            
        root.Insert(root.Children.Count - 1, border);
    }

    private void RemoveJsonTemplates(object sender, EventArgs e)
    {
        VerticalStackLayout root = ((sender as Button).Parent as HorizontalStackLayout).Parent as VerticalStackLayout;

        int childsCount = root.Children.Count;
        if (childsCount > 2)
        {
            root.RemoveAt(childsCount - 2);
        }
    }
}