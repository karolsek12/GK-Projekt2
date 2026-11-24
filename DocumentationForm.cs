using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Projekt2
{
    public partial class DocumentationForm : Form
    {
        
        private static string DocumentationText = "Opcje:"  + Environment.NewLine +
            "Checkbox 'Fill Triangles' - określa czy trójkąty mają być wypełniane." + Environment.NewLine +
            "Checkbox 'Draw Mesh' - określa czy krawędzie trójkątów mają być rysowane." + Environment.NewLine +
            "Checkbox 'Draw Poly' - określa czy ma być rysowany wielokąt ograniczający punkty kontrolne." + Environment.NewLine +
            "Checkbox 'Draw Bezier' - określa czy ma być rysowana krzywa określająca ruch światła" + Environment.NewLine +
            "oraz czerwony punkt odpowiadający aktualnej pozycji światła." + Environment.NewLine +
            Environment.NewLine +
            "Suwak ks - aktualizuje wartośc ks wszystkich powierzchni. Wartości od 0.0 do 1.0 ." + Environment.NewLine +
            "Suwak kd - aktualizuje wartośc kd wszystkich powierzchni. Wartości od 0.0 do 1.0 ." + Environment.NewLine +
            "Suwak m - aktualizuje wartośc ks wszystkich powierzchni. Wartości od 1 do 100 ." + Environment.NewLine +
            "Suwak n - aktualizuję ilość trójkątów na powierzchni, n -> 2*n2 trójkątow. Wartości od 1 do 20 ." + Environment.NewLine +
            Environment.NewLine+
            "Checkbox 'Move Light' - określa czy światło ma aktualizować pozycję. " + Environment.NewLine +
            Environment.NewLine +
            "Wybór 'Curve ID' - ustawia ID obecnie kontrolowanej powierzchni Beziera" + Environment.NewLine +
            "Przycisk 'Set Color' - otwiera okno dialogowe wyboru koloru." + Environment.NewLine +
            "Powierzchnia aktualnie kontrolowana zmienia kolor na wybrany." + Environment.NewLine +
            "Przycisk 'Set Color' - otwiera okno dialogowe wyboru obrazu." + Environment.NewLine +
            "Powierzchnia aktualnie kontrolowana zmienia wyświetlany obraz na wybrany." + Environment.NewLine +
            "Przycisk 'Set Normal' - otwiera okno dialogowe wyboru mapy normalnych." + Environment.NewLine +
            "Powierzchnia aktualnie kontrolowana modyfikuje normalne zgodnie z wybraną mapą." + Environment.NewLine +
            "Przycisk 'Del Normal' - usuwa mapę normalnych z obecnie kontrolowanej powierzchni." + Environment.NewLine +
            Environment.NewLine +
            "Suwak z - aktualizuje wspołrzedną z krzywej światła. Wartości od -1.0 do 1.0" + Environment.NewLine+
            Environment.NewLine +
            "Wybór 'Control ID' - ustawia ID obecnie kontrolowanego punktu kontrolnego krzywej światła" + Environment.NewLine +
            "Suwak x - aktualizuje wspołrzedną x punktu kontrolnego. Wartości od -1.0 do 1.0" + Environment.NewLine +
            "Suwak y - aktualizuje wspołrzedną x punktu kontrolnego. Wartości od -1.0 do 1.0" + Environment.NewLine +
            Environment.NewLine +
            "Przycisk 'Light Color' - otwiera okno dialogowe wyboru koloru." + Environment.NewLine +
            "Światło zmienia kolor na wybrany." + Environment.NewLine+
            Environment.NewLine + Environment.NewLine +
            "Obrót płaszczyzn:" + Environment.NewLine +
            "Lewa część aplikacji zawiera pole wyświetlające płaszczyzny, nazwijmy te pole 'obrazem'." + Environment.NewLine +
            "Chcąc obrócic płaszczyzny naciskamy lewym przyciskiem myszy 'obraz'." + Environment.NewLine +
            "Następnie przesuwamy kursor ciągle trzymając lewy przycisk myszy." + Environment.NewLine +
            "Płaszczyzny wykonują obrót zgodnie z ruchem myszy." + Environment.NewLine +
            Environment.NewLine +
            "Algorytm obrotu płaszczyzn:" + Environment.NewLine +
            "Niech P1=(x1,y1) - położenie punktu w którym naciśnięto lewy przycisk myszy." + Environment.NewLine+
            "Niech P2=(x2,y2) - położenie punktu aktualnej pozycji myszy po pewnym ruchu." + Environment.NewLine +
            "Jeśli odległość P1 od P2 jest mniejsza od pewnej stałej (10.0), ruch jest ignorowany." + Environment.NewLine +
            "W przeciwnym przypadku wykonywana jest transformacja ruchu na obrót płaszczyzn, do punktu P1 jest zapisywany punkt P2." + Environment.NewLine +
            "Przy następnym ruchy myszą, nowy punkt P2 jest porównywany względem zaaktualizowanego punktu P2." + Environment.NewLine +
            "Niech V = P2 - P1 , wektor opisujący pomyślny ruch myszy." + Environment.NewLine +
            "Wektor V jest obracany o 90 stopni oraz mnożony o pewną stałą (pi/1000.0)." + Environment.NewLine +
            "Współrzędne wektora odpowiadają poszczególnym kątom obrotu." + Environment.NewLine +
            "stała * V = (obrót wokół osi X, obrót wokół osi Y, obrót wokół osi Z)." + Environment.NewLine +
            "Stałe zostały wybrane arbitralnie, następnie przeskalowane, tak, żeby obrót wydawał sie intuicyjny."


            ;

        public DocumentationForm()
        {
            InitializeComponent();
            documentationTextBox.Text = DocumentationText;
        }
    }
}
