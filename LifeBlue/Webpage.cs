namespace LifeBlue
{
    public class Webpage
    {
        private string _myUrl;
        private string index = "index.html";

        public bool ShowHighlight(string myUrl, string requestedUrl)
        {
            _myUrl = myUrl;

            if (string.Equals(_myUrl, requestedUrl, StringComparison.CurrentCultureIgnoreCase))
                return true;

            if (isIndex(_myUrl) && isSameParent(requestedUrl))
                return true;

            return isIndex(_myUrl) && isSameSection(requestedUrl);
        }

        private bool isIndex(string url)
        {
            return splitBySlash(url).Contains(index);
        }

        private bool isSameSection(string url)
        {
            var requestedUrlSections = splitBySlash(url).SkipLast(1);
            var myUrlSections = splitBySlash(_myUrl).SkipLast(1);

            var differences = requestedUrlSections.Except(myUrlSections);

            return !differences.Any();
        }

        private bool isSameParent(string url)
        {
            var requestedUrlParent = splitBySlash(url).FirstOrDefault();
            var myUrlParent = splitBySlash(_myUrl).FirstOrDefault();

            if (myUrlParent.Equals(requestedUrlParent, StringComparison.CurrentCultureIgnoreCase))
            {
                var myUrlSubsection = splitBySlash(_myUrl, 1).FirstOrDefault();
                var requestedUrlSubsection = splitBySlash(url, 1).FirstOrDefault();

                if (string.IsNullOrEmpty(myUrlSubsection) ||
                    myUrlSubsection.Contains(index, StringComparison.CurrentCultureIgnoreCase))
                    return true;

                return myUrlSubsection.Equals(requestedUrlSubsection, StringComparison.CurrentCultureIgnoreCase);
            }

            return false;
        }

        private string[] splitBySlash(string url, int skip = 0)
        {
            var sections = url.Split('/', StringSplitOptions.RemoveEmptyEntries).Skip(skip);
            return sections.ToArray();
        }
    }
}
