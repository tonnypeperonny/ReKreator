using System.Collections.Generic;
using System.Security.Policy;
using ReKreator.Web.Models;

namespace ReKreator.Web.Stubs
{
    public class StubsFactory : IStubsFactory
    {
        public IEnumerable<EventModel> CreateConcerts()
        {
            var result = new List<EventModel>
            {
                new EventModel {EventId = 1, EventName = " Душа романса", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\1small.jpeg"), IsFavorite = true},
                new EventModel { EventId = 2, EventName = "«Muse: Drones World Tour»", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\2small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 3, EventName = "Летние музыкальные вечера в Верхнем городе", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\3small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 4, EventName = "Некудаспешить и Modernova", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\4small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 5, EventName = "Группа \"Бабанцуйка\"", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\5small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 6, EventName = "Anton Ripatti", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\6small.jpeg"), IsFavorite = true },
                new EventModel { EventId = 7, EventName = "Прэзентацыя - Skroź EP + Танграм + The Simon", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\7small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 8, EventName = "Классика у Ратуши", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\8small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 9, EventName = "Гала-концерт \"Территория мюзикла\" - 5 лет", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\9small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 10, EventName = "\"Король и Шут\" трибъют", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\10small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 11, EventName = "Трибьют \"Король и шут\"", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\11small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 12, EventName = "Skroź і Yellow Power", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\12small.jpeg"), IsFavorite = true },
                new EventModel { EventId = 13, EventName = "Фестиваль Наш Грюнвальд ", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\13small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 14, EventName = "Концерт органной музыки: Екатерина Николаева", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\14small.jpeg"), IsFavorite = true },
                new EventModel { EventId = 15, EventName = "Фестиваль импровизационной музыки \"Импролето\"", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\15small.jpeg"), IsFavorite = false }

            };
            return result;
        }

        public IEnumerable<EventModel> CreateSpectacle()
        {
            var result = new List<EventModel>
            {
                new EventModel {EventId = 81, EventName = "TheatreHD: Двенадцатая ночь", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\81small.jpeg"), IsFavorite = false},
                new EventModel { EventId = 82, EventName = "Жмурик", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\82small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 83, EventName = "БелДрымШоу", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\83small.jpeg"), IsFavorite = true },
                new EventModel { EventId = 84, EventName = "Леди на день", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\84small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 85, EventName = "Юбілей ювеліра", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\85small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 86, EventName = "Волки и овцы", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\86small.jpeg"), IsFavorite = true },
                new EventModel { EventId = 87, EventName = "Английская рулетка (Double Double)", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\87small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 88, EventName = "Титаник ", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\88small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 89, EventName = "Три сестры", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\89small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 90, EventName = "Обыкновенное чудо", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\90small.jpeg"), IsFavorite = false }

        };
            return result;
        }

        public IEnumerable<EventModel> CreateMovie()
        {
            var result = new List<EventModel>
            {
                new EventModel {EventId = 16, EventName = "8 подруг Оушена", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\16small.jpeg"), IsFavorite = true},
                new EventModel { EventId = 17, EventName = "Во власти стихии", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\17small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 18, EventName = "Джим Пуговка и машинист Лукас", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\18small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 19, EventName = "Осторожно: Грамп!", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\19small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 20, EventName = "Суперсемейка 2", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\20small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 21, EventName = "Ты водишь!", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\21small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 22, EventName = "Убийца 2. Против всех", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\22small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 23, EventName = "Человек-Муравей и Оса", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\23small.jpeg"), IsFavorite = true },
                new EventModel { EventId = 24, EventName = "50 весенних дней", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\24small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 25, EventName = "Ant-Man and the Wasp (EN)", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\25small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 26, EventName = "TheatreHD: Винсент Ван Гог – Новый взгляд", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\26small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 27, EventName = "Аферисты поневоле", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\27small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 28, EventName = "Горы", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\28small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 29, EventName = "Зверь", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\29small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 30, EventName = "Книжный клуб", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\30small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 31, EventName = "Кто украл Banksy (EN)", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\31small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 32, EventName = "Невидимка", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\32small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 33, EventName = "Попробуй подкати", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\33small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 34, EventName = "Пылающий", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\34small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 35, EventName = "Хот-Дог", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\35small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 36, EventName = "Эскобар", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\36small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 37, EventName = "Мстители: Война бесконечности", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\37small.jpeg"), IsFavorite = true },
                new EventModel { EventId = 38, EventName = "Пчелка Майя и Кубок меда", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\38small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 39, EventName = "Трансляция телеканала Беларусь 5", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\39small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 40, EventName = "TheatreHD: Двенадцатая ночь", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\40small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 41, EventName = "ЗВЕРЬ [VELCOM SILVER.ART] (предпоказ, EN)", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\41small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 42, EventName = "Инсомния", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\42small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 43, EventName = "Смотри матчи FIFA вместе с Coca-Cola в Silver Sceen", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\43small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 44, EventName = "Ночная смена", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\44small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 45, EventName = "Мир Юрского периода 2", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\45small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 46, EventName = "Ретроспектива \"Познавая белый свет.Памяти Киры Муратовой\"", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\46small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 47, EventName = "Проект Cinemascope: Ночь на Земле", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\47small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 48, EventName = "Проект Cinemascope: Энни Холл", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\48small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 49, EventName = "Монстры на каникулах 3: Море зовет", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\49small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 50, EventName = "Небоскрёб", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\50small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 51, EventName = "Большая афера в маленьком городе", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\51small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 52, EventName = "Генезис 2.0", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\52small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 53, EventName = "Русалка. Озеро мертвых", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\53small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 54, EventName = "Талли", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\54small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 55, EventName = "«Muse: Drones World Tour»", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\55small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 56, EventName = "Фестиваль немого кино и современной музыки \"Кинемо 2018\"", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\56small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 57, EventName = "Проект \"Cinemascope\". \"Сансет бульвар\"", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\57small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 58, EventName = "Проект Cinemascope: Затмение", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\58small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 59, EventName = "Ночь Кино", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\59small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 60, EventName = "Проект Cinemascope: Кэрри", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\60small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 61, EventName = "Ретропрограмма \"Звуки музыки\"", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\61small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 62, EventName = "Проект Cinemascope: Дети райка", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\62small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 63, EventName = "Проект Cinemascope: Сияние", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\63small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 64, EventName = "Проект Cinemascope: Обед нагишом", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\64small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 65, EventName = "Проект Cinemascope: Печать зла", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\65small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 66, EventName = "Проект Cinemascope: Поющие под дождем", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\66small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 67, EventName = "TheatreHD: Молодой Маркс", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\67small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 68, EventName = "TheatreHD: Загадочное ночное убийство собаки", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\68small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 69, EventName = "Килиманджара", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\69small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 70, EventName = "Мектуб, моя любовь", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\70small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 71, EventName = "TheatreHD: Мэтью Борн: Кар Мен", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\71small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 72, EventName = "TheatreHD: Турандот", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\72small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 73, EventName = "TheatreHD: «Макбет: Рори Киннир» ", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\73small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 74, EventName = "TheatreHD: Веер леди Уиндермир (спектакль)", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\74small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 75, EventName = "TheatreHD: Гамлет: Камбербэтч", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\75small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 76, EventName = "TheatreHD: Сады в живописи – от Моне до Матисса (фильм-выставка)", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\76small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 77, EventName = "TheatreHD: Идеальный муж ", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\77small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 78, EventName = "TheatreHD: RSC: Ромео и Джульетта", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\78small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 79, EventName = "TheatreHD: Гойя – Образы из плоти и крови", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\79small.jpeg"), IsFavorite = false },
                new EventModel { EventId = 80, EventName = "Показы лучших рекламных роликов мира ABC show", EventPoster = new Url("C:\\Users\\y.makarau\\AppData\\Roaming\\RekReator\\ImageStorage\\80small.jpeg"), IsFavorite = false }
            };
            return result;
        }
    }
}