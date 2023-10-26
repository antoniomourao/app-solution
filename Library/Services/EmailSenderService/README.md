# Email Sender Service

## Description
Sends emails using the SmtpClient class.

### Configuration setup on appSettings:
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

### Read configuration and register configuration
We need to read the appSettings and register the configuration to be used by the service as a singleton. This is done in the Program.cs file.
Last we need to add the EmailServe as a scoped service.

To use the service with Authentication, we need to add the service as a scoped service in the Program.cs file.
```js
        services
            .AddOptions<EmailSenderServiceSmtpSettings>()
            .Bind(configuration.GetSection("SmtpSettings"))
            .ValidateDataAnnotations();

        var instance = services
            .BuildServiceProvider()
            .GetRequiredService<IOptionsMonitor<EmailSenderServiceSmtpSettings>>()
            .CurrentValue;
        services.AddSingleton(_ => instance);

        services.AddScoped<EmailService>();
```
To have the Authentication use the EmailService, we need to add a local util class to implement the IEmailSender interface and call the EmailService.
```js
        services.AddScoped<IEmailSender, EmailSenderUtil>();
```


##Version
v1.0.0 - Initial version