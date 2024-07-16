namespace Api.Interface
{
	//Interface en la que solo se pueden realizar consultas sensillas o de todos los elementos
	public interface IConsulta<T>
	{
		List<T> GetData();//Retorno un listado Con todos los elementos que existan
		T GetData(int id); //REtorna un elemento siempre que existan dentro del listado de elentos
	}
}
