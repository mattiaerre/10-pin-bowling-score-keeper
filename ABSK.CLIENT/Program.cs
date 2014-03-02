using System;
using ABSK.CLIENT.Properties;
using ABSK.CORE.Factories;
using ABSK.CORE.Repositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ABSK.CLIENT
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var container = BootstrapContainer();
      var repository = container.Resolve<IPlayerRepository>();

      // ask for the number of players
      Console.Write("enter the number of players: ");
      var line = Console.ReadLine();
      try
      {
        var numberOfPlayers = Convert.ToInt32(line);

        // iterate and populate the repository
        for (var i = 1; i <= numberOfPlayers; i++)
        {
          Console.Write("enter player #{0}'s name: ", i);
          var name = Console.ReadLine();
          repository.Add(name);
        }
      }
      catch (Exception ex)
      {
        // todo: add exception handling
        throw;
      }

      PressAnyKeyToContinue();

      container.Dispose();
    }

    private static void PressAnyKeyToContinue()
    {
      Console.WriteLine("press any key to continue ...");
      Console.ReadKey();
    }

    public static IWindsorContainer BootstrapContainer()
    {
      var container = new WindsorContainer().Install(FromAssembly.This());

      container.Register(Component.For<IPlayerRepository>().ImplementedBy<PlayerRepository>());
      container.Register(Component.For<IPlayerModelFactory>().ImplementedBy<PlayerModelFactory>()
        .DependsOn(new { numberOfFrames = Settings.Default.NumberOfFrames, numberOfPins = Settings.Default.NumberOfPins }));

      return container;
    }
  }
}
