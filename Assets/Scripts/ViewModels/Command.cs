namespace Assets.Scripts.ViewModels
{
  public delegate void Command();

  public delegate void CommandArg<T>(T arg0);

  public delegate void CommandArgs<T1, T2>(T1 arg0, T2 arg1);
}
