# 이메일 보내기

```cs
[Consumes("multipart/form-data")]
[HttpPost]
public async Task Post([FromForm] Form form)
{
  var mailMessage = new MailMessage("from@forest.com", "to@forest.com")
  {
      IsBodyHtml = true,
      Subject = "제목",
      Body = "<p>HTML 내용이군</p>"
  };

  mailMessage.Attachments.Add(new Attachment(form.SomeFile.OpenReadStream(), form.SomeFile.FileName));
  mailMessage.Attachments.Add(new Attachment(form.AnotherFile.OpenReadStream(), form.AnotherFile.FileName));

  var client = new SmtpClient()
  {
      Host = "Host address",
      Port = 25,
      DeliveryMethod = SmtpDeliveryMethod.Network,
      UseDefaultCredentials = true,
      Credentials = new NetworkCredential("username", "password")
  };
  
  await client.SendMailAsync(mailMessage);
}

```