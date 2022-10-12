namespace _006_ThreadWithState
{
    public delegate void MyResultDelegate(MyReturnObject myReturnObject);
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadWithStateClass threadWithStateClass = new ThreadWithStateClass("Hallo liebe Teilnehmer", 111, new MyResultDelegate(ShowCallbackResult));


            Thread thread = new Thread(threadWithStateClass.ThreadProc);
            thread.Start();

            

            Console.ReadLine();
        }


        public static void ShowCallbackResult(MyReturnObject myReturnObject)
            => Console.WriteLine($"Rückgabewerte-> {myReturnObject.Text} und {myReturnObject.Zahl}");
    }

    public class ThreadWithStateClass
    {
        //Meine Initialisierungwerte für die Threadbasierten Workflows

        private string myStringText;
        private int myNumberValue;
        private MyResultDelegate resultDelegate;


        public ThreadWithStateClass(string myStringText, int myNumberValue, MyResultDelegate myResultDelegate)
        {
            this.myStringText = myStringText;
            this.myNumberValue = myNumberValue;

            resultDelegate = myResultDelegate;
        }


        //Diese Methode wird später in einem Thread laufen
        public void ThreadProc()
        {
            Console.WriteLine("ThreadProc -> myStringText:" + myStringText);
            Console.WriteLine("ThreadProc -> myNumberValue:" + myNumberValue);


            //Wir senden ein Return-Object via Callback zurück

            MyReturnObject myReturnObject = new MyReturnObject();
            myReturnObject.Zahl = myNumberValue;
            myReturnObject.Text = myStringText;

            if (resultDelegate != null)
                resultDelegate(myReturnObject);

        }
    }

    public class MyReturnObject
    {
        public MyReturnObject()
        {
        }

        public string Text { get; set; }
        public int Zahl { get; set; }
    }
}