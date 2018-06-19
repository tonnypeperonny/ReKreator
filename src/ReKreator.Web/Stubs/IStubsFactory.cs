using System.Collections.Generic;
using ReKreator.Web.Models;

namespace ReKreator.Web.Stubs
{
    public interface IStubsFactory
    {
        IEnumerable<EventModel> CreateConcerts();
        IEnumerable<EventModel> CreateSpectacle();
        IEnumerable<EventModel> CreateMovie();
    }
}