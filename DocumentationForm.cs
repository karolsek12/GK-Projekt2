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
            "Światło zmienia kolor na wybrany."
            ;

        public DocumentationForm()
        {
            InitializeComponent();
            documentationTextBox.Text = DocumentationText;
        }
    }
}
