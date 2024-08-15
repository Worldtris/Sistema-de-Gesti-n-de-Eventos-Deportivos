
namespace Sistema_de_Gestión_de_Eventos_Deportivos.Controllers
{
    using System.Collections.Generic;
    using Sistema_de_Gestión_de_Eventos_Deportivos.Modelos;
    class EventosController
    {
        private EventosModel modelEve = new EventosModel();

        public List<EventosModel> todos()
        {

        return modelEve.todos(); }

        public EventosModel uno(EventosModel eve)
        {
            return modelEve.uno(eve);
        }

        public string insertar(EventosModel eve)
        {
            return modelEve.insertar(eve);
        }

        public string actualizar(EventosModel eve)
        {
            return modelEve.actualizar(eve);
        }

        public string eliminar(EventosModel eve)
        {
            return modelEve.eliminar(eve);
        }

    }
}
