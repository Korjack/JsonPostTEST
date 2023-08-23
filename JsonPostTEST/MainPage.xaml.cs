using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;

namespace JsonPostTEST;

public partial class MainPage : ContentPage
{
    private Requests _requests;
    private string URL;
    private int IntervalTime;
    
    private Thread sendWorker;
    
    private bool isRunning = false;
	
    public MainPage()
    {
        InitializeComponent();
        URL = InputURL.Text;
    }

    private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry = sender as Entry;
        URL = entry.Text;
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;

        if (isRunning)
        {
            button.Text = "전송 시작";
            isRunning = false;

            InputURL.IsEnabled = true;
            InputIntervalTime.IsEnabled = true;
            IsLoop.IsEnabled = true;
        }
        else
        {
            button.Text = "전송 진행중";
            isRunning = true;

            InputURL.IsEnabled = false;
            InputIntervalTime.IsEnabled = false;
            IsLoop.IsEnabled = false;

            IntervalTime = int.Parse(InputIntervalTime.Text);
            _requests = new Requests(URL);
            sendWorker = new Thread(new ThreadStart(sendPostData));
            // sendWorker.Start();
        }
    }

    private void sendPostData()
    {
        HttpStatusCode statusCode = HttpStatusCode.OK;
        while (isRunning && statusCode == HttpStatusCode.OK)
        {
            statusCode = _requests.POST("{A:1}", 1000);
            Thread.Sleep(IntervalTime);
        }
    }

    private void AddJsonTemplates(object sender, EventArgs e)
    {
        VerticalStackLayout parent = (sender as Button).Parent as VerticalStackLayout;
        
        VerticalStackLayout verticalStackLayout = new VerticalStackLayout();
        verticalStackLayout.Spacing = 5;
        verticalStackLayout.Padding = 10;
        
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

        Button button = new Button();
        button.Text = "Json Data 추가";
        button.Clicked += AddJsonTemplates;
        
        verticalStackLayout.Add(grid);
        verticalStackLayout.Add(button);
        
        parent.Add(verticalStackLayout);
    }
}