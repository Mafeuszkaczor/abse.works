using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abse.works.Application.ViewModels.HomePage
{
    public class HomeViewModel
    {
        public Dictionary<string, string> Specializations { get; set; }
        public Dictionary<string, string> Offers { get; set; }
        public Dictionary<string, string> Advantages { get; set; }
        public List<string> Photos { get; set; }
        public HomeViewModel()
        {
            Specializations = new Dictionary<string, string>
            {
                { "Budownictwo i wykończenia", "Oferujemy doświadczonych stolarzy budowlanych oraz ekipę wykonującą prace wykończeniowe od fundamentów po dach. Nasz zespół zapewnia najwyższą jakość usług, niezależnie od skali projektu." },
                { "Prace ziemne i landworkerzy", "Dostarczamy specjalistów do prac ziemnych oraz landworkerów, którzy gwarantują precyzyjne wykonanie zadań związanych z przygotowaniem terenu pod inwestycje." },
                { "Instalacje elektryczne i fotowoltaika", "Nasi elektrycy oraz eksperci od fotowoltaiki realizują zarówno standardowe instalacje elektryczne, jak i nowoczesne systemy energii odnawialnej, dostosowane do indywidualnych potrzeb klientów." },
                { "Usuwanie azbestu i prace z PVC", "Zapewniamy profesjonalne ekipy zajmujące się bezpiecznym usuwaniem azbestu oraz montażem elementów z PVC zgodnie z obowiązującymi normami." },
                { "Mechanicy linii produkcyjnych", "Specjalizujemy się w dostarczaniu mechaników do obsługi i tworzenia linii produkcyjnych. Nasi pracownicy są przygotowani do pracy w dynamicznych środowiskach przemysłowych." },
                { "Domy drewniane i modułowe", "Realizujemy projekty domów drewnianych oraz modułowych. Dostarczamy konstrukcje prefabrykowane, które łączą trwałość z energooszczędnością." },
                { "Cięcie CNC", "Nasza stolarnia oferuje precyzyjne cięcie CNC drewna, sklejki oraz MDF. Tworzymy unikatowe projekty zgodne z wymaganiami klienta, od mebli po elementy dekoracyjne." }
            };

            Advantages = new Dictionary<string, string>
            {
                { "Kompleksowość", "Od przygotowania terenu po prace wykończeniowe – jesteśmy partnerem na każdym etapie inwestycji." },
                { "Doświadczenie", "Realizujemy projekty w najbardziej wymagających lokalizacjach Szwecji, od południa po koło podbiegunowe." },
                { "Elastyczność", "Dostosowujemy nasze usługi do specyficznych potrzeb każdego klienta i projektu." },
                { "Międzynarodowy zasięg", "Nasze zaplecze logistyczne i kadrowe pozwala na realizację projektów w całej Europie i poza nią." },
                { "Innowacyjność", "Łączymy tradycyjne rzemiosło z nowoczesnymi technologiami, oferując rozwiązania na miarę XXI wieku." }
            };

            Offers = new Dictionary<string, string>
            {
                {"Stabilne zatrudnienie", "Nasza ekspansja na nowe rynki oznacza stały rozwój i nowe możliwości."},
                {"Międzynarodowe projekty", "Pracuj w różnych krajach, poznawaj nowe kultury i zdobywaj unikalne doświadczenie."},
                {"Rozwój zawodowy", "Szkolenia, certyfikacje i możliwość awansu w strukturach międzynarodowej firmy."},
                {"Atrakcyjne wynagrodzenie", "Szwedzkie stawki, szwedzka umowa, szwedzka emerytura."},
                { "Profesjonalne narzędzia", "Pracuj z wykorzystaniem najnowocześniejszego sprzętu i technologii."}
            };

            string wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "content", "realizations");
            Photos = new List<string>();

            if (Directory.Exists(wwwrootPath))
            {
                var files = Directory.GetFiles(wwwrootPath, "*.jpg");
                foreach (var file in files)
                {
                    string relativePath = "/" + Path.GetRelativePath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), file).Replace("\\", "/");
                    Photos.Add(relativePath);
                }
            }
        }
    }

    public class Offer
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
