using System.Net;
using JsonPostTEST.CustomView;

namespace JsonPostTEST;

public partial class MainPage : ContentPage
{
    private Requests _requests;
    private string URL;
    private int IntervalTime;
    
    private Thread sendWorker;
    
    private bool isRunning = false;

    private Dictionary<string, object> JsonData;
	
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
        GetJsonDataFromUI();
        // Button button = sender as Button;
        //
        // if (isRunning)
        // {
        //     button.Text = "전송 시작";
        //     isRunning = false;
        //
        //     InputURL.IsEnabled = true;
        //     InputIntervalTime.IsEnabled = true;
        //     IsLoop.IsEnabled = true;
        // }
        // else
        // {
        //     button.Text = "전송 진행중";
        //     isRunning = true;
        //
        //     InputURL.IsEnabled = false;
        //     InputIntervalTime.IsEnabled = false;
        //     IsLoop.IsEnabled = false;
        //
        //     IntervalTime = int.Parse(InputIntervalTime.Text);
        //     _requests = new Requests(URL);
        //         
        //     sendWorker = new Thread(new ThreadStart(sendPostData));
        //     // sendWorker.Start();
        // }
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


    private void readJson(VerticalStackLayout verticalStackLayout, Dictionary<string, object> dic)
    {
        foreach (var child in verticalStackLayout)
        {
            if (child is Grid)
            {
                Grid grid = child as Grid;
                Entry left = grid.Children[0] as Entry;
                Entry right = grid.Children[1] as Entry;
                dic.Add(left.Text, right.Text);
            }
            else if (child is Border)
            {
                Border border = child as Border;
                Entry entry = (border.Content as VerticalStackLayout).Children[0] as Entry;
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                
                dic.Add(entry.Text, dictionary);
                readJson((((child as Border).Content as VerticalStackLayout).Children[1] as JsonView).Content as VerticalStackLayout, dictionary);
            }
        }
    }

    private void GetJsonDataFromUI()
    {
        VerticalStackLayout verticalStackLayout = JsonDataView.Content as VerticalStackLayout;
        JsonData = new Dictionary<string, object>();
        
        readJson(verticalStackLayout, JsonData);

        Console.WriteLine(DicToString(JsonData));
    }

    private string DicToString(Dictionary<string, object> dic)
    {
        string reuslt = "";
        foreach (var item in dic)
        {
            if (item.Value is Dictionary<string, object>)
            {
                reuslt += $"[\n{item.Key} : \n";
                reuslt += DicToString(item.Value as Dictionary<string, object>);
                reuslt += "\n]";
            }
            else
            {
                reuslt += $"[{item.Key} : {item.Value}]\n";
                Console.WriteLine();
            }
        }

        return reuslt;
    }
}