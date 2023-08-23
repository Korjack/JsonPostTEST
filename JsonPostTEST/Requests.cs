using System.Net;
using System.Text;

namespace JsonPostTEST;

public class Requests
{
    private HttpWebRequest webRequest;
    private string _URL = string.Empty;
    public string _responseText { private set; get; }
    
    public Requests(string URL)
    {
        this._URL = URL;
    }

    public HttpStatusCode POST(string data, int timeout, string ContentType="application/json; charset=utf-8")
    {
        webRequest = (HttpWebRequest) WebRequest.Create(_URL);
        
        webRequest.Method = "POST";
        webRequest.Timeout = timeout;
        webRequest.ContentType = ContentType;
        
        string postData = data;
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        
        Stream dataStream = webRequest.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
        HttpStatusCode status = resp.StatusCode;

        return status;
    }
}