# Project - SecretSanta

"Secret Santa is a Western Christmas tradition in which members of a group or community are randomly assigned a person to whom they give a gift. The identity of the gift giver is a secret not to be revealed." - Wikipedia.

You can use this project to do a SecretSanta draw and notify the participants by sms. This is a flexible project built as a C# console app and it uses Twilio APIs to send sms.

## Getting Started
Use the following steps to get the project, run tests, and do a secret santa draw.

### Cloning the project

```
git clone https://github.com/rodriguez-maria/SecretSantaProject.git
```

### Running tests
Open [SecretSantaProject.sln](SecretSantaProject.sln) with Visual Studio 2017. Build both [SecretSantaProject](https://github.com/rodriguez-maria/SecretSantaProject/tree/master/SecretSantaProject) and [SecretSantaProject.Test](https://github.com/rodriguez-maria/SecretSantaProject/tree/master/SecretSantaProject.Test) projects. Run the tests.


### Setting up Twilio

1. Create an account at https://www.twilio.com
2. Get a free a phone number capable of sending text messages to your destination.
3. Update [TwilioSmsNotificationService.cs](https://github.com/rodriguez-maria/SecretSantaProject/blob/master/SecretSantaProject/Services/TwilioSmsNotificationService.cs) file with your Twilio accountSid and authToken.
4. In [Program.cs](https://github.com/rodriguez-maria/SecretSantaProject/blob/master/SecretSantaProject/Program.cs), replace:

```
builder.RegisterInstance(new ConsoleNotificationService())
                   .As<INotificationService>();
```
with:
```
builder.RegisterInstance(new TwilioSmsNotificationService())
                   .As<INotificationService>();
```

### Running the app

1. Create a file similar to [ContactstTest.txt](https://github.com/rodriguez-maria/SecretSantaProject/blob/master/SecretSantaProject.Test/ContactstTest.txt).
2. Pass the file path as the 1st commandline argument of the console app.


## Built With

* [Twilio](https://www.twilio.com/docs/) - The sms service used
* [Autofac](https://autofac.org/) - Dependency Injection framework used
* [Moq](https://github.com/moq/moq4) - Mocking framework used
* [MedallionRandom](https://github.com/madelson/MedallionUtilities/tree/master/MedallionRandom) - Randomizer used


## Authors

* **Maria Rodriguez** - *Initial work* - [rodriguez-maria](https://github.com/rodriguez-maria)
* **Faisal Rahman** - *Initial work* - [rfaisal](https://github.com/rfaisal)

See also the list of [contributors](https://github.com/rodriguez-maria/SecretSantaProject/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Acknowledgments

* Code sample from www.twilio.com website.
