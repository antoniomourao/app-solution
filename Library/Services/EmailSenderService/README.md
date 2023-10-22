# Email Sender Service

## Configuration setup on appSettings:
```js
  "SmtpSettings": {
    "FromDisplayName": "email-sender",
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "Username": "your-email@gmail.com",
    "Password": "your-password",
    "EnableSsl": true
  }
```

## Read configuration and register configuration
```js
  var emailConfig = Configuration
        .GetSection("SmtpSettings")
        .Get<EmailSenderServiceSmtpSettings>();
    services.AddSingleton(emailConfig);
```