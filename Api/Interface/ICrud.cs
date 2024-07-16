
using Api.Model;

namespace Api.Interface
{
    //Interfaz que herreda de IConsulta, con la cual se completan todos los metodos nesesarios para realizar un crud
    public interface ICrud:IConsulta<MTvShowClass>//Utiliza la clase MTvShow para difinir el tipo que va a utilizar
    {
        
        void AddTvShow(MTvShowClass tvShow);//Añade un nuevo elemento
        void UpdateTvShow(int id, MTvShowClass updatedTvShow);//Actualiza un elemento en funcion del id que se haya escojido
        void DeleteTvShow(MTvShowClass element);//Elimina el elemento del listado simpre que este exista
    }
}
