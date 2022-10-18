namespace DesignPatterns.Proxy
{
    public class ContentRepositoryProxy : IContentRepository
    {
        private readonly DeviceType _deviceType;
        readonly ContentRepository contentRepository =  new ContentRepository();

        public ContentRepositoryProxy(DeviceType deviceType)
        {
            this._deviceType = deviceType;
        }

        public List<Content> GetContent()
        {
            List<Content> contentList = contentRepository.GetContent();

            switch (_deviceType)
            {
                case DeviceType.Mobile:
                    contentList.ForEach(x => { x.Advertisements = new List<Advertisement>(); });
                    break;
                case DeviceType.Web:
                    contentList = contentList.Where(x => x.Category != CategoryEnum.Lifestyle).ToList();
                    break;
            }

            return contentList;
        }
    }

    public enum DeviceType
    {
        Web = 1,
        Mobile = 2,
        Desktop = 3
    }
}
