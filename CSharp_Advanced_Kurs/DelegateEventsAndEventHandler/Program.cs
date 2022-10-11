namespace DelegateEventsAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Beispiel 1
            MyComponent1 myComponent1 = new MyComponent1();

            myComponent1.ChangePercentValue += MyComponent1_ChangePercentValue;
            myComponent1.ResultDelegate += MyComponent1_ResultDelegate;
            myComponent1.StartProcess();
            myComponent1.Procress2();

            #endregion


            #region Beispiel 2

            MyComponent2 myComponent2 = new MyComponent2();
            myComponent2.PercentValueChanged += MyComponent2_PercentValueChanged;
            myComponent2.PercentValueChanged2 += MyComponent2_PercentValueChanged2;
            myComponent2.ProcessCompleted += MyComponent2_ProcessCompleted;
            myComponent2.StartProcess();
            #endregion


        }

        private static void MyComponent2_ProcessCompleted(object? sender, EventArgs e)
        {
            Console.WriteLine("sind fertig");
        }

        private static void MyComponent2_PercentValueChanged2(object? sender, MyPercentEventArgs e)
        {
            Console.WriteLine(e.PercentValue);
        }

        private static void MyComponent2_PercentValueChanged(object? sender, EventArgs e)
        {
            MyPercentEventArgs myPercentEventArgs = (MyPercentEventArgs)e;
            Console.WriteLine(myPercentEventArgs.PercentValue);
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


    #region Zweite Komponente mit EventHandler

    public class MyComponent2
    {
        public event EventHandler PercentValueChanged; //Bieten wir als Event an
        public event EventHandler<MyPercentEventArgs> PercentValueChanged2;
        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            //for + tab + tab -> Default For - Schleife
            for (int i = 0; i < 100; i++)
            {
                OnPercentValueChanged(i);
            }
        }

        protected virtual void OnPercentValueChanged(int i)
        {

            PercentValueChanged?.Invoke(this, new MyPercentEventArgs() { PercentValue = i });
        }

        public virtual void OnProcessCompleted ()
        {
            ProcessCompleted?.Invoke(this, EventArgs.Empty);
        }
    }


    public class MyPercentEventArgs : EventArgs
    {
        public int PercentValue { get; set; }
    }

    #endregion
}