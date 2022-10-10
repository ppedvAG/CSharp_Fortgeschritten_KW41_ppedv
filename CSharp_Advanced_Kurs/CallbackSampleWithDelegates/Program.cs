namespace CallbackSampleWithDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            UI ui = new UI();
            ProgressDelegate progressDelegate = new ProgressDelegate(ui.ShowProgressBar);


            ComponentWithProgress componentWithProgress = new ComponentWithProgress();
            componentWithProgress.DoSomething(progressDelegate);
        }
    }

    public class UI
    {
        public void ShowProgressBar(int percent)
        {
            Console.WriteLine($"Aktuelle ProgressBarstand ist {percent}");
        }
    }


    #region delegate und ComponentWithProgress kommt von einem Drittanbieter
    public delegate void ProgressDelegate(int percent);

    public class ComponentWithProgress
    {
        public void DoSomething(ProgressDelegate progressDelegate)
        {
            for (int i = 0; i < 100; i++)
            {
                progressDelegate(i); //UI.ShowProgressBar wird aufgerufen 
            }
        }
    }
    #endregion
}