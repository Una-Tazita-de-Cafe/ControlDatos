using Api.Interface;
using Api.Model;

namespace Api.Data
{
	//Estructura de datos, creada de manera loca
	public class CRUD_Listado: ICrud
	{
		//Declaracion y asignacion de los valores de tipo MTvShow en la lista que se estara usando
		private static List<MTvShowClass> datosTvShows = new List<MTvShowClass>
		{
			new MTvShowClass{Id=1,Name="Breaking Bad",Favorite=true},
			new MTvShowClass{Id=2,Name="Game of Thrones",Favorite=false},
			new MTvShowClass{Id=3,Name="Stranger Things",Favorite=true},
			new MTvShowClass{Id=4,Name="The Office",Favorite=false},
			new MTvShowClass{Id=5,Name="Friends",Favorite=true},
			new MTvShowClass{Id=6,Name="The Mandalorian",Favorite=false},
			new MTvShowClass{Id=7,Name="The Crown",Favorite=true},
			new MTvShowClass{Id=8,Name="Sherlock",Favorite=false},
			new MTvShowClass{Id=9,Name="Westworld",Favorite=true},
			new MTvShowClass{Id=10,Name="Black Mirror",Favorite=false},
		};
		#region  Metodos CRUD
		//Metodo get 
        public List<MTvShowClass> GetData()
		{
			return datosTvShows;
		}
		
		//Metodo Add
		public void AddTvShow(MTvShowClass tvShow)
		{
            tvShow.Id = datosTvShows.Max(t => t.Id) + 1;
            datosTvShows.Add(tvShow);  
		}
		//Metodo Update
		public void UpdateTvShow(int id, MTvShowClass updatedTvShow)
		{
            int index = datosTvShows.ToList().FindIndex(t => t.Id == id);
            datosTvShows[index].Name = updatedTvShow.Name;
            datosTvShows[index].Favorite = updatedTvShow.Favorite;
        }
		//Metodo delete
		public void DeleteTvShow(MTvShowClass element)
		{
			if (element != null)
			{
				int index = datosTvShows.IndexOf(element);
				if (index != -1)
				{
					datosTvShows.Remove(element);

					// Reajustar los IDs de los elementos posteriores
					for (int i = index; i < datosTvShows.Count; i++)
					{
						datosTvShows[i].Id = i + 1;
					}
				}
			}
		}
		//Metodo para buscar un elemento
		public MTvShowClass GetData(int id)
        {
			return datosTvShows.FirstOrDefault(t => t.Id == id);  
        }
        #endregion
    }
}
