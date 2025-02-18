namespace Patterns.Decorator {

    //This class is used as an inteface ti define the method 'Operation' that will be override in all Decorators classes
    public abstract class Component {
        public abstract string Operation();
    }

    //This class defines the default implementations of the method 'Operation'
    public class ConcreteComponent : Component {
        public override string Operation() {
            return "All notifications were sent";
        }
    }

    //This class is the base of all others concrete decorators
    //Here we define an attribute for storing a wrapped component
    abstract class Decorator : Component {
        protected Component _component;

        public Decorator(Component component) {
            this._component = component;
        }

        public void SetComponent(Component component) {
            this._component = component;
        }

        public override string Operation() {
            if(this._component != null) {
                return this._component.Operation();
            }
            else {
                return string.Empty;
            }
        }
    }

    //Decorators can execute their behavior either before or after the call to a wrapped object
    class SMSSender : Decorator {
        private List <string> numbers;
        public SMSSender(Component component, List<string> numbers) : base(component) {
            this.numbers = numbers;
        }

        //Decorators can call their parents implementation of the function Operation. This can simplify the extension of
        //decorator class, so you don't need to remake the validations made on primary class
        public override string Operation() {
            foreach (string number in numbers) {
                Console.WriteLine($"Sending SMS to: {number}");
            }

            return base.Operation();
        }
    }

    //Decorators can execute their behavior either before or after the call to a wrapped object
    class FacebookSender : Decorator {
        private List <string> users;
        public FacebookSender(Component component, List<string> users) : base(component) {
            this.users = users;
        }

        public override string Operation() {
            foreach (string user in users) {
                Console.WriteLine($"Sending notification in facebook to: {user}");
            }

            return base.Operation();
        }
    }

    class Client {
        //The client code works with any instance of objects using the Component interface
        //This way it can stay independent of the concreet classes
        public void ClientCode(Component component) {
            Console.WriteLine("Result: " + component.Operation());
        }
    }
}
