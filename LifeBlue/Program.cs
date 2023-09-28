using LifeBlue;

string[,] values =
{
    {"/section/index.html", "/section/page.html"},
    {"/section/page.html", "/section/other-page.html"},
    {"/section/index.html", "/section/subsection/index.html"},
    {"/section/index.html", "/section/subsection/page.html"},
    {"/section/subsection/index.html", "section/other/index.html"}
};

for (int i = 0; i < values.Length / 2; i++)
{
    var webpage = new Webpage();
    var myUrl = values[i, 0];
    var requestedUrl = values[i, 1];
    var showHighlight = webpage.ShowHighlight(myUrl, requestedUrl);
    Console.WriteLine($"Show highlight for {myUrl} and {requestedUrl}: {showHighlight}");
}

Console.Read();