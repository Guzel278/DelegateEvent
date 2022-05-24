using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace DelegateEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Alarm alarm = new Alarm();
            alarm.OnSetTime += (Alarm sender, AlarmEventArgs e) => Console.WriteLine($"OnSetTime {e.Time}");
            alarm.OnExecute += (Alarm sender, AlarmEventArgs e) => Console.WriteLine($"OnExecute {e.Time}");
            alarm.SetTime(TimeSpan.FromSeconds(2), SendEmail);
            alarm.SetTime(TimeSpan.FromSeconds(5), OpenFile);

            
            Console.ReadLine(); 
            
        }
        public static void OpenFile()
        {
            Process openFile = new Process();
            openFile.StartInfo.UseShellExecute = true;        
            try
            {
                openFile.StartInfo.FileName = "_Refeci_Michel_Fannoun_feat_Colone_Where_Are_You_Original_Mix_2021.mp3";
                openFile.StartInfo.CreateNoWindow = false;
                openFile.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }                              
        }

        public static void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("123@mail.ru"); // Адрес отправителя
                mail.To.Add(new MailAddress("234@mail.ru")); // Адрес получателя
                mail.Subject = "Test";
                mail.Body = " test ";

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.mail.ru";
                client.Port = 587; 
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("123@mail.ru", "password"); // логин и пароль
                client.Send(mail);
                Console.WriteLine($"Mail was sent to {mail.To}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Mail wasn't sent {ex}");
            }
           
        }        
    }
}
