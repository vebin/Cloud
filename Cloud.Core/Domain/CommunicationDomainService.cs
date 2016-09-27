using Abp.Domain.Services;

namespace Cloud.Domain
{
    public class CommunicationDomainService : IDomainService
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="body">内容</param>
        /// <param name="sendTo">发送到</param>
        public void SendEmail(string title, string body, string sendTo)
        {

        }

        /// <summary>
        /// 短信
        /// </summary>
        /// <param name="context">内容</param>
        /// <param name="sendTo">发送到</param>
        public void SendShortMessage(string context, string sendTo)
        {

        }
    }
}