namespace DelegateEventsAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyComponent1 myComponent1 = new MyComponent1();

            myComponent1.ChangePercentValue += MyComponent1_ChangePercentValue;
            myComponent1.ResultDelegate += MyComponent1_ResultDelegate;
            myComponent1.StartProcess();
            myComponent1.Procress2();
        }

        private static void MyComponent1_ResultDelegate(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void MyComponent1_ChangePercentValue(int percentValue)
        {
            Console.WriteLine($"Die eingekaufte Komponente steht gerade bei {percentValue} %");
        }
    }


    #region Eine Komponente von einem Drittanbieter

    public delegate void ChangePercentValueDelegate(int percentValue);
    public delegate void ResultDelegate(string msg);
    public class MyComponent1
    {
        
        public event ChangePercentValueDelegate ChangePercentValue;
        public event ResultDelegate ResultDelegate;

        public void StartProcess()
        {
            for (int i = 0; i <= 100; i++)
            {
                //Einmal wollen wir dem Kunden mitteilen, bei welchen Prozentsatz wir stehen 

                //Gibt es eine zugewiesene Methode mit der kommunizieren kann? 
                if (ChangePercentValue != null)
                    ChangePercentValue(i); //Wenn ja, wird diese mit dem Parameter 'i' auferufen
            }


            //wollen den Kunden mitteilen, dass wir mit dem Prozess fertig sind.
            if(ResultDelegate != null)
                ResultDelegate("Sind fertig");
        }


        public void Procress2()
        {
            for (int i = 0; i <= 100; i++)
            {
                //Einmal wollen wir dem Kunden mitteilen, bei welchen Prozentsatz wir stehen 

                //Gibt es eine zugewiesene Methode mit der kommunizieren kann? 
                //if (ChangePercentValue != null)
                //    ChangePercentValue(i); //Wenn ja, wird diese mit dem Parameter 'i' auferufen


                OnProcressPercentStatus(i);
            }

            OnFinishDelegate("fertig");
        }

        protected virtual void OnProcressPercentStatus(int percent)
        {
            ChangePercentValue?.Invoke(percent);
        }

        protected virtual void OnFinishDelegate(string msg)
        {
            ResultDelegate?.Invoke(msg);
        }
    }
    #endregion
}