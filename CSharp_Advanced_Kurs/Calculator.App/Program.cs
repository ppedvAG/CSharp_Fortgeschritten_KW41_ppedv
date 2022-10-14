using Calculator.PluginBase;
using System.Reflection;

namespace Calculator.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ermitteln des Pfades der ausführbaren Datei
            string executeFilePath = Assembly.GetExecutingAssembly().Location;

            string strWorkPath = Path.GetDirectoryName(executeFilePath);

            //Plugin-Verzeichnis ermitteln
            string pluginPath = Path.Combine(strWorkPath, "Plugins");


            DirectoryInfo directoryInfo = new DirectoryInfo(pluginPath);

            //Wenn kein Plugin-Verzeichnis existiert, dann Fehler
            if (!directoryInfo.Exists)
                new ApplicationException("Plugin-Verzeichnis ist nicht vorhanden");

            //Alle Dlls werden selektiert
            FileInfo[] fileInfoPluginDlls = directoryInfo.GetFiles("*.dll");

            //Geladenen Interfaces von den Plugins
            IList<ICalculatorPlugIn> geladenePlugins = new List<ICalculatorPlugIn>();


            foreach (FileInfo currentFileInfo in fileInfoPluginDlls)
            {
                Assembly assembly = Assembly.LoadFrom(currentFileInfo.FullName);

                ICalculatorPlugIn pluginInterface = GetPluginInterface(assembly);

                geladenePlugins.Add(pluginInterface);
            }

            double zahl1 = 32;
            double zahl2 = 8;


            Console.WriteLine($"Es sind {geladenePlugins.Count} Plugins geladen");

            foreach (ICalculatorPlugIn plugin in geladenePlugins)
                Console.WriteLine($"{zahl1} {plugin.OperatorDescription} {zahl2} = {plugin.Operation(zahl1, zahl2)}");

            Console.ReadLine();

        }

        private static ICalculatorPlugIn GetPluginInterface(Assembly assembly)
        {
            foreach (Type currentTyp in assembly.GetTypes())
            {
                if (currentTyp.GetInterfaces().Contains(typeof(ICalculatorPlugIn)))
                {
                    ICalculatorPlugIn validPlugin = Activator.CreateInstance(currentTyp) as ICalculatorPlugIn;
                    return validPlugin;
                }
            }

            string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));

            throw new ApplicationException(
                            $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                            $"Available types: {availableTypes}");
        }
    }
}