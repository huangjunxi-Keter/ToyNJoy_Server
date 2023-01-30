using System.Net.Mail;
using System.Text;

namespace ToyNJoy
{
    public static class EmailHelper
    {
        public static bool SendMail(string email,string title,string content)
        {
            // 设置发送方的邮件信息 
            string mailTo = email;  //收件人：收件箱邮箱
            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;//指定电子邮件发送方式
            smtpClient.Host = "smtp.qq.com"; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential("huangjunxi-test@foxmail.com", "jtjssbnkauiweada");//用户名和密码

            // 发送邮件设置        
            MailMessage mailMessage = new MailMessage("huangjunxi-test@foxmail.com", mailTo);
            mailMessage.Subject = title;//主题
            mailMessage.Body = content;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级
            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
    }
}