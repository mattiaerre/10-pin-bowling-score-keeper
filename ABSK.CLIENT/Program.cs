using System.Linq;
using ABSK.CLIENT.Properties;
using ABSK.CORE.Domain;
using ABSK.CORE.Factories;
using ABSK.CORE.Models;
using ABSK.CORE.Repositories;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;

namespace ABSK.CLIENT
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var container = BootstrapContainer();
      var game = container.Resolve<IGame>();
      try
      {
        PreGame(game);
        Game(game);
      }
      catch (Exception ex)
      {
        // todo: add exception handling
        Console.WriteLine(ex.Message);
      }
      PressAnyKeyToContinue();
      container.Dispose();
    }

    private static void Game(IGame game)
    {
      foreach (var frameNumber in game.Frames)
      {
        foreach (var player in game.Players)
        {
          ManageScore(game, player, frameNumber);
        }
      }
    }

    private static void PreGame(IGame game)
    {
      Console.Write("enter the number of players: ");
      var line = Console.ReadLine();
      for (var i = 1; i <= Convert.ToInt32(line); i++)
      {
        Console.Write("enter player #{0}'s name: ", i);
        var name = Console.ReadLine();
        game.AddPlayer(name);
      }
    }

    private static void ManageScore(IGame game, PlayerModel player, int frameNumber)
    {
      // todo: managing the last frame's lable
      Console.Write("{0}, please enter your score for the 2 bowl of frame {1}: ", player.Name, frameNumber);
      var score = ParseScoreList(Console.ReadLine());
      game.SetScore(score, player, frameNumber);
    }

    private static int?[] ParseScoreList(string input)
    {
      var score = input.Split(' ');
      return score.Select(ParseScoreItem).ToArray();
    }

    private static int? ParseScoreItem(string input)
    {
      if (input == "-")
        return null; // info: not sure if I need this
      return Convert.ToInt32(input);
    }

    private static void PressAnyKeyToContinue()
    {
      Console.WriteLine("press any key to continue ...");
      Console.ReadKey();
    }

    public static IWindsorContainer BootstrapContainer()
    {
      var container = new WindsorContainer().Install(FromAssembly.This());

      var numberOfFrames = 2; // Settings.Default.NumberOfFrames;

      container.Register(Component.For<IPlayerRepository>().ImplementedBy<PlayerRepository>());
      container.Register(Component.For<IPlayerModelFactory>().ImplementedBy<PlayerModelFactory>()
        .DependsOn(new { numberOfFrames = numberOfFrames, numberOfPins = Settings.Default.NumberOfPins }));
      container.Register(Component.For<IGame>().ImplementedBy<Game>()
        .DependsOn(new { numberOfFrames = numberOfFrames }));

      return container;
    }
  }
}
