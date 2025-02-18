using Patterns.Decorator;

Client client = new Client();

var simple = new ConcreteComponent();
Console.WriteLine("Client: I get a simple component:");
client.ClientCode(simple);

List<string> numbers = new List<string>();
numbers.Add("(xx) xxxxx-xxxx");
numbers.Add("(yy) xxxxx-xxxx");
numbers.Add("(zz) xxxxx-xxxx");
numbers.Add("(tt) xxxxx-xxxx");
numbers.Add("(ii) xxxxx-xxxx");

List<string> users = new List<string>();
users.Add("LitteZeca");
users.Add("Jp");
users.Add("Greg");
users.Add("MrKelly");
users.Add("Yennfer");

SMSSender sms = new SMSSender(simple, numbers);
FacebookSender face = new FacebookSender(simple, users);

Console.WriteLine();
Console.WriteLine("Client: I need to send by SMS:");
client.ClientCode(sms);
Console.WriteLine();
Console.WriteLine("Client: I need to send by Facebook:");
client.ClientCode(face);

face = new FacebookSender(sms, users);
Console.WriteLine();
Console.WriteLine("Client: I need to send both:");
client.ClientCode(face);
